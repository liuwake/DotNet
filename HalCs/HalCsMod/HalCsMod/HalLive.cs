using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalconDotNet;


namespace HalCsWpf
{
    public partial class HalLive
    {

        public HTuple hv_ExpDefaultWinHandle;
        HObject ho_Image = null;
        HTuple hv_AcqHandle = null;

        private void action()//采集
        {
            HOperatorSet.GenEmptyObj(out ho_Image);

            HOperatorSet.OpenFramegrabber("GigEVision2", 0, 0, 0, 0, 0, 0, "progressive",
        -1, "default", -1, "false", "default", "c42f90f2b7fa_Hikvision_MVCE12010GM",
        0, -1, out hv_AcqHandle);
            HOperatorSet.GrabImageStart(hv_AcqHandle, -1);
            while ((int)(1) != 0)
            {
                ho_Image.Dispose();
                HOperatorSet.GrabImageAsync(out ho_Image, hv_AcqHandle, -1);
                HOperatorSet.DispObj(ho_Image, hv_ExpDefaultWinHandle);
            }
        }
        public void InitHalcon()
        {
            // Default settings used in HDevelop
            HOperatorSet.SetSystem("width", 512);
            HOperatorSet.SetSystem("height", 512);
        }

        public void RunHalcon(HTuple Window)
        {
            hv_ExpDefaultWinHandle = Window;
            action();
        }
        public void StopHalcon()
        {
            HOperatorSet.CloseFramegrabber(hv_AcqHandle);
        }
    }
}
