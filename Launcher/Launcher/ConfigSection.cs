using System;
using System.Configuration;
using System.Windows.Forms;

namespace Launcher
{
	// Token: 0x02000009 RID: 9
	public sealed class ConfigSection : ConfigurationSection
	{
		// Token: 0x0600003D RID: 61 RVA: 0x000040D8 File Offset: 0x000030D8
		public ConfigSection()
		{
			this.parent = null;
			ConfigSection.propertyBag = new ConfigurationPropertyCollection();
			ConfigSection.propertyBag.Add(ConfigSection.videoMode);
			ConfigSection.propertyBag.Add(ConfigSection.multiSample);
			ConfigSection.propertyBag.Add(ConfigSection.vSync);
			ConfigSection.propertyBag.Add(ConfigSection.windowed);
			ConfigSection.propertyBag.Add(ConfigSection.language);
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x0600003E RID: 62 RVA: 0x00004147 File Offset: 0x00003147
		protected override ConfigurationPropertyCollection Properties
		{
			get
			{
				return ConfigSection.propertyBag;
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600003F RID: 63 RVA: 0x0000414E File Offset: 0x0000314E
		// (set) Token: 0x06000040 RID: 64 RVA: 0x00004156 File Offset: 0x00003156
		public Configuration Parent
		{
			get
			{
				return this.parent;
			}
			set
			{
				this.parent = value;
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000041 RID: 65 RVA: 0x00004160 File Offset: 0x00003160
		// (set) Token: 0x06000042 RID: 66 RVA: 0x000041D2 File Offset: 0x000031D2
		public string VideoMode
		{
			get
			{
				string text = (string)base["VideoMode"];
				if (this.parent.DisplayInfo.IsModeSupported(text))
				{
					return text;
				}
				string supportedMode = this.parent.DisplayInfo.GetSupportedMode(true);
				if (supportedMode == null)
				{
					MessageBox.Show(null, "An error occurred while selecting compatible display modes! Please check your display driver is up to date!", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
					Environment.Exit(0);
				}
				return base["VideoMode"] = supportedMode;
			}
			set
			{
				base["VideoMode"] = value;
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000043 RID: 67 RVA: 0x000041E0 File Offset: 0x000031E0
		// (set) Token: 0x06000044 RID: 68 RVA: 0x00004233 File Offset: 0x00003233
		public string MultiSample
		{
			get
			{
				string text = (string)base["Multi-Sampling"];
				if (this.parent.DisplayInfo.IsSamplingSupported(text))
				{
					return text;
				}
				string supportedSampling = this.parent.DisplayInfo.GetSupportedSampling();
				return base["Multi-Sampling"] = supportedSampling;
			}
			set
			{
				base["Multi-Sampling"] = value;
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000045 RID: 69 RVA: 0x00004241 File Offset: 0x00003241
		// (set) Token: 0x06000046 RID: 70 RVA: 0x00004253 File Offset: 0x00003253
		public bool VSync
		{
			get
			{
				return (bool)base["V-Sync"];
			}
			set
			{
				base["V-Sync"] = value;
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000047 RID: 71 RVA: 0x00004266 File Offset: 0x00003266
		// (set) Token: 0x06000048 RID: 72 RVA: 0x00004278 File Offset: 0x00003278
		public bool Windowed
		{
			get
			{
				return (bool)base["Windowed"];
			}
			set
			{
				base["Windowed"] = value;
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000049 RID: 73 RVA: 0x0000428B File Offset: 0x0000328B
		// (set) Token: 0x0600004A RID: 74 RVA: 0x0000429D File Offset: 0x0000329D
		public Configuration.Lang Language
		{
			get
			{
				return (Configuration.Lang)base["Language"];
			}
			set
			{
				base["Language"] = value;
			}
		}

		// Token: 0x0400002E RID: 46
		private Configuration parent;

		// Token: 0x0400002F RID: 47
		private static ConfigurationPropertyCollection propertyBag;

		// Token: 0x04000030 RID: 48
		private static readonly ConfigurationProperty videoMode = new ConfigurationProperty("VideoMode", typeof(string), " ", ConfigurationPropertyOptions.IsRequired);

		// Token: 0x04000031 RID: 49
		private static readonly ConfigurationProperty multiSample = new ConfigurationProperty("Multi-Sampling", typeof(string), "None", ConfigurationPropertyOptions.IsRequired);

		// Token: 0x04000032 RID: 50
		private static readonly ConfigurationProperty vSync = new ConfigurationProperty("V-Sync", typeof(bool), true, ConfigurationPropertyOptions.IsRequired);

		// Token: 0x04000033 RID: 51
		private static readonly ConfigurationProperty windowed = new ConfigurationProperty("Windowed", typeof(bool), false, ConfigurationPropertyOptions.IsRequired);

		// Token: 0x04000034 RID: 52
		private static readonly ConfigurationProperty language = new ConfigurationProperty("Language", typeof(Configuration.Lang), Configuration.Lang.English, ConfigurationPropertyOptions.IsRequired);
	}
}
