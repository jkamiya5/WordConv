using SQLite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLite.Form
{
    class IchiranBoCreateService : IService<IchiranBoCreateServiceOutBo>
    {
        private IchiranBoCreateServiceInBo inBo;

        public void setInBo(WordConvTool.Service.IBo inBo)
        {
            this.inBo = (IchiranBoCreateServiceInBo)inBo;
        }

        public IchiranBoCreateServiceOutBo execute()
        {
            IchiranBoCreateServiceOutBo outBo = new IchiranBoCreateServiceOutBo();
            String str = "";
            for (int i = 0; i < this.inBo.ichiranDataGridView.Rows.Count; i++)
            {
                String ronriName = Convert.ToString(this.inBo.ichiranDataGridView.Rows[i].Cells["RONRI_NAME1"].Value);
                String butsuriName = Convert.ToString(this.inBo.ichiranDataGridView.Rows[i].Cells["BUTSURI_NAME"].Value);

                if (!String.IsNullOrEmpty(ronriName) && !String.IsNullOrEmpty(butsuriName))
                {
                    String s = "/** " + ronriName + " */" + System.Environment.NewLine;
                    s += "private String " + butsuriName + ";" + System.Environment.NewLine + System.Environment.NewLine;
                    str += s;
                }
            }
            outBo.boText = str;
            return outBo;
        }
    }
}
