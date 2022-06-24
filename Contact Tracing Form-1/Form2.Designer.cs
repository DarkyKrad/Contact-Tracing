namespace Contact_Tracing_Form_1
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnFN = new System.Windows.Forms.ColumnHeader();
            this.columnDate = new System.Windows.Forms.ColumnHeader();
            this.lblDetail = new System.Windows.Forms.Label();
            this.dtpDOV2 = new System.Windows.Forms.DateTimePicker();
            this.btnDF = new System.Windows.Forms.Button();
            this.btnRF = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnFN,
            this.columnDate});
            this.listView1.Location = new System.Drawing.Point(358, 66);
            this.listView1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(274, 351);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listview_indexchange);
            // 
            // columnFN
            // 
            this.columnFN.DisplayIndex = 1;
            this.columnFN.Tag = "FullName";
            this.columnFN.Text = "Full Name";
            // 
            // columnDate
            // 
            this.columnDate.DisplayIndex = 0;
            this.columnDate.Tag = "Date";
            this.columnDate.Text = "Date";
            // 
            // lblDetail
            // 
            this.lblDetail.AutoSize = true;
            this.lblDetail.Location = new System.Drawing.Point(13, 76);
            this.lblDetail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDetail.Name = "lblDetail";
            this.lblDetail.Size = new System.Drawing.Size(47, 14);
            this.lblDetail.TabIndex = 1;
            this.lblDetail.Text = "Details";
            // 
            // dtpDOV2
            // 
            this.dtpDOV2.Location = new System.Drawing.Point(13, 266);
            this.dtpDOV2.Name = "dtpDOV2";
            this.dtpDOV2.Size = new System.Drawing.Size(239, 21);
            this.dtpDOV2.TabIndex = 15;
            // 
            // btnDF
            // 
            this.btnDF.Location = new System.Drawing.Point(42, 386);
            this.btnDF.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDF.Name = "btnDF";
            this.btnDF.Size = new System.Drawing.Size(86, 22);
            this.btnDF.TabIndex = 16;
            this.btnDF.Text = "Filter Date";
            this.btnDF.UseVisualStyleBackColor = true;
            this.btnDF.Click += new System.EventHandler(this.btnDF_Click);
            // 
            // btnRF
            // 
            this.btnRF.Location = new System.Drawing.Point(211, 386);
            this.btnRF.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnRF.Name = "btnRF";
            this.btnRF.Size = new System.Drawing.Size(86, 22);
            this.btnRF.TabIndex = 17;
            this.btnRF.Text = "Reset Filter";
            this.btnRF.UseVisualStyleBackColor = true;
            this.btnRF.Click += new System.EventHandler(this.btnRF_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, -4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(632, 77);
            this.panel1.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(121, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(209, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Contact Tracing Form";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(94, 73);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(633, 420);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnRF);
            this.Controls.Add(this.btnDF);
            this.Controls.Add(this.dtpDOV2);
            this.Controls.Add(this.lblDetail);
            this.Controls.Add(this.listView1);
            this.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.form2_closing);
            this.Shown += new System.EventHandler(this.Form2_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListView listView1;
        private ColumnHeader columnDate;
        private ColumnHeader columnFN;
        private Label lblDetail;
        private DateTimePicker dtpDOV2;
        private Button btnDF;
        private Button btnRF;
        private Panel panel1;
        private Label label2;
        private PictureBox pictureBox1;
    }
}