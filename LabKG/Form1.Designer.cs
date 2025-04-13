namespace LabKG
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            menuStrip1 = new MenuStrip();
            aFToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            filtersToolStripMenuItem = new ToolStripMenuItem();
            spotFiltersToolStripMenuItem = new ToolStripMenuItem();
            inversionToolStripMenuItem = new ToolStripMenuItem();
            grayScaleFilterToolStripMenuItem = new ToolStripMenuItem();
            sepiaToolStripMenuItem = new ToolStripMenuItem();
            brightnessToolStripMenuItem = new ToolStripMenuItem();
            shiftToolStripMenuItem = new ToolStripMenuItem();
            grayWorldToolStripMenuItem = new ToolStripMenuItem();
            autoLevelsToolStripMenuItem = new ToolStripMenuItem();
            perfectReflectorToolStripMenuItem = new ToolStripMenuItem();
            matrixFiltersToolStripMenuItem = new ToolStripMenuItem();
            blurToolStripMenuItem = new ToolStripMenuItem();
            gaussianToolStripMenuItem = new ToolStripMenuItem();
            sobelToolStripMenuItem = new ToolStripMenuItem();
            sharpenToolStripMenuItem = new ToolStripMenuItem();
            embossToolStripMenuItem = new ToolStripMenuItem();
            motionBlurToolStripMenuItem = new ToolStripMenuItem();
            expansionToolStripMenuItem = new ToolStripMenuItem();
            compressionToolStripMenuItem = new ToolStripMenuItem();
            medianFilterToolStripMenuItem = new ToolStripMenuItem();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            progressBar1 = new ProgressBar();
            Button1 = new Button();
            sharraToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            pictureBox1.BackColor = Color.Black;
            pictureBox1.Location = new Point(0, 27);
            pictureBox1.MinimumSize = new Size(400, 300);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1546, 812);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { aFToolStripMenuItem, filtersToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1546, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // aFToolStripMenuItem
            // 
            aFToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem });
            aFToolStripMenuItem.Name = "aFToolStripMenuItem";
            aFToolStripMenuItem.Size = new Size(37, 20);
            aFToolStripMenuItem.Text = "File";
            aFToolStripMenuItem.Click += aFToolStripMenuItem_Click;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(103, 22);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // filtersToolStripMenuItem
            // 
            filtersToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { spotFiltersToolStripMenuItem, matrixFiltersToolStripMenuItem });
            filtersToolStripMenuItem.Name = "filtersToolStripMenuItem";
            filtersToolStripMenuItem.Size = new Size(50, 20);
            filtersToolStripMenuItem.Text = "Filters";
            // 
            // spotFiltersToolStripMenuItem
            // 
            spotFiltersToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { inversionToolStripMenuItem, grayScaleFilterToolStripMenuItem, sepiaToolStripMenuItem, brightnessToolStripMenuItem, shiftToolStripMenuItem, grayWorldToolStripMenuItem, autoLevelsToolStripMenuItem, perfectReflectorToolStripMenuItem });
            spotFiltersToolStripMenuItem.Name = "spotFiltersToolStripMenuItem";
            spotFiltersToolStripMenuItem.Size = new Size(180, 22);
            spotFiltersToolStripMenuItem.Text = "Spot filters";
            spotFiltersToolStripMenuItem.Click += spotFiltersToolStripMenuItem_Click;
            // 
            // inversionToolStripMenuItem
            // 
            inversionToolStripMenuItem.Name = "inversionToolStripMenuItem";
            inversionToolStripMenuItem.Size = new Size(158, 22);
            inversionToolStripMenuItem.Text = "Inversion";
            inversionToolStripMenuItem.Click += inversionToolStripMenuItem_Click;
            // 
            // grayScaleFilterToolStripMenuItem
            // 
            grayScaleFilterToolStripMenuItem.Name = "grayScaleFilterToolStripMenuItem";
            grayScaleFilterToolStripMenuItem.Size = new Size(158, 22);
            grayScaleFilterToolStripMenuItem.Text = "GrayScaleFilter";
            grayScaleFilterToolStripMenuItem.Click += grayScaleFilterToolStripMenuItem_Click;
            // 
            // sepiaToolStripMenuItem
            // 
            sepiaToolStripMenuItem.Name = "sepiaToolStripMenuItem";
            sepiaToolStripMenuItem.Size = new Size(158, 22);
            sepiaToolStripMenuItem.Text = "Sepia";
            sepiaToolStripMenuItem.Click += sepiaToolStripMenuItem_Click;
            // 
            // brightnessToolStripMenuItem
            // 
            brightnessToolStripMenuItem.Name = "brightnessToolStripMenuItem";
            brightnessToolStripMenuItem.Size = new Size(158, 22);
            brightnessToolStripMenuItem.Text = "Brightness";
            brightnessToolStripMenuItem.Click += brightnessToolStripMenuItem_Click;
            // 
            // shiftToolStripMenuItem
            // 
            shiftToolStripMenuItem.Name = "shiftToolStripMenuItem";
            shiftToolStripMenuItem.Size = new Size(158, 22);
            shiftToolStripMenuItem.Text = "Shift";
            shiftToolStripMenuItem.Click += shiftToolStripMenuItem_Click;
            // 
            // grayWorldToolStripMenuItem
            // 
            grayWorldToolStripMenuItem.Name = "grayWorldToolStripMenuItem";
            grayWorldToolStripMenuItem.Size = new Size(158, 22);
            grayWorldToolStripMenuItem.Text = "GrayWorld";
            grayWorldToolStripMenuItem.Click += grayWorldToolStripMenuItem_Click;
            // 
            // autoLevelsToolStripMenuItem
            // 
            autoLevelsToolStripMenuItem.Name = "autoLevelsToolStripMenuItem";
            autoLevelsToolStripMenuItem.Size = new Size(158, 22);
            autoLevelsToolStripMenuItem.Text = "AutoLevels";
            autoLevelsToolStripMenuItem.Click += autoLevelsToolStripMenuItem_Click;
            // 
            // perfectReflectorToolStripMenuItem
            // 
            perfectReflectorToolStripMenuItem.Name = "perfectReflectorToolStripMenuItem";
            perfectReflectorToolStripMenuItem.Size = new Size(158, 22);
            perfectReflectorToolStripMenuItem.Text = "PerfectReflector";
            perfectReflectorToolStripMenuItem.Click += perfectReflectorToolStripMenuItem_Click;
            // 
            // matrixFiltersToolStripMenuItem
            // 
            matrixFiltersToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { blurToolStripMenuItem, gaussianToolStripMenuItem, sobelToolStripMenuItem, sharpenToolStripMenuItem, embossToolStripMenuItem, motionBlurToolStripMenuItem, expansionToolStripMenuItem, compressionToolStripMenuItem, medianFilterToolStripMenuItem, sharraToolStripMenuItem });
            matrixFiltersToolStripMenuItem.Name = "matrixFiltersToolStripMenuItem";
            matrixFiltersToolStripMenuItem.Size = new Size(180, 22);
            matrixFiltersToolStripMenuItem.Text = "Matrix filters";
            // 
            // blurToolStripMenuItem
            // 
            blurToolStripMenuItem.Name = "blurToolStripMenuItem";
            blurToolStripMenuItem.Size = new Size(180, 22);
            blurToolStripMenuItem.Text = "Blur";
            blurToolStripMenuItem.Click += blurToolStripMenuItem_Click;
            // 
            // gaussianToolStripMenuItem
            // 
            gaussianToolStripMenuItem.Name = "gaussianToolStripMenuItem";
            gaussianToolStripMenuItem.Size = new Size(180, 22);
            gaussianToolStripMenuItem.Text = "Gaussian";
            gaussianToolStripMenuItem.Click += gaussianToolStripMenuItem_Click;
            // 
            // sobelToolStripMenuItem
            // 
            sobelToolStripMenuItem.Name = "sobelToolStripMenuItem";
            sobelToolStripMenuItem.Size = new Size(180, 22);
            sobelToolStripMenuItem.Text = "Sobel";
            sobelToolStripMenuItem.Click += sobelToolStripMenuItem_Click;
            // 
            // embossToolStripMenuItem
            // 
            embossToolStripMenuItem.Name = "embossToolStripMenuItem";
            embossToolStripMenuItem.Size = new Size(180, 22);
            embossToolStripMenuItem.Text = "Emboss";
            embossToolStripMenuItem.Click += embossToolStripMenuItem_Click;
            // 
            // motionBlurToolStripMenuItem
            // 
            motionBlurToolStripMenuItem.Name = "motionBlurToolStripMenuItem";
            motionBlurToolStripMenuItem.Size = new Size(180, 22);
            motionBlurToolStripMenuItem.Text = "MotionBlur";
            motionBlurToolStripMenuItem.Click += motionBlurToolStripMenuItem_Click;
            // 
            // expansionToolStripMenuItem
            // 
            expansionToolStripMenuItem.Name = "expansionToolStripMenuItem";
            expansionToolStripMenuItem.Size = new Size(180, 22);
            expansionToolStripMenuItem.Text = "Expansion";
            expansionToolStripMenuItem.Click += expansionToolStripMenuItem_Click;
            // 
            // compressionToolStripMenuItem
            // 
            compressionToolStripMenuItem.Name = "compressionToolStripMenuItem";
            compressionToolStripMenuItem.Size = new Size(180, 22);
            compressionToolStripMenuItem.Text = "Compression";
            compressionToolStripMenuItem.Click += compressionToolStripMenuItem_Click;
            // 
            // medianFilterToolStripMenuItem
            // 
            medianFilterToolStripMenuItem.Name = "medianFilterToolStripMenuItem";
            medianFilterToolStripMenuItem.Size = new Size(180, 22);
            medianFilterToolStripMenuItem.Text = "MedianFilter";
            medianFilterToolStripMenuItem.Click += medianFilterToolStripMenuItem_Click;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            // 
            // progressBar1
            // 
            progressBar1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            progressBar1.Location = new Point(12, 854);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(1348, 23);
            progressBar1.TabIndex = 2;
            // 
            // Button1
            // 
            Button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Button1.Location = new Point(1390, 854);
            Button1.MaximumSize = new Size(144, 23);
            Button1.MinimumSize = new Size(144, 23);
            Button1.Name = "Button1";
            Button1.Size = new Size(144, 23);
            Button1.TabIndex = 3;
            Button1.Text = "Отмена";
            Button1.UseVisualStyleBackColor = true;
            Button1.Click += button1_Click;
            // 
            // sharraToolStripMenuItem
            // 
            sharraToolStripMenuItem.Name = "sharraToolStripMenuItem";
            sharraToolStripMenuItem.Size = new Size(180, 22);
            sharraToolStripMenuItem.Text = "Sharra";
            sharraToolStripMenuItem.Click += sharraToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(1546, 881);
            Controls.Add(Button1);
            Controls.Add(progressBar1);
            Controls.Add(pictureBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(400, 298);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem aFToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem filtersToolStripMenuItem;
        private ToolStripMenuItem spotFiltersToolStripMenuItem;
        private ToolStripMenuItem matrixFiltersToolStripMenuItem;
        private ToolStripMenuItem inversionToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ProgressBar progressBar1;
        private Button Button1;
        private ToolStripMenuItem blurToolStripMenuItem;
        private ToolStripMenuItem gaussianToolStripMenuItem;
        private ToolStripMenuItem grayScaleFilterToolStripMenuItem;
        private ToolStripMenuItem sepiaToolStripMenuItem;
        private ToolStripMenuItem brightnessToolStripMenuItem;
        private ToolStripMenuItem sobelToolStripMenuItem;
        private ToolStripMenuItem sharpenToolStripMenuItem;
        private ToolStripMenuItem shiftToolStripMenuItem;
        private ToolStripMenuItem embossToolStripMenuItem;
        private ToolStripMenuItem motionBlurToolStripMenuItem;
        private ToolStripMenuItem grayWorldToolStripMenuItem;
        private ToolStripMenuItem autoLevelsToolStripMenuItem;
        private ToolStripMenuItem perfectReflectorToolStripMenuItem;
        private ToolStripMenuItem expansionToolStripMenuItem;
        private ToolStripMenuItem compressionToolStripMenuItem;
        private ToolStripMenuItem medianFilterToolStripMenuItem;
        private ToolStripMenuItem sharraToolStripMenuItem;
    }
}
