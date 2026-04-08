struct K3D_S
{
    char pad[0x930];
    unsigned long ScreenVSize;          // 0x930 - name from Duckymomos widescreen patch
    long Ratio;                         // 0x934 - Screen Ratio
    char pad2[0x69410 - 0x938];        // unknown gap
    long ForcedLOD;                     // 0x69410 - Force Level of Detail to max
};

extern "C" K3D_S* K3D_gpo_Display;
