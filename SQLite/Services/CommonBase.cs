﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordConvertTool;

namespace WordConvTool
{
    /// <summary>
    /// 
    /// </summary>
    public class CommonFunction
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        public void executeQuery(string sql)
        {
            using (var conn = new SQLiteConnection(ConfigurationManager.AppSettings.Get("DataSource")))
            {
                conn.Open();
                using (SQLiteTransaction sqlt = conn.BeginTransaction())
                {
                    using (SQLiteCommand command = conn.CreateCommand())
                    {
                        command.CommandText = sql;
                        command.ExecuteNonQuery();
                    }
                    sqlt.Commit();
                }
                conn.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGridView"></param>
        public void addCheckBox(ref DataGridView dataGridView, int index)
        {
            Boolean isExistChecBox = false;
            int id = 0;
            foreach (Object obj in dataGridView.Columns)
            {
                if (obj is DataGridViewCheckBoxColumn && id == index)
                {
                    isExistChecBox = true;
                }
                id++;
            }
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            if (!isExistChecBox)
            {
                dataGridView.Columns.Insert(index, chk);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="checkBoxObjWidth"></param>
        /// <param name="textBoxObjWidth"></param>
        internal void viewWidthSetting(ref DataGridView dataGridView, int checkBoxObjWidth, int textBoxObjWidth)
        {
            int j = 0;
            foreach (Object obj in dataGridView.Columns)
            {
                if (j == 0)
                {
                    DataGridViewCheckBoxColumn checkBoxObj = (DataGridViewCheckBoxColumn)obj;
                    checkBoxObj.Width = checkBoxObjWidth;
                }
                if (obj is DataGridViewTextBoxColumn)
                {
                    DataGridViewTextBoxColumn textBoxObj = (DataGridViewTextBoxColumn)obj;
                    textBoxObj.Width = textBoxObjWidth;
                }
                j++;
            }
        }

        internal System.Drawing.Color switchRowBackColor(DataGridViewRow dataGridViewRow)
        {
            return dataGridViewRow.DefaultCellStyle.BackColor != Color.WhiteSmoke ? Color.WhiteSmoke : Color.White;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static string ToTitleCase(this string self)
        {
            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(self);
        }

        public static string NullAble(this string self)
        {
            if (String.IsNullOrEmpty(self))
            {
                return "";
            }
            return self;
        }

        public static string AddCondtion(this string self, int i)
        {
            if (String.IsNullOrEmpty(self))
            {
                return "";
            }
            return self.ToString();
        }

        public static int NullAble(this int self)
        {
            if (null == self)
            {
                return 0;
            }
            return self;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static string ToPascalCase(this string self)
        {
            if (String.IsNullOrEmpty(self))
            {
                return "";
            }

            String butsuriName = "";
            String inParams = Convert.ToString(self);
            string UNDER_SCORE = "_";
            String[] names = inParams.Split(new string[] { UNDER_SCORE }, StringSplitOptions.None);
            if (names.Count() > 1)
            {
                foreach (String s in names)
                {
                    String str = "";
                    str = s.ToLower();
                    str = str.ToTitleCase();
                    butsuriName += str;
                }
                return butsuriName;

            }
            return self.ToTitleCase();
        }

        public static string ToCamelCase(this string self)
        {
            if (String.IsNullOrEmpty(self))
            {
                return "";
            }

            String butsuriName = "";
            String inParams = Convert.ToString(self);
            string UNDER_SCORE = "_";
            String[] names = inParams.Split(new string[] { UNDER_SCORE }, StringSplitOptions.None);
            if (names.Count() > 1)
            {
                foreach (String s in names)
                {
                    String str = "";
                    str = s.ToLower();
                    str = str.ToTitleCase();
                    butsuriName += str;
                }
                butsuriName = Char.ToLower(butsuriName[0]) + butsuriName.Substring(1);
                return butsuriName;
            }
            return self;
        }

        public static string ToSnakeCase(this string self)
        {
            if (String.IsNullOrEmpty(self))
            {
                return "";
            }

            char[] cs = self.ToCharArray();
            string str = "";
            for (int i = 0; i < cs.Length; i++)
            {
                if (char.IsUpper(cs[i]))
                {
                    str += "_" + cs[i];
                }
                else if (char.IsLower(cs[i]))
                {
                    str += char.ToUpper(cs[i]);
                }
            }
            return str;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static string CommaSeparatedValue(this String[] self)
        {
            string condition = "";
            foreach (object obj in self)
            {
                if (!String.IsNullOrEmpty((string)obj))
                {
                    condition += "\'" + obj + "\'" + ",";
                }
            }
            char[] trimChars = { ',' };
            condition = condition.Remove(condition.Length - 1);
            return condition;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static long ToKeyType(this String self)
        {
            long condition = 0L;
            if (!String.IsNullOrEmpty(self))
            {
                try
                {
                    return (long)Convert.ToInt16(self);
                }
                catch
                {
                    return 0L;
                }
            }
            return condition;
        }

        public static int ToIntType(this String self)
        {
            int condition = 0;
            if (!String.IsNullOrEmpty(self))
            {
                try
                {
                    return int.Parse(self);
                }
                catch
                {
                    return 0;
                }
            }
            return condition;
        }

        public static bool IsAlphanumeric(this string self)
        {
            return new Regex("^[0-9a-zA-Z]+$").IsMatch(self);
        }

        public static List<T> ToIchiranListCount<T>(this List<T> self)
        {
            if (self.Count > 0)
            {
                if (BaseForm.UserInfo.dispNumber == 0)
                {
                    return self;
                }
                return self.Take(BaseForm.UserInfo.dispNumber).ToList();
            }
            return self;
        }

    }
}
