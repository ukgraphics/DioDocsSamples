using DDClassLibrary1.Properties;
using GrapeCity.Documents.Excel;
using System;
using System.IO;

namespace DDClassLibrary1
{
    public class DDExcel
    {
        public static void Create(string platformname)
        {
            // トライアル用
            string key = Resources.ResourceManager.GetString("DdExcelLicenseString");
            Workbook.SetLicenseKey(key);

            // ワークブックの作成
            Workbook workbook = new Workbook();

            // ワークシートの取得
            IWorksheet worksheet = workbook.Worksheets[0];

            // セル範囲を指定して文字列を設定
            worksheet.Range["B2"].Value = "Hello de:code 2019";
            worksheet.Range["B3"].Value = "from " + platformname;

            // メモリストリームに保存
            MemoryStream ms = new MemoryStream();
            workbook.Save(ms, SaveFileFormat.Xlsx);
            ms.Seek(0, SeekOrigin.Begin);

            // BLOBストレージにアップロード
            AzStorage.UploadExcelAsync(ms);
        }
    }
}
