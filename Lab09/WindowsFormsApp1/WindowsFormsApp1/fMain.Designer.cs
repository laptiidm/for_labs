namespace Lab09
{
	partial class fMain
	{
		private System.ComponentModel.IContainer components = null;

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;

		private System.Windows.Forms.TextBox tbx1min;
		private System.Windows.Forms.TextBox tbx1max;
		private System.Windows.Forms.TextBox tbdx1;
		private System.Windows.Forms.TextBox tbx2min;
		private System.Windows.Forms.TextBox tbx2max;
		private System.Windows.Forms.TextBox tbdx2;

		private System.Windows.Forms.DataGridView gv;

		private System.Windows.Forms.Button btnCalc;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.Button btnExit;

		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
				components.Dispose();
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.tbx1min = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tbx1max = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tbdx1 = new System.Windows.Forms.TextBox();

			this.label4 = new System.Windows.Forms.Label();
			this.tbx2min = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.tbx2max = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.tbdx2 = new System.Windows.Forms.TextBox();

			this.gv = new System.Windows.Forms.DataGridView();

			this.btnCalc = new System.Windows.Forms.Button();
			this.btnClear = new System.Windows.Forms.Button();
			this.btnExit = new System.Windows.Forms.Button();

			((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
			this.SuspendLayout();

			// labels top row (x1)
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Text = "X1min";
			this.tbx1min.Location = new System.Drawing.Point(60, 12);
			this.tbx1min.Size = new System.Drawing.Size(80, 22);

			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(150, 15);
			this.label2.Text = "X1max";
			this.tbx1max.Location = new System.Drawing.Point(200, 12);
			this.tbx1max.Size = new System.Drawing.Size(80, 22);

			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(292, 15);
			this.label3.Text = "dX1";
			this.tbdx1.Location = new System.Drawing.Point(330, 12);
			this.tbdx1.Size = new System.Drawing.Size(80, 22);

			// labels second row (x2)
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 45);
			this.label4.Text = "X2min";
			this.tbx2min.Location = new System.Drawing.Point(60, 42);
			this.tbx2min.Size = new System.Drawing.Size(80, 22);

			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(150, 45);
			this.label5.Text = "X2max";
			this.tbx2max.Location = new System.Drawing.Point(200, 42);
			this.tbx2max.Size = new System.Drawing.Size(80, 22);

			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(292, 45);
			this.label6.Text = "dX2";
			this.tbdx2.Location = new System.Drawing.Point(330, 42);
			this.tbdx2.Size = new System.Drawing.Size(80, 22);

			// DataGridView
			this.gv.Location = new System.Drawing.Point(15, 80);
			this.gv.Size = new System.Drawing.Size(600, 350);
			this.gv.AllowUserToAddRows = false;
			this.gv.AllowUserToDeleteRows = false;
			this.gv.ReadOnly = true;
			this.gv.RowHeadersWidth = 80;
			this.gv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

			// Buttons
			this.btnCalc.Location = new System.Drawing.Point(630, 80);
			this.btnCalc.Size = new System.Drawing.Size(120, 35);
			this.btnCalc.Text = "Розрахувати";
			this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);

			this.btnClear.Location = new System.Drawing.Point(630, 125);
			this.btnClear.Size = new System.Drawing.Size(120, 35);
			this.btnClear.Text = "Очистити";
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

			this.btnExit.Location = new System.Drawing.Point(630, 170);
			this.btnExit.Size = new System.Drawing.Size(120, 35);
			this.btnExit.Text = "Вийти";
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);

			// form
			this.AcceptButton = this.btnCalc;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(770, 450);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.btnCalc);
			this.Controls.Add(this.gv);

			this.Controls.Add(this.tbdx2);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.tbx2max);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.tbx2min);
			this.Controls.Add(this.label4);

			this.Controls.Add(this.tbdx1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.tbx1max);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tbx1min);
			this.Controls.Add(this.label1);

			this.MaximizeBox = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Name = "fMain";
			this.Text = "Лабораторна робота №9";

			((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
	}
}
