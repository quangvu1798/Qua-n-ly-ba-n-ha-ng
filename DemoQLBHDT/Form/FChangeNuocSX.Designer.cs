namespace DemoQLBHDT
{
    partial class FChangeNuocSX
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
            this.txtMaNuocSX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenNuocSX = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labTacVu = new System.Windows.Forms.Label();
            this.labLuuY = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(239, 159);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 31);
            this.btnHuy.TabIndex = 53;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnThucHien
            // 
            this.btnThucHien.Location = new System.Drawing.Point(99, 159);
            this.btnThucHien.Name = "btnThucHien";
            this.btnThucHien.Size = new System.Drawing.Size(75, 31);
            this.btnThucHien.TabIndex = 52;
            this.btnThucHien.Text = "Thực Hiện";
            this.btnThucHien.UseVisualStyleBackColor = true;
            this.btnThucHien.Click += new System.EventHandler(this.btnThucHien_Click);
            // 
            // txtMaNuocSX
            // 
            this.txtMaNuocSX.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNuocSX.Location = new System.Drawing.Point(99, 38);
            this.txtMaNuocSX.Multiline = true;
            this.txtMaNuocSX.Name = "txtMaNuocSX";
            this.txtMaNuocSX.Size = new System.Drawing.Size(215, 27);
            this.txtMaNuocSX.TabIndex = 51;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 19);
            this.label1.TabIndex = 50;
            this.label1.Text = "Mã Nước";
            // 
            // txtTenNuocSX
            // 
            this.txtTenNuocSX.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenNuocSX.Location = new System.Drawing.Point(99, 92);
            this.txtTenNuocSX.Multiline = true;
            this.txtTenNuocSX.Name = "txtTenNuocSX";
            this.txtTenNuocSX.Size = new System.Drawing.Size(215, 27);
            this.txtTenNuocSX.TabIndex = 49;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 19);
            this.label2.TabIndex = 48;
            this.label2.Text = "Tên Nước";
            // 
            // labTacVu
            // 
            this.labTacVu.AutoSize = true;
            this.labTacVu.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTacVu.Location = new System.Drawing.Point(137, 9);
            this.labTacVu.Name = "labTacVu";
            this.labTacVu.Size = new System.Drawing.Size(76, 25);
            this.labTacVu.TabIndex = 63;
            this.labTacVu.Text = "label1";
            // 
            // labLuuY
            // 
            this.labLuuY.AutoSize = true;
            this.labLuuY.ForeColor = System.Drawing.Color.Red;
            this.labLuuY.Location = new System.Drawing.Point(96, 133);
            this.labLuuY.Name = "labLuuY";
            this.labLuuY.Size = new System.Drawing.Size(0, 13);
            this.labLuuY.TabIndex = 64;
            // 
            // FChangeNuocSX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 202);
            this.Controls.Add(this.labLuuY);
            this.Controls.Add(this.labTacVu);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnThucHien);
            this.Controls.Add(this.txtMaNuocSX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTenNuocSX);
            this.Controls.Add(this.label2);
            this.Name = "FChangeNuocSX";
            this.Text = "Nước Sản Xuất";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnThucHien;
        private System.Windows.Forms.TextBox txtMaNuocSX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTenNuocSX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labTacVu;
        private System.Windows.Forms.Label labLuuY;
    }
}