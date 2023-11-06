namespace QLThuvien
{
    partial class frmThongKeDocGia
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbConNo = new System.Windows.Forms.RadioButton();
            this.rdbTatCa = new System.Windows.Forms.RadioButton();
            this.lvMuonSach = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTong = new System.Windows.Forms.Label();
            this.btnXem = new System.Windows.Forms.Button();
            this.btnIn = new System.Windows.Forms.Button();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(220, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(393, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "BÁO CÁO THỐNG KÊ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbConNo);
            this.groupBox1.Controls.Add(this.rdbTatCa);
            this.groupBox1.Location = new System.Drawing.Point(78, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(118, 75);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thống kê theo";
            // 
            // rdbConNo
            // 
            this.rdbConNo.AutoSize = true;
            this.rdbConNo.Location = new System.Drawing.Point(19, 44);
            this.rdbConNo.Name = "rdbConNo";
            this.rdbConNo.Size = new System.Drawing.Size(59, 17);
            this.rdbConNo.TabIndex = 1;
            this.rdbConNo.TabStop = true;
            this.rdbConNo.Text = "Còn nợ";
            this.rdbConNo.UseVisualStyleBackColor = true;
            // 
            // rdbTatCa
            // 
            this.rdbTatCa.AutoSize = true;
            this.rdbTatCa.Location = new System.Drawing.Point(19, 20);
            this.rdbTatCa.Name = "rdbTatCa";
            this.rdbTatCa.Size = new System.Drawing.Size(56, 17);
            this.rdbTatCa.TabIndex = 0;
            this.rdbTatCa.TabStop = true;
            this.rdbTatCa.Text = "Tất cả";
            this.rdbTatCa.UseVisualStyleBackColor = true;
            // 
            // lvMuonSach
            // 
            this.lvMuonSach.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvMuonSach.HideSelection = false;
            this.lvMuonSach.Location = new System.Drawing.Point(12, 164);
            this.lvMuonSach.Name = "lvMuonSach";
            this.lvMuonSach.Size = new System.Drawing.Size(776, 274);
            this.lvMuonSach.TabIndex = 2;
            this.lvMuonSach.UseCompatibleStateImageBehavior = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(615, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tổng tiền:";
            // 
            // lblTong
            // 
            this.lblTong.AutoSize = true;
            this.lblTong.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblTong.Location = new System.Drawing.Point(682, 139);
            this.lblTong.Name = "lblTong";
            this.lblTong.Size = new System.Drawing.Size(35, 13);
            this.lblTong.TabIndex = 4;
            this.lblTong.Text = "label3";
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(264, 134);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 5;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(370, 133);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(75, 23);
            this.btnIn.TabIndex = 6;
            this.btnIn.Text = "In";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "STT";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Họ tên";
            this.columnHeader2.Width = 180;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Tiền nợ";
            // 
            // frmThongKeDocGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.lblTong);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lvMuonSach);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "frmThongKeDocGia";
            this.Text = "frmThongKeDocGia";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbConNo;
        private System.Windows.Forms.RadioButton rdbTatCa;
        private System.Windows.Forms.ListView lvMuonSach;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTong;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}