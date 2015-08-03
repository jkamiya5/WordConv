using SQLite.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using WordConvertTool;
using WordConvTool.Model;

namespace SQLite.Form
{
    class IchiranInitService : IService<IchiranInitServiceOutBo>
    {
        private IchiranInitServiceInBo inBo = new IchiranInitServiceInBo();

        public void setInBo(WordConvTool.Service.IBo inBo)
        {
            this.inBo = (IchiranInitServiceInBo)inBo;
        }

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
                        cmd.CommandText = "SELECT * FROM WORD_DIC";

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader["RONRI_NAME1"].ToString().IndexOf(key) == 0 &&
                                    !isContains(reader["BUTSURI_NAME"].ToString(), wordList))
                                {
                                    word = new IchiranWordBo();
                                    word.RONRI_NAME1 = reader["RONRI_NAME1"].ToString();
                                    word.BUTSURI_NAME = reader["BUTSURI_NAME"].ToString();
                                    wordList.Add(word);
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

                        string condition = "";
                        foreach (object obj in keys)
                        {
                            if (!String.IsNullOrEmpty((string)obj))
                            {
                                condition += "\'" + obj + "\'" + ",";
                            }
                        }
                        char[] trimChars = { ',' };
                        condition = condition.Remove(condition.Length - 1);

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

            outBo.wordList = wordList;
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
