using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Launcher.Controlls;
using Launcher.Properties;

namespace Launcher
{
	// Token: 0x02000003 RID: 3
	public partial class JoystickCalibration : Form
	{
		// Token: 0x06000004 RID: 4 RVA: 0x00002078 File Offset: 0x00001078
		public JoystickCalibration()
		{
			this.InitializeComponent();
			this.btnControlls = new CustomPictureBox[4];
			this.btnControlls[0] = this.ButtonA;
			this.btnControlls[1] = this.ButtonB;
			this.btnControlls[2] = this.ButtonX;
			this.btnControlls[3] = this.ButtonY;
			this.btnIndex = new int[4];
			for (int i = 0; i < 4; i++)
			{
				this.btnIndex[i] = -1;
			}
			foreach (CustomPictureBox customPictureBox in this.btnControlls)
			{
				customPictureBox.Click += this.Button_Click;
				customPictureBox.MouseEnter += this.ButtonEnter;
				customPictureBox.MouseLeave += this.ButtonLeave;
			}
			this.pad = new Joypad();
			this.buttonIsClicked = false;
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002158 File Offset: 0x00001158
		public int WaitButtonAssigned()
		{
			this.pad.Update();
			int joypadButtonDown;
			while ((joypadButtonDown = this.pad.GetJoypadButtonDown()) == -1)
			{
				this.pad.Update();
				Application.DoEvents();
			}
			return joypadButtonDown;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002193 File Offset: 0x00001193
		private void ButtonEnter(object sender, EventArgs e)
		{
			if (!this.buttonIsClicked)
			{
				this.Cursor = Cursors.Cross;
			}
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000021A8 File Offset: 0x000011A8
		private void ButtonLeave(object sender, EventArgs e)
		{
			this.Cursor = Cursors.Arrow;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000021B8 File Offset: 0x000011B8
		private void Button_Click(object sender, EventArgs e)
		{
			if (!this.buttonIsClicked)
			{
				this.labelPushBtn.Visible = true;
				this.Cursor = Cursors.Arrow;
				for (int i = 0; i < this.btnControlls.Length; i++)
				{
					CustomPictureBox customPictureBox = this.btnControlls[i];
				}
				this.buttonIsClicked = true;
				this.buttonIsClicked = false;
				this.labelPushBtn.Visible = false;
			}
		}

		// Token: 0x04000002 RID: 2
		private CustomPictureBox[] btnControlls;

		// Token: 0x04000003 RID: 3
		private int[] btnIndex;

		// Token: 0x04000004 RID: 4
		private Joypad pad;

		// Token: 0x04000005 RID: 5
		private bool buttonIsClicked;

		// Token: 0x02000004 RID: 4
		public enum ButtonCtrl
		{
			// Token: 0x04000018 RID: 24
			ButtonCtrl_A,
			// Token: 0x04000019 RID: 25
			ButtonCtrl_B,
			// Token: 0x0400001A RID: 26
			ButtonCtrl_X,
			// Token: 0x0400001B RID: 27
			ButtonCtrl_Y,
			// Token: 0x0400001C RID: 28
			ButtonCtrl_Count
		}
	}
}
