using SQLite.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using WordConvertTool;
using WordConvTool;
using WordConvTool.Model;

namespace SQLite.Form
{
    /// <summary>
    /// 
    /// </summary>
    class IchiranInitService : IService<IchiranInitServiceInBo, IchiranInitServiceOutBo>
    {
        /// <summary>
        /// 
        /// </summary>
        private IchiranInitServiceInBo inBo = new IchiranInitServiceInBo();
        private static CommonFunction common = new CommonFunction();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inBo"></param>
        public void setInBo(IchiranInitServiceInBo inBo)
        {
            this.inBo = inBo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IchiranInitServiceOutBo execute()
        {
            IchiranInitServiceOutBo outBo = new IchiranInitServiceOutBo();
            List<IchiranWordBo> wordList = new List<IchiranWordBo>();
            IchiranWordBo word = new IchiranWordBo();

            if (!String.IsNullOrEmpty(this.inBo.clipboardText))
            {
                string dbConnectionString = ConfigurationManager.AppSettings.Get("DataSource");
                string key = this.inBo.clipboardText;
                string nl = Environment.NewLine;
                String[] keys = key.Split(new string[] { nl }, StringSplitOptions.None);

                if (keys.Count() == 1)
                {
                    using (SQLiteConnection cn = new SQLiteConnection(dbConnectionString))
                    {
                        cn.Open();
                        SQLiteCommand cmd = cn.CreateCommand();

                        string[] sp = { " ", "　" };
                        String[] keyStrs = keys[0].Split(sp, StringSplitOptions.None);
                        String condition = keyStrs.CommaSeparatedValue();
                        condition = condition.Replace("\'", "");
                        condition = "\'" + condition.Replace(",", "%") + "%\'";

                        cmd.CommandText = "SELECT * FROM WORD_DIC where RONRI_NAME1 like (" + condition + ")";

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (!isContains(reader["BUTSURI_NAME"].ToString(), wordList))
                                {
                                    if (!reader["BUTSURI_NAME"].ToString().IsAlphanumeric())
                                    {
                                        word = new IchiranWordBo();
                                        word.RONRI_NAME1 = reader["RONRI_NAME1"].ToString();
                                        word.BUTSURI_NAME = reader["BUTSURI_NAME"].ToString();
                                        wordList.Add(word);
                                        continue;
                                    }
                                    bool isDoneRonriNameDisp = false;
                                    if (BaseForm.UserInfo.pascal)
                                    {
                                        word = new IchiranWordBo();
                                        word.RONRI_NAME1 = reader["RONRI_NAME1"].ToString();
                                        word.BUTSURI_NAME = reader["BUTSURI_NAME"].ToString().ToPascalCase();
                                        wordList.Add(word);
                                        isDoneRonriNameDisp = true;
                                    }
                                    if (BaseForm.UserInfo.camel)
                                    {
                                        word = new IchiranWordBo();
                                        word.RONRI_NAME1 = isDoneRonriNameDisp ? "" : reader["RONRI_NAME1"].ToString();
                                        word.BUTSURI_NAME = reader["BUTSURI_NAME"].ToString().ToCamelCase();
                                        wordList.Add(word);
                                        isDoneRonriNameDisp = true;
                                    }
                                    if (BaseForm.UserInfo.snake)
                                    {
                                        word = new IchiranWordBo();
                                        word.RONRI_NAME1 = isDoneRonriNameDisp ? "" : reader["RONRI_NAME1"].ToString();
                                        word.BUTSURI_NAME = reader["BUTSURI_NAME"].ToString().ToSnakeCase();
                                        wordList.Add(word);
                                    }
                                }
                            }
                        }
                        cn.Close();
                    }
                }
                else
                {
                    using (SQLiteConnection cn = new SQLiteConnection(dbConnectionString))
                    {
                        cn.Open();
                        SQLiteCommand cmd = cn.CreateCommand();
                        string condition = keys.CommaSeparatedValue();
                        cmd.CommandText = "SELECT * FROM WORD_DIC where RONRI_NAME1 in (" + condition + ")";

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                word = new IchiranWordBo();
                                word.RONRI_NAME1 = reader["RONRI_NAME1"].ToString();
                                word.BUTSURI_NAME = reader["BUTSURI_NAME"].ToString();
                                wordList.Add(word);
                            }
                        }
                        cn.Close();
                    }
                }
            }

            if (wordList.Count == 0 || String.IsNullOrEmpty(this.inBo.clipboardText))
            {
                word.RONRI_NAME1 = "-";
                word.BUTSURI_NAME = Constant.NONE_WORD;
                wordList.Add(word);
            }

            outBo.wordList = wordList.ToIchiranListCount();
            return outBo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tango"></param>
        /// <param name="wordList"></param>
        /// <returns></returns>
        private bool isContains(string tango, List<IchiranWordBo> wordList)
        {
            if (wordList.Count > 0)
            {
                foreach (IchiranWordBo obj in wordList)
                {
                    if (obj.BUTSURI_NAME == tango)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
