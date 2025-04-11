using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;
using LabKG;
using System.Net.NetworkInformation;

namespace LabKG
{
    abstract class Filters
    {
        protected abstract Color calculateNewPixelColor(Bitmap sourceimage, int x, int y);
        public Bitmap processImage(Bitmap sourceimage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourceimage.Width, sourceimage.Height);
            for (int i = 0; i < sourceimage.Width; i++)
            {
                worker.ReportProgress((int)((float)i / resultImage.Width * 100));
                if (worker.CancellationPending) return null;
                for (int j = 0; j < sourceimage.Height; j++)
                {
                    resultImage.SetPixel(i, j, calculateNewPixelColor(sourceimage, i, j));
                }
            }
            return resultImage;
        }

        public int Clamp(int value, int min, int max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }
    }

    class MatrixFilter : Filters
    {
        protected float[,] kernel = null;
        protected MatrixFilter() { }
        public MatrixFilter(float[,] kernel)
        {
            this.kernel = kernel;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceimage, int x, int y)
        {
            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;

            float resultR = 0;
            float resultG = 0;
            float resultB = 0;
            for (int l = -radiusX; l <= radiusY; l++)
            {
                for (int k = -radiusX; k <= radiusY; k++)
                {
                    int idX = Clamp(x + k, 0, sourceimage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceimage.Height - 1);
                    Color neighborColor = sourceimage.GetPixel(idX, idY);
                    resultR += neighborColor.R * kernel[k + radiusX, l + radiusY];
                    resultG += neighborColor.G * kernel[k + radiusX, l + radiusY];
                    resultB += neighborColor.B * kernel[k + radiusX, l + radiusY];
                }
            }
            return Color.FromArgb(
                Clamp((int)resultR, 0, 255),
                Clamp((int)resultG, 0, 255),
                Clamp((int)resultB, 0, 255));
        }
    }

    class InvertFilter : Filters
    {

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourseColor = sourceImage.GetPixel(x, y);
            Color resultColor = Color.FromArgb(255 - sourseColor.R, 255 - sourseColor.G, 255 - sourseColor.B);
            return resultColor;
        }
    }

    class BlurFilter : MatrixFilter
    {
        public BlurFilter()
        {
            int sizeX = 3;
            int sizeY = 3;
            kernel = new float[sizeX, sizeY];
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    kernel[i, j] = 1.0f / (float)(sizeX * sizeY);
                }
            }
        }
    }

    class GaussianFilter : MatrixFilter
    {

        public GaussianFilter()
        {
            createGaussianKernel(3, 2);
        }

        public void createGaussianKernel(int radius, float sigma)
        {
            int size = 2 * radius + 1;

            kernel = new float[size, size];

            float norm = 0;

            for (int i = -radius; i <= radius; i++)
            {
                for (int j = -radius; j <= radius; j++)
                {
                    kernel[i + radius, j + radius] = (float)(Math.Exp(-(i * i + j * j) / (2 * sigma * sigma)));
                    norm += kernel[i + radius, j + radius];
                }
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    kernel[i, j] /= norm;
                }
            }
        }
    }

    class GrayScaleFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceimage, int x, int y)
        {
            Color sourseColor = sourceimage.GetPixel(x, y);
            int Intensity = (int)(0.299 * sourseColor.R + 0.587 * sourseColor.G + 0.114 * sourseColor.B);
            Color resultColor = Color.FromArgb(Intensity, Intensity, Intensity);
            return resultColor;
        }
    }

    class SepiaFilter : Filters
    {
        private int k = 15;
        protected override Color calculateNewPixelColor(Bitmap sourceimage, int x, int y)
        {
            Color sourceColor = sourceimage.GetPixel(x, y);
            int Intensity = (int)(0.299 * sourceColor.R + 0.587 * sourceColor.G + 0.114 * sourceColor.B);

            int R = Clamp(Intensity + 2 * k, 0, 255);
            int G = Clamp(Intensity + (int)(0.5 * k), 0, 255);
            int B = Clamp(Intensity - k, 0, 255);

            return Color.FromArgb(R, G, B);
        }
    }

    class BrightnessFilter : Filters
    {
        private int brightness = 30;
        protected override Color calculateNewPixelColor(Bitmap sourceimage, int x, int y)
        {
            Color sourceColor = sourceimage.GetPixel(x, y);

            int R = Clamp(sourceColor.R + brightness, 0, 255);
            int G = Clamp(sourceColor.G + brightness, 0, 255);
            int B = Clamp(sourceColor.B + brightness, 0, 255);

            return Color.FromArgb(R, G, B);
        }
    }

    class SobelFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceimage, int x, int y)
        {
            // Оператор Собеля по X
            float[,] kernelX = {
            { -1,  0,  1 },
            { -2,  0,  2 },
            { -1,  0,  1 }
        };

            // Оператор Собеля по Y
            float[,] kernelY = {
            { -1, -2, -1 },
            {  0,  0,  0 },
            {  1,  2,  1 }
        };

            int radius = 1; // Поскольку размер ядра 3x3
            float gradX_R = 0, gradX_G = 0, gradX_B = 0;
            float gradY_R = 0, gradY_G = 0, gradY_B = 0;

            // Проходим по ядру 3x3
            for (int i = -radius; i <= radius; i++)
            {
                for (int j = -radius; j <= radius; j++)
                {
                    int idX = Clamp(x + i, 0, sourceimage.Width - 1);
                    int idY = Clamp(y + j, 0, sourceimage.Height - 1);
                    Color neighborColor = sourceimage.GetPixel(idX, idY);

                    gradX_R += neighborColor.R * kernelX[i + radius, j + radius];
                    gradX_G += neighborColor.G * kernelX[i + radius, j + radius];
                    gradX_B += neighborColor.B * kernelX[i + radius, j + radius];

                    gradY_R += neighborColor.R * kernelY[i + radius, j + radius];
                    gradY_G += neighborColor.G * kernelY[i + radius, j + radius];
                    gradY_B += neighborColor.B * kernelY[i + radius, j + radius];
                }
            }

            // Вычисляем общий градиент по формуле
            int R = Clamp((int)Math.Sqrt(gradX_R * gradX_R + gradY_R * gradY_R), 0, 255);
            int G = Clamp((int)Math.Sqrt(gradX_G * gradX_G + gradY_G * gradY_G), 0, 255);
            int B = Clamp((int)Math.Sqrt(gradX_B * gradX_B + gradY_B * gradY_B), 0, 255);

            return Color.FromArgb(R, G, B);
        }
    }

    class SharpenFilter : MatrixFilter
    {
        public SharpenFilter()
        {
            kernel = new float[,]
            {
            {  0, -1,  0 },
            { -1,  5, -1 },
            {  0, -1,  0 }
            };
        }
    }

    class ShiftFilter : Filters
    {
        private int shiftX = 50;
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int newX = x - shiftX;

            if (newX < 0 || newX >= sourceImage.Width) return Color.Black;

            return sourceImage.GetPixel(newX, y);
        }
    }

    class EmbossFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int[,] kernel = {
            {  0, +1,  0 },
            { -1,  0, +1 },
            {  0, -1,  0 }
            };

            int radius = 1;
            int intensity = 0;

            for (int i = -radius; i <= radius; i++)
            {
                for (int j = -radius; j <= radius; j++)
                {
                    int idX = Clamp(x + i, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + j, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);

                    int gray = (int)(0.299 * neighborColor.R + 0.587 * neighborColor.G + 0.114 * neighborColor.B);

                    intensity += gray * kernel[i + radius, j + radius];
                }
            }

            intensity = Clamp(intensity + 100, 0, 255);

            return Color.FromArgb(intensity, intensity, intensity);
        }
    }

    class MotionBlurFilter : Filters
    {
        private double[,] kernel = { { (1.0/9.0), 0, 0, 0, 0, 0, 0, 0, 0 },
                                     { 0, (1.0/9.0), 0, 0, 0, 0, 0, 0, 0 },
                                     { 0, 0, (1.0/9.0), 0, 0, 0, 0, 0, 0 },
                                     { 0, 0, 0, (1.0/9.0), 0, 0, 0, 0, 0 },
                                     { 0, 0, 0, 0, (1.0/9.0), 0, 0, 0, 0 },
                                     { 0, 0, 0, 0, 0, (1.0/9.0), 0, 0, 0 },
                                     { 0, 0, 0, 0, 0, 0, (1.0/9.0), 0, 0 },
                                     { 0, 0, 0, 0, 0, 0, 0, (1.0/9.0), 0 },
                                     { 0, 0, 0, 0, 0, 0, 0, 0, (1.0/9.0) },};

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int width = sourceImage.Width;
            int height = sourceImage.Height;

            double sumR = 0.0;
            double sumG = 0.0;
            double sumB = 0.0;

            for (int ky = 0; ky < 9; ky++)
            {
                for (int kx = 0; kx < 9; kx++)
                {
                    int px = x + kx - 4;
                    int py = y + ky - 4;

                    px = Clamp(px, 0, width - 1);
                    py = Clamp(py, 0, height - 1);

                    Color pix = sourceImage.GetPixel(px, py);
                    sumR += pix.R * kernel[ky, kx];
                    sumG += pix.G * kernel[ky, kx];
                    sumB += pix.B * kernel[ky, kx];

                }
            }

            // Ограничиваем значения и возвращаем цвет
            int valR = Clamp((int)sumR, 0, 255);
            int valG = Clamp((int)sumG, 0, 255);
            int valB = Clamp((int)sumB, 0, 255);

            return Color.FromArgb(valR, valG, valB);
        }
    }

    class GrayWorldFilter : Filters
    {

        public double avgR = 0;
        public double avgG = 0;
        public double avgB = 0;
        public double avgGray = 0;
        public GrayWorldFilter(Bitmap sourse)
        {
            int totalPixels = sourse.Width * sourse.Height; //N
            int sumR = 0, sumG = 0, sumB = 0;
            for (int x = 0; x < sourse.Width; x++)
            {
                for (int y = 0; y < sourse.Height; y++)
                {
                    Color pixel = sourse.GetPixel(x, y);
                    sumR += pixel.R;
                    sumG += pixel.G;
                    sumB += pixel.B;
                }
            }

            avgR = (sumR / totalPixels);
            avgG = (sumG / totalPixels);
            avgB = (sumB / totalPixels);

            avgGray = (avgR + avgG + avgB) / 3;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color pixel = sourceImage.GetPixel(x, y);
            int resultR = Clamp((int)((avgGray * pixel.R) / avgR), 0, 255);
            int resultG = Clamp((int)((avgGray * pixel.G) / avgG), 0, 255);
            int resultB = Clamp((int)((avgGray * pixel.B) / avgB), 0, 255);

            return Color.FromArgb(resultR, resultG, resultB);
        }
    }

    class AutoLevels : Filters
    {

        public int rMin = 255, rMax = 0;
        public int gMin = 255, gMax = 0;
        public int bMin = 255, bMax = 0;

        public AutoLevels(Bitmap source)
        {
            for (int x = 0; x < source.Width; x++)
            {
                for (int y = 0; y < source.Height; y++)
                {
                    Color c = source.GetPixel(x, y);
                    if (c.R < rMin) rMin = c.R;
                    if (c.R > rMax) rMax = c.R;
                    if (c.G < gMin) gMin = c.G;
                    if (c.G > gMax) gMax = c.G;
                    if (c.B < bMin) bMin = c.B;
                    if (c.B > bMax) bMax = c.B;
                }
            }
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color c = sourceImage.GetPixel(x, y);
            int red = Clamp((c.R - rMin) * 255 / Math.Max(1, rMax - rMin), 0, 255);
            int green = Clamp((c.G - gMin) * 255 / Math.Max(1, gMax - gMin), 0, 255);
            int blue = Clamp((c.B - bMin) * 255 / Math.Max(1, bMax - bMin), 0, 255);

            return Color.FromArgb(red, green, blue);
        }

    }

    class PerfectReflector : Filters
    {
        public int Rmax = 0, Gmax = 0, Bmax = 0;
        public PerfectReflector(Bitmap source) 
        {
            for (int y = 0; y < source.Height; y++)
            {
                for (int x = 0; x < source.Width; x++)
                {
                    Color pixel = source.GetPixel(x, y);
                    if (pixel.R > Rmax) Rmax = pixel.R;
                    if (pixel.G > Gmax) Gmax = pixel.G;
                    if (pixel.B > Bmax) Bmax = pixel.B;
                }
            }
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color pixel = sourceImage.GetPixel(x, y);

            int newR = Clamp(pixel.R * 255 / Rmax, 0, 255);
            int newG = Clamp(pixel.G * 255 / Gmax, 0, 255);
            int newB = Clamp(pixel.B * 255 / Bmax, 0, 255);

            return Color.FromArgb(newR, newG, newB);
        }
    }

    class Expansion : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int[,] mask = {
                { 0, 1, 0 },
                { 1, 1, 1 },
                { 0, 1, 0 }
            };

            int maxR = 0, maxG = 0, maxB = 0;

            int radius = 1;

            for (int j = -radius; j <= radius; j++)
            {
                for (int i = -radius; i <= radius; i++)
                {
                    int maskValue = mask[j + radius, i + radius];
                    if (maskValue == 0) continue;

                    int nx = Clamp(x + i, 0, sourceImage.Width - 1);
                    int ny = Clamp(y + j, 0, sourceImage.Height - 1);
                    Color neighbor = sourceImage.GetPixel(nx, ny);

                    maxR = Math.Max(maxR, neighbor.R);
                    maxG = Math.Max(maxG, neighbor.G);
                    maxB = Math.Max(maxB, neighbor.B);
                }
            }
            return Color.FromArgb(maxR, maxG, maxB);
        }
    }

    class Compression : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int[,] mask = {
                { 0, 1, 0 },
                { 1, 1, 1 },
                { 0, 1, 0 }
            };

            int minR = 255, minG = 255, minB = 255;

            int radius = 1;

            for (int j = -radius; j <= radius; j++)
            {
                for (int i = -radius; i <= radius; i++)
                {
                    int maskValue = mask[j + radius, i + radius];
                    if (maskValue == 0) continue;

                    int nx = Clamp(x + i, 0, sourceImage.Width - 1);
                    int ny = Clamp(y + j, 0, sourceImage.Height - 1);
                    Color neighbor = sourceImage.GetPixel(nx, ny);

                    minR = Math.Min(minR, neighbor.R);
                    minG = Math.Min(minG, neighbor.G);
                    minB = Math.Min(minB, neighbor.B);
                }
            }
            return Color.FromArgb(minG, minG, minB);
        }
    }

    class MedianFilter : Filters
    {
        private int radius = 1;

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            List<byte> rList = new List<byte>();
            List<byte> gList = new List<byte>();
            List<byte> bList = new List<byte>();

            for (int dy = -radius; dy <= radius; dy++)
            {
                for (int dx = -radius; dx <= radius; dx++)
                {
                    int nx = Clamp(x + dx, 0, sourceImage.Width - 1);
                    int ny = Clamp(y + dy, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(nx, ny);

                    rList.Add(neighborColor.R);
                    gList.Add(neighborColor.G);
                    bList.Add(neighborColor.B);
                }
            }

            rList.Sort();
            gList.Sort();
            bList.Sort();

            int medianIndex = rList.Count / 2;

            Color medianColor = Color.FromArgb(
                rList[medianIndex],
                gList[medianIndex],
                bList[medianIndex]
            );

            return medianColor;
        }
    }
}
namespace Filter
{
    public class Filter
    {

        public static Bitmap Execute(Bitmap source)
        {

            Bitmap result = new Bitmap(source.Width, source.Height);

            float[,] kernelX = {
            { -1,  0,  1 },
            { -2,  0,  2 },
            { -1,  0,  1 }
            };

            float[,] kernelY = {
            { -1, -2, -1 },
            {  0,  0,  0 },
            {  1,  2,  1 }
            };

            int radius = 1;
            float gradX_R = 0, gradX_G = 0, gradX_B = 0;
            float gradY_R = 0, gradY_G = 0, gradY_B = 0;

            for (int y = 0; y < source.Height; y++)
            {
                for (int x = 0; x < source.Width; x++)
                {

                    for (int i = -radius; i <= radius; i++)
                    {
                        for (int j = -radius; j <= radius; j++)
                        {
                            int idX = Clamp(x + i, 0, source.Width - 1);
                            int idY = Clamp(y + j, 0, source.Height - 1);
                            Color neighborColor = source.GetPixel(idX, idY);

                            gradX_R += neighborColor.R * kernelX[i + radius, j + radius];
                            gradX_G += neighborColor.G * kernelX[i + radius, j + radius];
                            gradX_B += neighborColor.B * kernelX[i + radius, j + radius];

                            gradY_R += neighborColor.R * kernelY[i + radius, j + radius];
                            gradY_G += neighborColor.G * kernelY[i + radius, j + radius];
                            gradY_B += neighborColor.B * kernelY[i + radius, j + radius];
                        }
                    }

                    int R = Clamp((int)Math.Sqrt(gradX_R * gradX_R + gradY_R * gradY_R), 0, 255);
                    int G = Clamp((int)Math.Sqrt(gradX_G * gradX_G + gradY_G * gradY_G), 0, 255);
                    int B = Clamp((int)Math.Sqrt(gradX_B * gradX_B + gradY_B * gradY_B), 0, 255);
                    result.SetPixel(x, y, Color.FromArgb(R, G, B));
                }
            }

            return result;
        }

        public static int Clamp(int value, int min, int max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }
    }
}


namespace Filter2
{
    public class Filter
    {
        public static Bitmap Execute(Bitmap source)
        {
            int width = source.Width;
            int height = source.Height;

            Bitmap result = new Bitmap(width, height);

            // Структурный элемент
            int[,] kernel = {
                { 0, 1, 0 },
                { 1, 1, 1 },
                { 0, 1, 0 }
            };

            int radius = 1;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int minR = 255, minG = 255, minB = 255;

                    for (int j = -radius; j <= radius; j++)
                    {
                        for (int i = -radius; i <= radius; i++)
                        {
                            int kernelValue = kernel[j + radius, i + radius];
                            if (kernelValue == 0) continue;

                            int nx = Clamp(x + i, 0, width - 1);
                            int ny = Clamp(y + j, 0, height - 1);
                            Color neighbor = source.GetPixel(nx, ny);

                            minR = Math.Min(minR, neighbor.R);
                            minG = Math.Min(minG, neighbor.G);
                            minB = Math.Min(minB, neighbor.B);
                        }
                    }

                    result.SetPixel(x, y, Color.FromArgb(minR, minG, minB));
                }
            }

            return result;
        }

        public static int Clamp(int value, int min, int max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }
    }
}



namespace Filter
{
    public class Filter3
    {
        public static Bitmap Execute(Bitmap source)
        {
            Bitmap result = new Bitmap(source.Width, source.Height);

            float[,] kernelX = {
                { -1,  0,  1 },
                { -2,  0,  2 },
                { -1,  0,  1 }
            };

            float[,] kernelY = {
                { -1, -2, -1 },
                {  0,  0,  0 },
                {  1,  2,  1 }
            };

            int radius = 1;

            for (int y = 0; y < source.Height; y++)
            {
                for (int x = 0; x < source.Width; x++)
                {
                    double gradX = 0;
                    double gradY = 0;

                    for (int i = -radius; i <= radius; i++)
                    {
                        for (int j = -radius; j <= radius; j++)
                        {
                            int idX = Clamp(x + i, 0, source.Width - 1);
                            int idY = Clamp(y + j, 0, source.Height - 1);
                            Color color = source.GetPixel(idX, idY);

                            double intensity = 0.299f * color.R + 0.587f * color.G + 0.114f * color.B;

                            gradX += intensity * kernelX[i + radius, j + radius];
                            gradY += intensity * kernelY[i + radius, j + radius];
                        }
                    }

                    int gradient = Clamp((int)Math.Sqrt(gradX * gradX + gradY * gradY), 0, 255);

                    result.SetPixel(x, y, Color.FromArgb(gradient, gradient, gradient));
                }
            }

            return result;
        }

        public static int Clamp(int value, int min, int max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }
    }
}
