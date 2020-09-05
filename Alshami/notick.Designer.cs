namespace Alshami
{
    partial class notick
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
            this.tbnamenotick = new System.Windows.Forms.TextBox();
            this.lvnotick = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbticknotick = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbname2notick = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbidnotick = new System.Windows.Forms.TextBox();
            this.btndonenotick = new System.Windows.Forms.Button();
            this.btnsearchnotick = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(571, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "الاسم";
            // 
            // tbnamenotick
            // 
            this.tbnamenotick.Location = new System.Drawing.Point(131, 43);
            this.tbnamenotick.Name = "tbnamenotick";
            this.tbnamenotick.Size = new System.Drawing.Size(425, 35);
            this.tbnamenotick.TabIndex = 1;
            // 
            // lvnotick
            // 
            this.lvnotick.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader5,
            this.col4});
            this.lvnotick.FullRowSelect = true;
            this.lvnotick.GridLines = true;
            this.lvnotick.HideSelection = false;
            this.lvnotick.Location = new System.Drawing.Point(0, 83);
            this.lvnotick.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lvnotick.MultiSelect = false;
            this.lvnotick.Name = "lvnotick";
            this.lvnotick.RightToLeftLayout = true;
            this.lvnotick.Size = new System.Drawing.Size(635, 269);
            this.lvnotick.TabIndex = 19;
            this.lvnotick.UseCompatibleStateImageBehavior = false;
            this.lvnotick.View = System.Windows.Forms.View.Details;
            this.lvnotick.SelectedIndexChanged += new System.EventHandler(this.Lvnotick_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "رقم الايصال";
            this.columnHeader1.Width = 74;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "الاسم";
            this.columnHeader2.Width = 143;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "النوع";
            this.columnHeader4.Width = 146;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "التاريخ";
            this.columnHeader5.Width = 198;
            // 
            // col4
            // 
            this.col4.Text = "التسليم";
            // 
            // tbticknotick
            // 
            this.tbticknotick.Location = new System.Drawing.Point(69, 381);
            this.tbticknotick.Name = "tbticknotick";
            this.tbticknotick.Size = new System.Drawing.Size(420, 35);
            this.tbticknotick.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(541, 384);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 27);
            this.label2.TabIndex = 0;
            this.label2.Text = "رقم الايصال";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(544, 425);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 27);
            this.label3.TabIndex = 0;
            this.label3.Text = "اسم المستلم";
            // 
            // tbname2notick
            // 
            this.tbname2notick.Location = new System.Drawing.Point(69, 422);
            this.tbname2notick.Name = "tbname2notick";
            this.tbname2notick.Size = new System.Drawing.Size(420, 35);
            this.tbname2notick.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(496, 466);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 27);
            this.label4.TabIndex = 0;
            this.label4.Text = "رقم البطاقة الشخصية";
            // 
            // tbidnotick
            // 
            this.tbidnotick.Location = new System.Drawing.Point(69, 463);
            this.tbidnotick.Name = "tbidnotick";
            this.tbidnotick.Size = new System.Drawing.Size(420, 35);
            this.tbidnotick.TabIndex = 20;
            // 
            // btndonenotick
            // 
            this.btndonenotick.Location = new System.Drawing.Point(414, 525);
            this.btndonenotick.Name = "btndonenotick";
            this.btndonenotick.Size = new System.Drawing.Size(75, 35);
            this.btndonenotick.TabIndex = 21;
            this.btndonenotick.Text = "تسليم";
            this.btndonenotick.UseVisualStyleBackColor = true;
            this.btndonenotick.Click += new System.EventHandler(this.Btndonenotick_Click);
            // 
            // btnsearchnotick
            // 
            this.btnsearchnotick.Location = new System.Drawing.Point(52, 43);
            this.btnsearchnotick.Name = "btnsearchnotick";
            this.btnsearchnotick.Size = new System.Drawing.Size(63, 35);
            this.btnsearchnotick.TabIndex = 21;
            this.btnsearchnotick.Text = "بحث";
            this.btnsearchnotick.UseVisualStyleBackColor = true;
            this.btnsearchnotick.Click += new System.EventHandler(this.Btnsearchnotick_Click);
            // 
            // notick
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 591);
            this.Controls.Add(this.btnsearchnotick);
            this.Controls.Add(this.btndonenotick);
            this.Controls.Add(this.tbidnotick);
            this.Controls.Add(this.tbname2notick);
            this.Controls.Add(this.tbticknotick);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lvnotick);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbnamenotick);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arabic Typesetting", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "notick";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "تسليم بلا وصل";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbnamenotick;
        private System.Windows.Forms.ListView lvnotick;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.TextBox tbticknotick;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbname2notick;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbidnotick;
        private System.Windows.Forms.Button btndonenotick;
        private System.Windows.Forms.Button btnsearchnotick;
        private System.Windows.Forms.ColumnHeader col4;
    }
}