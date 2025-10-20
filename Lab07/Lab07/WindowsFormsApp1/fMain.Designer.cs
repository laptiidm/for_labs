namespace WindowsFormsApp1
{
	partial class fMain
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.tbX1 = new System.Windows.Forms.TextBox();
			this.tbX2 = new System.Windows.Forms.TextBox();
			this.tbY = new System.Windows.Forms.TextBox();
			this.tbMin = new System.Windows.Forms.TextBox();
			this.btnCalculate = new System.Windows.Forms.Button();
			this.btnClear = new System.Windows.Forms.Button();
			this.btnExit = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(36, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(70, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Змінна X1\r\n";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(36, 101);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(70, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "Змінна X2";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(36, 249);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 16);
			this.label3.TabIndex = 2;
			this.label3.Text = "Min(X1, X2)";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(34, 180);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(89, 16);
			this.label4.TabIndex = 3;
			this.label4.Text = "Результат Y";
			// 
			// tbX1
			// 
			this.tbX1.Location = new System.Drawing.Point(231, 24);
			this.tbX1.Name = "tbX1";
			this.tbX1.Size = new System.Drawing.Size(100, 22);
			this.tbX1.TabIndex = 4;
			// 
			// tbX2
			// 
			this.tbX2.Location = new System.Drawing.Point(231, 98);
			this.tbX2.Name = "tbX2";
			this.tbX2.Size = new System.Drawing.Size(100, 22);
			this.tbX2.TabIndex = 5;
			// 
			// tbY
			// 
			this.tbY.Location = new System.Drawing.Point(231, 177);
			this.tbY.Name = "tbY";
			this.tbY.ReadOnly = true;
			this.tbY.Size = new System.Drawing.Size(100, 22);
			this.tbY.TabIndex = 6;
			// 
			// tbMin
			// 
			this.tbMin.Location = new System.Drawing.Point(231, 246);
			this.tbMin.Name = "tbMin";
			this.tbMin.ReadOnly = true;
			this.tbMin.Size = new System.Drawing.Size(100, 22);
			this.tbMin.TabIndex = 7;
			// 
			// btnCalculate
			// 
			this.btnCalculate.Location = new System.Drawing.Point(38, 387);
			this.btnCalculate.Name = "btnCalculate";
			this.btnCalculate.Size = new System.Drawing.Size(97, 23);
			this.btnCalculate.TabIndex = 8;
			this.btnCalculate.Text = "Обчислити";
			this.btnCalculate.UseVisualStyleBackColor = true;
			this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
			// 
			// btnClear
			// 
			this.btnClear.Location = new System.Drawing.Point(208, 387);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(104, 23);
			this.btnClear.TabIndex = 9;
			this.btnClear.Text = "Очистити";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// btnExit
			// 
			this.btnExit.Location = new System.Drawing.Point(398, 387);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(102, 23);
			this.btnExit.TabIndex = 10;
			this.btnExit.Text = "Вихід";
			this.btnExit.UseVisualStyleBackColor = true;
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// fMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.btnCalculate);
			this.Controls.Add(this.tbMin);
			this.Controls.Add(this.tbY);
			this.Controls.Add(this.tbX2);
			this.Controls.Add(this.tbX1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.Name = "fMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Лабораторна робота №7";
			this.Load += new System.EventHandler(this.fMain_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbX1;
		private System.Windows.Forms.TextBox tbX2;
		private System.Windows.Forms.TextBox tbY;
		private System.Windows.Forms.TextBox tbMin;
		private System.Windows.Forms.Button btnCalculate;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.Button btnExit;
	}
}

