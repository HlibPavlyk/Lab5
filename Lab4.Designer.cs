namespace Lab4
{
    partial class Lab4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Lab4));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.обєктиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ellipseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cubeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineOOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.СlearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stepBackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stepForwardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonPoint = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonLine = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRect = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEllipse = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCube = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonLineOO = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Info;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.обєктиToolStripMenuItem,
            this.clearToolStripMenuItem,
            this.infoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(769, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(68, 24);
            this.toolStripMenuItem1.Text = "Файли";
            // 
            // обєктиToolStripMenuItem
            // 
            this.обєктиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pointToolStripMenuItem,
            this.lineToolStripMenuItem,
            this.rectToolStripMenuItem,
            this.ellipseToolStripMenuItem,
            this.cubeToolStripMenuItem,
            this.lineOOToolStripMenuItem});
            this.обєктиToolStripMenuItem.Name = "обєктиToolStripMenuItem";
            this.обєктиToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.обєктиToolStripMenuItem.Text = "Об\'єкти";
            // 
            // pointToolStripMenuItem
            // 
            this.pointToolStripMenuItem.Name = "pointToolStripMenuItem";
            this.pointToolStripMenuItem.Size = new System.Drawing.Size(227, 26);
            this.pointToolStripMenuItem.Text = "Крапка";
            this.pointToolStripMenuItem.Click += new System.EventHandler(this.pointToolStripMenuItem_Click);
            // 
            // lineToolStripMenuItem
            // 
            this.lineToolStripMenuItem.Name = "lineToolStripMenuItem";
            this.lineToolStripMenuItem.Size = new System.Drawing.Size(227, 26);
            this.lineToolStripMenuItem.Text = "Лінія";
            this.lineToolStripMenuItem.Click += new System.EventHandler(this.lineToolStripMenuItem_Click);
            // 
            // rectToolStripMenuItem
            // 
            this.rectToolStripMenuItem.Name = "rectToolStripMenuItem";
            this.rectToolStripMenuItem.Size = new System.Drawing.Size(227, 26);
            this.rectToolStripMenuItem.Text = "Прямокутник";
            this.rectToolStripMenuItem.Click += new System.EventHandler(this.rectToolStripMenuItem_Click);
            // 
            // ellipseToolStripMenuItem
            // 
            this.ellipseToolStripMenuItem.Name = "ellipseToolStripMenuItem";
            this.ellipseToolStripMenuItem.Size = new System.Drawing.Size(227, 26);
            this.ellipseToolStripMenuItem.Text = "Еліпс";
            this.ellipseToolStripMenuItem.Click += new System.EventHandler(this.ellipseToolStripMenuItem_Click);
            // 
            // cubeToolStripMenuItem
            // 
            this.cubeToolStripMenuItem.Name = "cubeToolStripMenuItem";
            this.cubeToolStripMenuItem.Size = new System.Drawing.Size(227, 26);
            this.cubeToolStripMenuItem.Text = "Каркас куба";
            this.cubeToolStripMenuItem.Click += new System.EventHandler(this.CubeToolStripMenuItem_Click);
            // 
            // lineOOToolStripMenuItem
            // 
            this.lineOOToolStripMenuItem.Name = "lineOOToolStripMenuItem";
            this.lineOOToolStripMenuItem.Size = new System.Drawing.Size(227, 26);
            this.lineOOToolStripMenuItem.Text = "Лінія з кружечками";
            this.lineOOToolStripMenuItem.Click += new System.EventHandler(this.LineOOToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.СlearToolStripMenuItem,
            this.stepBackToolStripMenuItem,
            this.stepForwardToolStripMenuItem});
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(41, 24);
            this.clearToolStripMenuItem.Text = "Дії";
            // 
            // СlearToolStripMenuItem
            // 
            this.СlearToolStripMenuItem.Name = "СlearToolStripMenuItem";
            this.СlearToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.СlearToolStripMenuItem.Text = "Очистити ";
            this.СlearToolStripMenuItem.Click += new System.EventHandler(this.СlearToolStripMenuItem_Click);
            // 
            // stepBackToolStripMenuItem
            // 
            this.stepBackToolStripMenuItem.Name = "stepBackToolStripMenuItem";
            this.stepBackToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.stepBackToolStripMenuItem.Text = "Крок  назад";
            this.stepBackToolStripMenuItem.Click += new System.EventHandler(this.stepBackToolStripMenuItem_Click);
            // 
            // stepForwardToolStripMenuItem
            // 
            this.stepForwardToolStripMenuItem.Name = "stepForwardToolStripMenuItem";
            this.stepForwardToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.stepForwardToolStripMenuItem.Text = "Крок вперед";
            this.stepForwardToolStripMenuItem.Click += new System.EventHandler(this.stepForwardToolStripMenuItem_Click);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.infoToolStripMenuItem.Text = "Довідка";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(769, 386);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonPoint,
            this.toolStripButtonLine,
            this.toolStripButtonRect,
            this.toolStripButtonEllipse,
            this.toolStripButtonCube,
            this.toolStripButtonLineOO,
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(769, 27);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonPoint
            // 
            this.toolStripButtonPoint.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripButtonPoint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPoint.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPoint.Image")));
            this.toolStripButtonPoint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPoint.Name = "toolStripButtonPoint";
            this.toolStripButtonPoint.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonPoint.Text = "toolStripButtonPoint";
            this.toolStripButtonPoint.ToolTipText = "Режим редагування крапки";
            this.toolStripButtonPoint.Click += new System.EventHandler(this.pointToolStripMenuItem_Click);
            // 
            // toolStripButtonLine
            // 
            this.toolStripButtonLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonLine.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonLine.Image")));
            this.toolStripButtonLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLine.Name = "toolStripButtonLine";
            this.toolStripButtonLine.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonLine.Text = "toolStripButtonLine";
            this.toolStripButtonLine.ToolTipText = "Режим редагування лінії";
            this.toolStripButtonLine.Click += new System.EventHandler(this.lineToolStripMenuItem_Click);
            // 
            // toolStripButtonRect
            // 
            this.toolStripButtonRect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRect.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRect.Image")));
            this.toolStripButtonRect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRect.Name = "toolStripButtonRect";
            this.toolStripButtonRect.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonRect.Text = "toolStripButton3";
            this.toolStripButtonRect.ToolTipText = "Режим редагування прямокутника";
            this.toolStripButtonRect.Click += new System.EventHandler(this.rectToolStripMenuItem_Click);
            // 
            // toolStripButtonEllipse
            // 
            this.toolStripButtonEllipse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEllipse.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonEllipse.Image")));
            this.toolStripButtonEllipse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEllipse.Name = "toolStripButtonEllipse";
            this.toolStripButtonEllipse.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonEllipse.Text = "toolStripButton4";
            this.toolStripButtonEllipse.ToolTipText = "Режим редагування еліпсу";
            this.toolStripButtonEllipse.Click += new System.EventHandler(this.ellipseToolStripMenuItem_Click);
            // 
            // toolStripButtonCube
            // 
            this.toolStripButtonCube.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCube.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCube.Image")));
            this.toolStripButtonCube.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCube.Name = "toolStripButtonCube";
            this.toolStripButtonCube.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonCube.Text = "toolStripCube";
            this.toolStripButtonCube.ToolTipText = "Режим редагування каркасу куба";
            this.toolStripButtonCube.Click += new System.EventHandler(this.CubeToolStripMenuItem_Click);
            // 
            // toolStripButtonLineOO
            // 
            this.toolStripButtonLineOO.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonLineOO.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonLineOO.Image")));
            this.toolStripButtonLineOO.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLineOO.Name = "toolStripButtonLineOO";
            this.toolStripButtonLineOO.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonLineOO.Text = "toolStripLineOO";
            this.toolStripButtonLineOO.ToolTipText = "Режим редагування лінії з кружечками";
            this.toolStripButtonLineOO.Click += new System.EventHandler(this.LineOOToolStripMenuItem_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Margin = new System.Windows.Forms.Padding(0, 1, 30, 2);
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(29, 24);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripButton1.ToolTipText = "Повернутись на крок вперед";
            this.toolStripButton1.Click += new System.EventHandler(this.stepForwardToolStripMenuItem_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(29, 24);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.ToolTipText = "Повернутись на крок назад";
            this.toolStripButton2.Click += new System.EventHandler(this.stepBackToolStripMenuItem_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(29, 24);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.ToolTipText = "Очистити";
            this.toolStripButton3.Click += new System.EventHandler(this.СlearToolStripMenuItem_Click);
            // 
            // Lab4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(769, 414);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(372, 259);
            this.Name = "Lab4";
            this.Text = "Графічний редактор";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pointToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ellipseToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem обєктиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonPoint;
        private System.Windows.Forms.ToolStripButton toolStripButtonLine;
        private System.Windows.Forms.ToolStripButton toolStripButtonRect;
        private System.Windows.Forms.ToolStripButton toolStripButtonEllipse;
        private System.Windows.Forms.ToolStripMenuItem cubeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineOOToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonCube;
        private System.Windows.Forms.ToolStripButton toolStripButtonLineOO;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripMenuItem СlearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stepBackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stepForwardToolStripMenuItem;
    }
}

