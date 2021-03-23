using iText.Barcodes;
using iText.IO.Font;
using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Kernel.Pdf.Xobject;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Layout;
using iText.Layout.Properties;
using iText.Layout.Renderer;
using System;
using System.Collections.Generic;

namespace ITextSharps
{
    class Program
    {
        public static readonly string DEST = "simple_table.pdf";
        public static readonly string FONT = "STZHONGS.TTF";
        public static readonly string SRC = "Right.pdf";
        // السعر الاجمالي 
        public static readonly string ARABIC = "\u0627\u0644\u0633\u0639\u0631 \u0627\u0644\u0627\u062c\u0645\u0627\u0644\u064a";
        static void Main(string[] args)
        {
            try
            {
                ManipulatePdf(DEST);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Done.");

            //Console.ReadKey();
        }

        //创建PDF
        private static void ManipulatePdf(string dest)
        {
            #region 101 - a very simple table
            //PdfDocument pdfDoc = new PdfDocument(new PdfWriter(dest));
            //Document doc = new Document(pdfDoc, PageSize.A4.Rotate());

            //Table table = new Table(UnitValue.CreatePercentArray(31)).UseAllAvailableWidth();

            //for (int i = 0; i < 32; i++)
            //{
            //    table.AddCell("hi");
            //}

            //doc.Add(table);

            //doc.Close();
            #endregion

            #region Adding a background to a table
            //PdfDocument pdfDoc = new PdfDocument(new PdfWriter(dest));
            //Document doc = new Document(pdfDoc);

            //PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
            //Table table = new Table(UnitValue.CreatePercentArray(16)).UseAllAvailableWidth();

            //for (int aw = 0; aw < 16; aw++)
            //{
            //    Cell cell = new Cell().Add(new Paragraph("hi").SetFont(font).SetFontColor(ColorConstants.WHITE));
            //    cell.SetBackgroundColor(ColorConstants.CYAN);
            //    cell.SetBorder(Border.NO_BORDER);
            //    cell.SetTextAlignment(TextAlignment.CENTER);
            //    table.AddCell(cell);
            //}

            //doc.Add(table);

            //doc.Close();
            #endregion

            #region Cell and table widths
            //PdfDocument pdfDoc = new PdfDocument(new PdfWriter(dest));
            //Document doc = new Document(pdfDoc, PageSize.A4.Rotate());

            //float[] columnWidths = { 1, 5, 5 };
            //Table table = new Table(UnitValue.CreatePercentArray(columnWidths));

            //PdfFont f = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
            //Cell cell = new Cell(1, 3)
            //    .Add(new Paragraph("This is a header"))
            //    .SetFont(f)
            //    .SetFontSize(13)
            //    .SetFontColor(DeviceGray.WHITE)
            //    .SetBackgroundColor(DeviceGray.BLACK)
            //    .SetTextAlignment(TextAlignment.CENTER);

            //table.AddHeaderCell(cell);

            //for (int i = 0; i < 2; i++)
            //{
            //    Cell[] headerFooter =
            //    {
            //        new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("#")),
            //        new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("Key")),
            //        new Cell().SetBackgroundColor(new DeviceGray(0.75f)).Add(new Paragraph("Value"))
            //    };

            //    foreach (Cell hfCell in headerFooter)
            //    {
            //        if (i == 0)
            //        {
            //            table.AddHeaderCell(hfCell);
            //        }
            //        else
            //        {
            //            table.AddFooterCell(hfCell);
            //        }
            //    }
            //}

            //for (int counter = 0; counter < 100; counter++)
            //{
            //    table.AddCell(new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph((counter + 1).ToString())));
            //    table.AddCell(new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("key " + (counter + 1))));
            //    table.AddCell(new Cell().SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("value " + (counter + 1))));
            //}

            //doc.Add(table);

            //doc.Close();
            #endregion

            #region Cell heights
            //PdfDocument pdfDoc = new PdfDocument(new PdfWriter(dest));
            //Document doc = new Document(pdfDoc, PageSize.A5.Rotate());

            //// By default column width is calculated automatically for the best fit.
            //// useAllAvailableWidth() method makes table use the whole page's width while placing the content.
            //Table table = new Table(UnitValue.CreatePercentArray(2)).UseAllAvailableWidth();

            //// A long phrase with newlines
            //Paragraph p = new Paragraph("Dr. iText or:\nHow I Learned to Stop Worrying\nand Love PDF.");
            //Cell cell = new Cell().Add(p);

            //// The phrase fits the fixed height
            //table.AddCell("set height (more than sufficient)");
            //cell.SetHeight(172);

            //// In iText7 a cell is meant to be used only once in the table.
            //// If you want to reuse it, please clone it (either including the content or not)
            //table.AddCell(cell.Clone(true));

            //// the phrase doesn't fit the fixed height
            //table.AddCell("set height (not sufficient)");
            //cell.SetHeight(36);
            //table.AddCell(cell.Clone(true));

            //// The minimum height is exceeded
            //table.AddCell("minimum height");
            //cell = new Cell().Add(new Paragraph("Dr. iText"));
            //cell.SetMinHeight(70);
            //table.AddCell(cell.Clone(true));

            //// The last cell that should be extended
            //table.AddCell("extend last row");
            //cell.DeleteOwnProperty(Property.MIN_HEIGHT);
            //table.AddCell(cell.Clone(true));

            //table.SetExtendBottomRow(true);

            //doc.Add(table);

            //doc.Close();
            #endregion

            #region Centering text
            //PdfDocument pdfDoc = new PdfDocument(new PdfWriter(dest));
            //Document document = new Document(pdfDoc);
            //Rectangle pageSize = pdfDoc.GetDefaultPageSize();
            //float width = pageSize.GetWidth() - document.GetLeftMargin() - document.GetRightMargin();

            //SolidLine line = new SolidLine();
            //AddParagraphWithTabs(document, line, width);

            //// Draw a custom line to fill both sides, as it is described in iText5 example
            //MyLine customLine = new MyLine();
            //AddParagraphWithTabs(document, customLine, width);

            //document.Close();

            #endregion

            #region Colspan and rowspan
            //PdfDocument pdfDoc = new PdfDocument(new PdfWriter(dest));
            //Document doc = new Document(pdfDoc);

            //Table table = new Table(UnitValue.CreatePercentArray(4)).UseAllAvailableWidth();
            //Cell cell = new Cell().Add(new Paragraph(" 1,1 "));
            //table.AddCell(cell);

            //cell = new Cell().Add(new Paragraph(" 1,2 "));
            //table.AddCell(cell);

            //Cell cell23 = new Cell(2, 2).Add(new Paragraph("multi 1,3 and 1,4"));
            //table.AddCell(cell23);

            //cell = new Cell().Add(new Paragraph(" 2,1 "));
            //table.AddCell(cell);

            //cell = new Cell().Add(new Paragraph(" 2,2 "));
            //table.AddCell(cell);

            //doc.Add(table);

            //doc.Close();
            #endregion

            #region Drawing a Grid
            //PdfDocument pdfDoc = new PdfDocument(new PdfWriter(dest));

            //PageSize pageSize = new PageSize(612, 792);
            //pdfDoc.SetDefaultPageSize(pageSize);

            //PdfCanvas canvas = new PdfCanvas(pdfDoc.AddNewPage());
            //for (float x = 0; x < pageSize.GetWidth(); x += 72f)
            //{
            //    for (float y = 0; y < pageSize.GetHeight(); y += 72f)
            //    {
            //        canvas.Circle(x, y, 1f);
            //    }
            //}

            //canvas.Fill();

            //pdfDoc.Close();
            #endregion

            #region Fit text in cell
            //PdfDocument pdfDoc = new PdfDocument(new PdfWriter(dest));
            //Document doc = new Document(pdfDoc);

            //Table table = new Table(UnitValue.CreatePercentArray(5)).UseAllAvailableWidth();

            //for (int r = 'A'; r <= 'Z'; r++)
            //{
            //    for (int c = 1; c <= 5; c++)
            //    {
            //        Cell cell = new Cell();
            //        if (r == 'D' && c == 2)
            //        {
            //            // Draw a content that will be clipped in the cell 
            //            cell.SetNextRenderer(new ClipCenterCellContentCellRenderer(cell,
            //                new Paragraph("D2 is a cell with more content than we can fit into the cell.")));
            //        }
            //        else
            //        {
            //            cell.Add(new Paragraph(((char)r).ToString() + c));
            //        }

            //        table.AddCell(cell);
            //    }
            //}

            //doc.Add(table);

            //doc.Close();
            #endregion

            #region Generating and displaying bar codes
            //PdfDocument pdfDoc = new PdfDocument(new PdfWriter(dest));
            //Document doc = new Document(pdfDoc);
            //Table table = new Table(UnitValue.CreatePercentArray(4)).UseAllAvailableWidth();

            //for (int i = 0; i < 12; i++)
            //{
            //    table.AddCell(CreateBarcode(string.Format("{0:d8}", i), pdfDoc));
            //}

            //doc.Add(table);

            //doc.Close();

            #endregion

            #region Header and footer examples
            //PdfDocument pdfDoc = new PdfDocument(new PdfReader(SRC), new PdfWriter(dest));
            //Document doc = new Document(pdfDoc);

            //Paragraph header = new Paragraph("Copy")
            //        .SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA))
            //        .SetFontSize(14)
            //        .SetFontColor(ColorConstants.RED);

            //for (int i = 1; i <= pdfDoc.GetNumberOfPages(); i++)
            //{
            //    Rectangle pageSize = pdfDoc.GetPage(i).GetPageSize();
            //    float x = pageSize.GetWidth() / 2;
            //    float y = pageSize.GetTop() - 20;
            //    doc.ShowTextAligned(header, x, y, i, TextAlignment.LEFT, VerticalAlignment.BOTTOM, 0);
            //}

            //doc.Close();
            #endregion

            #region Language-specific examples
            //PdfDocument pdfDoc = new PdfDocument(new PdfWriter(dest));
            //Document doc = new Document(pdfDoc);
            //PdfFont f = PdfFontFactory.CreateFont(FONT, PdfEncodings.IDENTITY_H);

            //// It is required to add iText typography dependency to handle correctly arabic text
            //Paragraph p = new Paragraph("This is auto detection: ");
            //p.Add(new Text("Hello 你支持中午吗 sssss").SetFont(f));
            //p.Add(new Text(": 50.00 USD"));
            //doc.Add(p);

            //doc.Close();
            #endregion


            #region Drawing lines
            //PdfDocument pdfDoc = new PdfDocument(new PdfWriter(dest));
            //PdfCanvas canvas = new PdfCanvas(pdfDoc.AddNewPage());
            //canvas.MoveTo(36, 36)
            //    .LineTo(36, 806)
            //    .LineTo(559, 36)
            //    .LineTo(559, 806)
            //    .ClosePathStroke();

            //pdfDoc.Close();
            #endregion

            #region 青岛四方焊接线 - 工位环境条件点检导出格式
            var titleFontSize = 20;
            var bodyFontSize = 8;
            var writer = new PdfWriter(dest);
            var pdf = new PdfDocument(writer);
            var document = new Document(pdf, PageSize.A4.Rotate());
            var f = PdfFontFactory.CreateFont(FONT, PdfEncodings.IDENTITY_H);

            document.Add(new Paragraph("工位环境条件点检表").SetFont(f).SetTextAlignment(TextAlignment.CENTER).SetFontSize(titleFontSize));

            //创建表格
            Table table = new Table(UnitValue.CreatePercentArray(35)).UseAllAvailableWidth();

            #region 表头
            table.AddCell(new Cell(1, 12).SetBorderRight(Border.NO_BORDER).Add(new Paragraph("班组:不锈钢地铁二号线激光焊1班").SetFont(f).SetTextAlignment(TextAlignment.LEFT)));
            table.AddCell(new Cell(1, 11).SetBorderLeft(Border.NO_BORDER).SetBorderRight(Border.NO_BORDER).Add(new Paragraph("工位:2020200").SetFont(f).SetTextAlignment(TextAlignment.CENTER)));
            table.AddCell(new Cell(1, 12).SetBorderLeft(Border.NO_BORDER).Add(new Paragraph("日期:202103").SetFont(f).SetTextAlignment(TextAlignment.RIGHT)));
            #endregion

            #region 第二行
            table.AddCell(new Cell(1, 1).SetFontSize(bodyFontSize).Add(new Paragraph("项目").SetFont(f).SetTextAlignment(TextAlignment.CENTER).SetHorizontalAlignment(HorizontalAlignment.CENTER)));
            table.AddCell(new Cell(1, 1).SetFontSize(bodyFontSize).Add(new Paragraph("标准").SetFont(f).SetTextAlignment(TextAlignment.CENTER).SetHorizontalAlignment(HorizontalAlignment.CENTER)));
            table.AddCell(new Cell(1, 1).SetFontSize(bodyFontSize).Add(new Paragraph("检查方式").SetFont(f).SetTextAlignment(TextAlignment.CENTER).SetHorizontalAlignment(HorizontalAlignment.CENTER)));
            table.AddCell(new Cell(1, 1).SetFontSize(bodyFontSize).Add(new Paragraph("点检时间").SetFont(f).SetTextAlignment(TextAlignment.RIGHT)));

            for (int i = 1; i <= 31; i++)
            {
                table.AddCell(new Cell(1, 1).SetFontSize(bodyFontSize).Add(new Paragraph(i.ToString()).SetFont(f).SetTextAlignment(TextAlignment.CENTER).SetHorizontalAlignment(HorizontalAlignment.CENTER)));
            }
            #endregion

            table.AddCell(new Cell(5, 1).SetFontSize(bodyFontSize).Add(new Paragraph("温度").SetFont(f).SetTextAlignment(TextAlignment.CENTER).SetHorizontalAlignment(HorizontalAlignment.CENTER)));
            table.AddCell(new Cell(5, 1).SetFontSize(bodyFontSize).Add(new Paragraph("≥8°C铝合金项目\r\n≥5°C不锈钢、碳钢项目").SetFont(f).SetTextAlignment(TextAlignment.CENTER).SetHorizontalAlignment(HorizontalAlignment.CENTER)));
            table.AddCell(new Cell(5, 1).SetFontSize(bodyFontSize).Add(new Paragraph("目视温湿度计").SetFont(f).SetTextAlignment(TextAlignment.CENTER).SetHorizontalAlignment(HorizontalAlignment.CENTER)));
            table.AddCell(new Cell(1, 1).SetFontSize(bodyFontSize).Add(new Paragraph("8:30").SetFont(f).SetTextAlignment(TextAlignment.CENTER).SetHorizontalAlignment(HorizontalAlignment.CENTER)));

            for (int i = 1; i <= 31; i++)
            {

                table.AddCell(new Cell(1, 1).SetFontSize(bodyFontSize).Add(new Paragraph(i.ToString()).SetFont(f).SetTextAlignment(TextAlignment.CENTER).SetHorizontalAlignment(HorizontalAlignment.CENTER)));
            }

            table.AddCell(new Cell(1, 1).SetFontSize(bodyFontSize).Add(new Paragraph("10:00").SetFont(f).SetTextAlignment(TextAlignment.CENTER).SetHorizontalAlignment(HorizontalAlignment.CENTER)));

            for (int i = 1; i <= 31; i++)
            {

                table.AddCell(new Cell(1, 1).SetFontSize(bodyFontSize).Add(new Paragraph(i.ToString()).SetFont(f).SetTextAlignment(TextAlignment.CENTER).SetHorizontalAlignment(HorizontalAlignment.CENTER)));
            }

            table.AddCell(new Cell(1, 1).SetFontSize(bodyFontSize).Add(new Paragraph("15:00").SetFont(f).SetTextAlignment(TextAlignment.CENTER).SetHorizontalAlignment(HorizontalAlignment.CENTER)));

            for (int i = 1; i <= 31; i++)
            {

                table.AddCell(new Cell(1, 1).SetFontSize(bodyFontSize).Add(new Paragraph(i.ToString()).SetFont(f).SetTextAlignment(TextAlignment.CENTER).SetHorizontalAlignment(HorizontalAlignment.CENTER)));
            }

            table.AddCell(new Cell(1, 1).SetFontSize(bodyFontSize).Add(new Paragraph("20:30").SetFont(f).SetTextAlignment(TextAlignment.CENTER).SetHorizontalAlignment(HorizontalAlignment.CENTER)));

            for (int i = 1; i <= 31; i++)
            {

                table.AddCell(new Cell(1, 1).SetFontSize(bodyFontSize).Add(new Paragraph(i.ToString()).SetFont(f).SetTextAlignment(TextAlignment.CENTER).SetHorizontalAlignment(HorizontalAlignment.CENTER)));
            }

            table.AddCell(new Cell(1, 1).SetFontSize(bodyFontSize).Add(new Paragraph("00:30").SetFont(f).SetTextAlignment(TextAlignment.CENTER).SetHorizontalAlignment(HorizontalAlignment.CENTER)));

            for (int i = 1; i <= 31; i++)
            {

                table.AddCell(new Cell(1, 1).SetFontSize(bodyFontSize).Add(new Paragraph(i.ToString()).SetFont(f).SetTextAlignment(TextAlignment.CENTER).SetHorizontalAlignment(HorizontalAlignment.CENTER)));
            }

            table.AddCell(new Cell(5, 1).SetFontSize(bodyFontSize).Add(new Paragraph("湿度").SetFont(f).SetTextAlignment(TextAlignment.CENTER).SetHorizontalAlignment(HorizontalAlignment.CENTER)));
            table.AddCell(new Cell(5, 1).SetFontSize(bodyFontSize).Add(new Paragraph("	≤80%").SetFont(f).SetTextAlignment(TextAlignment.CENTER).SetHorizontalAlignment(HorizontalAlignment.CENTER)));
            table.AddCell(new Cell(5, 1).SetFontSize(bodyFontSize).Add(new Paragraph("目视温湿度计").SetFont(f).SetTextAlignment(TextAlignment.CENTER).SetHorizontalAlignment(HorizontalAlignment.CENTER)));
            table.AddCell(new Cell(1, 1).SetFontSize(bodyFontSize).Add(new Paragraph("8:30").SetFont(f).SetTextAlignment(TextAlignment.CENTER).SetHorizontalAlignment(HorizontalAlignment.CENTER)));

            for (int i = 1; i <= 31; i++)
            {

                table.AddCell(new Cell(1, 1).SetFontSize(bodyFontSize).Add(new Paragraph(i.ToString()).SetFont(f).SetTextAlignment(TextAlignment.CENTER).SetHorizontalAlignment(HorizontalAlignment.CENTER)));
            }

            table.AddCell(new Cell(1, 1).SetFontSize(bodyFontSize).Add(new Paragraph("10:00").SetFont(f).SetTextAlignment(TextAlignment.CENTER).SetHorizontalAlignment(HorizontalAlignment.CENTER)));

            for (int i = 1; i <= 31; i++)
            {

                table.AddCell(new Cell(1, 1).SetFontSize(bodyFontSize).Add(new Paragraph(i.ToString()).SetFont(f).SetTextAlignment(TextAlignment.CENTER).SetHorizontalAlignment(HorizontalAlignment.CENTER)));
            }

            table.AddCell(new Cell(1, 1).SetFontSize(bodyFontSize).Add(new Paragraph("15:00").SetFont(f).SetTextAlignment(TextAlignment.CENTER).SetHorizontalAlignment(HorizontalAlignment.CENTER)));

            for (int i = 1; i <= 31; i++)
            {

                table.AddCell(new Cell(1, 1).SetFontSize(bodyFontSize).Add(new Paragraph(i.ToString()).SetFont(f).SetTextAlignment(TextAlignment.CENTER).SetHorizontalAlignment(HorizontalAlignment.CENTER)));
            }

            table.AddCell(new Cell(1, 1).SetFontSize(bodyFontSize).Add(new Paragraph("20:30").SetFont(f).SetTextAlignment(TextAlignment.CENTER).SetHorizontalAlignment(HorizontalAlignment.CENTER)));

            for (int i = 1; i <= 31; i++)
            {

                table.AddCell(new Cell(1, 1).SetFontSize(bodyFontSize).Add(new Paragraph(i.ToString()).SetFont(f).SetTextAlignment(TextAlignment.CENTER).SetHorizontalAlignment(HorizontalAlignment.CENTER)));
            }

            table.AddCell(new Cell(1, 1).SetFontSize(bodyFontSize).Add(new Paragraph("00:30").SetFont(f).SetTextAlignment(TextAlignment.CENTER).SetHorizontalAlignment(HorizontalAlignment.CENTER)));

            for (int i = 1; i <= 31; i++)
            {

                table.AddCell(new Cell(1, 1).SetFontSize(bodyFontSize).Add(new Paragraph(i.ToString()).SetFont(f).SetTextAlignment(TextAlignment.CENTER).SetHorizontalAlignment(HorizontalAlignment.CENTER)));
            }

            #endregion

            document.Add(table);

            document.Close();
        }

        private static Cell CreateBarcode(string code, PdfDocument pdfDoc)
        {
            BarcodeEAN barcode = new BarcodeEAN(pdfDoc);
            barcode.SetCodeType(BarcodeEAN.EAN8);
            barcode.SetCode(code);

            // Create barcode object to put it to the cell as image
            PdfFormXObject barcodeObject = barcode.CreateFormXObject(null, null, pdfDoc);
            Cell cell = new Cell().Add(new Image(barcodeObject));
            cell.SetPaddingTop(10);
            cell.SetPaddingRight(10);
            cell.SetPaddingBottom(10);
            cell.SetPaddingLeft(10);

            return cell;
        }

        private class ClipCenterCellContentCellRenderer : CellRenderer
        {
            private Paragraph content;

            public ClipCenterCellContentCellRenderer(Cell modelElement, Paragraph content)
                : base(modelElement)
            {
                this.content = content;
            }

            // If renderer overflows on the next area, iText uses getNextRender() method to create a renderer for the overflow part.
            // If getNextRenderer isn't overriden, the default method will be used and thus a default rather than custom
            // renderer will be created
            public override IRenderer GetNextRenderer()
            {
                return new ClipCenterCellContentCellRenderer((Cell)modelElement, content);
            }

            public override void Draw(DrawContext drawContext)
            {

                // Fictitiously layout the renderer and find out, how much space does it require
                IRenderer pr = content.CreateRendererSubTree().SetParent(this);

                LayoutResult textArea = pr.Layout(new LayoutContext(
                    new LayoutArea(0, new Rectangle(GetOccupiedAreaBBox().GetWidth(), 1000))));

                float spaceNeeded = textArea.GetOccupiedArea().GetBBox().GetHeight();
                Console.WriteLine("The content requires {0} pt whereas the height is {1} pt.",
                    spaceNeeded, GetOccupiedAreaBBox().GetHeight());

                float offset = (GetOccupiedAreaBBox().GetHeight() - textArea.GetOccupiedArea()
                                    .GetBBox().GetHeight()) / 2;
                Console.WriteLine("The difference is {0} pt; we'll need an offset of {1} pt.",
                    -2f * offset, offset);

                PdfFormXObject xObject = new PdfFormXObject(new Rectangle(GetOccupiedAreaBBox().GetWidth(),
                    GetOccupiedAreaBBox().GetHeight()));

                Canvas layoutCanvas = new Canvas(new PdfCanvas(xObject, drawContext.GetDocument()),
                    new Rectangle(0, offset, GetOccupiedAreaBBox().GetWidth(), spaceNeeded));
                layoutCanvas.Add(content);

                drawContext.GetCanvas().AddXObjectAt(xObject, occupiedArea.GetBBox().GetLeft(),
                    occupiedArea.GetBBox().GetBottom());
            }
        }

        private static void AddParagraphWithTabs(Document document, ILineDrawer line, float width)
        {
            List<TabStop> tabStops = new List<TabStop>();

            // Create a TabStop at the middle of the page
            tabStops.Add(new TabStop(width / 2, TabAlignment.CENTER, line));

            // Create a TabStop at the end of the page
            tabStops.Add(new TabStop(width, TabAlignment.LEFT, line));

            Paragraph p = new Paragraph().AddTabStops(tabStops);
            p
                .Add(new Tab())
                .Add("Text in the middle")
                .Add(new Tab());
            document.Add(p);
        }

        private class MyLine : ILineDrawer
        {
            private float lineWidth = 1;
            private float offset = 2.02f;
            private Color color = ColorConstants.BLACK;

            public void Draw(PdfCanvas canvas, Rectangle drawArea)
            {
                float coordY = drawArea.GetY() + lineWidth / 2 + offset;
                canvas
                    .SaveState()
                    .SetStrokeColor(color)
                    .SetLineWidth(lineWidth)
                    .MoveTo(drawArea.GetX(), coordY)
                    .LineTo(drawArea.GetX() + drawArea.GetWidth(), coordY)
                    .Stroke()
                    .RestoreState();
            }

            public float GetLineWidth()
            {
                return lineWidth;
            }

            public void SetLineWidth(float lineWidth)
            {
                this.lineWidth = lineWidth;
            }

            public Color GetColor()
            {
                return color;
            }

            public void SetColor(Color color)
            {
                this.color = color;
            }

            public float GetOffset()
            {
                return offset;
            }

            public void SetOffset(float offset)
            {
                this.offset = offset;
            }
        }
    }
}
