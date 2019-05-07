using GrapeCity.Documents.Pdf;
using GrapeCity.Documents.Text;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace DDClassLibrary1
{
    public class DDPdf
    {
        public static void Create(string platformname)
        {
            // 新規 PDF ドキュメントを作成します。
            GcPdfDocument doc = new GcPdfDocument();

            // ページを追加し、そのグラフィックスを取得します。
            GcPdfGraphics g = doc.NewPage().Graphics;

            // ページに文字列を描画します。
            // メモ:
            // - GcPdf のページ座標は、デフォルトで 72 dpi を使用して左上隅から始まります。
            // - 標準のフォントを使用します（14個の標準 PDF フォントは GcPdf に組み込まれており、
            //   常に利用可能です）：
            g.DrawString("Hello, World!" + Environment.NewLine + "from " + platformname,
                new TextFormat() { Font = StandardFonts.Times, FontSize = 12 },
                new PointF(72, 72));

            // PDF を保存します。
            doc.Save("Result.pdf");
        }
    }
}
