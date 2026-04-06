using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Launcher
{
	// Token: 0x0200000A RID: 10
	public partial class MainForm : Form
	{
		// Token: 0x0600004E RID: 78 RVA: 0x00004670 File Offset: 0x00003670
		public MainForm(int versionIndex)
		{
			this.InitializeComponent();
			if (versionIndex == 5)
			{
				this.Text += " - DVD";
			}
			else
			{
				this.Text = this.Text + " - Chapter " + versionIndex.ToString();
			}
			this.versionIndex = versionIndex;
			List<string> splashFiles = this.GetSplashFiles();
			Image splash;
			if (splashFiles.Count != 0)
			{
				Random random = new Random();
				int index = random.Next(0, splashFiles.Count - 1);
				splash = Image.FromFile(splashFiles[index]);
			}
			else
			{
				splash = this.GetEmbededSplash();
			}
			base.SuspendLayout();
			if (!this.SetupFromSplash(splash))
			{
				this.SetupFromSplash(this.GetEmbededSplash());
			}
			base.ResumeLayout();
		}

		// Token: 0x0600004F RID: 79 RVA: 0x0000472C File Offset: 0x0000372C
		public Size GetMinSplashSize()
		{
			int num = Math.Max(this.playBtn.Width, Math.Max(this.settingsBtn.Width, this.exitBtn.Width));
			int num2 = num / 4 * 5;
			return new Size(num * 3 + num2, 1);
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00004778 File Offset: 0x00003778
		public bool IsValidSplash(Image splash)
		{
			Size minSplashSize = this.GetMinSplashSize();
			return splash != null && splash.Width > minSplashSize.Width && splash.Height > minSplashSize.Height;
		}

		// Token: 0x06000051 RID: 81 RVA: 0x000047B0 File Offset: 0x000037B0
		public bool SetupFromSplash(Image splash)
		{
			if (!this.IsValidSplash(splash))
			{
				return false;
			}
			int num = Math.Max(this.playBtn.Height, Math.Max(this.settingsBtn.Height, this.exitBtn.Height));
			int num2 = (base.Width - base.ClientSize.Width) / 2;
			int num3 = base.Height - base.ClientSize.Height - 2 * num2;
			base.Width = splash.Width;
			base.Height = splash.Height + num * 2 + num3;
			this.splashContainer.Image = splash;
			this.splashContainer.Width = splash.Width;
			this.splashContainer.Height = splash.Height;
			int y = this.splashContainer.Height + num / 2;
			this.playBtn.Location = new Point(this.playBtn.Location.X, y);
			int num4 = base.Width - this.exitBtn.Width - this.exitBtn.Width / 4;
			int x = num4 - this.settingsBtn.Width - this.settingsBtn.Width / 4;
			this.settingsBtn.Location = new Point(x, y);
			this.exitBtn.Location = new Point(num4, y);
			return true;
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00004910 File Offset: 0x00003910
		private Image GetEmbededSplash()
		{
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			return Image.FromStream(executingAssembly.GetManifestResourceStream("Launcher.Images.bunnies.png"));
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00004934 File Offset: 0x00003934
		public List<string> GetSplashFiles()
		{
			List<string> list = new List<string>();
			string[] array = MainForm.splashFormats;
			int i = 0;
			while (i < array.Length)
			{
				string str = array[i];
				string[] array2 = null;
				try
				{
					array2 = Directory.GetFiles(Configuration.GetMediaPath(), "*." + str);
				}
				catch (DirectoryNotFoundException)
				{
					goto IL_58;
				}
				goto IL_35;
				IL_58:
				i++;
				continue;
				IL_35:
				foreach (string item in array2)
				{
					list.Add(item);
				}
				goto IL_58;
			}
			return list;
		}

		// Token: 0x06000054 RID: 84 RVA: 0x000049B8 File Offset: 0x000039B8
		private void playBtn_Click(object sender, EventArgs e)
		{
			DialogResult dialogResult = DialogResult.None;
			do
			{
				if (!ApplicationLauncher.Launch(this.versionIndex))
				{
					dialogResult = MessageBox.Show(null, "An error occurred while launching the game!", "Error...", MessageBoxButtons.RetryCancel, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
				}
			}
			while (dialogResult == DialogResult.Retry);
			base.Close();
		}

		// Token: 0x06000055 RID: 85 RVA: 0x000049F3 File Offset: 0x000039F3
		private void exitBtn_MouseClick(object sender, MouseEventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000056 RID: 86 RVA: 0x000049FB File Offset: 0x000039FB
		private void settingsBtn_Click(object sender, EventArgs e)
		{
			if (this.settingsForm == null)
			{
				this.settingsForm = new Settings();
				this.settingsForm.Show(this);
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000057 RID: 87 RVA: 0x00004A1C File Offset: 0x00003A1C
		// (set) Token: 0x06000058 RID: 88 RVA: 0x00004A24 File Offset: 0x00003A24
		public Form SettingsForm
		{
			get
			{
				return this.settingsForm;
			}
			set
			{
				this.settingsForm = value;
			}
		}

		// Token: 0x0400003A RID: 58
		private int versionIndex;

		// Token: 0x0400003B RID: 59
		private Form settingsForm;

		// Token: 0x0400003C RID: 60
		private static string[] splashFormats = new string[]
		{
			"bmp"
		};
	}
}
