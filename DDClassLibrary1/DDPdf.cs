using GrapeCity.Documents.Pdf;
using GrapeCity.Documents.Text;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace DDClassLibrary1
{
    public class DDPdf
    {
        public static void Create(string platformname)
        {
            // PDFドキュメントを作成します。
            GcPdfDocument doc = new GcPdfDocument();

            // ページを追加し、そのグラフィックスを取得します。
            GcPdfGraphics g = doc.NewPage().Graphics;

            // ページに文字列を描画します。
            g.DrawString("Hello, World!" + Environment.NewLine + "from " + platformname,
                new TextFormat() { Font = StandardFonts.Times, FontSize = 12 },
                new PointF(72, 72));

            // PDFを保存します。
            doc.Save("Result.pdf");

            // メモリストリームに保存
            MemoryStream ms = new MemoryStream();
            doc.Save(ms, false);
            ms.Seek(0, SeekOrigin.Begin);

            // BLOBストレージにアップロード
            AzStorage.UploadPdfAsync(ms);
        }
    }
}
