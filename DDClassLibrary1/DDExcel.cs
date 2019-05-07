using GrapeCity.Documents.Excel;
using System;

namespace DDClassLibrary1
{
    public class DDExcel
    {
        public static void Create(string platformname)
        {
            // ワークブックの作成
            Workbook workbook = new Workbook();

            // ワークシートの取得
            IWorksheet worksheet = workbook.Worksheets[0];

            // セル範囲を指定して文字列を設定
            worksheet.Range["B2"].Value = "Hello World!";
            worksheet.Range["C2"].Value = "from " + platformname;

            // Excelファイルとして保存
            workbook.Save("Result.xlsx");
        }
    }
}
