namespace Launcher
{
	// Token: 0x0200000A RID: 10
	public partial class MainForm : global::System.Windows.Forms.Form
	{
		// Token: 0x0600004C RID: 76 RVA: 0x0000435B File Offset: 0x0000335B
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600004D RID: 77 RVA: 0x0000437C File Offset: 0x0000337C
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Launcher.MainForm));
			this.splashContainer = new global::System.Windows.Forms.PictureBox();
			this.playBtn = new global::System.Windows.Forms.Button();
			this.settingsBtn = new global::System.Windows.Forms.Button();
			this.exitBtn = new global::System.Windows.Forms.Button();
			((global::System.ComponentModel.ISupportInitialize)this.splashContainer).BeginInit();
			base.SuspendLayout();
			this.splashContainer.AccessibleDescription = null;
			this.splashContainer.AccessibleName = null;
			componentResourceManager.ApplyResources(this.splashContainer, "splashContainer");
			this.splashContainer.BackgroundImage = null;
			this.splashContainer.BorderStyle = global::System.Windows.Forms.BorderStyle.Fixed3D;
			this.splashContainer.Font = null;
			this.splashContainer.ImageLocation = null;
			this.splashContainer.Name = "splashContainer";
			this.splashContainer.TabStop = false;
			this.playBtn.AccessibleDescription = null;
			this.playBtn.AccessibleName = null;
			componentResourceManager.ApplyResources(this.playBtn, "playBtn");
			this.playBtn.BackgroundImage = null;
			this.playBtn.Font = null;
			this.playBtn.Name = "playBtn";
			this.playBtn.UseVisualStyleBackColor = true;
			this.playBtn.Click += new global::System.EventHandler(this.playBtn_Click);
			this.settingsBtn.AccessibleDescription = null;
			this.settingsBtn.AccessibleName = null;
			componentResourceManager.ApplyResources(this.settingsBtn, "settingsBtn");
			this.settingsBtn.BackgroundImage = null;
			this.settingsBtn.Font = null;
			this.settingsBtn.Name = "settingsBtn";
			this.settingsBtn.UseVisualStyleBackColor = true;
			this.settingsBtn.Click += new global::System.EventHandler(this.settingsBtn_Click);
			this.exitBtn.AccessibleDescription = null;
			this.exitBtn.AccessibleName = null;
			componentResourceManager.ApplyResources(this.exitBtn, "exitBtn");
			this.exitBtn.BackgroundImage = null;
			this.exitBtn.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.exitBtn.Font = null;
			this.exitBtn.Name = "exitBtn";
			this.exitBtn.UseVisualStyleBackColor = true;
			this.exitBtn.MouseClick += new global::System.Windows.Forms.MouseEventHandler(this.exitBtn_MouseClick);
			base.AcceptButton = this.playBtn;
			base.AccessibleDescription = null;
			base.AccessibleName = null;
			componentResourceManager.ApplyResources(this, "$this");
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = null;
			base.CancelButton = this.exitBtn;
			base.Controls.Add(this.exitBtn);
			base.Controls.Add(this.settingsBtn);
			base.Controls.Add(this.playBtn);
			base.Controls.Add(this.splashContainer);
			this.DoubleBuffered = true;
			this.Font = null;
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.Name = "MainForm";
			((global::System.ComponentModel.ISupportInitialize)this.splashContainer).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000035 RID: 53
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000036 RID: 54
		private global::System.Windows.Forms.PictureBox splashContainer;

		// Token: 0x04000037 RID: 55
		private global::System.Windows.Forms.Button playBtn;

		// Token: 0x04000038 RID: 56
		private global::System.Windows.Forms.Button settingsBtn;

		// Token: 0x04000039 RID: 57
		private global::System.Windows.Forms.Button exitBtn;
	}
}
