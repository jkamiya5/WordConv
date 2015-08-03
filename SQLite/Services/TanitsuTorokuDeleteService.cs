using SQLite.Models;
using SQLite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WordConvertTool;
using WordConvTool.Model;
using WordConvTool.Service;

namespace SQLite.Form
{
    class TanitsuTorokuDeleteService : IService<TanitsuTorokuDeleteServiceOutBo>
    {
        private TanitsuTorokuDeleteServiceInBo inBo;

        public void setInBo(WordConvTool.Service.IBo inBo)
        {
            this.inBo = (TanitsuTorokuDeleteServiceInBo)inBo;
        }

        public TanitsuTorokuDeleteServiceOutBo execute()
        {
            TanitsuTorokuDeleteServiceOutBo outBo = new TanitsuTorokuDeleteServiceOutBo();

            for (int i = 0; i < this.inBo.tanitsuDataGridView.Rows.Count; i++)
            {
                if (this.inBo.tanitsuDataGridView.Rows[i].Cells[0].Value == null)
                {
                    continue;
                }
                if (this.inBo.tanitsuDataGridView.Rows[i].Cells[0].Value.Equals(true))
                {
                    using (var context = new MyContext())
                    {
                        long condtion = Convert.ToInt64(this.inBo.tanitsuDataGridView.Rows[i].Cells["WORD_ID"].Value.ToString());
                        var toRemoveWord = new WordDic { WORD_ID = condtion };
                        context.WordDic.Attach(toRemoveWord);
                        context.WordDic.Remove(toRemoveWord);
                        context.SaveChanges();
                    }
                }
            }
            MessageBox.Show("辞書テーブルから削除されました。");
            return outBo;
        }
    }
}
