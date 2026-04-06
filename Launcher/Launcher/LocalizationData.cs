using System;
using System.Globalization;
using System.Threading;

namespace Launcher
{
	// Token: 0x0200000F RID: 15
	public class LocalizationData
	{
		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000075 RID: 117 RVA: 0x0000501D File Offset: 0x0000401D
		// (set) Token: 0x06000076 RID: 118 RVA: 0x00005024 File Offset: 0x00004024
		public static bool ResetAppCulture
		{
			get
			{
				return LocalizationData.resetAppCulture;
			}
			set
			{
				LocalizationData.resetAppCulture = value;
			}
		}

		// Token: 0x06000077 RID: 119 RVA: 0x0000502C File Offset: 0x0000402C
		public static bool SetThreadUICulture(Configuration.Lang language)
		{
			if (LocalizationData.resetAppCulture)
			{
				string name = "en";
				switch (language)
				{
				case Configuration.Lang.French:
					name = "fr";
					break;
				case Configuration.Lang.German:
					name = "de";
					break;
				case Configuration.Lang.Italian:
					name = "it";
					break;
				case Configuration.Lang.Spanish:
					name = "es";
					break;
				case Configuration.Lang.Dutch:
					name = "nl";
					break;
				}
				Thread.CurrentThread.CurrentUICulture = new CultureInfo(name);
				LocalizationData.resetAppCulture = false;
				return true;
			}
			return false;
		}

		// Token: 0x0400004F RID: 79
		private static bool resetAppCulture = true;
	}
}
