using System.Windows.Forms;

namespace UpdateTool
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        /// <summary>
        /// 解决全屏闪动//Hide()方法需要全注释掉
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label_gif = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.flowLayout1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lable_download = new System.Windows.Forms.Label();
            this.progressBar_download = new System.Windows.Forms.ProgressBar();
            this.label_uzip = new System.Windows.Forms.Label();
            this.progressBar_uzip = new System.Windows.Forms.ProgressBar();
            this.label_update = new System.Windows.Forms.Label();
            this.progressBar_update = new System.Windows.Forms.ProgressBar();
            this.Startbutton = new System.Windows.Forms.Button();
            this.button_exit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.flowLayout1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Controls.Add(this.tableLayout);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(960, 540);
            this.panel1.TabIndex = 1;
            // 
            // tableLayout
            // 
            this.tableLayout.BackgroundImage = global::UpdateTool.Properties.Resources.bg5;
            this.tableLayout.ColumnCount = 3;
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayout.Controls.Add(this.pictureBox1, 1, 1);
            this.tableLayout.Controls.Add(this.pictureBox2, 1, 3);
            this.tableLayout.Controls.Add(this.label_gif, 0, 6);
            this.tableLayout.Controls.Add(this.pictureBox3, 1, 5);
            this.tableLayout.Controls.Add(this.flowLayout1, 1, 6);
            this.tableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayout.Location = new System.Drawing.Point(0, 0);
            this.tableLayout.Name = "tableLayout";
            this.tableLayout.Padding = new System.Windows.Forms.Padding(2);
            this.tableLayout.RowCount = 7;
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.003F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.181437F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.40428F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.261253F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.260853F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.781157F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.10802F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayout.Size = new System.Drawing.Size(960, 540);
            this.tableLayout.TabIndex = 0;
            this.tableLayout.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = global::UpdateTool.Properties.Resources.logo;
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.Location = new System.Drawing.Point(193, 82);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(573, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::UpdateTool.Properties.Resources.loadinggif;
            this.pictureBox2.Location = new System.Drawing.Point(193, 234);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(573, 33);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // label_gif
            // 
            this.label_gif.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_gif.BackColor = System.Drawing.Color.Maroon;
            this.label_gif.Image = global::UpdateTool.Properties.Resources._1;
            this.label_gif.Location = new System.Drawing.Point(2, 319);
            this.label_gif.Margin = new System.Windows.Forms.Padding(0);
            this.label_gif.Name = "label_gif";
            this.label_gif.Size = new System.Drawing.Size(191, 219);
            this.label_gif.TabIndex = 9;
            this.label_gif.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_gif.Visible = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::UpdateTool.Properties.Resources.uping;
            this.pictureBox3.Location = new System.Drawing.Point(193, 289);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(573, 30);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // flowLayout1
            // 
            this.flowLayout1.Controls.Add(this.lable_download);
            this.flowLayout1.Controls.Add(this.progressBar_download);
            this.flowLayout1.Controls.Add(this.label_uzip);
            this.flowLayout1.Controls.Add(this.progressBar_uzip);
            this.flowLayout1.Controls.Add(this.label_update);
            this.flowLayout1.Controls.Add(this.progressBar_update);
            this.flowLayout1.Controls.Add(this.Startbutton);
            this.flowLayout1.Controls.Add(this.button_exit);
            this.flowLayout1.Location = new System.Drawing.Point(196, 322);
            this.flowLayout1.Name = "flowLayout1";
            this.flowLayout1.Size = new System.Drawing.Size(275, 213);
            this.flowLayout1.TabIndex = 3;
            this.flowLayout1.Visible = false;
            // 
            // lable_download
            // 
            this.lable_download.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lable_download.Location = new System.Drawing.Point(0, 0);
            this.lable_download.Margin = new System.Windows.Forms.Padding(0);
            this.lable_download.Name = "lable_download";
            this.lable_download.Size = new System.Drawing.Size(100, 23);
            this.lable_download.TabIndex = 6;
            this.lable_download.Text = "下载进度";
            this.lable_download.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progressBar_download
            // 
            this.progressBar_download.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.progressBar_download.Location = new System.Drawing.Point(0, 23);
            this.progressBar_download.Margin = new System.Windows.Forms.Padding(0);
            this.progressBar_download.Name = "progressBar_download";
            this.progressBar_download.Size = new System.Drawing.Size(240, 20);
            this.progressBar_download.TabIndex = 3;
            // 
            // label_uzip
            // 
            this.label_uzip.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_uzip.Location = new System.Drawing.Point(0, 43);
            this.label_uzip.Margin = new System.Windows.Forms.Padding(0);
            this.label_uzip.Name = "label_uzip";
            this.label_uzip.Size = new System.Drawing.Size(100, 23);
            this.label_uzip.TabIndex = 7;
            this.label_uzip.Text = "解压进度";
            this.label_uzip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progressBar_uzip
            // 
            this.progressBar_uzip.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.progressBar_uzip.Location = new System.Drawing.Point(0, 66);
            this.progressBar_uzip.Margin = new System.Windows.Forms.Padding(0);
            this.progressBar_uzip.Name = "progressBar_uzip";
            this.progressBar_uzip.Size = new System.Drawing.Size(240, 20);
            this.progressBar_uzip.TabIndex = 4;
            this.progressBar_uzip.Tag = "";
            // 
            // label_update
            // 
            this.label_update.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_update.Location = new System.Drawing.Point(0, 86);
            this.label_update.Margin = new System.Windows.Forms.Padding(0);
            this.label_update.Name = "label_update";
            this.label_update.Size = new System.Drawing.Size(100, 23);
            this.label_update.TabIndex = 8;
            this.label_update.Text = "更新进度";
            this.label_update.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progressBar_update
            // 
            this.progressBar_update.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.progressBar_update.Location = new System.Drawing.Point(0, 109);
            this.progressBar_update.Margin = new System.Windows.Forms.Padding(0);
            this.progressBar_update.Name = "progressBar_update";
            this.progressBar_update.Size = new System.Drawing.Size(240, 20);
            this.progressBar_update.TabIndex = 5;
            // 
            // Startbutton
            // 
            this.Startbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Startbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Startbutton.Location = new System.Drawing.Point(3, 132);
            this.Startbutton.Name = "Startbutton";
            this.Startbutton.Size = new System.Drawing.Size(50, 30);
            this.Startbutton.TabIndex = 0;
            this.Startbutton.Text = "Start";
            this.Startbutton.UseVisualStyleBackColor = false;
            this.Startbutton.Visible = false;
            this.Startbutton.Click += new System.EventHandler(this.Startbutton_Click);
            // 
            // button_exit
            // 
            this.button_exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_exit.Location = new System.Drawing.Point(59, 132);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(50, 30);
            this.button_exit.TabIndex = 10;
            this.button_exit.Text = "Exit";
            this.button_exit.UseVisualStyleBackColor = true;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 540);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "UpdateTool1";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.flowLayout1.ResumeLayout(false);
            this.ResumeLayout(false);

        }



        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Startbutton;
        private ProgressBar progressBar_download;
        private Label label_uzip;
        private Label label_update;
        private ProgressBar progressBar_update;
        private ProgressBar progressBar_uzip;
        private Label label_gif;
        private Button button_exit;
        private TableLayoutPanel tableLayout;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Label lable_download;
        private FlowLayoutPanel flowLayout1;
    }
}

