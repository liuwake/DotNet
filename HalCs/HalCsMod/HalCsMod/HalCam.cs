﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//dev
using HalconDotNet;

namespace HalCsMod
{
   public class HalCam
    {
        public HTuple hv_ExpDefaultWinHandle;
        public HTuple hv_AcqHandle = new HTuple();
        public HObject ho_Image = null;
        public int halEn = 1;

        public  HalCam()
        {
            //int this.enable = 1;
            HOperatorSet.GenEmptyObj(out ho_Image);
        }
        public void Cam()
        {
            
            hv_AcqHandle.Dispose();
            HOperatorSet.OpenFramegrabber("GigEVision2", 0, 0, 0, 0, 0, 0, "progressive",
                -1, "default", -1, "false", "default", "c42f90f2b7fa_Hikvision_MVCE12010GM",
                0, -1, out hv_AcqHandle);
        }
        public void Vision( out HTuple hv_Mean, out HTuple hv_Deviation)
        {
            
            

            hv_Mean = new HTuple();
            hv_Deviation = new HTuple();

            HOperatorSet.GrabImageStart(hv_AcqHandle, -1);
            ho_Image.Dispose();
            HOperatorSet.GrabImageAsync(out ho_Image, hv_AcqHandle, -1);
            //Image Acquisition 02: Do something
            hv_Mean.Dispose(); hv_Deviation.Dispose();
            HOperatorSet.Intensity(ho_Image, ho_Image, out hv_Mean, out hv_Deviation);
            HOperatorSet.CloseFramegrabber(hv_AcqHandle);
        }
        public void showFrame(HTuple Window)//采集
        {
            hv_ExpDefaultWinHandle = Window;
            HOperatorSet.GenEmptyObj(out ho_Image);
            //HOperatorSet.OpenFramegrabber("DirectShow", 1, 1, 0, 0, 0, 0, "default", 8, "gray",
            //    -1, "false", "default", "[0] ", 0, -1, out hv_AcqHandle);
            HOperatorSet.OpenFramegrabber("GigEVision2", 0, 0, 0, 0, 0, 0, "progressive",
        -1, "default", -1, "false", "default", "c42f90f2b7fa_Hikvision_MVCE12010GM",
        0, -1, out hv_AcqHandle);
            HOperatorSet.GrabImageStart(hv_AcqHandle, -1);
            while ((int)(1) != 0)
            {
                ho_Image.Dispose();
                HOperatorSet.GrabImageAsync(out ho_Image, hv_AcqHandle, -1);

                HOperatorSet.DispObj(ho_Image, hv_ExpDefaultWinHandle);
                //System.Diagnostics.Debug.WriteLine("image");
            }
        }
        
    }
}
