namespace WindowsFormsApp1
{
	partial class fCamera
	{
		private System.ComponentModel.IContainer components = null;

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1; // Модель
		private System.Windows.Forms.Label label2; // Виробник
		private System.Windows.Forms.Label label3; // Мегапікселі
		private System.Windows.Forms.Label label4; // Ємність батареї
		private System.Windows.Forms.Label label5; // Вага
		private System.Windows.Forms.Label label6; // Ціна
		private System.Windows.Forms.Label label7; // Рік випуску
		private System.Windows.Forms.TextBox tbModel;
		private System.Windows.Forms.TextBox tbManufacturer;
		private System.Windows.Forms.TextBox tbMegapixels;
		private System.Windows.Forms.TextBox tbBattery;
		private System.Windows.Forms.TextBox tbWeight;
		private System.Windows.Forms.TextBox tbPrice;
		private System.Windows.Forms.TextBox tbYear;

		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckBox chbHasWiFi;
		private System.Windows.Forms.CheckBox chbHasInterchangeableLens;

		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;

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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tbYear = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.tbPrice = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.tbWeight = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.tbBattery = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tbMegapixels = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tbManufacturer = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tbModel = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.chbHasInterchangeableLens = new System.Windows.Forms.CheckBox();
			this.chbHasWiFi = new System.Windows.Forms.CheckBox();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tbYear);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.tbPrice);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.tbWeight);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.tbBattery);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.tbMegapixels);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.tbManufacturer);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.tbModel);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(16, 15);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(430, 258);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Загальні дані";
			// 
			// tbYear
			// 
			this.tbYear.Location = new System.Drawing.Point(172, 214);
			this.tbYear.Name = "tbYear";
			this.tbYear.Size = new System.Drawing.Size(236, 22);
			this.tbYear.TabIndex = 6;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(16, 217);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(106, 16);
			this.label7.TabIndex = 12;
			this.label7.Text = "Рік випуску (р.)";
			// 
			// tbPrice
			// 
			this.tbPrice.Location = new System.Drawing.Point(172, 181);
			this.tbPrice.Name = "tbPrice";
			this.tbPrice.Size = new System.Drawing.Size(236, 22);
			this.tbPrice.TabIndex = 5;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(16, 184);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(79, 16);
			this.label6.TabIndex = 10;
			this.label6.Text = "Ціна (USD)";
			// 
			// tbWeight
			// 
			this.tbWeight.Location = new System.Drawing.Point(172, 148);
			this.tbWeight.Name = "tbWeight";
			this.tbWeight.Size = new System.Drawing.Size(236, 22);
			this.tbWeight.TabIndex = 4;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(16, 151);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(99, 16);
			this.label5.TabIndex = 8;
			this.label5.Text = "Вага (грами)";
			// 
			// tbBattery
			// 
			this.tbBattery.Location = new System.Drawing.Point(172, 115);
			this.tbBattery.Name = "tbBattery";
			this.tbBattery.Size = new System.Drawing.Size(236, 22);
			this.tbBattery.TabIndex = 3;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(16, 118);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(136, 16);
			this.label4.TabIndex = 6;
			this.label4.Text = "Ємність батареї (mAh)";
			// 
			// tbMegapixels
			// 
			this.tbMegapixels.Location = new System.Drawing.Point(172, 82);
			this.tbMegapixels.Name = "tbMegapixels";
			this.tbMegapixels.Size = new System.Drawing.Size(236, 22);
			this.tbMegapixels.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(16, 85);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(90, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "Мегапікселі";
			// 
			// tbManufacturer
			// 
			this.tbManufacturer.Location = new System.Drawing.Point(172, 49);
			this.tbManufacturer.Name = "tbManufacturer";
			this.tbManufacturer.Size = new System.Drawing.Size(236, 22);
			this.tbManufacturer.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(16, 52);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(81, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Виробник";
			// 
			// tbModel
			// 
			this.tbModel.Location = new System.Drawing.Point(172, 16);
			this.tbModel.Name = "tbModel";
			this.tbModel.Size = new System.Drawing.Size(236, 22);
			this.tbModel.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(57, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Модель";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.chbHasInterchangeableLens);
			this.groupBox2.Controls.Add(this.chbHasWiFi);
			this.groupBox2.Location = new System.Drawing.Point(16, 279);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(430, 83);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Опції";
			// 
			// chbHasInterchangeableLens
			// 
			this.chbHasInterchangeableLens.AutoSize = true;
			this.chbHasInterchangeableLens.Location = new System.Drawing.Point(19, 52);
			this.chbHasInterchangeableLens.Name = "chbHasInterchangeableLens";
			this.chbHasInterchangeableLens.Size = new System.Drawing.Size(192, 20);
			this.chbHasInterchangeableLens.TabIndex = 8;
			this.chbHasInterchangeableLens.Text = "Змінний об’єктив (ILC)";
			this.chbHasInterchangeableLens.UseVisualStyleBackColor = true;
			// 
			// chbHasWiFi
			// 
			this.chbHasWiFi.AutoSize = true;
			this.chbHasWiFi.Location = new System.Drawing.Point(19, 26);
			this.chbHasWiFi.Name = "chbHasWiFi";
			this.chbHasWiFi.Size = new System.Drawing.Size(58, 20);
			this.chbHasWiFi.TabIndex = 7;
			this.chbHasWiFi.Text = "WiFi";
			this.chbHasWiFi.UseVisualStyleBackColor = true;
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(16, 376);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(123, 36);
			this.btnOk.TabIndex = 9;
			this.btnOk.Text = "OK";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(159, 376);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(123, 36);
			this.btnCancel.TabIndex = 10;
			this.btnCancel.Text = "Скасувати";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// fCamera
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(459, 427);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "fCamera";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Дані про нову камеру";
			this.Load += new System.EventHandler(this.fCamera_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
		}
	}
}
