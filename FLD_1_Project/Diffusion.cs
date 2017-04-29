using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoadMNIST;

namespace FLD_1_Project
{
    class Diffusion
    {
        public static double[][] apply_Diffusion(DataPoint[] givenImage,int option, double kappa)
        {
            for (int i = 0; i < givenImage.Length; i++)
            {
                double[][] transformingImage = null;

                // Applying diffusion algorithm
                //---------------------------------


                // PDE(partial differential equation) initial condition.
                //diff_im = im;

                transformingImage = givenImage[i].Data_2D;

                //Center pixel distances.

                double dx = 1;
                double dy = 1;
                double dd = Math.Sqrt(2);

                // 2D convolution masks - finite differences.
                //hN = [0 1 0; 0 -1 0; 0 0 0];

                double[][] hN = null;

                hN[0] = new double[] { 0, 1, 0 };
                hN[1] = new double[] { 0, -1, 0 };
                hN[2] = new double[] { 0, 0, 0 };

                //hS = [0 0 0; 0 -1 0; 0 1 0];

                double[][] hS = null;

                hS[0] = new double[] { 0, 0, 0 };
                hS[1] = new double[] { 0, -1, 0 };
                hS[2] = new double[] { 0, 1, 0 };

                //hE = [0 0 0; 0 -1 1; 0 0 0];

                double[][] hE = null;

                hE[0] = new double[] { 0, 0, 0 };
                hE[1] = new double[] { 0, -1, 1 };
                hE[2] = new double[] { 0, 0, 0 };

                //hW = [0 0 0; 1 -1 0; 0 0 0];

                double[][] hW = null;

                hW[0] = new double[] { 0, 0, 0 };
                hW[1] = new double[] { 0, -1, 0 };
                hW[2] = new double[] { 0, 0, 0 };

                //hNE = [0 0 1; 0 -1 0; 0 0 0];

                double[][] hNE = null;

                hNE[0] = new double[] { 0, 0, 1 };
                hNE[1] = new double[] { 0, -1, 0 };
                hNE[2] = new double[] { 0, 0, 0 };

                //hSE = [0 0 0; 0 -1 0; 0 0 1];

                double[][] hSE = null;

                hSE[0] = new double[] { 0, 0, 0 };
                hSE[1] = new double[] { 0, -1, 0 };
                hSE[2] = new double[] { 0, 0, 1 };

                //hSW = [0 0 0; 0 -1 0; 1 0 0];

                double[][] hSW = null;

                hSW[0] = new double[] { 0, 0, 0 };
                hSW[1] = new double[] { 0, -1, 0 };
                hSW[2] = new double[] { 1, 0, 0 };

                //hNW = [1 0 0; 0 -1 0; 0 0 0];

                double[][] hNW = null;

                hNW[0] = new double[] { 1, 0, 0 };
                hNW[1] = new double[] { 0, -1, 0 };
                hNW[2] = new double[] { 0, 0, 0 };

                //Anisotropic diffusion:

                int numOfIterations = 50;

                for (int j = 0; j < numOfIterations; j++)
                {

                    //Finite differences. 

                    double[][] nablaN = convolve(transformingImage, hN);
                    double[][] nablaS = convolve(transformingImage, hS);
                    double[][] nablaW = convolve(transformingImage, hW);
                    double[][] nablaE = convolve(transformingImage, hE);
                    double[][] nablaNE = convolve(transformingImage, hNE);
                    double[][] nablaSE = convolve(transformingImage, hSE);
                    double[][] nablaSW = convolve(transformingImage, hSW);
                    double[][] nablaNW = convolve(transformingImage, hNW);

                    for (int k = 0; k < transformingImage.Length; k++)
                    {
                        for (int l = 0; l < transformingImage[0].Length; l++)
                        {
                            nablaN[i][j] = Math.Pow((nablaN[i][j] / kappa), 2);
                            nablaS[i][j] = Math.Pow((nablaS[i][j] / kappa), 2);
                            nablaW[i][j] = Math.Pow((nablaW[i][j] / kappa), 2);
                            nablaE[i][j] = Math.Pow((nablaE[i][j] / kappa), 2);
                            nablaNE[i][j] = Math.Pow((nablaNE[i][j] / kappa), 2);
                            nablaSE[i][j] = Math.Pow((nablaSE[i][j] / kappa), 2);
                            nablaSW[i][j] = Math.Pow((nablaSW[i][j] / kappa), 2);
                            nablaNW[i][j] = Math.Pow((nablaNW[i][j] / kappa), 2);
                        }
                    }

                    //--------------------Diffusion function
                    if (option == 1)
                    {
                        double[][] cN = Math.Exp(-(nablaN).^ 2);
                        double[][] cS = Math.Exp(-(nablaS).^ 2);
                        double[][] cW = Math.Exp(-(nablaW).^ 2);
                        double[][] cE = Math.Exp(-(nablaE).^ 2);
                        double[][] cNE = Math.Exp(-(nablaNE).^ 2);
                        double[][] cSE = Math.Exp(-(nablaSE).^ 2);
                        double[][] cSW = Math.Exp(-(nablaSW).^ 2);
                        double[][] cNW = Math.Exp(-(nablaNW).^ 2);
                    }
                    else if (option == 2)
                    {
                        //            cN = 1./ (1 + (nablaN / kappa).^ 2);
                        //            cS = 1./ (1 + (nablaS / kappa).^ 2);
                        //            cW = 1./ (1 + (nablaW / kappa).^ 2);
                        //            cE = 1./ (1 + (nablaE / kappa).^ 2);
                        //            cNE = 1./ (1 + (nablaNE / kappa).^ 2);
                        //            cSE = 1./ (1 + (nablaSE / kappa).^ 2);
                        //            cSW = 1./ (1 + (nablaSW / kappa).^ 2);
                        //            cNW = 1./ (1 + (nablaNW / kappa).^ 2);
                        //            end
                    }

                }
                }
            }

            return (diffusedImages);
        }

        private static double[][] convolve(double[][] image, double[][] kernel)
        {
            double[] result = null;
            //------------------------------------------------------INCOMPLETE
            // assumes kernel is symmetric or already rotated by 180 degrees
            //  the return format is BGR, NOT RGB.
            //Bitmap bSrc = (Bitmap)b.Clone();
            //BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height),
            //                    ImageLockMode.ReadWrite,
            //                    PixelFormat.Format24bppRgb);
            //BitmapData bmSrc = bSrc.LockBits(new Rectangle(0, 0, bSrc.Width, bSrc.Height),
            //                   ImageLockMode.ReadWrite,
            //                   PixelFormat.Format24bppRgb);

            //int stride = bmData.Stride; // number of bytes in a row 3*b.Width + even bits
            //System.IntPtr Scan0 = bmData.Scan0;
            //System.IntPtr SrcScan0 = bmSrc.Scan0;

            //unsafe
            //{
            //    byte* p = (byte*)(void*)Scan0;
            //    byte* pc = (byte*)(void*)SrcScan0;

            //    byte red, green, blue;
            //    int nOffset = stride - b.Width * 3;
            //    for (int y = 0; y < b.Height - 2; ++y)
            //    {
            //        for (int x = 0; x < b.Width - 2; ++x)
            //        {
            //            double[][] bluem = new double[3][];
            //            for (int i = 0; i < 3; i++)
            //                bluem[i] = new double[3];
            //            double[][] greenm = new double[3][];
            //            for (int i = 0; i < 3; i++)
            //                greenm[i] = new double[3];
            //            double[][] redm = new double[3][];
            //            for (int i = 0; i < 3; i++)
            //                redm[i] = new double[3];
            //            bluem[0][0] = pc[0];
            //            greenm[0][0] = pc[1];
            //            redm[0][0] = pc[2];

            //            bluem[0][1] = pc[3];
            //            greenm[0][1] = pc[4];
            //            redm[0][1] = pc[5];

            //            bluem[0][2] = pc[6];
            //            greenm[0][2] = pc[7];
            //            redm[0][2] = pc[8];

            //            bluem[1][0] = pc[0 + stride];
            //            greenm[1][0] = pc[1 + stride];
            //            redm[1][0] = pc[2 + stride];

            //            bluem[1][1] = pc[3 + stride];
            //            greenm[1][1] = pc[4 + stride];
            //            redm[1][1] = pc[5 + stride];

            //            bluem[1][2] = pc[6 + stride];
            //            greenm[1][2] = pc[7 + stride];
            //            redm[1][2] = pc[8 + stride];

            //            bluem[2][0] = pc[0 + stride * 2];
            //            greenm[2][0] = pc[1 + stride * 2];
            //            redm[2][0] = pc[2 + stride * 2];

            //            bluem[2][1] = pc[3 + stride * 2];
            //            greenm[2][1] = pc[4 + stride * 2];
            //            redm[2][1] = pc[5 + stride * 2];

            //            bluem[2][2] = pc[6 + stride * 2];
            //            greenm[2][2] = pc[7 + stride * 2];
            //            redm[2][2] = pc[8 + stride * 2];


            //            double cblue = bluem[0][0] * kernel[0][0] +
            //                bluem[0][1] * kernel[0][1] +
            //                bluem[0][2] * kernel[0][2] +
            //                bluem[1][0] * kernel[1][0] +
            //                bluem[1][1] * kernel[1][1] +
            //                bluem[1][2] * kernel[1][2] +
            //                bluem[2][0] * kernel[2][0] +
            //                bluem[2][1] * kernel[2][1] +
            //                bluem[2][2] * kernel[2][2];

            //            double cgreen = greenm[0][0] * kernel[0][0] +
            //               greenm[0][1] * kernel[0][1] +
            //               greenm[0][2] * kernel[0][2] +
            //               greenm[1][0] * kernel[1][0] +
            //               greenm[1][1] * kernel[1][1] +
            //               greenm[1][2] * kernel[1][2] +
            //               greenm[2][0] * kernel[2][0] +
            //               greenm[2][1] * kernel[2][1] +
            //               greenm[2][2] * kernel[2][2];

            //            double cred = redm[0][0] * kernel[0][0] +
            //               redm[0][1] * kernel[0][1] +
            //               redm[0][2] * kernel[0][2] +
            //               redm[1][0] * kernel[1][0] +
            //               redm[1][1] * kernel[1][1] +
            //               redm[1][2] * kernel[1][2] +
            //               redm[2][0] * kernel[2][0] +
            //               redm[2][1] * kernel[2][1] +
            //               redm[2][2] * kernel[2][2];

            //            if (cblue < 0) cblue = 0;
            //            if (cblue > 255) cblue = 255;
            //            if (cgreen < 0) cgreen = 0;
            //            if (cgreen > 255) cgreen = 255;
            //            if (cred < 0) cred = 0;
            //            if (cred > 255) cred = 255;

            //            p[3 + stride] = (byte)cblue;
            //            p[4 + stride] = (byte)cgreen;
            //            p[5 + stride] = (byte)cred;

            //            p += 3;
            //            pc += 3;
            //        }
            //        p += nOffset;
            //        pc += nOffset;
            //    }
            //}
            //b.UnlockBits(bmData);
            //bSrc.UnlockBits(bmSrc);
            //return true;

            return result;
        }

    }
}
