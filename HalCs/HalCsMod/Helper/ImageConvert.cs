
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HalconDotNet;
using System.Drawing;

namespace HalCsMod.Helper
{
    class ImageConv1
    {
        /// <summary>
        /// 灰度图像 HObject -> Bitmap
        /// </summary>

        public static Bitmap HObject2Bitmap(HObject ho)
        {
            try
            {
                HTuple type, width, height, pointer;
                //HOperatorSet.AccessChannel(ho, out ho, 1);
                HOperatorSet.GetImagePointer1(ho, out pointer, out type, out width, out height);
                //himg.GetImagePointer1(out type, out width, out height);

                Bitmap bmp = new Bitmap(width.I, height.I, PixelFormat.Format8bppIndexed);
                ColorPalette pal = bmp.Palette;
                for (int i = 0; i <= 255; i++)
                {
                    pal.Entries[i] = Color.FromArgb(255, i, i, i);
                }
                bmp.Palette = pal;
                BitmapData bitmapData = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);
                int PixelSize = Bitmap.GetPixelFormatSize(bitmapData.PixelFormat) / 8;
                int stride = bitmapData.Stride;
                int ptr = bitmapData.Scan0.ToInt32();
                for (int i = 0; i < height; i++)
                {
                    CopyMemory(ptr, pointer, width * PixelSize);
                    pointer += width;
                    ptr += bitmapData.Stride;
                }

                bmp.UnlockBits(bitmapData);
                return bmp;
            }
            catch (Exception exc)
            {
                return null;
            }
        }
        /// <summary>
        /// 灰度图像 HObject -> HImage1
        /// </summary>
        public HImage HObject2HImage1(HObject hObj)
        {
            HImage image = new HImage();
            HTuple type, width, height, pointer;
            HOperatorSet.GetImagePointer1(hObj, out pointer, out type, out width, out height);
            image.GenImage1(type, width, height, pointer);
            return image;
        }

        /// <summary>
        /// 彩色图像 HObject -> HImage3
        /// </summary>
        public HImage HObject2HImage3(HObject hObj)
        {
            HImage image = new HImage();
            HTuple type, width, height, pointerRed, pointerGreen, pointerBlue;
            HOperatorSet.GetImagePointer3(hObj, out pointerRed, out pointerGreen, out pointerBlue,
                                          out type, out width, out height);
            image.GenImage3(type, width, height, pointerRed, pointerGreen, pointerBlue);
            return image;
        }
    }
    class ImageTypeConverter
    {
        /// <summary>
        /// Convert Bitmap to HImage which Halcon dot net data type
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static HalconDotNet.HImage Bitmap2HImage(System.Drawing.Bitmap input)
        {
            if (input == null)
                return new HalconDotNet.HImage();

            try
            {
                System.Drawing.Rectangle rect = new System.Drawing.Rectangle(0, 0, input.Width, input.Height);

                HalconDotNet.HImage himg = new HalconDotNet.HImage();
                if (input.PixelFormat == System.Drawing.Imaging.PixelFormat.Format8bppIndexed)
                {
                    System.Drawing.Imaging.BitmapData srcBmpData = input.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
                    himg.GenImage1("byte", input.Width, input.Height, srcBmpData.Scan0);
                    input.UnlockBits(srcBmpData);
                }
                else if (input.PixelFormat == System.Drawing.Imaging.PixelFormat.Format24bppRgb)
                {
                    System.Drawing.Imaging.BitmapData srcBmpData = input.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                    himg.GenImageInterleaved(srcBmpData.Scan0, "bgr", input.Width, input.Height, -1, "byte", 0, 0, 0, 0, -1, 0);
                    input.UnlockBits(srcBmpData);
                }
                else if (input.PixelFormat == System.Drawing.Imaging.PixelFormat.Format32bppArgb)
                {
                    System.Drawing.Imaging.BitmapData srcBmpData = input.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, input.PixelFormat);
                    himg.GenImageInterleaved(srcBmpData.Scan0, "bgrx", input.Width, input.Height, -1, "byte", input.Width, input.Height, 0, 0, -1, 0);
                    input.UnlockBits(srcBmpData);
                }
                else // default: trans to color image
                {
                    System.Drawing.Imaging.BitmapData srcBmpData = null;
                    System.Drawing.Bitmap MetaBmp = new System.Drawing.Bitmap(input.Width, input.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                    System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(MetaBmp);
                    g.DrawImage(input, rect);
                    g.Dispose();
                    srcBmpData = MetaBmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                    himg.GenImageInterleaved(srcBmpData.Scan0, "bgr", input.Width, input.Height, -1, "byte", 0, 0, 0, 0, -1, 0);
                    MetaBmp.UnlockBits(srcBmpData);
                }


                return himg;
            }
            catch (HalconDotNet.HalconException ex)
            {
                Console.WriteLine("In ImageTypeConverter.Bitmap2HImage: " + ex.Message);
                return null;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("In ImageTypeConverter.Bitmap2HImage: " + ex.Message);
                return null;
            }
        }

       
        /// <summary>
        /// Copy data from one memory address, source, to another address, destination.
        /// </summary>
        /// <param name="destination"></param>
        /// <param name="source"></param>
        /// <param name="length"></param>
        [System.Runtime.InteropServices.DllImport("kernel32.dll", SetLastError = true, EntryPoint = "CopyMemory")]
        private static extern void CopyMemory(Int64 destination, Int64 source, Int64 length);
        /// <summary>
        /// Convert HImage to Bitmap
        /// </summary>
        /// <param name="HImg"></param>
        /// <returns></returns>
        public static System.Drawing.Bitmap HImage2Bitmap(HalconDotNet.HImage HImg)
        {
            if (HImg == null)
                return null;

            try
            {
                System.Drawing.Bitmap bmpImg;

                HalconDotNet.HTuple Channels;
                Channels = HImg.CountChannels();


                if (Channels.I == 1)
                {
                    System.Drawing.Imaging.PixelFormat pixelFmt = System.Drawing.Imaging.PixelFormat.Format8bppIndexed;
                    HalconDotNet.HTuple hpointer, type, width, height;
                    const int Alpha = 255;
                    Int64[] ptr = new Int64[2];
                    hpointer = HImg.GetImagePointer1(out type, out width, out height);

                    bmpImg = new System.Drawing.Bitmap(width.I, height.I, pixelFmt);
                    System.Drawing.Imaging.ColorPalette pal = bmpImg.Palette;
                    for (int i = 0; i < 256; i++)
                        pal.Entries[i] = System.Drawing.Color.FromArgb(Alpha, i, i, i);

                    bmpImg.Palette = pal;
                    System.Drawing.Imaging.BitmapData bitmapData = bmpImg.LockBits(new System.Drawing.Rectangle(0, 0, width.I, height.I), System.Drawing.Imaging.ImageLockMode.ReadWrite, pixelFmt);
                    int PixelsSize = System.Drawing.Bitmap.GetPixelFormatSize(bitmapData.PixelFormat) / 8;

                    Console.WriteLine(bitmapData.Scan0);
                    ptr[0] = (Int64)bitmapData.Scan0;
                    ptr[1] = (Int64)hpointer.IP;
                    if (width % 4 == 0)
                        CopyMemory(ptr[0], ptr[1], width * height * PixelsSize);
                    else
                    {
                        ptr[1] += width;
                        CopyMemory(ptr[0], ptr[1], width * PixelsSize);
                        ptr[0] += width;
                    }
                    bmpImg.UnlockBits(bitmapData);
                }
                else if (Channels.I == 3)
                {
                    System.Drawing.Imaging.PixelFormat pixelFmt = System.Drawing.Imaging.PixelFormat.Format24bppRgb;
                    HalconDotNet.HTuple hred, hgreen, hblue, type, width, height;
                    HImg.GetImagePointer3(out hred, out hgreen, out hblue, out type, out width, out height);
                    //HalconDotNet.HOperatorSet.GetImagePointer3(HImg, out hred, out hgreen, out hblue, out type, out width, out height);

                    bmpImg = new System.Drawing.Bitmap(width.I, height.I, pixelFmt);
                    System.Drawing.Imaging.BitmapData bitmapData = bmpImg.LockBits(new System.Drawing.Rectangle(0, 0, width.I, height.I), System.Drawing.Imaging.ImageLockMode.ReadWrite, pixelFmt);
                    unsafe
                    {
                        byte* data = (byte*)bitmapData.Scan0;
                        byte* hr = (byte*)hred.IP;
                        byte* hg = (byte*)hgreen.IP;
                        byte* hb = (byte*)hblue.IP;

                        for (int i = 0; i < width.I * height.I; i++)
                        {
                            *(data + (i * 3)) = (*(hb + i));
                            *(data + (i * 3) + 1) = *(hg + i);
                            *(data + (i * 3) + 2) = *(hr + i);
                        }

                    }
                    bmpImg.UnlockBits(bitmapData);
                }
                else if (Channels.I == 4)
                {
                    System.Drawing.Imaging.PixelFormat pixelFmt = System.Drawing.Imaging.PixelFormat.Format32bppRgb;
                    HalconDotNet.HTuple hred, hgreen, hblue, type, width, height;
                    HImg.GetImagePointer3(out hred, out hgreen, out hblue, out type, out width, out height);
                    //HalconDotNet.HOperatorSet.GetImagePointer3(HImg, out hred, out hgreen, out hblue, out type, out width, out height);

                    bmpImg = new System.Drawing.Bitmap(width.I, height.I, pixelFmt);
                    System.Drawing.Imaging.BitmapData bitmapData = bmpImg.LockBits(new System.Drawing.Rectangle(0, 0, width.I, height.I), System.Drawing.Imaging.ImageLockMode.ReadWrite, pixelFmt);
                    unsafe
                    {
                        byte* data = (byte*)bitmapData.Scan0;
                        byte* hr = (byte*)hred.IP;
                        byte* hg = (byte*)hgreen.IP;
                        byte* hb = (byte*)hblue.IP;

                        for (int i = 0; i < width.I * height.I; i++)
                        {
                            *(data + (i * 4)) = *(hb + i);
                            *(data + (i * 4) + 1) = *(hg + i);
                            *(data + (i * 4) + 2) = *(hr + i);
                            *(data + (i * 4) + 3) = 255;
                        }
                        bmpImg.UnlockBits(bitmapData);
                    }
                }
                else
                {
                    bmpImg = null;
                }

                return bmpImg;
            }
            catch (HalconDotNet.HalconException ex)
            {
                Console.WriteLine("In ImageTypeConverter.HImage2Bitmap: " + ex.Message);
                return null;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("In ImageTypeConverter.HImage2Bitmap: " + ex.Message);
                return null;
            }

        }

      // -- following by relative HObject converter codes

        /// <summary>
        /// Convert Bitmap to HObject which Halcon dot net data type
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static HalconDotNet.HObject Bitmap2Hobject(System.Drawing.Bitmap input)
        {
            if (input == null)
                return new HalconDotNet.HObject();

            try
            {
                System.Drawing.Rectangle rect = new System.Drawing.Rectangle(0, 0, input.Width, input.Height);

                HalconDotNet.HObject himg = new HalconDotNet.HObject();
                if (input.PixelFormat == System.Drawing.Imaging.PixelFormat.Format8bppIndexed)
                {
                    System.Drawing.Imaging.BitmapData srcBmpData = input.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
                    HalconDotNet.HOperatorSet.GenImage1(out himg, "byte", input.Width, input.Height, srcBmpData.Scan0);
                    input.UnlockBits(srcBmpData);
                }
                else if (input.PixelFormat == System.Drawing.Imaging.PixelFormat.Format24bppRgb)
                {
                    System.Drawing.Imaging.BitmapData srcBmpData = input.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                    HalconDotNet.HOperatorSet.GenImageInterleaved(out himg, srcBmpData.Scan0, "bgr", input.Width, input.Height, -1, "byte", 0, 0, 0, 0, -1, 0);
                    input.UnlockBits(srcBmpData);
                }
                else if (input.PixelFormat == System.Drawing.Imaging.PixelFormat.Format32bppArgb)
                {
                    System.Drawing.Imaging.BitmapData srcBmpData = input.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, input.PixelFormat);
                    HalconDotNet.HOperatorSet.GenImageInterleaved(out himg, srcBmpData.Scan0, "bgrx", input.Width, input.Height, -1, "byte", input.Width, input.Height, 0, 0, -1, 0);
                    input.UnlockBits(srcBmpData);
                }
                else // default: trans to color image
                {
                    System.Drawing.Imaging.BitmapData srcBmpData = null;
                    System.Drawing.Bitmap MetaBmp = new System.Drawing.Bitmap(input.Width, input.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                    System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(MetaBmp);
                    g.DrawImage(input, rect);
                    g.Dispose();
                    srcBmpData = MetaBmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                    HalconDotNet.HOperatorSet.GenImageInterleaved(out himg, srcBmpData.Scan0, "bgr", input.Width, input.Height, -1, "byte", 0, 0, 0, 0, -1, 0);
                    MetaBmp.UnlockBits(srcBmpData);
                }

                return himg;
            }
            catch (HalconDotNet.HalconException ex)
            {
                Console.WriteLine("In ImageTypeConverter.Bitmap2Hobject: " + ex.Message);
                return null;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("In ImageTypeConverter.Bitmap2Hobject: " + ex.Message);
                return null;
            }
        }
    }
    class ImageHalCV
    {

    }
}
