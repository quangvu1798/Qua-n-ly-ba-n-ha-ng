namespace DemoQLBHDT
{
    partial class FChangeCaLam
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
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnThucHien = new System.Windows.Forms.Button();
            this.txtMaCa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenCa = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labTacVu = new System.Windows.Forms.Label();
            this.labLuuY = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(239, 225);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 31);
            this.btnHuy.TabIndex = 59;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnThucHien
            // 
            this.btnThucHien.Location = new System.Drawing.Point(99, 225);
            this.btnThucHien.Name = "btnThucHien";
            this.btnThucHien.Size = new System.Drawing.Size(75, 31);
            this.btnThucHien.TabIndex = 58;
            this.btnThucHien.Text = "Thực Hiện";
            this.btnThucHien.UseVisualStyleBackColor = true;
            this.btnThucHien.Click += new System.EventHandler(this.btnThucHien_Click);
            // 
            // txtMaCa
            // 
            this.txtMaCa.Location = new System.Drawing.Point(99, 49);
            this.txtMaCa.Multiline = true;
            this.txtMaCa.Name = "txtMaCa";
            this.txtMaCa.Size = new System.Drawing.Size(215, 27);
            this.txtMaCa.TabIndex = 57;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 19);
            this.label1.TabIndex = 56;
            this.label1.Text = "Mã Ca";
            // 
            // txtTenCa
            // 
            this.txtTenCa.Location = new System.Drawing.Point(99, 103);
            this.txtTenCa.Multiline = true;
            this.txtTenCa.Name = "txtTenCa";
            this.txtTenCa.Size = new System.Drawing.Size(215, 27);
            this.txtTenCa.TabIndex = 55;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 19);
            this.label2.TabIndex = 54;
            this.label2.Text = "Tên Ca";
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(99, 153);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(215, 27);
            this.txtMoTa.TabIndex = 61;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 19);
            this.label3.TabIndex = 60;
            this.label3.Text = "Mô Tả";
            // 
            // labTacVu
            // 
            this.labTacVu.AutoSize = true;
            this.labTacVu.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTacVu.Location = new System.Drawing.Point(153, 9);
            this.labTacVu.Name = "labTacVu";
            this.labTacVu.Size = new System.Drawing.Size(76, 25);
            this.labTacVu.TabIndex = 62;
            this.labTacVu.Text = "label4";
            // 
            // labLuuY
            // 
            this.labLuuY.AutoSize = true;
            this.labLuuY.ForeColor = System.Drawing.Color.Red;
            this.labLuuY.Location = new System.Drawing.Point(96, 193);
            this.labLuuY.Name = "labLuuY";
            this.labLuuY.Size = new System.Drawing.Size(0, 13);
            this.labLuuY.TabIndex = 63;
            // 
            // FChangeCaLam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 268);
            this.Controls.Add(this.labLuuY);
            this.Controls.Add(this.labTacVu);
            this.Controls.Add(this.txtMoTa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnThucHien);
            this.Controls.Add(this.txtMaCa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTenCa);
            this.Controls.Add(this.label2);
            this.Name = "FChangeCaLam";
            this.Text = "Ca Làm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnThucHien;
        private System.Windows.Forms.TextBox txtMaCa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTenCa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labTacVu;
        private System.Windows.Forms.Label labLuuY;
    }
}