namespace Launcher
{
	// Token: 0x02000008 RID: 8
	public partial class Settings : global::System.Windows.Forms.Form
	{
		// Token: 0x0600003B RID: 59 RVA: 0x00003AE9 File Offset: 0x00002AE9
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00003B08 File Offset: 0x00002B08
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Launcher.Settings));
			this.windowedCheck = new global::System.Windows.Forms.CheckBox();
			this.vSyncCheck = new global::System.Windows.Forms.CheckBox();
			this.rezCombo = new global::System.Windows.Forms.ComboBox();
			this.langCombo = new global::System.Windows.Forms.ComboBox();
			this.cancelBtn = new global::System.Windows.Forms.Button();
			this.okBtn = new global::System.Windows.Forms.Button();
			this.rabbidPicture = new global::System.Windows.Forms.PictureBox();
			this.joyCalibrate = new global::System.Windows.Forms.Button();
			global::System.Windows.Forms.GroupBox groupBox = new global::System.Windows.Forms.GroupBox();
			global::System.Windows.Forms.Label label = new global::System.Windows.Forms.Label();
			global::System.Windows.Forms.GroupBox groupBox2 = new global::System.Windows.Forms.GroupBox();
			groupBox.SuspendLayout();
			groupBox2.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.rabbidPicture).BeginInit();
			base.SuspendLayout();
			groupBox.AccessibleDescription = null;
			groupBox.AccessibleName = null;
			componentResourceManager.ApplyResources(groupBox, "displayGroup");
			groupBox.BackgroundImage = null;
			groupBox.Controls.Add(this.windowedCheck);
			groupBox.Controls.Add(this.vSyncCheck);
			groupBox.Controls.Add(label);
			groupBox.Controls.Add(this.rezCombo);
			groupBox.Font = null;
			groupBox.Name = "displayGroup";
			groupBox.TabStop = false;
			this.windowedCheck.AccessibleDescription = null;
			this.windowedCheck.AccessibleName = null;
			componentResourceManager.ApplyResources(this.windowedCheck, "windowedCheck");
			this.windowedCheck.BackgroundImage = null;
			this.windowedCheck.Font = null;
			this.windowedCheck.Name = "windowedCheck";
			this.windowedCheck.UseVisualStyleBackColor = true;
			this.vSyncCheck.AccessibleDescription = null;
			this.vSyncCheck.AccessibleName = null;
			componentResourceManager.ApplyResources(this.vSyncCheck, "vSyncCheck");
			this.vSyncCheck.BackgroundImage = null;
			this.vSyncCheck.Font = null;
			this.vSyncCheck.Name = "vSyncCheck";
			this.vSyncCheck.UseVisualStyleBackColor = true;
			label.AccessibleDescription = null;
			label.AccessibleName = null;
			componentResourceManager.ApplyResources(label, "rezLabel");
			label.Font = null;
			label.Name = "rezLabel";
			this.rezCombo.AccessibleDescription = null;
			this.rezCombo.AccessibleName = null;
			componentResourceManager.ApplyResources(this.rezCombo, "rezCombo");
			this.rezCombo.BackgroundImage = null;
			this.rezCombo.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.rezCombo.Font = null;
			this.rezCombo.Name = "rezCombo";
			groupBox2.AccessibleDescription = null;
			groupBox2.AccessibleName = null;
			componentResourceManager.ApplyResources(groupBox2, "langGroup");
			groupBox2.BackgroundImage = null;
			groupBox2.Controls.Add(this.langCombo);
			groupBox2.Font = null;
			groupBox2.Name = "langGroup";
			groupBox2.TabStop = false;
			this.langCombo.AccessibleDescription = null;
			this.langCombo.AccessibleName = null;
			componentResourceManager.ApplyResources(this.langCombo, "langCombo");
			this.langCombo.BackgroundImage = null;
			this.langCombo.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.langCombo.Font = null;
			this.langCombo.Name = "langCombo";
			this.cancelBtn.AccessibleDescription = null;
			this.cancelBtn.AccessibleName = null;
			componentResourceManager.ApplyResources(this.cancelBtn, "cancelBtn");
			this.cancelBtn.BackgroundImage = null;
			this.cancelBtn.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn.Font = null;
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.UseVisualStyleBackColor = true;
			this.cancelBtn.Click += new global::System.EventHandler(this.cancelBtn_Click);
			this.okBtn.AccessibleDescription = null;
			this.okBtn.AccessibleName = null;
			componentResourceManager.ApplyResources(this.okBtn, "okBtn");
			this.okBtn.BackgroundImage = null;
			this.okBtn.Font = null;
			this.okBtn.Name = "okBtn";
			this.okBtn.UseVisualStyleBackColor = true;
			this.okBtn.Click += new global::System.EventHandler(this.okBtn_Click);
			this.rabbidPicture.AccessibleDescription = null;
			this.rabbidPicture.AccessibleName = null;
			componentResourceManager.ApplyResources(this.rabbidPicture, "rabbidPicture");
			this.rabbidPicture.BackgroundImage = null;
			this.rabbidPicture.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
			this.rabbidPicture.Font = null;
			this.rabbidPicture.ImageLocation = null;
			this.rabbidPicture.Name = "rabbidPicture";
			this.rabbidPicture.TabStop = false;
			this.joyCalibrate.AccessibleDescription = null;
			this.joyCalibrate.AccessibleName = null;
			componentResourceManager.ApplyResources(this.joyCalibrate, "joyCalibrate");
			this.joyCalibrate.BackgroundImage = null;
			this.joyCalibrate.Font = null;
			this.joyCalibrate.Name = "joyCalibrate";
			this.joyCalibrate.UseVisualStyleBackColor = true;
			this.joyCalibrate.Click += new global::System.EventHandler(this.joyCalibrate_Click);
			base.AcceptButton = this.okBtn;
			base.AccessibleDescription = null;
			base.AccessibleName = null;
			componentResourceManager.ApplyResources(this, "$this");
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = null;
			base.CancelButton = this.cancelBtn;
			base.Controls.Add(this.joyCalibrate);
			base.Controls.Add(this.rabbidPicture);
			base.Controls.Add(this.okBtn);
			base.Controls.Add(this.cancelBtn);
			base.Controls.Add(groupBox2);
			base.Controls.Add(groupBox);
			this.Font = null;
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Icon = null;
			base.Name = "Settings";
			base.ShowInTaskbar = false;
			groupBox.ResumeLayout(false);
			groupBox.PerformLayout();
			groupBox2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.rabbidPicture).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000025 RID: 37
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000026 RID: 38
		private global::System.Windows.Forms.Button cancelBtn;

		// Token: 0x04000027 RID: 39
		private global::System.Windows.Forms.Button okBtn;

		// Token: 0x04000028 RID: 40
		private global::System.Windows.Forms.ComboBox langCombo;

		// Token: 0x04000029 RID: 41
		private global::System.Windows.Forms.ComboBox rezCombo;

		// Token: 0x0400002A RID: 42
		private global::System.Windows.Forms.CheckBox vSyncCheck;

		// Token: 0x0400002B RID: 43
		private global::System.Windows.Forms.CheckBox windowedCheck;

		// Token: 0x0400002C RID: 44
		private global::System.Windows.Forms.PictureBox rabbidPicture;

		// Token: 0x0400002D RID: 45
		private global::System.Windows.Forms.Button joyCalibrate;
	}
}
