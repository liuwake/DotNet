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


using System;
using HalconDotNet;

public partial class HDevelopExport
{
  public void ocr_split (HTuple hv_SymbolNames_OCR_01_0, out HTuple hv_Ocr)
  {



    // Local iconic variables 

    // Local control variables 

    HTuple hv_Index = new HTuple();
    // Initialize local and output iconic variables 
    hv_Ocr = new HTuple();
    hv_Ocr.Dispose();
    hv_Ocr = "";
    for (hv_Index=0; (int)hv_Index<=(int)((new HTuple(hv_SymbolNames_OCR_01_0.TupleLength()
        ))-1); hv_Index = (int)hv_Index + 1)
    {
      using (HDevDisposeHelper dh = new HDevDisposeHelper())
      {
      {
      HTuple 
        ExpTmpLocalVar_Ocr = hv_Ocr+(hv_SymbolNames_OCR_01_0.TupleSelect(
          hv_Index));
      hv_Ocr.Dispose();
      hv_Ocr = ExpTmpLocalVar_Ocr;
      }
      }
    }

    hv_Index.Dispose();

    return;
  }

}
