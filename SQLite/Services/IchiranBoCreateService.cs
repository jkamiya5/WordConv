using SQLite.Services;
using System;
using WordConverter.Models.InBo;
using WordConverter.Models.OutBo;

namespace WordConverter.Services
{
    class IchiranBoCreateService : IService<IchiranBoCreateServiceInBo, IchiranBoCreateServiceOutBo>
    {
        /// <summary>
        /// 
        /// </summary>
        private IchiranBoCreateServiceInBo inBo;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inBo"></param>
        public void setInBo(IchiranBoCreateServiceInBo inBo)
        {
            this.inBo = inBo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
