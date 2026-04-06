using System;
using System.Collections.Generic;
using Microsoft.DirectX.Direct3D;

namespace Launcher
{
	// Token: 0x02000006 RID: 6
	public class DisplayInformation
	{
		// Token: 0x06000010 RID: 16 RVA: 0x00003070 File Offset: 0x00002070
		public DisplayInformation()
		{
			AdapterInformation @default = Manager.Adapters.Default;
			this.supportedModes = new List<string>();
			this.supportedSampling = new List<string>();
			foreach (object obj in @default.SupportedDisplayModes)
			{
				DisplayMode displayMode = (DisplayMode)obj;
				if (displayMode.Format == Format.X8R8G8B8)
				{
					this.AppendSupportedMode(string.Format("{0}x{1}", displayMode.Width, displayMode.Height));
				}
			}
			int num = 0;
			foreach (MultiSampleType multisampleType in DisplayInformation.desiredSampling)
			{
				if (this.IsMultiSamplingSupported(DepthFormat.D24S8, Format.X8R8G8B8, multisampleType))
				{
					this.AppendSupportedSampling(DisplayInformation.desiredSamplingNames[num]);
				}
				num++;
			}
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00003164 File Offset: 0x00002164
		private bool IsMultiSamplingSupported(DepthFormat depthFmt, Format backbufferFmt, MultiSampleType multisampleType)
		{
			AdapterInformation @default = Manager.Adapters.Default;
			for (int i = 0; i < 2; i++)
			{
				if (!Manager.CheckDeviceMultiSampleType(@default.Adapter, DeviceType.Hardware, backbufferFmt, i == 0, multisampleType) || !Manager.CheckDeviceMultiSampleType(@default.Adapter, DeviceType.Hardware, (Format)depthFmt, i == 0, multisampleType))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000031B4 File Offset: 0x000021B4
		private void AppendSupportedMode(string mode)
		{
			foreach (string a in this.supportedModes)
			{
				if (a == mode)
				{
					return;
				}
			}
			this.supportedModes.Add(mode);
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00003218 File Offset: 0x00002218
		public bool IsModeSupported(string mode)
		{
			foreach (string a in this.supportedModes)
			{
				if (a == mode)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00003274 File Offset: 0x00002274
		private void AppendSupportedSampling(string sampling)
		{
			foreach (string a in this.supportedSampling)
			{
				if (a == sampling)
				{
					return;
				}
			}
			this.supportedSampling.Add(sampling);
		}

		// Token: 0x06000015 RID: 21 RVA: 0x000032D8 File Offset: 0x000022D8
		public bool IsSamplingSupported(string sampling)
		{
			foreach (string a in this.supportedSampling)
			{
				if (a == sampling)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00003334 File Offset: 0x00002334
		public string GetSupportedMode(bool desiredMode)
		{
			if (desiredMode)
			{
				for (int i = 0; i < DisplayInformation.desiredModes.Length; i++)
				{
					for (int j = 0; j < this.supportedModes.Count; j++)
					{
						if (DisplayInformation.desiredModes[i] == this.supportedModes[j])
						{
							return this.supportedModes[j];
						}
					}
				}
				return null;
			}
			if (this.supportedModes.Count <= 0)
			{
				return null;
			}
			return this.supportedModes[0];
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000033B1 File Offset: 0x000023B1
		public string GetSupportedSampling()
		{
			if (this.supportedSampling.Count <= 0)
			{
				return DisplayInformation.desiredSamplingNames[0];
			}
			return this.supportedSampling[0];
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000018 RID: 24 RVA: 0x000033D5 File Offset: 0x000023D5
		public static string[] DesiredModes
		{
			get
			{
				return DisplayInformation.desiredModes;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000019 RID: 25 RVA: 0x000033DC File Offset: 0x000023DC
		public static string[] DesiredSampling
		{
			get
			{
				return DisplayInformation.desiredSamplingNames;
			}
		}

		// Token: 0x0400001E RID: 30
		private List<string> supportedModes;

		// Token: 0x0400001F RID: 31
		private List<string> supportedSampling;

		// Token: 0x04000020 RID: 32
		private static string[] desiredModes = new string[]
		{
			"640x480",
			"800x600",
			"1024x768",
			"1280x720",
			"1280x1024",
			"1440x900",
			"1600x1200",
			"1680x1050",
			"1920x1080"
		};

		// Token: 0x04000021 RID: 33
		private static MultiSampleType[] desiredSampling = new MultiSampleType[]
		{
			MultiSampleType.None,
			MultiSampleType.TwoSamples,
			MultiSampleType.FourSamples,
			MultiSampleType.SixSamples,
			MultiSampleType.EightSamples
		};

		// Token: 0x04000022 RID: 34
		private static string[] desiredSamplingNames = new string[]
		{
			"None",
			"2",
			"4",
			"6",
			"8"
		};
	}
}
