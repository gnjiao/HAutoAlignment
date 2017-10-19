//
// File generated by HDevelop for HALCON/.NET (C#) Version 13.0
//
//  This file is intended to be used with the HDevelopTemplate or
//  HDevelopTemplateWPF projects located under %HALCONEXAMPLES%\c#

using System;
using System.Windows.Forms;
using HalconDotNet;

namespace FC.MarkLocator
{
    public partial class HFindProductMark_0551601
    {
        public static HTuple hv_ExpDefaultWinHandle;

        HTuple hv_ModelID = null;
        HObject ho_ModelContours;
        HTuple hv_MetrologyHandle = null;

        public void HDevelopStop()
        {
            MessageBox.Show("Press button to continue", "Program stop");
        }

        // Procedures 
        // External procedures 
        // Chapter: Graphics / Text
        // Short Description: This procedure writes a text message. 
        public void disp_message(HTuple hv_WindowHandle, HTuple hv_String, HTuple hv_CoordSystem,
            HTuple hv_Row, HTuple hv_Column, HTuple hv_Color, HTuple hv_Box)
        {
            // Local iconic variables 

            // Local control variables 

            HTuple hv_GenParamName = null, hv_GenParamValue = null;
            HTuple hv_Color_COPY_INP_TMP = hv_Color.Clone();
            HTuple hv_Column_COPY_INP_TMP = hv_Column.Clone();
            HTuple hv_CoordSystem_COPY_INP_TMP = hv_CoordSystem.Clone();
            HTuple hv_Row_COPY_INP_TMP = hv_Row.Clone();

            // Initialize local and output iconic variables 
            //This procedure displays text in a graphics window.
            //
            //Input parameters:
            //WindowHandle: The WindowHandle of the graphics window, where
            //   the message should be displayed
            //String: A tuple of strings containing the text message to be displayed
            //CoordSystem: If set to 'window', the text position is given
            //   with respect to the window coordinate system.
            //   If set to 'image', image coordinates are used.
            //   (This may be useful in zoomed images.)
            //Row: The row coordinate of the desired text position
            //   A tuple of values is allowed to display text at different
            //   positions.
            //Column: The column coordinate of the desired text position
            //   A tuple of values is allowed to display text at different
            //   positions.
            //Color: defines the color of the text as string.
            //   If set to [], '' or 'auto' the currently set color is used.
            //   If a tuple of strings is passed, the colors are used cyclically...
            //   - if |Row| == |Column| == 1: for each new textline
            //   = else for each text position.
            //Box: If Box[0] is set to 'true', the text is written within an orange box.
            //     If set to' false', no box is displayed.
            //     If set to a color string (e.g. 'white', '#FF00CC', etc.),
            //       the text is written in a box of that color.
            //     An optional second value for Box (Box[1]) controls if a shadow is displayed:
            //       'true' -> display a shadow in a default color
            //       'false' -> display no shadow
            //       otherwise -> use given string as color string for the shadow color
            //
            //It is possible to display multiple text strings in a single call.
            //In this case, some restrictions apply:
            //- Multiple text positions can be defined by specifying a tuple
            //  with multiple Row and/or Column coordinates, i.e.:
            //  - |Row| == n, |Column| == n
            //  - |Row| == n, |Column| == 1
            //  - |Row| == 1, |Column| == n
            //- If |Row| == |Column| == 1,
            //  each element of String is display in a new textline.
            //- If multiple positions or specified, the number of Strings
            //  must match the number of positions, i.e.:
            //  - Either |String| == n (each string is displayed at the
            //                          corresponding position),
            //  - or     |String| == 1 (The string is displayed n times).
            //
            //
            //Convert the parameters for disp_text.
            if ((int)((new HTuple(hv_Row_COPY_INP_TMP.TupleEqual(new HTuple()))).TupleOr(
                new HTuple(hv_Column_COPY_INP_TMP.TupleEqual(new HTuple())))) != 0)
            {

                return;
            }
            if ((int)(new HTuple(hv_Row_COPY_INP_TMP.TupleEqual(-1))) != 0)
            {
                hv_Row_COPY_INP_TMP = 12;
            }
            if ((int)(new HTuple(hv_Column_COPY_INP_TMP.TupleEqual(-1))) != 0)
            {
                hv_Column_COPY_INP_TMP = 12;
            }
            //
            //Convert the parameter Box to generic parameters.
            hv_GenParamName = new HTuple();
            hv_GenParamValue = new HTuple();
            if ((int)(new HTuple((new HTuple(hv_Box.TupleLength())).TupleGreater(0))) != 0)
            {
                if ((int)(new HTuple(((hv_Box.TupleSelect(0))).TupleEqual("false"))) != 0)
                {
                    //Display no box
                    hv_GenParamName = hv_GenParamName.TupleConcat("box");
                    hv_GenParamValue = hv_GenParamValue.TupleConcat("false");
                }
                else if ((int)(new HTuple(((hv_Box.TupleSelect(0))).TupleNotEqual("true"))) != 0)
                {
                    //Set a color other than the default.
                    hv_GenParamName = hv_GenParamName.TupleConcat("box_color");
                    hv_GenParamValue = hv_GenParamValue.TupleConcat(hv_Box.TupleSelect(0));
                }
            }
            if ((int)(new HTuple((new HTuple(hv_Box.TupleLength())).TupleGreater(1))) != 0)
            {
                if ((int)(new HTuple(((hv_Box.TupleSelect(1))).TupleEqual("false"))) != 0)
                {
                    //Display no shadow.
                    hv_GenParamName = hv_GenParamName.TupleConcat("shadow");
                    hv_GenParamValue = hv_GenParamValue.TupleConcat("false");
                }
                else if ((int)(new HTuple(((hv_Box.TupleSelect(1))).TupleNotEqual("true"))) != 0)
                {
                    //Set a shadow color other than the default.
                    hv_GenParamName = hv_GenParamName.TupleConcat("shadow_color");
                    hv_GenParamValue = hv_GenParamValue.TupleConcat(hv_Box.TupleSelect(1));
                }
            }
            //Restore default CoordSystem behavior.
            if ((int)(new HTuple(hv_CoordSystem_COPY_INP_TMP.TupleNotEqual("window"))) != 0)
            {
                hv_CoordSystem_COPY_INP_TMP = "image";
            }
            //
            if ((int)(new HTuple(hv_Color_COPY_INP_TMP.TupleEqual(""))) != 0)
            {
                //disp_text does not accept an empty string for Color.
                hv_Color_COPY_INP_TMP = new HTuple();
            }
            //
            HOperatorSet.DispText(hv_ExpDefaultWinHandle, hv_String, hv_CoordSystem_COPY_INP_TMP,
                hv_Row_COPY_INP_TMP, hv_Column_COPY_INP_TMP, hv_Color_COPY_INP_TMP, hv_GenParamName,
                hv_GenParamValue);

            return;
        }

        //generate mark model
        public void  GenMarkModel(out HTuple hv_ModelID, out HObject ho_ModelContours, out HTuple hv_MetrologyHandle)
        {
            // Local iconic variables 
            HObject ho_Image, ho_Rectangle, ho_ImageReduced;
            HObject  ho_ShowContours, ho_ModelContour;
            HObject ho_MeasureContour = null;

         // Local control variables 
         HTuple hv_Height = null, hv_Width = null;
            HTuple hv_Area = null, hv_RowRefer = null, hv_ColRefer = null;
            HTuple hv_HomMat2D = null;
            HTuple hv_Line = null, hv_LineIndices = null, hv_Row = null, hv_Column = null;

         // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_Image);
            HOperatorSet.GenEmptyObj(out ho_Rectangle);
            HOperatorSet.GenEmptyObj(out ho_ImageReduced);
            HOperatorSet.GenEmptyObj(out ho_ModelContours);
            HOperatorSet.GenEmptyObj(out ho_ShowContours);
            HOperatorSet.GenEmptyObj(out ho_ModelContour);

            //**读取图片所在路径**
            ho_Image.Dispose();
            HOperatorSet.ReadImage(out ho_Image, "Model.bmp");
            HOperatorSet.GetImageSize(ho_Image, out hv_Width, out hv_Height);
            //dev_open_window(...);
            //HOperatorSet.SetDraw(hv_ExpDefaultWinHandle, "margin");
            //HOperatorSet.SetLineWidth(hv_ExpDefaultWinHandle, 2);
            //HOperatorSet.DispObj(ho_Image, hv_ExpDefaultWinHandle);

            //创建模板
            ho_Rectangle.Dispose();
            HOperatorSet.GenRectangle1(out ho_Rectangle, 400, 570, 550, 700);
            ho_ImageReduced.Dispose();
            HOperatorSet.ReduceDomain(ho_Image, ho_Rectangle, out ho_ImageReduced);
            HOperatorSet.AreaCenter(ho_ImageReduced, out hv_Area, out hv_RowRefer, out hv_ColRefer);
            HOperatorSet.CreateShapeModel(ho_ImageReduced, "auto", (new HTuple(-10)).TupleRad()
                , (new HTuple(20)).TupleRad(), "auto", "auto", "use_polarity", "auto", "auto",
                out hv_ModelID);
            ho_ModelContours.Dispose();
            HOperatorSet.GetShapeModelContours(out ho_ModelContours, hv_ModelID, 1);
            HOperatorSet.VectorAngleToRigid(0, 0, 0, hv_RowRefer, hv_ColRefer, 0, out hv_HomMat2D);
            ho_ShowContours.Dispose();
            HOperatorSet.AffineTransContourXld(ho_ModelContours, out ho_ShowContours, hv_HomMat2D);
            HOperatorSet.DispObj(ho_Image, hv_ExpDefaultWinHandle);
            HOperatorSet.DispObj(ho_ShowContours, hv_ExpDefaultWinHandle);

            //创建测量模板
            HOperatorSet.CreateMetrologyModel(out hv_MetrologyHandle);
            HOperatorSet.SetMetrologyModelImageSize(hv_MetrologyHandle, hv_Width, hv_Height);

            //从左向右在矩形上边缘画一条直线*
            hv_Line = new HTuple();
            hv_Line[0] = 445;
            hv_Line[1] = 600;
            hv_Line[2] = 445;
            hv_Line[3] = 670;
            HOperatorSet.AddMetrologyObjectGeneric(hv_MetrologyHandle, "line", hv_Line, 25,
                5, 1, 30, new HTuple(), new HTuple(), out hv_LineIndices);
            ho_ModelContour.Dispose();
            HOperatorSet.GetMetrologyObjectModelContour(out ho_ModelContour, hv_MetrologyHandle,
                "all", 1.5);
           // ho_MeasureContour.Dispose();
            HOperatorSet.GetMetrologyObjectMeasures(out ho_MeasureContour, hv_MetrologyHandle,
                "all", "all", out hv_Row, out hv_Column);

            //把测量的位置和模板的位置关联起来
            HOperatorSet.SetMetrologyModelParam(hv_MetrologyHandle, "reference_system", ((hv_RowRefer.TupleConcat(
                hv_ColRefer))).TupleConcat(0));
            HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, hv_LineIndices, "measure_transition",
                "positive");
            HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, hv_LineIndices, "measure_select",
                "first");
            HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, hv_LineIndices, "measure_length1",
                25);
            HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, hv_LineIndices, "measure_length2",
                5);
            HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, hv_LineIndices, "measure_threshold",
                15);
            HOperatorSet.SetMetrologyObjectParam(hv_MetrologyHandle, hv_LineIndices, "min_score",
                0.3);

        }

        public bool FindMark(string FileName, out double centerRow, out double centerCol, out double angle)
        {
            bool result = false;

            if (hv_ModelID == null)
            {
                GenMarkModel(out hv_ModelID, out ho_ModelContours, out hv_MetrologyHandle);
            }

            HObject ho_Image;
            HObject ho_ResultContours = null, ho_Contour = null;
            HObject ho_UsedEdges = null, ho_Cross = null;

            HTuple hv_RowFound = new HTuple(), hv_ColFound = new HTuple(), hv_AngleFound = new HTuple();
            HTuple hv_ScoreFound = new HTuple();
            HTuple hv_HomMat2D = null;
            HTuple hv_Column = null, hv_Row = null;

            HTuple hv_UsedColumn = new HTuple(), hv_UsedRow = new HTuple();
            HTuple hv_Angle = new HTuple(), hv_Degree = new HTuple();

            HOperatorSet.GenEmptyObj(out ho_Image);
            HOperatorSet.GenEmptyObj(out ho_ResultContours);
            HOperatorSet.GenEmptyObj(out ho_Contour);
            HOperatorSet.GenEmptyObj(out ho_UsedEdges);
            HOperatorSet.GenEmptyObj(out ho_Cross);

            ho_Image.Dispose();
            HOperatorSet.ReadImage(out ho_Image, FileName);
            HOperatorSet.FindShapeModel(ho_Image, hv_ModelID, (new HTuple(-10)).TupleRad()
                , (new HTuple(20)).TupleRad(), 0.3, 1, 0.5, "least_squares", 0, 0.75, out hv_RowFound,
                out hv_ColFound, out hv_AngleFound, out hv_ScoreFound);
            if ((int)(new HTuple((new HTuple(1)).TupleEqual(new HTuple(hv_RowFound.TupleLength()
                )))) != 0)
            {
                HOperatorSet.HomMat2dIdentity(out hv_HomMat2D);
                HOperatorSet.HomMat2dRotate(hv_HomMat2D, hv_AngleFound, 0, 0, out hv_HomMat2D);
                HOperatorSet.HomMat2dTranslate(hv_HomMat2D, hv_RowFound - 0, hv_ColFound - 0,
                    out hv_HomMat2D);
                ho_ResultContours.Dispose();
                HOperatorSet.AffineTransContourXld(ho_ModelContours, out ho_ResultContours,
                    hv_HomMat2D);

                HOperatorSet.DispObj(ho_Image, hv_ExpDefaultWinHandle);
                HOperatorSet.SetColor(hv_ExpDefaultWinHandle, "red");
                HOperatorSet.DispObj(ho_ResultContours, hv_ExpDefaultWinHandle);

                HOperatorSet.AlignMetrologyModel(hv_MetrologyHandle, hv_RowFound, hv_ColFound,
                    hv_AngleFound);
                //应用测量
                HOperatorSet.ApplyMetrologyModel(ho_Image, hv_MetrologyHandle);
                //获取结果
                ho_Contour.Dispose();
                HOperatorSet.GetMetrologyObjectMeasures(out ho_Contour, hv_MetrologyHandle,
                    "all", "all", out hv_Row, out hv_Column);

                HOperatorSet.GetMetrologyObjectResult(hv_MetrologyHandle, "all", "all", "used_edges",
                    "row", out hv_UsedRow);
                HOperatorSet.GetMetrologyObjectResult(hv_MetrologyHandle, "all", "all", "used_edges",
                    "column", out hv_UsedColumn);
                ho_UsedEdges.Dispose();
                HOperatorSet.GenCrossContourXld(out ho_UsedEdges, hv_UsedRow, hv_UsedColumn,
                    10, (new HTuple(45)).TupleRad());
                ho_ResultContours.Dispose();
                HOperatorSet.GetMetrologyObjectResultContour(out ho_ResultContours, hv_MetrologyHandle,
                    "all", "all", 1.5);


                ho_Cross.Dispose();
                HOperatorSet.GenCrossContourXld(out ho_Cross, hv_RowFound, hv_ColFound, 40,
                    hv_AngleFound);
                //HOperatorSet.DispObj(ho_Image, hv_ExpDefaultWinHandle);
                //HOperatorSet.SetColor(hv_ExpDefaultWinHandle, "green");
                //HOperatorSet.DispObj(ho_Cross, hv_ExpDefaultWinHandle);
                //HOperatorSet.SetColor(hv_ExpDefaultWinHandle, "green");
                //HOperatorSet.DispObj(ho_ResultContours, hv_ExpDefaultWinHandle);

                HOperatorSet.AngleLx(hv_UsedRow.TupleSelect(1), hv_UsedColumn.TupleSelect(
                    1), hv_UsedRow.TupleSelect(6), hv_UsedColumn.TupleSelect(6), out hv_Angle);
                HOperatorSet.TupleDeg(hv_Angle, out hv_Degree);
                //disp_message(hv_ExpDefaultWinHandle, "定位成功！", "window", 12, 12, "black",
                //    "true");


                disp_message(hv_ExpDefaultWinHandle, ((((((new HTuple("mark位置：") + "[ ") + hv_RowFound) + new HTuple(",")) + hv_ColFound) + new HTuple(",")) + hv_Degree) + "° ]",
                      "window", 32, 12, "black", "true");
                //相对模板角度
                //HOperatorSet.TupleDeg(hv_AngleFound, out hv_Degree);
                //disp_message(hv_ExpDefaultWinHandle, ("相对模板角度为" + hv_Degree) + "°", "window",
                //    52, 12, "black", "true");

                centerRow = hv_RowFound;
                centerCol = hv_ColFound;
                angle = hv_Degree;

                result = true;
            }
            else
            {
                disp_message(hv_ExpDefaultWinHandle, "未识别到靶标", "window", hv_Row, hv_Column,
                    "black", "true");
                centerRow = centerCol = angle = 0;
            }

            ho_Image.Dispose();
            ho_ResultContours.Dispose();
            ho_Contour.Dispose();
            ho_UsedEdges.Dispose();
            ho_Cross.Dispose();

            return result;
        }

        public void InitHalcon()
        {
            // Default settings used in HDevelop 
            HOperatorSet.SetSystem("width", 512);
            HOperatorSet.SetSystem("height", 512);
        }

        public void RunHalcon(HTuple Window, string fileName)
        {
            hv_ExpDefaultWinHandle = Window;
           // FindMark(fileName);
        }

    }

}