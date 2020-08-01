using Aspose.Words;
using Aspose.Words.Tables;
using System.Drawing;

namespace AposeProject
{
    /// <summary>
    /// Aspose.Words使用教程大全:https://blog.csdn.net/ibigpig/article/details/8432245
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //常规操作
            //Sample1.Demonstration();

            //插入表格并合并单元格
            Sample2.Demonstration();

            //插入页眉
            //Sample3.Demonstration();
        }
    }

    internal class Sample1
    {
        internal static void Demonstration()
        {
            Document doc = new Document();
            //这里面的`builder`相当于一个画笔，提前给他规定样式，然后他就能根据你的要求画出你想画的Word。
            //这里的画笔使用的是就近原则，当上面没有定义了builder的时候，会使用默认的格式，当上面定义了某个格式的时候，使用最近的一个（即最后一个改变的样式）
            DocumentBuilder builder = new DocumentBuilder(doc);

            //设定Word页面的样式
            builder.PageSetup.PaperSize = PaperSize.A4;//A4纸
            builder.PageSetup.Orientation = Orientation.Portrait;//方向
            builder.PageSetup.VerticalAlignment = PageVerticalAlignment.Top;//垂直对准
            builder.PageSetup.LeftMargin = 42;//页面左边距
            builder.PageSetup.RightMargin = 42;//页面右边距

            //写入一段文字
            //获取ParagraphFormat对象，关于行的样式基本都在这里
            var ph = builder.ParagraphFormat;
            //文字对齐方式
            ph.Alignment = ParagraphAlignment.Center;
            // 单倍行距 = 12 ， 1.5 倍 = 18
            ph.LineSpacing = 12;

            //获取Font对象，关于文字的大小，颜色，字体等等基本都在这个里面
            Aspose.Words.Font font = builder.Font;
            //字体大小
            font.Size = 22;
            //是否粗体
            font.Bold = false;
            //下划线样式，None为无下划线
            font.Underline = Underline.None;
            //字体颜色
            font.Color = Color.Black;//C#的颜色
            font.Color = System.Drawing.ColorTranslator.FromHtml("#3b3131");//自定义颜色
                                                                            //设置字体
            font.NameFarEast = "宋体";
            //添加文字
            builder.Write("添加的文字");
            //添加回车
            builder.Writeln();
            //添加文字后回车
            builder.Writeln("添加的文字后回车");

            //添加图片
            //builder.InsertImage("图片绝对地址");
            //builder.InsertImage("图片绝对地址", 80, 80);//可以控制图片的宽高

            //添加表格
            Table table = builder.StartTable();
            //开始添加第一行，并设置表格行高
            RowFormat rowf = builder.RowFormat;
            rowf.Height = 40;
            // ....这里rowf可以有很多的设置
            //插入一个单元格
            builder.InsertCell();
            //设置单元格是否水平合并，None为不合并
            builder.CellFormat.HorizontalMerge = CellMerge.None;
            //设置单元格是否垂直合并，None为不合并
            builder.CellFormat.VerticalMerge = CellMerge.None;
            //设置单元格宽
            builder.CellFormat.Width = 40;
            //单元格垂直对齐方向
            builder.CellFormat.VerticalAlignment = CellVerticalAlignment.Center;
            //单元格水平对齐方向
            builder.ParagraphFormat.Alignment = ParagraphAlignment.Left;
            //单元格内文字设为多行（默认为单行，会影响单元格宽）
            builder.CellFormat.FitText = true;
            //单元格内添加文字
            builder.Write("这是第一行第一个单元格");
            builder.InsertCell();
            //当不需要规定这个单元格的宽度的时候，设置成-1，会是自动宽度
            builder.CellFormat.Width = -1;
            builder.Write("这是第一行第二个单元格");
            //结束第一行
            builder.EndRow();
            //结束表格
            builder.EndTable();
            //设置这个表格的上下左右，内部水平，垂直的线为白色（当背景为白色的时候就相当于隐藏边框了）
            table.SetBorder(BorderType.Left, LineStyle.Double, 1, Color.White, false);
            table.SetBorder(BorderType.Top, LineStyle.Double, 1, Color.White, false);
            table.SetBorder(BorderType.Right, LineStyle.Double, 1, Color.White, false);
            table.SetBorder(BorderType.Bottom, LineStyle.Double, 1, Color.White, false);
            table.SetBorder(BorderType.Vertical, LineStyle.Double, 1, Color.White, false);

            //表格的合并单元格
            //横向合并单元格
            builder.CellFormat.HorizontalMerge = CellMerge.None;
            builder.CellFormat.HorizontalMerge = CellMerge.First;
            builder.CellFormat.HorizontalMerge = CellMerge.Previous;
            //纵向合并单元格
            builder.CellFormat.VerticalMerge = CellMerge.None;
            builder.CellFormat.VerticalMerge = CellMerge.First;
            builder.CellFormat.VerticalMerge = CellMerge.Previous;

            doc.Save("DocumentBuilder.CreateFormattedTable Out.doc");
        }
    }

    internal class Sample2
    {
        internal static void Demonstration()
        {
            Document doc = new Document();
            DocumentBuilder builder = new DocumentBuilder(doc);

            //设定Word页面的样式
            builder.PageSetup.PaperSize = PaperSize.A4;//A4纸
            builder.PageSetup.Orientation = Orientation.Portrait;//方向
            builder.PageSetup.VerticalAlignment = PageVerticalAlignment.Top;//垂直对准
            builder.PageSetup.LeftMargin = 22;//页面左边距
            builder.PageSetup.RightMargin = 22;//页面右边距

            //设置单元格宽
            builder.RowFormat.Height = 20;

            //获取ParagraphFormat对象，关于行的样式基本都在这里
            var ph = builder.ParagraphFormat;
            //文字对齐方式
            ph.Alignment = ParagraphAlignment.Center;
            // 单倍行距 = 12 ， 1.5 倍 = 18
            ph.LineSpacing = 12;

            //获取Font对象，关于文字的大小，颜色，字体等等基本都在这个里面
            Aspose.Words.Font font = builder.Font;
            //字体大小
            font.Size = 10.5;
            //是否粗体
            font.Bold = false;
            //下划线样式，None为无下划线
            font.Underline = Underline.None;
            //字体颜色
            font.Color = Color.Black;
            //自定义颜色
            font.Color = ColorTranslator.FromHtml("#3b3131");
            //设置字体
            font.NameFarEast = "宋体";

            // Go to the primary footer
            builder.MoveToHeaderFooter(HeaderFooterType.HeaderPrimary);

            #region 页眉表头

            builder.StartTable();

            InsertCell(builder, "中车青岛四方股份", CellMerge.First, CellMerge.None);
            InsertCell(builder, string.Empty, CellMerge.Previous, CellMerge.None);

            InsertCell(builder, "产品质量确认表", CellMerge.First, CellMerge.None);
            InsertCell(builder, string.Empty, CellMerge.Previous, CellMerge.None);

            InsertCell(builder, "版本号:05", CellMerge.First, CellMerge.None);
            InsertCell(builder, string.Empty, CellMerge.Previous, CellMerge.None);

            builder.EndRow();

            InsertCell(builder, "产品名称");
            InsertCell(builder, "青岛地铁8号线");

            InsertCell(builder, "确认表名称");
            InsertCell(builder, "中部骨架组成");

            InsertCell(builder, "文件编号");
            InsertCell(builder, "质-SFM71TC1-T-695");

            builder.EndRow();

            InsertCell(builder, "使用单位");
            InsertCell(builder, "车体分厂、质管部");

            InsertCell(builder, "施工班组");
            InsertCell(builder, "激光焊");

            InsertCell(builder, "生产编号");
            InsertCell(builder, string.Empty);

            builder.EndRow();

            InsertCell(builder, "班长/日期");
            InsertCell(builder, string.Empty);

            InsertCell(builder, "图号");
            InsertCell(builder, string.Empty);

            InsertCell(builder, "检查/日期");
            InsertCell(builder, string.Empty);

            builder.EndRow();

            builder.EndTable();
            #endregion

            // Go to the primary footer
            builder.MoveToDocumentStart();

            //设置单元格宽
            builder.RowFormat.Height = 40;

            #region 设置检测项点
            builder.StartTable();

            //表格头部行

            InsertCell(builder, "序号", CellMerge.None, CellMerge.None);
            InsertCell(builder, "检测项点", CellMerge.None, CellMerge.None);
            InsertCell(builder, "检验标准", CellMerge.None, CellMerge.None);
            InsertCell(builder, "检查方法", CellMerge.None, CellMerge.None);
            InsertCell(builder, "检测结果", CellMerge.None, CellMerge.None);
            InsertCell(builder, "自检/日期", CellMerge.None, CellMerge.None);
            InsertCell(builder, "互检/日期", CellMerge.None, CellMerge.None);
            InsertCell(builder, "质量分级", CellMerge.None, CellMerge.None);

            builder.EndRow();

            //表格数据行

            InsertCell(builder, "1", CellMerge.None, CellMerge.None);
            InsertCell(builder, "○来料检查", CellMerge.None, CellMerge.None);
            InsertCell(builder, "符合图纸、工艺文件要求", CellMerge.None, CellMerge.None);
            InsertCell(builder, "目视、Ⅰ级5m钢卷尺", CellMerge.None, CellMerge.None);
            InsertCell(builder, "", CellMerge.None, CellMerge.None);
            InsertCell(builder, "", CellMerge.None, CellMerge.None);
            InsertCell(builder, "", CellMerge.None, CellMerge.None);
            InsertCell(builder, "C", CellMerge.None, CellMerge.None);

            builder.EndRow();

            InsertCell(builder, "2", CellMerge.None, CellMerge.None);
            InsertCell(builder, "○激光焊工装、工件焊缝处表面清理", CellMerge.None, CellMerge.None);
            InsertCell(builder, "无油污、杂质", CellMerge.None, CellMerge.None);
            InsertCell(builder, "目视", CellMerge.None, CellMerge.None);
            InsertCell(builder, "", CellMerge.None, CellMerge.None);
            InsertCell(builder, "", CellMerge.None, CellMerge.None);
            InsertCell(builder, "", CellMerge.None, CellMerge.None);
            InsertCell(builder, "C", CellMerge.None, CellMerge.None);

            builder.EndRow();

            InsertCell(builder, "3", CellMerge.None, CellMerge.First);
            InsertCell(builder, "○激光焊缝处间隙", CellMerge.None, CellMerge.First);
            InsertCell(builder, "≤0.15mm", CellMerge.None, CellMerge.First);
            InsertCell(builder, "塞尺", CellMerge.None, CellMerge.First);
            InsertCell(builder, "墙板：", CellMerge.None, CellMerge.None);
            InsertCell(builder, "", CellMerge.None, CellMerge.First);
            InsertCell(builder, "", CellMerge.None, CellMerge.First);
            InsertCell(builder, "B", CellMerge.None, CellMerge.First);

            builder.EndRow();

            InsertCell(builder, "3", CellMerge.None, CellMerge.Previous);
            InsertCell(builder, "○激光焊缝处间隙", CellMerge.None, CellMerge.Previous);
            InsertCell(builder, "≤0.15mm", CellMerge.None, CellMerge.Previous);
            InsertCell(builder, "塞尺", CellMerge.None, CellMerge.Previous);
            InsertCell(builder, "窗框：", CellMerge.None, CellMerge.None);
            InsertCell(builder, "", CellMerge.None, CellMerge.Previous);
            InsertCell(builder, "", CellMerge.None, CellMerge.Previous);
            InsertCell(builder, "B", CellMerge.None, CellMerge.Previous);

            builder.EndRow();

            InsertCell(builder, "3", CellMerge.None, CellMerge.Previous);
            InsertCell(builder, "○激光焊缝处间隙", CellMerge.None, CellMerge.Previous);
            InsertCell(builder, "≤0.15mm", CellMerge.None, CellMerge.Previous);
            InsertCell(builder, "塞尺", CellMerge.None, CellMerge.Previous);
            InsertCell(builder, "横梁：", CellMerge.None, CellMerge.None);
            InsertCell(builder, "", CellMerge.None, CellMerge.Previous);
            InsertCell(builder, "", CellMerge.None, CellMerge.Previous);
            InsertCell(builder, "B", CellMerge.None, CellMerge.Previous);

            builder.EndRow();

            //焊接督查签字/日期
            InsertCell(builder, "焊接督查签字/日期", CellMerge.First, CellMerge.None);
            InsertCell(builder, "", CellMerge.Previous, CellMerge.None);
            InsertCell(builder, "", CellMerge.First, CellMerge.None);
            InsertCell(builder, "", CellMerge.Previous, CellMerge.None);
            InsertCell(builder, "", CellMerge.Previous, CellMerge.None);
            InsertCell(builder, "", CellMerge.Previous, CellMerge.None);
            InsertCell(builder, "", CellMerge.Previous, CellMerge.None);
            InsertCell(builder, "", CellMerge.Previous, CellMerge.None);

            builder.EndRow();

            //焊接督查签字/日期
            InsertCell(builder, "图号（版本号）", CellMerge.None, CellMerge.None);
            InsertCell(builder, "焊缝编号", CellMerge.None, CellMerge.None);
            InsertCell(builder, "返修人员", CellMerge.None, CellMerge.None);
            InsertCell(builder, "缺陷种类", CellMerge.None, CellMerge.None);
            InsertCell(builder, "缺陷描述", CellMerge.First, CellMerge.None);
            InsertCell(builder, "", CellMerge.Previous, CellMerge.None);
            InsertCell(builder, "", CellMerge.Previous, CellMerge.None);
            InsertCell(builder, "返修次数", CellMerge.None, CellMerge.None);

            builder.EndRow();

            for (int i = 0; i < 10; i++)
            {
                //焊接督查签字/日期
                InsertCell(builder, "", CellMerge.None, CellMerge.None);
                InsertCell(builder, "", CellMerge.None, CellMerge.None);
                InsertCell(builder, "", CellMerge.None, CellMerge.None);
                InsertCell(builder, "", CellMerge.None, CellMerge.None);
                InsertCell(builder, "", CellMerge.First, CellMerge.None);
                InsertCell(builder, "", CellMerge.Previous, CellMerge.None);
                InsertCell(builder, "", CellMerge.Previous, CellMerge.None);
                InsertCell(builder, "", CellMerge.None, CellMerge.None);

                builder.EndRow();
            }

            //说明/备注
            InsertCell(builder, @"说明：
1、结果栏：合格……○  不合格……×  修理后 合格……在×上画○，有具体数据的由自检填写实测值；自检栏/互检栏：由自检人员和互检人员签名确认；对于集体作业项自检栏填写全部操作者；
2、本表适用于各车型中部单元。
3、标“○”项点为自检、互检检测项点。
4、焊接监督签字仅对本表中焊接相关的项点负责。
5、检查项点第3~4项，墙板和横梁焊缝长度小于1000mm塞尺均匀测3处，大于1000mm均匀测5处，目视间隙较大的增加测量；检查频次100%，只记录最终结果。
6、关于焊修记录的说明：缺陷位置描述仅适用于一个焊缝编号有多条焊缝的情况，描述精确到缺陷所在的具体焊缝，其余划“/”；当一条焊缝自检、互检、无损检测有返修，专检也有返修时，在返修次数栏进行划改，划改处加盖质量工程师印章。", CellMerge.First, CellMerge.None, LineStyle.Single, CellVerticalAlignment.Top, ParagraphAlignment.Left);
            InsertCell(builder, "", CellMerge.Previous, CellMerge.None);
            InsertCell(builder, "", CellMerge.Previous, CellMerge.None);
            InsertCell(builder, "", CellMerge.Previous, CellMerge.None);
            InsertCell(builder, " 备注:", CellMerge.First, CellMerge.None, LineStyle.Single, CellVerticalAlignment.Top, ParagraphAlignment.Left);
            InsertCell(builder, "", CellMerge.Previous, CellMerge.None);
            InsertCell(builder, "", CellMerge.Previous, CellMerge.None);
            InsertCell(builder, "", CellMerge.Previous, CellMerge.None);

            builder.EndRow();

            builder.EndTable();
            #endregion

            doc.Save("DocumentBuilder.CreateFormattedTable Out.doc");
        }

        private static void InsertCell(
            DocumentBuilder builder,
            string cellContext,
            CellMerge horizontalMerge = CellMerge.None,
            CellMerge verticalMerge = CellMerge.None,
            LineStyle lineStyle = LineStyle.Single,
            CellVerticalAlignment cellVerticalAlignment = CellVerticalAlignment.Center,
            ParagraphAlignment alignment = ParagraphAlignment.Center
            )
        {
            builder.InsertCell();
            builder.CellFormat.Borders.LineStyle = lineStyle;
            builder.CellFormat.Borders.Color = Color.Black;

            //单元格垂直对齐方向
            builder.CellFormat.VerticalAlignment = cellVerticalAlignment;

            //单元格水平对齐方向
            builder.ParagraphFormat.Alignment = alignment;

            builder.CellFormat.HorizontalMerge = horizontalMerge;
            builder.CellFormat.VerticalMerge = verticalMerge;

            builder.Write(cellContext);
        }
    }

    internal class Sample3
    {
        internal static void Demonstration()
        {
            Document doc = new Document();
            //这里面的`builder`相当于一个画笔，提前给他规定样式，然后他就能根据你的要求画出你想画的Word。
            //这里的画笔使用的是就近原则，当上面没有定义了builder的时候，会使用默认的格式，当上面定义了某个格式的时候，使用最近的一个（即最后一个改变的样式）
            DocumentBuilder builder = new DocumentBuilder(doc);

            //设定Word页面的样式
            builder.PageSetup.PaperSize = PaperSize.A4;//A4纸
            builder.PageSetup.Orientation = Orientation.Portrait;//方向
            builder.PageSetup.VerticalAlignment = PageVerticalAlignment.Top;//垂直对准
            builder.PageSetup.LeftMargin = 22;//页面左边距
            builder.PageSetup.RightMargin = 22;//页面右边距

            //写入一段文字
            //获取ParagraphFormat对象，关于行的样式基本都在这里
            var ph = builder.ParagraphFormat;
            //文字对齐方式
            ph.Alignment = ParagraphAlignment.Center;
            // 单倍行距 = 12 ， 1.5 倍 = 18
            ph.LineSpacing = 12;

            //获取Font对象，关于文字的大小，颜色，字体等等基本都在这个里面
            Aspose.Words.Font font = builder.Font;
            //字体大小
            font.Size = 10.5;
            //是否粗体
            font.Bold = false;
            //下划线样式，None为无下划线
            font.Underline = Underline.None;
            //字体颜色
            font.Color = Color.Black;
            //自定义颜色
            font.Color = ColorTranslator.FromHtml("#3b3131");
            //设置字体
            font.NameFarEast = "宋体";

            // Go to the primary footer
            builder.MoveToHeaderFooter(HeaderFooterType.HeaderPrimary);

            builder.StartTable();

            builder.InsertCell();

            builder.InsertCell();
            builder.CellFormat.HorizontalMerge = CellMerge.Previous;
            builder.Write("中车青岛四方股份");

            builder.InsertCell();

            builder.InsertCell();
            builder.CellFormat.HorizontalMerge = CellMerge.Previous;
            builder.Write("产品质量确认表");

            builder.InsertCell();

            builder.InsertCell();
            builder.CellFormat.HorizontalMerge = CellMerge.Previous;
            builder.Write("中车青岛四方股份");

            builder.EndRow();

            builder.InsertCell();
            builder.Write("产品名称");

            builder.InsertCell();
            builder.Write("青岛地铁8号线");

            builder.InsertCell();
            builder.Write("确认表名称");

            builder.InsertCell();
            builder.Write("中部骨架组成");

            builder.InsertCell();
            builder.Write("文件编号");

            builder.InsertCell();
            builder.Write("质-SFM71TC1-T-695");

            builder.EndRow();

            builder.InsertCell();
            builder.Write("使用单位");

            builder.InsertCell();
            builder.Write("车体分厂、质管部");

            builder.InsertCell();
            builder.Write("施工班组");

            builder.InsertCell();
            builder.Write("激光焊");

            builder.InsertCell();
            builder.Write("生产编号");

            builder.InsertCell();
            builder.Write("生产编号");

            builder.EndRow();

            builder.InsertCell();
            builder.Write("班长/日期");

            builder.InsertCell();
            builder.Write("2020-07-30");

            builder.InsertCell();
            builder.Write("图号");

            builder.InsertCell();
            builder.Write("2020-07-30");

            builder.InsertCell();
            builder.Write("检查/日期");

            builder.InsertCell();
            builder.Write("2020-07-30");

            builder.EndRow();

            //builder.insert

            builder.EndTable();

            doc.Save("DocumentBuilder.CreateFormattedTable Out.doc");
        }
    }
}
