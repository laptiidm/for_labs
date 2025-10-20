namespace WindowsFormsApp1
{
	partial class fMain
	{
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TextBox tbCamerasInfo;
		private System.Windows.Forms.Button btnAddCamera;
		private System.Windows.Forms.Button btnClose;

		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.tbCamerasInfo = new System.Windows.Forms.TextBox();
			this.btnAddCamera = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// tbCamerasInfo
			// 
			this.tbCamerasInfo.Location = new System.Drawing.Point(12, 12);
			this.tbCamerasInfo.Multiline = true;
			this.tbCamerasInfo.Name = "tbCamerasInfo";
			this.tbCamerasInfo.ReadOnly = true;
			this.tbCamerasInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbCamerasInfo.Size = new System.Drawing.Size(546, 336);
			this.tbCamerasInfo.TabIndex = 0;
			// 
			// btnAddCamera
			// 
			this.btnAddCamera.Location = new System.Drawing.Point(575, 12);
			this.btnAddCamera.Name = "btnAddCamera";
			this.btnAddCamera.Size = new System.Drawing.Size(151, 40);
			this.btnAddCamera.TabIndex = 1;
			this.btnAddCamera.Text = "Додати камеру";
			this.btnAddCamera.UseVisualStyleBackColor = true;
			this.btnAddCamera.Click += new System.EventHandler(this.btnAddCamera_Click);
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(575, 64);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(151, 40);
			this.btnClose.TabIndex = 2;
			this.btnClose.Text = "Закрити";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// fMain
			// 
			this.AcceptButton = this.btnAddCamera;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(738, 360);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnAddCamera);
			this.Controls.Add(this.tbCamerasInfo);
			this.MaximizeBox = false;
			this.Name = "fMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Лабораторна робота №8";
			this.Load += new System.EventHandler(this.fMain_Load);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
	}
}
