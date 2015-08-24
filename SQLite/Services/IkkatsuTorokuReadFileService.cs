using SQLite.Services;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WordConverter.Common;
using WordConverter.Models.InBo;
using WordConverter.Models.OutBo;
using WordConvertTool;
using WordConvTool.Model;

namespace WordConverter.Services
{
    class IkkatsuTorokuReadFileService : IService<IkkatsuTorokuReadFileServiceInBo, IkkatsuTorokuReadFileServiceOutBo>
    {
        /// <summary>
        /// 共通関数インクルード
        /// </summary>
        private static CommonFunction common = new CommonFunction();
        private IkkatsuTorokuReadFileServiceInBo inBo = new IkkatsuTorokuReadFileServiceInBo();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inBo"></param>
        public void setInBo(IkkatsuTorokuReadFileServiceInBo inBo)
        {
            this.inBo = inBo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IkkatsuTorokuReadFileServiceOutBo execute()
        {
            IkkatsuTorokuReadFileServiceOutBo outBo = new IkkatsuTorokuReadFileServiceOutBo();
            
            Microsoft.Office.Interop.Excel.Application oExcelApp = null; // Excelオブジェクト
            Microsoft.Office.Interop.Excel.Workbook oExcelWBook = null;  // Excel Workbookオブジェクト
            try
            {
                oExcelApp = new Microsoft.Office.Interop.Excel.Application();
                oExcelApp.DisplayAlerts = false; // Excelの確認ダイアログ表示有無
                oExcelApp.Visible = false;       // Excel表示有無
                // Excelファイルをオープンする(第一パラメタ以外は省略可)
                oExcelWBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcelApp.Workbooks.Open(
                  this.inBo.Filename,      // Filename
                  Type.Missing,  // UpdateLinks
                  Type.Missing,  // ReadOnly
                  Type.Missing,  // Format
                  Type.Missing,  // Password
                  Type.Missing,  // WriteResPassword
                  Type.Missing,  // IgnoreReadOnlyRecommended
                  Type.Missing,  // Origin
                  Type.Missing,  // Delimiter
                  Type.Missing,  // Editable
                  Type.Missing,  // Notify
                  Type.Missing,  // Converter
                  Type.Missing,  // AddToMru
                  Type.Missing,  // Local
                  Type.Missing   // CorruptLoad
                ));

                Microsoft.Office.Interop.Excel._Worksheet oWSheet =
                    (Microsoft.Office.Interop.Excel._Worksheet)oExcelWBook.ActiveSheet;

                int RONRI_NAME1 = 1;
                int BUTSURI_NAME = 2;
                int rowId = 2;

                using (var context = new WordConvertTool.MyContext())
                {
                    while (!String.IsNullOrEmpty(oWSheet.Cells[rowId, RONRI_NAME1].Value))
                    {
                        string ronriName = oWSheet.Cells[rowId, RONRI_NAME1].Value;
                        string butsuriName = oWSheet.Cells[rowId, BUTSURI_NAME].Value;

                        if (!String.IsNullOrEmpty(ronriName) && !String.IsNullOrEmpty(butsuriName))
                        {

                            var upWord = context.WordDic.Where(x => x.RONRI_NAME1 == ronriName);
                            if (upWord.Count() == 1)
                            {
                                rowId++;
                                continue;
                            }

                            WordDic word = new WordDic();
                            word.RONRI_NAME1 = Convert.ToString(ronriName);
                            word.BUTSURI_NAME = Convert.ToString(butsuriName).ToPascalCase();
                            word.CRE_DATE = System.DateTime.Now.ToString();
                            word.USER_ID = BaseForm.UserInfo.userId;
                            context.WordDic.Add(word);
                            context.SaveChanges();
                        }
                        rowId++;
                    }
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show(
                "Excelファイルの操作に失敗しました。\n",
                System.Windows.Forms.Application.ProductName,
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            }
            finally
            {
                oExcelWBook.Close(Type.Missing, Type.Missing, Type.Missing);
                oExcelApp.Quit();
                File.SetAttributes(this.inBo.Filename, FileAttributes.Normal);
            }

            MessageBox.Show("正常に読み込みました。");
            return outBo;
        }
    }
}
