using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Launcher
{
	// Token: 0x02000008 RID: 8
	public partial class Settings : Form
	{
		// Token: 0x06000034 RID: 52 RVA: 0x0000383C File Offset: 0x0000283C
		public Settings()
		{
			this.InitializeComponent();
			base.SuspendLayout();
			this.rabbidPicture.Image = this.GetEmbededRabbid();
			this.langCombo.Items.Clear();
			foreach (string item in Enum.GetNames(typeof(Configuration.Lang)))
			{
				this.langCombo.Items.Add(item);
			}
			this.rezCombo.Items.Clear();
			for (int j = 0; j < DisplayInformation.DesiredModes.Length; j++)
			{
				string text = DisplayInformation.DesiredModes[j];
				if (Configuration.Global.DisplayInfo.IsModeSupported(text))
				{
					this.rezCombo.Items.Add(text);
				}
			}
			this.joyCalibrate.Visible = false;
			base.ResumeLayout();
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00003918 File Offset: 0x00002918
		protected override void OnShown(EventArgs e)
		{
			MainForm mainForm;
			if ((mainForm = (base.Owner as MainForm)) != null)
			{
				mainForm.Enabled = false;
			}
			this.langCombo.SelectedIndex = (int)Configuration.Global.Settings.Language;
			this.rezCombo.SelectedItem = Configuration.Global.Settings.VideoMode;
			this.vSyncCheck.Checked = Configuration.Global.Settings.VSync;
			this.windowedCheck.Checked = Configuration.Global.Settings.Windowed;
			base.OnShown(e);
		}

		// Token: 0x06000036 RID: 54 RVA: 0x000039AC File Offset: 0x000029AC
		protected override void OnClosing(CancelEventArgs e)
		{
			MainForm mainForm;
			if ((mainForm = (base.Owner as MainForm)) != null)
			{
				mainForm.Enabled = true;
				mainForm.SettingsForm = null;
				mainForm.Activate();
			}
			base.OnClosing(e);
		}

		// Token: 0x06000037 RID: 55 RVA: 0x000039E8 File Offset: 0x000029E8
		private void okBtn_Click(object sender, EventArgs e)
		{
			Configuration.Global.Settings.VideoMode = (string)this.rezCombo.SelectedItem;
			Configuration.Global.Settings.VSync = this.vSyncCheck.Checked;
			Configuration.Global.Settings.Windowed = this.windowedCheck.Checked;
			if (Configuration.Global.Settings.Language != (Configuration.Lang)this.langCombo.SelectedIndex)
			{
				Configuration.Global.Settings.Language = (Configuration.Lang)this.langCombo.SelectedIndex;
				LocalizationData.ResetAppCulture = true;
				MainForm mainForm;
				if ((mainForm = (base.Owner as MainForm)) != null)
				{
					mainForm.Close();
				}
			}
			base.Close();
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00003AA1 File Offset: 0x00002AA1
		private void cancelBtn_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00003AAC File Offset: 0x00002AAC
		private Image GetEmbededRabbid()
		{
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			return Image.FromStream(executingAssembly.GetManifestResourceStream("Launcher.Images.rabbid.png"));
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00003AD0 File Offset: 0x00002AD0
		private void joyCalibrate_Click(object sender, EventArgs e)
		{
			JoystickCalibration joystickCalibration = new JoystickCalibration();
			joystickCalibration.Show();
		}
	}
}
