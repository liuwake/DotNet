//
// File generated by HDevelop for HALCON/.NET (C#) Version 18.11.1.1
// Non-ASCII strings in this file are encoded in UTF-8.
// 
// Please note that non-ASCII characters in string constants are exported
// as octal codes in order to guarantee that the strings are correctly
// created on all systems, independent on any compiler settings.
// 
// Source files with different encoding should not be mixed in one project.
//
//  This file is intended to be used with the HDevelopTemplate or
//  HDevelopTemplateWPF projects located under %HALCONEXAMPLES%\c#

using System;
using HalconDotNet;

public partial class HDevelopExport
{
  public HTuple hv_ExpDefaultWinHandle;

  // Procedures 
  public void image_judge_stop (HObject ho_ImageBefore, HObject ho_ImageLater, out HObject ho_Selected, 
      out HTuple hv_juadge_stop)
  {



    // Local iconic variables 

    // Local control variables 

    HTuple hv_Area = new HTuple(), hv_Row = new HTuple();
    HTuple hv_Column = new HTuple();
    // Initialize local and output iconic variables 
    HOperatorSet.GenEmptyObj(out ho_Selected);
    hv_juadge_stop = new HTuple();
    //** 初始化图片
    //* 测试traffic demo
    //read_image (ImageBefore, 'traffic1')
    //read_image (ImageLater, 'traffic2')
    //* 测试 高拍测试
    //read_image (ImageBefore, 'C:/Users/iwake/MVS/Data/Hos0.bmp')
    //read_image (ImageLater, 'C:/Users/iwake/MVS/Data/Hos1.bmp')
    //read_image (ImageLater2, 'C:/Users/iwake/MVS/Data/Hos2.bmp')

    //* 对比图像
    //difference
    //diff_of_gauss (ImageLater, DiffOfGauss, 3, 1.6)
    //traffic demo 参数
    //check_difference (ImageBefore, ImageLater2, Selected, 'diff_outside', -15, 255, 0, 0, 0)
    //高拍测试 参数
    ho_Selected.Dispose();
    HOperatorSet.CheckDifference(ho_ImageBefore, ho_ImageLater, out ho_Selected, 
        "diff_outside", -15, 255, 0, 0, 0);

    hv_Area.Dispose();hv_Row.Dispose();hv_Column.Dispose();
    HOperatorSet.AreaCenter(ho_Selected, out hv_Area, out hv_Row, out hv_Column);
    //disp_obj (Selected, WindowHandle)

    //** 判断
    hv_juadge_stop.Dispose();
    hv_juadge_stop = 0;
    if ((int)(new HTuple(hv_Area.TupleLessEqual(10000))) != 0)
    {
      hv_juadge_stop.Dispose();
      hv_juadge_stop = 1;
    }

    hv_Area.Dispose();
    hv_Row.Dispose();
    hv_Column.Dispose();

    return;
  }


}

