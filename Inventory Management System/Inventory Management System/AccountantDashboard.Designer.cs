
namespace Inventory_Management_System
{
    partial class AccountantDashboard
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
            this.btnLogout = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvOrder = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpDays = new System.Windows.Forms.DateTimePicker();
            this.cmbMonths = new System.Windows.Forms.ComboBox();
            this.btnSeachByDate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSearchByMonth = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvOrderItems = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtPriceMax = new System.Windows.Forms.TextBox();
            this.txtNameMax = new System.Windows.Forms.TextBox();
            this.txtIDMax = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtPriceMin = new System.Windows.Forms.TextBox();
            this.txtNameMin = new System.Windows.Forms.TextBox();
            this.txtIDMin = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLogout
            // 
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnLogout.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnLogout.Location = new System.Drawing.Point(992, 799);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(110, 37);
            this.btnLogout.TabIndex = 46;
            this.btnLogout.Text = "Log Out";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(424, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(330, 33);
            this.label3.TabIndex = 47;
            this.label3.Text = "Accountant Dashboard";
            // 
            // dgvOrder
            // 
            this.dgvOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrder.Location = new System.Drawing.Point(19, 123);
            this.dgvOrder.Name = "dgvOrder";
            this.dgvOrder.RowHeadersWidth = 51;
            this.dgvOrder.RowTemplate.Height = 24;
            this.dgvOrder.Size = new System.Drawing.Size(731, 267);
            this.dgvOrder.TabIndex = 43;
            this.dgvOrder.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvOrder_CellMouseClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpDays);
            this.groupBox1.Controls.Add(this.cmbMonths);
            this.groupBox1.Controls.Add(this.btnSeachByDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dgvOrder);
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.btnSearchByMonth);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(23, 109);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(766, 415);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "View Order";
            // 
            // dtpDays
            // 
            this.dtpDays.CustomFormat = "yyyy-MM-dd";
            this.dtpDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDays.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDays.Location = new System.Drawing.Point(180, 80);
            this.dtpDays.Name = "dtpDays";
            this.dtpDays.Size = new System.Drawing.Size(206, 27);
            this.dtpDays.TabIndex = 67;
            // 
            // cmbMonths
            // 
            this.cmbMonths.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmbMonths.FormattingEnabled = true;
            this.cmbMonths.Location = new System.Drawing.Point(180, 32);
            this.cmbMonths.Name = "cmbMonths";
            this.cmbMonths.Size = new System.Drawing.Size(206, 28);
            this.cmbMonths.TabIndex = 66;
            // 
            // btnSeachByDate
            // 
            this.btnSeachByDate.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnSeachByDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnSeachByDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSeachByDate.Location = new System.Drawing.Point(409, 78);
            this.btnSeachByDate.Name = "btnSeachByDate";
            this.btnSeachByDate.Size = new System.Drawing.Size(104, 29);
            this.btnSeachByDate.TabIndex = 48;
            this.btnSeachByDate.Text = "Search";
            this.btnSeachByDate.UseVisualStyleBackColor = false;
            this.btnSeachByDate.Click += new System.EventHandler(this.btnSeachByDate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(21, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 20);
            this.label2.TabIndex = 47;
            this.label2.Text = "Daily Reports:";
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.SystemColors.Info;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(636, 31);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(114, 29);
            this.btnReset.TabIndex = 55;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSearchByMonth
            // 
            this.btnSearchByMonth.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnSearchByMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnSearchByMonth.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSearchByMonth.Location = new System.Drawing.Point(409, 31);
            this.btnSearchByMonth.Name = "btnSearchByMonth";
            this.btnSearchByMonth.Size = new System.Drawing.Size(104, 29);
            this.btnSearchByMonth.TabIndex = 45;
            this.btnSearchByMonth.Text = "Search";
            this.btnSearchByMonth.UseVisualStyleBackColor = false;
            this.btnSearchByMonth.Click += new System.EventHandler(this.btnSearchByMonth_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(21, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 20);
            this.label5.TabIndex = 44;
            this.label5.Text = "Monthly Reports:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvOrderItems);
            this.groupBox2.Location = new System.Drawing.Point(23, 540);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(766, 327);
            this.groupBox2.TabIndex = 53;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "View Order Items";
            // 
            // dgvOrderItems
            // 
            this.dgvOrderItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderItems.Location = new System.Drawing.Point(19, 29);
            this.dgvOrderItems.Name = "dgvOrderItems";
            this.dgvOrderItems.RowHeadersWidth = 51;
            this.dgvOrderItems.RowTemplate.Height = 24;
            this.dgvOrderItems.Size = new System.Drawing.Size(731, 267);
            this.dgvOrderItems.TabIndex = 43;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Aquamarine;
            this.groupBox3.Controls.Add(this.txtPriceMax);
            this.groupBox3.Controls.Add(this.txtNameMax);
            this.groupBox3.Controls.Add(this.txtIDMax);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(816, 109);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(286, 186);
            this.groupBox3.TabIndex = 54;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Most Demand Item";
            // 
            // txtPriceMax
            // 
            this.txtPriceMax.Location = new System.Drawing.Point(123, 130);
            this.txtPriceMax.Name = "txtPriceMax";
            this.txtPriceMax.ReadOnly = true;
            this.txtPriceMax.Size = new System.Drawing.Size(146, 22);
            this.txtPriceMax.TabIndex = 5;
            // 
            // txtNameMax
            // 
            this.txtNameMax.Location = new System.Drawing.Point(123, 85);
            this.txtNameMax.Name = "txtNameMax";
            this.txtNameMax.ReadOnly = true;
            this.txtNameMax.Size = new System.Drawing.Size(146, 22);
            this.txtNameMax.TabIndex = 4;
            // 
            // txtIDMax
            // 
            this.txtIDMax.Location = new System.Drawing.Point(123, 40);
            this.txtIDMax.Name = "txtIDMax";
            this.txtIDMax.ReadOnly = true;
            this.txtIDMax.Size = new System.Drawing.Size(146, 22);
            this.txtIDMax.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 17);
            this.label8.TabIndex = 2;
            this.label8.Text = "Item Price:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 17);
            this.label7.TabIndex = 1;
            this.label7.Text = "Item Name:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Item ID:";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.LightSalmon;
            this.groupBox4.Controls.Add(this.txtPriceMin);
            this.groupBox4.Controls.Add(this.txtNameMin);
            this.groupBox4.Controls.Add(this.txtIDMin);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(816, 338);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(286, 186);
            this.groupBox4.TabIndex = 55;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Least Demand Item";
            // 
            // txtPriceMin
            // 
            this.txtPriceMin.Location = new System.Drawing.Point(123, 130);
            this.txtPriceMin.Name = "txtPriceMin";
            this.txtPriceMin.ReadOnly = true;
            this.txtPriceMin.Size = new System.Drawing.Size(146, 22);
            this.txtPriceMin.TabIndex = 5;
            // 
            // txtNameMin
            // 
            this.txtNameMin.Location = new System.Drawing.Point(123, 85);
            this.txtNameMin.Name = "txtNameMin";
            this.txtNameMin.ReadOnly = true;
            this.txtNameMin.Size = new System.Drawing.Size(146, 22);
            this.txtNameMin.TabIndex = 4;
            // 
            // txtIDMin
            // 
            this.txtIDMin.Location = new System.Drawing.Point(123, 40);
            this.txtIDMin.Name = "txtIDMin";
            this.txtIDMin.ReadOnly = true;
            this.txtIDMin.Size = new System.Drawing.Size(146, 22);
            this.txtIDMin.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 133);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 17);
            this.label9.TabIndex = 2;
            this.label9.Text = "Item Price:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 88);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 17);
            this.label10.TabIndex = 1;
            this.label10.Text = "Item Name:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(24, 43);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 17);
            this.label11.TabIndex = 0;
            this.label11.Text = "Item ID:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(422, 33);
            this.label1.TabIndex = 56;
            this.label1.Text = "Prasad Mobile Center Pvt Ltd";
            // 
            // AccountantDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 892);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnLogout);
            this.Name = "AccountantDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Accountant Dashboard";
            this.Load += new System.EventHandler(this.AccountantDashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvOrder;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSeachByDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSearchByMonth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvOrderItems;
        private System.Windows.Forms.ComboBox cmbMonths;
        private System.Windows.Forms.DateTimePicker dtpDays;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPriceMax;
        private System.Windows.Forms.TextBox txtNameMax;
        private System.Windows.Forms.TextBox txtIDMax;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtPriceMin;
        private System.Windows.Forms.TextBox txtNameMin;
        private System.Windows.Forms.TextBox txtIDMin;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
    }
}