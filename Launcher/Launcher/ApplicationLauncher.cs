using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Launcher
{
	// Token: 0x02000005 RID: 5
	public class ApplicationLauncher
	{
		// Token: 0x0600000B RID: 11 RVA: 0x00002EB8 File Offset: 0x00001EB8
		public static bool Launch(int versionIndex)
		{
			string text = Configuration.GetExecutablePath() + "\\RGH_defrag.bf";
			text = string.Format("\"{0}\"", text);
			if (text != null)
			{
				Process process = new Process();
				process.StartInfo.FileName = ApplicationLauncher.GetEngineExecutable();
				process.StartInfo.WorkingDirectory = Configuration.GetExecutablePath();
				process.StartInfo.Arguments = text + " " + ApplicationLauncher.GetCommandLine(versionIndex);
				process.StartInfo.ErrorDialog = true;
				try
				{
					process.Start();
				}
				catch (Win32Exception)
				{
					return false;
				}
				return true;
			}
			return false;
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002F58 File Offset: 0x00001F58
		public static string GetCommandLine(int versionIndex)
		{
			string str = "";
			str += "/binload/fe ";
			str = str + ApplicationLauncher.strLangCmd[(int)Configuration.Global.Settings.Language] + " ";
			str += (Configuration.Global.Settings.Windowed ? "" : "/fullscreen ");
			str += (Configuration.Global.Settings.VSync ? "/vsync " : "");
			str = str + "/res" + Configuration.Global.Settings.VideoMode + " ";
			return str + "/versionIndex:" + versionIndex.ToString();
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00003014 File Offset: 0x00002014
		public static string GetEngineExecutable()
		{
			return "LyN_f.exe";
		}

		// Token: 0x0400001D RID: 29
		private static string[] strLangCmd = new string[]
		{
			"/lang/en",
			"/lang/fr",
			"/lang/de",
			"/lang/it",
			"/lang/es",
			"/lang/nl"
		};
	}
}
