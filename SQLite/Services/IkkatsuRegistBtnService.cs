using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordConvertTool;
using WordConvTool.Model;

namespace SQLite.Form
{
    public static class StringExtensions
    {
        public static string ToTitleCase(this string self)
        {
            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(self);
        }
    }

    class IkkatsuTorokuIkkatsuRegistService
    {
        private IkkatsuTorokuIkkatsuRegistServiceInBo inBo = new IkkatsuTorokuIkkatsuRegistServiceInBo();

        internal void setInBo(IkkatsuTorokuIkkatsuRegistServiceInBo InBo)
        {
            this.inBo = InBo;
        }

        internal IkkatsuTorokuIkkatsuRegistServiceOutBo execute()
        {
            IkkatsuTorokuIkkatsuRegistServiceOutBo outBo = new IkkatsuTorokuIkkatsuRegistServiceOutBo();

            for (int i = 0; i < this.inBo.ikkatsuDataGridView.Rows.Count; i++)
            {
                if (this.inBo.ikkatsuDataGridView.Rows[i].Cells[0].Value == null)
                {
                    continue;
                }
                if (this.inBo.ikkatsuDataGridView.Rows[i].Cells[0].Value.Equals(true))
                {
                    using (var context = new MyContext())
                    {
                        long condtion = Convert.ToInt64(this.inBo.ikkatsuDataGridView.Rows[i].Cells["WORD_ID"].Value.ToString());
                        var upWord = context.WordDic
                            .Where(x => x.WORD_ID == condtion);

                        String butsuriName = "";
                        String inParams = Convert.ToString(this.inBo.ikkatsuDataGridView.Rows[i].Cells["BUTSURI_NAME"].Value);
                        string UNDER_SCORE = "_";
                        String[] names = inParams.Split(new string[] { UNDER_SCORE }, StringSplitOptions.None);
                        foreach (String s in names)
                        {
                            String str = "";
                            str = s.ToLower();
                            str = str.ToTitleCase();
                            butsuriName += str;
                        }

                        if (upWord.Count() == 1)
                        {
                            var w = context.WordDic.Single(x => x.WORD_ID == condtion);
                            w.RONRI_NAME1 = Convert.ToString(this.inBo.ikkatsuDataGridView.Rows[i].Cells["RONRI_NAME1"].Value);
                            w.BUTSURI_NAME = butsuriName;
                            w.CRE_DATE = System.DateTime.Now.ToString();
                            context.SaveChanges();
                            continue;
                        }

                        UserMst user = new UserMst();
                        user.USER_NAME = "ジョウジ";
                        WordDic word = new WordDic();
                        word.RONRI_NAME1 = Convert.ToString(this.inBo.ikkatsuDataGridView.Rows[i].Cells["RONRI_NAME1"].Value);
                        word.BUTSURI_NAME = butsuriName;
                        word.CRE_DATE = System.DateTime.Now.ToString();
                        word.User = user;
                        context.WordDic.Add(word);
                        context.SaveChanges();
                    }
                }
            }

            return outBo;
        }
    }
}
