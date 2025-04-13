using System.Runtime.InteropServices;

namespace LabKG
{
    public partial class Form1 : Form
    {
        Bitmap image;

        public Form1()
        {
            InitializeComponent();
        }

        // Структура для работы с размерами окна
        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left, Top, Right, Bottom;
        }

        private void aFToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void spotFiltersToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.png; *.jpg; *.bmp | All files (*.*)| *.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(ofd.FileName);
            }

            pictureBox1.Image = image;

            if (pictureBox1.Image != null)
            {
                int width = pictureBox1.Image.Width % 1920;
                int height = pictureBox1.Image.Height % 1080;
                this.MinimumSize = new Size(1000, 1000);
                this.Size = new Size(width, height);
            }

            pictureBox1.Refresh();
        }

        private void inversionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new InvertFilter();
            backgroundWorker1.RunWorkerAsync(filter);

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Bitmap newImage = ((Filters)e.Argument).processImage(image, backgroundWorker1);
            if (backgroundWorker1.CancellationPending != true)
            {
                image = newImage;
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
            progressBar1.Value = 0;
        }

        private void blurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new BlurFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void gaussianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GaussianFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void grayScaleFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GrayScaleFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new SepiaFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void brightnessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new BrightnessFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void sobelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new SobelFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void shiftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new ShiftFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void embossToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new EmbossFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void motionBlurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new MotionBlurFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void grayWorldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GrayWorldFilter(image);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void autoLevelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new AutoLevels(image);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void perfectReflectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new PerfectReflector(image);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void expansionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Expansion();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void compressionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Compression();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void medianFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new MedianFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void sharraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new SharraFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }
    }
}
