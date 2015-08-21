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

namespace WordConverter.Common
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

        public string getDbPath()
        {
            System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
            string appConfigPath;
            appConfigPath = System.IO.Path.GetDirectoryName(asm.Location) + @"\WordConverter.exe.config";
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.Load(appConfigPath);
            System.Xml.XmlNode node = doc["configuration"]["connectionStrings"];
            foreach (System.Xml.XmlNode n in doc["configuration"]["connectionStrings"])
            {
                if (n.Name == "add")
                {
                    if (n.Attributes.GetNamedItem("name").Value == "MyContext")
                    {
                        return n.Attributes.GetNamedItem("connectionString").Value;
                    }
                }
            }
            return "";
        }

        public void setDbPath(string path)
        {
            System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
            string appConfigPath;
            appConfigPath = System.IO.Path.GetDirectoryName(asm.Location) + @"\WordConverter.exe.config";
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.Load(appConfigPath);
            System.Xml.XmlNode node = doc["configuration"]["connectionStrings"];
            foreach (System.Xml.XmlNode n in doc["configuration"]["connectionStrings"])
            {
                if (n.Name == "add")
                {
                    if (n.Attributes.GetNamedItem("name").Value == "MyContext")
                    {
                        n.Attributes.GetNamedItem("connectionString").Value = "Data Source=" + path + ";foreign keys=true;";
                        break;
                    }
                }
            }
            doc.Save(appConfigPath);
        }
    }
}
