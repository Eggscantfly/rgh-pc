using System;
using System.Threading;
using System.Windows.Forms;

namespace Launcher
{
	// Token: 0x02000010 RID: 16
	internal static class Program
	{
		// Token: 0x0600007A RID: 122 RVA: 0x000050B8 File Offset: 0x000040B8
		[STAThread]
		private static void Main()
		{
			Mutex mutex = null;
			int versionIndex = Configuration.GetVersionIndex();
			string configFileName = Configuration.GetConfigFileName(versionIndex);
			if (versionIndex != -1 && configFileName != null)
			{
				bool flag;
				mutex = new Mutex(true, "RGH_Launcher_" + versionIndex.ToString(), ref flag);
				if (!flag)
				{
					return;
				}
				Configuration.Global = new Configuration();
				Configuration.Global.OpenConfigurationObject(configFileName);
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				while (LocalizationData.SetThreadUICulture(Configuration.Global.Settings.Language))
				{
					Application.Run(new MainForm(versionIndex));
				}
			}
			else
			{
				MessageBox.Show("An error occurred while starting the game launcher!\nPlease reinstall the application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
			}
			if (Configuration.Global != null)
			{
				Configuration.Global.CloseConfigurationObject();
			}
			if (mutex != null)
			{
				GC.KeepAlive(mutex);
			}
		}
	}
}
