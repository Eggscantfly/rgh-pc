# RGH Recomp
A Recompilation of Rabbids Go Home Wii Version 

**Static recompilation of Rabbids Go Home (Wii) to native Windows/Linux — no emulation, no interpreter.**

> ⚠️ **Early development.** The scaffold, recompiler pipeline, and HAL are complete. Translated functions are in progress. The game does not boot yet.

---

## What Is This?

RGH Recomp translates the original Wii binary of *Rabbids Go Home* — compiled for the IBM PowerPC 750CL ("Broadway") CPU — into native C code that compiles and runs directly on Windows and Linux. The approach is **static recompilation**: every function in the ELF is read, disassembled, and translated to equivalent C, then recompiled for x86-64.

No emulator. No interpreter. The game's own logic runs natively.

The long-term goal is a general-purpose **WiiRecomp** tool — not just RGH, but any Wii game — similar to what [n64recomp](https://github.com/N64Recomp/N64Recomp) is for the N64 and [PSXRecomp](https://matthewstanley.dev) is for the PS1.

This project is inspired by Matthew Stanley's PSXRecomp (March 2026), which demonstrated that a Claude Code + Ghidra + GhidraMCP workflow could produce a playable PS1 native port in ~3 weeks. We replicate that methodology for the Wii.

---

## Target

| | |
|---|---|
| **Game** | Rabbids Go Home (Wii, NTSC-U) |
| **Engine** | LyN (Ubisoft internal — also used in Just Dance, Rabbids Travel in Time) |
| **CPU** | IBM PowerPC 750CL ("Broadway"), 729 MHz, big-endian, 32-bit |
| **Primary ELF** | `LynWiiF.elf` — 23,255 functions |
| **Dynamic lib** | `Ai2CppWiiFinal.rso` (Wii RSO format) |

---

## Project Status

| Component | Status |
|---|---|
| ELF + RSO parsing | ✅ Complete |
| PPC disassembly (capstone) | ✅ Complete |
| 23,255 C stub files emitted | ✅ Complete |
| `ppc_types.h` (types, MEM macros, PS macros) | ✅ Complete |
| HAL — OS threading, mutexes, message queues | ✅ Complete |
| HAL — IOS syscall stubs | ✅ Complete |
| HAL — GX graphics stubs | ✅ Stubs only |
| HAL — AX audio stubs | ✅ Stubs only |
| HAL — DVD filesystem | ✅ Stubs only |
| CMakeLists.txt | ✅ Builds cleanly |
| GhidraMCP integration | ✅ Connected |
| AI translation loop | 🔄 In progress |
| Dolphin MCP integration | ❌ Not started |
| GX OpenGL backend | ❌ Not started |
| AX audio backend | ❌ Not started |
| **Game boots** | ❌ Not yet |

---

## Repository Structure

```
rgh-recomp/
├── CLAUDE.md                    ← Law file: hardware specs, ABI, PS table, RSO format
├── REGRESSIONS.md               ← Regression log
├── CURRENT_TASK.md              ← AI session briefing (written by launcher)
├── START_RECOMP.py              ← Main launcher (Tkinter GUI + AI orchestrator)
├── Prompts/
│   ├── CLAUDE.md
│   ├── KICKOFF_PROMPT_WII.md
│   └── REGRESSIONS.md
├── Executables/
│   ├── LynWiiF.elf              ← Primary target (23,255 functions)
│   ├── LynWiiRetail.elf         ← Cross-validation reference
│   ├── Ai2CppWiiFinal.rso       ← RSO dynamic library
│   └── LyN_f.exe                ← PC port demo (same engine, x86 — reference behavior)
├── recompiler/
│   ├── ppc_decoder.py           ← ELF reader + capstone disassembler → functions.json
│   ├── rso_loader.py            ← RSO parser + relocation applicator
│   ├── emit.py                  ← C stub emitter → src/generated/
│   └── functions.json           ← 23,255 functions with disassembly (generated)
├── src/
│   ├── main.c                   ← Entry point, WII_MEM buffer
│   ├── hal/
│   │   ├── os_thread.c          ← OSThread (Win32 / pthreads)
│   │   ├── os_message.c         ← OSMessageQueue
│   │   ├── os_mutex.c           ← OSMutex
│   │   └── ios_stubs.c          ← IOS syscall stubs
│   ├── gfx/
│   │   └── gx_stub.c            ← GX HAL (stubs → OpenGL backend planned)
│   ├── audio/
│   │   └── ax_stub.c            ← AX HAL (stubs → SDL2 backend planned)
│   ├── fs/
│   │   └── dvd_stub.c           ← DVD filesystem (maps to fopen/fread)
│   └── generated/               ← DO NOT EDIT — 23,255 AI-translated .c files
├── include/
│   ├── ppc_types.h              ← All types, MEM_READ/WRITE macros, PS_* macros
│   ├── wii_hal.h                ← HAL declarations
│   └── gx.h                    ← GX type stubs
├── escalated/                   ← Functions the AI couldn't translate (with diagnostics)
├── ghidra/                      ← Ghidra project (RGHrecomp.gpr)
├── Help!/
│   └── Dolphin Source/          ← Dolphin source used as HAL reference
└── CMakeLists.txt
```

---

## How It Works

### Translation Pipeline

1. `ppc_decoder.py` reads `LynWiiF.elf`, disassembles every function with capstone, and outputs `functions.json` (23,255 entries with full PPC disassembly).
2. `rso_loader.py` parses `Ai2CppWiiFinal.rso`, applies relocations, and merges symbols into the function list.
3. `emit.py` writes one `.c` stub per function to `src/generated/`, with the PPC disassembly as comments.
4. An AI (Claude Code + GhidraMCP) translates each stub from PPC disassembly comments into working C — validating every decision against Ghidra as ground truth.
5. `CMakeLists.txt` builds `main.c` + HAL + all translated stubs into a native binary.

### AI Iteration Loop

Based on Matthew Stanley's PSXRecomp workflow:

1. Build with debugging enabled
2. Run → observe incorrect behavior
3. Report behavior to Claude Code
4. Claude iterates, validates fix against Ghidra
5. Human validates
6. Commit — never manually edit `src/generated/`

`CLAUDE.md` is the hard-rules file that forces the AI to validate against Ghidra instead of speculating. It is the backbone of translation quality.

### Key Hardware Notes

- **All memory access** uses `MEM_READ32(addr)` / `MEM_WRITE32(addr, val)` — handles big↔little endian
- **Paired-single FPU** (`(instr >> 26) == 4`) — capstone cannot decode these; handled via `PS_*` macros in `ppc_types.h`
- **OSThread priority** is inverted: `native = 31 - wii_priority`
- **RSO structs** are always big-endian — never `struct.unpack('<', ...)`
- **r2 (RTOC)** = read-only global data base; **r13 (SDA)** = small data base

---

## Building

### Prerequisites

- CMake 3.16+
- GCC or MSVC
- Python 3.10+ with: `pyelftools`, `capstone`, `tkinter`, `aider-chat`, `litellm`
- Ghidra with [GhidraMCP](https://github.com/LaurieWired/GhidraMCP) plugin

### Build

```bash
cmake -B build
cmake --build build
```

### Run the Launcher

```bash
python START_RECOMP.py
```

The launcher reads `LynWiiF.elf`, emits/updates stubs, and starts the AI translation loop.

### Ghidra Setup

1. Open Ghidra → create new project
2. Import `LynWiiF.elf` (PowerPC / BE / 32-bit)
3. Run auto-analysis
4. Window → GhidraMCP Server → Start (port 8080)

---

## Escalation Protocol

When a function cannot be cleanly translated, it is moved to `escalated/` instead of emitting broken code:

```
escalated/0x80123ABC_FunctionName/
├── INFO.md       ← why flagged, what was tried
├── disasm.txt    ← full capstone disassembly
├── ghidra.txt    ← Ghidra decompiler output
└── stub.c        ← compilable placeholder with // TODO: ESCALATED
```

Escalation triggers: computed branches, complex paired-single FPU, unresolved RSO cross-calls, functions >40 instructions with unclear register liveness.

---

## Milestones

- [ ] ELF loads, entry point reached, no crash
- [ ] Title screen renders (even broken)
- [ ] Title screen correct
- [ ] New game starts
- [ ] First level geometry renders
- [ ] Player character visible
- [ ] Basic movement works
- [ ] Audio plays
- [ ] Full first level completable
- [ ] Generalize to WiiRecomp tool

---

## Hard Rules

1. **Never manually edit `src/generated/`.** All fixes go into the recompiler or HAL.
2. **Never speculate about hardware behavior.** Everything is in `CLAUDE.md`.
3. **Validate every translation against Ghidra before marking complete.**
4. **Flag untranslatable functions** — never silently emit broken code.
5. HAL calls → `src/hal/`. GX → `src/gfx/gx_stub.c`. Audio → `src/audio/ax_stub.c`. DVD/FS → `src/fs/dvd_stub.c`.
6. **RSO binary fields are always big-endian.**

---

## Related Projects

- [n64recomp](https://github.com/N64Recomp/N64Recomp) — N64 static recompiler (Majora's Mask)
- [PSXRecomp](https://matthewstanley.dev) — PS1 static recompiler, direct inspiration for this project
- [GhidraMCP](https://github.com/LaurieWired/GhidraMCP) — Ghidra HTTP API plugin
- [emubench-dolphin](https://github.com/dwilliams27/emubench-dolphin) — Dolphin HTTP API (planned integration)
- [Ship of Harkinian](https://github.com/HarbourMasters/Shipwright) — OoT decompilation/port

---

## Contributors

- **Eggscantfly** 
- **Skibidi_sigma** 

---

## License

TBD — will be open source. See repository for updates.
