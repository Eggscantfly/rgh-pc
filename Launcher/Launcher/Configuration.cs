using System;
using System.Configuration;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Launcher
{
	// Token: 0x0200000D RID: 13
	public class Configuration
	{
		// Token: 0x06000066 RID: 102 RVA: 0x00004BCC File Offset: 0x00003BCC
		public Configuration()
		{
			this.config = null;
			this.section = null;
			this.displayInfo = new DisplayInformation();
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00004BF0 File Offset: 0x00003BF0
		public static string GetConfigFileName(int versionIndex)
		{
			string result = null;
			if (versionIndex != -1)
			{
				result = Application.CommonAppDataPath + "\\Launcher_" + versionIndex.ToString() + ".exe.config";
			}
			return result;
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00004C20 File Offset: 0x00003C20
		public static int GetVersionIndex()
		{
			foreach (string str in Configuration.regLocations)
			{
				for (int j = 0; j < Configuration.installationGUID.Length; j++)
				{
					RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(str + Configuration.installationGUID[j]);
					if (registryKey != null)
					{
						string a = (string)registryKey.GetValue("InstallLocation", "NONE");
						string executablePath = Configuration.GetExecutablePath();
						if (a == executablePath)
						{
							return j + 1;
						}
					}
				}
			}
			return -1;
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00004CAC File Offset: 0x00003CAC
		public static bool WriteRegLanguage(Configuration.Lang language)
		{
			int num = Configuration.GetVersionIndex() - 1;
			foreach (string str in Configuration.regLocations)
			{
				RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(str + Configuration.installationGUID[num], true);
				if (registryKey != null)
				{
					try
					{
						registryKey.SetValue("Language", Configuration.LangToRegLang(language));
					}
					catch (UnauthorizedAccessException)
					{
						goto IL_55;
					}
					return true;
				}
				IL_55:;
			}
			return false;
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00004D30 File Offset: 0x00003D30
		public void OpenConfigurationObject(string fileName)
		{
			if (this.config != null)
			{
				this.CloseConfigurationObject();
			}
			this.config = ConfigurationManager.OpenMappedExeConfiguration(new ExeConfigurationFileMap
			{
				ExeConfigFilename = fileName
			}, ConfigurationUserLevel.None);
			if ((this.section = (this.config.GetSection("Launcher.Settings") as ConfigSection)) == null)
			{
				this.section = new ConfigSection();
				this.config.Sections.Add("Launcher.Settings", this.section);
				Configuration.Lang language = Configuration.Lang.English;
				foreach (string str in Configuration.regLocations)
				{
					for (int j = 0; j < Configuration.installationGUID.Length; j++)
					{
						RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(str + Configuration.installationGUID[j]);
						if (registryKey != null)
						{
							string a = registryKey.GetValue("InstallLocation", "NONE").ToString();
							if (a == Configuration.GetExecutablePath())
							{
								language = Configuration.RegLangToLang((int)registryKey.GetValue("Language", 1033));
								break;
							}
						}
					}
				}
				this.section.Parent = this;
				this.section.Language = language;
				return;
			}
			this.section.Parent = this;
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00004E78 File Offset: 0x00003E78
		public void CloseConfigurationObject()
		{
			DialogResult dialogResult = DialogResult.None;
			do
			{
				try
				{
					this.config.Save(ConfigurationSaveMode.Full);
				}
				catch (ConfigurationErrorsException)
				{
					dialogResult = MessageBox.Show(null, "An error occurred while saving configuration file!", "Error...", MessageBoxButtons.RetryCancel, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
				}
			}
			while (dialogResult == DialogResult.Retry);
			this.section = null;
			this.config = null;
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00004ED0 File Offset: 0x00003ED0
		public static string GetExecutablePath()
		{
			return Path.GetDirectoryName(Application.ExecutablePath);
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00004EDC File Offset: 0x00003EDC
		public static string GetMediaPath()
		{
			return Configuration.GetExecutablePath() + "\\Media";
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x0600006E RID: 110 RVA: 0x00004EED File Offset: 0x00003EED
		public ConfigSection Settings
		{
			get
			{
				return this.section;
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x0600006F RID: 111 RVA: 0x00004EF5 File Offset: 0x00003EF5
		public DisplayInformation DisplayInfo
		{
			get
			{
				return this.displayInfo;
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000070 RID: 112 RVA: 0x00004EFD File Offset: 0x00003EFD
		// (set) Token: 0x06000071 RID: 113 RVA: 0x00004F04 File Offset: 0x00003F04
		public static Configuration Global
		{
			get
			{
				return Configuration.globalInstance;
			}
			set
			{
				Configuration.globalInstance = value;
			}
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00004F0C File Offset: 0x00003F0C
		private static Configuration.Lang RegLangToLang(int lang)
		{
			switch (lang)
			{
			case 1031:
				return Configuration.Lang.German;
			case 1032:
			case 1035:
				break;
			case 1033:
				return Configuration.Lang.English;
			case 1034:
				return Configuration.Lang.Spanish;
			case 1036:
				return Configuration.Lang.French;
			default:
				if (lang == 1040)
				{
					return Configuration.Lang.Italian;
				}
				if (lang == 1043)
				{
					return Configuration.Lang.Dutch;
				}
				break;
			}
			return Configuration.Lang.English;
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00004F60 File Offset: 0x00003F60
		private static int LangToRegLang(Configuration.Lang lang)
		{
			switch (lang)
			{
			case Configuration.Lang.English:
				return 1033;
			case Configuration.Lang.French:
				return 1036;
			case Configuration.Lang.German:
				return 1031;
			case Configuration.Lang.Italian:
				return 1040;
			case Configuration.Lang.Spanish:
				return 1034;
			case Configuration.Lang.Dutch:
				return 1043;
			default:
				return 1033;
			}
		}

		// Token: 0x04000042 RID: 66
		private Configuration config;

		// Token: 0x04000043 RID: 67
		private ConfigSection section;

		// Token: 0x04000044 RID: 68
		private DisplayInformation displayInfo;

		// Token: 0x04000045 RID: 69
		private static Configuration globalInstance = null;

		// Token: 0x04000046 RID: 70
		private static string[] regLocations = new string[]
		{
			"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\",
			"SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\"
		};

		// Token: 0x04000047 RID: 71
		private static string[] installationGUID = new string[]
		{
			"{0E065330-E9AD-4FB2-96BB-1EB08971C3E2}",
			"{8D598F02-4381-458A-BABD-A04479A65CD5}",
			"{B82BE3D3-70BC-48C1-8DB2-5F63184E0765}",
			"{BD74619D-38CD-4A3D-AAFA-D29B6FA1EF3D}",
			"{41899391-E156-4166-9DD3-DDDB76B45895}"
		};

		// Token: 0x0200000E RID: 14
		public enum Lang
		{
			// Token: 0x04000049 RID: 73
			English,
			// Token: 0x0400004A RID: 74
			French,
			// Token: 0x0400004B RID: 75
			German,
			// Token: 0x0400004C RID: 76
			Italian,
			// Token: 0x0400004D RID: 77
			Spanish,
			// Token: 0x0400004E RID: 78
			Dutch
		}
	}
}
