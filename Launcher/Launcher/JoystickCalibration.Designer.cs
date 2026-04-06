namespace Launcher
{
	// Token: 0x02000003 RID: 3
	public partial class JoystickCalibration : global::System.Windows.Forms.Form
	{
		// Token: 0x06000009 RID: 9 RVA: 0x0000221C File Offset: 0x0000121C
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600000A RID: 10 RVA: 0x0000223C File Offset: 0x0000123C
		private void InitializeComponent()
		{
			this.xboxController = new global::System.Windows.Forms.PictureBox();
			this.labelPushBtn = new global::System.Windows.Forms.Label();
			this.ButtonY = new global::Launcher.Controlls.CustomPictureBox();
			this.customPictureBox14 = new global::Launcher.Controlls.CustomPictureBox();
			this.customPictureBox13 = new global::Launcher.Controlls.CustomPictureBox();
			this.customPictureBox12 = new global::Launcher.Controlls.CustomPictureBox();
			this.customPictureBox11 = new global::Launcher.Controlls.CustomPictureBox();
			this.customPictureBox10 = new global::Launcher.Controlls.CustomPictureBox();
			this.customPictureBox9 = new global::Launcher.Controlls.CustomPictureBox();
			this.customPictureBox8 = new global::Launcher.Controlls.CustomPictureBox();
			this.customPictureBox7 = new global::Launcher.Controlls.CustomPictureBox();
			this.ButtonB = new global::Launcher.Controlls.CustomPictureBox();
			this.ButtonA = new global::Launcher.Controlls.CustomPictureBox();
			this.ButtonX = new global::Launcher.Controlls.CustomPictureBox();
			this.customPictureBox3 = new global::Launcher.Controlls.CustomPictureBox();
			this.customPictureBox2 = new global::Launcher.Controlls.CustomPictureBox();
			((global::System.ComponentModel.ISupportInitialize)this.xboxController).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.ButtonY).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.customPictureBox14).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.customPictureBox13).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.customPictureBox12).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.customPictureBox11).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.customPictureBox10).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.customPictureBox9).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.customPictureBox8).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.customPictureBox7).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.ButtonB).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.ButtonA).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.ButtonX).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.customPictureBox3).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.customPictureBox2).BeginInit();
			base.SuspendLayout();
			this.xboxController.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.xboxController.Image = global::Launcher.Properties.Resources.padx360;
			this.xboxController.Location = new global::System.Drawing.Point(0, 0);
			this.xboxController.Name = "xboxController";
			this.xboxController.Size = new global::System.Drawing.Size(400, 326);
			this.xboxController.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.xboxController.TabIndex = 0;
			this.xboxController.TabStop = false;
			this.labelPushBtn.AutoSize = true;
			this.labelPushBtn.BackColor = global::System.Drawing.SystemColors.ActiveCaptionText;
			this.labelPushBtn.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 204);
			this.labelPushBtn.Location = new global::System.Drawing.Point(129, 225);
			this.labelPushBtn.Name = "labelPushBtn";
			this.labelPushBtn.Size = new global::System.Drawing.Size(148, 20);
			this.labelPushBtn.TabIndex = 17;
			this.labelPushBtn.Text = "Push new button.";
			this.ButtonY.BackColor = global::System.Drawing.Color.Transparent;
			this.ButtonY.BackgroundImage = global::Launcher.Properties.Resources.padx360;
			this.ButtonY.Image = global::Launcher.Properties.Resources.padx360_triangle;
			this.ButtonY.Location = new global::System.Drawing.Point(282, 61);
			this.ButtonY.Name = "ButtonY";
			this.ButtonY.Size = new global::System.Drawing.Size(31, 29);
			this.ButtonY.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.ButtonY.TabIndex = 16;
			this.ButtonY.TabStop = false;
			this.customPictureBox14.BackColor = global::System.Drawing.Color.Transparent;
			this.customPictureBox14.BackgroundImage = global::Launcher.Properties.Resources.padx360;
			this.customPictureBox14.Image = global::Launcher.Properties.Resources.padx360_down;
			this.customPictureBox14.Location = new global::System.Drawing.Point(139, 165);
			this.customPictureBox14.Name = "customPictureBox14";
			this.customPictureBox14.Size = new global::System.Drawing.Size(20, 15);
			this.customPictureBox14.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.customPictureBox14.TabIndex = 14;
			this.customPictureBox14.TabStop = false;
			this.customPictureBox13.BackColor = global::System.Drawing.Color.Transparent;
			this.customPictureBox13.BackgroundImage = global::Launcher.Properties.Resources.padx360;
			this.customPictureBox13.Image = global::Launcher.Properties.Resources.padx360_up;
			this.customPictureBox13.Location = new global::System.Drawing.Point(138, 128);
			this.customPictureBox13.Name = "customPictureBox13";
			this.customPictureBox13.Size = new global::System.Drawing.Size(20, 17);
			this.customPictureBox13.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.customPictureBox13.TabIndex = 13;
			this.customPictureBox13.TabStop = false;
			this.customPictureBox12.BackColor = global::System.Drawing.Color.Transparent;
			this.customPictureBox12.BackgroundImage = global::Launcher.Properties.Resources.padx360;
			this.customPictureBox12.Image = global::Launcher.Properties.Resources.padx360_start;
			this.customPictureBox12.Location = new global::System.Drawing.Point(223, 91);
			this.customPictureBox12.Name = "customPictureBox12";
			this.customPictureBox12.Size = new global::System.Drawing.Size(26, 22);
			this.customPictureBox12.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.customPictureBox12.TabIndex = 12;
			this.customPictureBox12.TabStop = false;
			this.customPictureBox11.BackColor = global::System.Drawing.Color.Transparent;
			this.customPictureBox11.BackgroundImage = global::Launcher.Properties.Resources.padx360;
			this.customPictureBox11.Image = global::Launcher.Properties.Resources.padx360_select;
			this.customPictureBox11.Location = new global::System.Drawing.Point(152, 92);
			this.customPictureBox11.Name = "customPictureBox11";
			this.customPictureBox11.Size = new global::System.Drawing.Size(25, 21);
			this.customPictureBox11.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.customPictureBox11.TabIndex = 11;
			this.customPictureBox11.TabStop = false;
			this.customPictureBox10.BackColor = global::System.Drawing.Color.Transparent;
			this.customPictureBox10.BackgroundImage = global::Launcher.Properties.Resources.padx360;
			this.customPictureBox10.Image = global::Launcher.Properties.Resources.padx360_right;
			this.customPictureBox10.Location = new global::System.Drawing.Point(160, 144);
			this.customPictureBox10.Name = "customPictureBox10";
			this.customPictureBox10.Size = new global::System.Drawing.Size(16, 23);
			this.customPictureBox10.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.customPictureBox10.TabIndex = 10;
			this.customPictureBox10.TabStop = false;
			this.customPictureBox9.BackColor = global::System.Drawing.Color.Transparent;
			this.customPictureBox9.BackgroundImage = global::Launcher.Properties.Resources.padx360;
			this.customPictureBox9.Image = global::Launcher.Properties.Resources.padx360_R2;
			this.customPictureBox9.Location = new global::System.Drawing.Point(272, 9);
			this.customPictureBox9.Name = "customPictureBox9";
			this.customPictureBox9.Size = new global::System.Drawing.Size(27, 30);
			this.customPictureBox9.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.customPictureBox9.TabIndex = 9;
			this.customPictureBox9.TabStop = false;
			this.customPictureBox8.BackColor = global::System.Drawing.Color.Transparent;
			this.customPictureBox8.BackgroundImage = global::Launcher.Properties.Resources.padx360;
			this.customPictureBox8.Image = global::Launcher.Properties.Resources.padx360_R1;
			this.customPictureBox8.Location = new global::System.Drawing.Point(267, 38);
			this.customPictureBox8.Name = "customPictureBox8";
			this.customPictureBox8.Size = new global::System.Drawing.Size(60, 24);
			this.customPictureBox8.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.customPictureBox8.TabIndex = 8;
			this.customPictureBox8.TabStop = false;
			this.customPictureBox7.BackColor = global::System.Drawing.Color.Transparent;
			this.customPictureBox7.BackgroundImage = global::Launcher.Properties.Resources.padx360;
			this.customPictureBox7.Image = global::Launcher.Properties.Resources.padx360_L2;
			this.customPictureBox7.Location = new global::System.Drawing.Point(105, 10);
			this.customPictureBox7.Name = "customPictureBox7";
			this.customPictureBox7.Size = new global::System.Drawing.Size(24, 28);
			this.customPictureBox7.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.customPictureBox7.TabIndex = 7;
			this.customPictureBox7.TabStop = false;
			this.ButtonB.BackColor = global::System.Drawing.Color.Transparent;
			this.ButtonB.BackgroundImage = global::Launcher.Properties.Resources.padx360;
			this.ButtonB.Image = global::Launcher.Properties.Resources.padx360_rond;
			this.ButtonB.Location = new global::System.Drawing.Point(308, 86);
			this.ButtonB.Name = "ButtonB";
			this.ButtonB.Size = new global::System.Drawing.Size(30, 30);
			this.ButtonB.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.ButtonB.TabIndex = 6;
			this.ButtonB.TabStop = false;
			this.ButtonA.BackColor = global::System.Drawing.Color.Transparent;
			this.ButtonA.BackgroundImage = global::Launcher.Properties.Resources.padx360;
			this.ButtonA.Image = global::Launcher.Properties.Resources.padx360_croix;
			this.ButtonA.Location = new global::System.Drawing.Point(283, 111);
			this.ButtonA.Name = "ButtonA";
			this.ButtonA.Size = new global::System.Drawing.Size(30, 29);
			this.ButtonA.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.ButtonA.TabIndex = 5;
			this.ButtonA.TabStop = false;
			this.ButtonX.BackColor = global::System.Drawing.Color.Transparent;
			this.ButtonX.BackgroundImage = global::Launcher.Properties.Resources.padx360;
			this.ButtonX.Image = global::Launcher.Properties.Resources.padx360_carre;
			this.ButtonX.Location = new global::System.Drawing.Point(257, 86);
			this.ButtonX.Name = "ButtonX";
			this.ButtonX.Size = new global::System.Drawing.Size(29, 29);
			this.ButtonX.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.ButtonX.TabIndex = 4;
			this.ButtonX.TabStop = false;
			this.customPictureBox3.BackColor = global::System.Drawing.Color.Transparent;
			this.customPictureBox3.BackgroundImage = global::Launcher.Properties.Resources.padx360;
			this.customPictureBox3.Image = global::Launcher.Properties.Resources.padx360_L1;
			this.customPictureBox3.ImageVisible = true;
			this.customPictureBox3.Location = new global::System.Drawing.Point(80, 37);
			this.customPictureBox3.Name = "customPictureBox3";
			this.customPictureBox3.Size = new global::System.Drawing.Size(55, 18);
			this.customPictureBox3.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.customPictureBox3.TabIndex = 3;
			this.customPictureBox3.TabStop = false;
			this.customPictureBox2.BackColor = global::System.Drawing.Color.Transparent;
			this.customPictureBox2.BackgroundImage = global::Launcher.Properties.Resources.padx360;
			this.customPictureBox2.Image = global::Launcher.Properties.Resources.padx360_left;
			this.customPictureBox2.Location = new global::System.Drawing.Point(122, 144);
			this.customPictureBox2.Name = "customPictureBox2";
			this.customPictureBox2.Size = new global::System.Drawing.Size(14, 23);
			this.customPictureBox2.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.customPictureBox2.TabIndex = 2;
			this.customPictureBox2.TabStop = false;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::Launcher.Properties.Resources.padx360;
			base.ClientSize = new global::System.Drawing.Size(400, 326);
			base.Controls.Add(this.labelPushBtn);
			base.Controls.Add(this.ButtonY);
			base.Controls.Add(this.customPictureBox14);
			base.Controls.Add(this.customPictureBox13);
			base.Controls.Add(this.customPictureBox12);
			base.Controls.Add(this.customPictureBox11);
			base.Controls.Add(this.customPictureBox10);
			base.Controls.Add(this.customPictureBox9);
			base.Controls.Add(this.customPictureBox8);
			base.Controls.Add(this.customPictureBox7);
			base.Controls.Add(this.ButtonB);
			base.Controls.Add(this.ButtonA);
			base.Controls.Add(this.ButtonX);
			base.Controls.Add(this.customPictureBox3);
			base.Controls.Add(this.customPictureBox2);
			base.Controls.Add(this.xboxController);
			base.Name = "JoystickCalibration";
			this.Text = "JoystickCalibration";
			((global::System.ComponentModel.ISupportInitialize)this.xboxController).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.ButtonY).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.customPictureBox14).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.customPictureBox13).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.customPictureBox12).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.customPictureBox11).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.customPictureBox10).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.customPictureBox9).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.customPictureBox8).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.customPictureBox7).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.ButtonB).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.ButtonA).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.ButtonX).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.customPictureBox3).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.customPictureBox2).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000006 RID: 6
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000007 RID: 7
		private global::System.Windows.Forms.PictureBox xboxController;

		// Token: 0x04000008 RID: 8
		private global::Launcher.Controlls.CustomPictureBox customPictureBox2;

		// Token: 0x04000009 RID: 9
		private global::Launcher.Controlls.CustomPictureBox customPictureBox3;

		// Token: 0x0400000A RID: 10
		private global::Launcher.Controlls.CustomPictureBox ButtonX;

		// Token: 0x0400000B RID: 11
		private global::Launcher.Controlls.CustomPictureBox ButtonA;

		// Token: 0x0400000C RID: 12
		private global::Launcher.Controlls.CustomPictureBox ButtonB;

		// Token: 0x0400000D RID: 13
		private global::Launcher.Controlls.CustomPictureBox customPictureBox7;

		// Token: 0x0400000E RID: 14
		private global::Launcher.Controlls.CustomPictureBox customPictureBox8;

		// Token: 0x0400000F RID: 15
		private global::Launcher.Controlls.CustomPictureBox customPictureBox9;

		// Token: 0x04000010 RID: 16
		private global::Launcher.Controlls.CustomPictureBox customPictureBox11;

		// Token: 0x04000011 RID: 17
		private global::Launcher.Controlls.CustomPictureBox customPictureBox12;

		// Token: 0x04000012 RID: 18
		private global::Launcher.Controlls.CustomPictureBox customPictureBox13;

		// Token: 0x04000013 RID: 19
		private global::Launcher.Controlls.CustomPictureBox customPictureBox14;

		// Token: 0x04000014 RID: 20
		private global::Launcher.Controlls.CustomPictureBox ButtonY;

		// Token: 0x04000015 RID: 21
		private global::Launcher.Controlls.CustomPictureBox customPictureBox10;

		// Token: 0x04000016 RID: 22
		private global::System.Windows.Forms.Label labelPushBtn;
	}
}
