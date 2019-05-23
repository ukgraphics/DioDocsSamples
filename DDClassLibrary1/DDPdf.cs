﻿using DDClassLibrary1.Properties;
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
            // トライアル用
            string key = Resources.ResourceManager.GetString("DdPdfLicenseString");
            GcPdfDocument.SetLicenseKey(key);

            // PDFドキュメントを作成します。
            GcPdfDocument doc = new GcPdfDocument();

            // ページを追加し、そのグラフィックスを取得します。
            GcPdfGraphics g = doc.NewPage().Graphics;

            // ページに文字列を描画します。
            g.DrawString("Hello, de:code 2019!" + Environment.NewLine + "from " + platformname,
                new TextFormat() { Font = StandardFonts.Helvetica, FontSize = 12 },
                new PointF(72, 72));

            // メモリストリームに保存
            MemoryStream ms = new MemoryStream();
            doc.Save(ms, false);
            ms.Seek(0, SeekOrigin.Begin);

            // BLOBストレージにアップロード
            AzStorage.UploadPdfAsync(ms);
        }
    }
}
