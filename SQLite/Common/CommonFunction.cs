using System;
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
using WordConvTool.Const;

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
        internal void checkBoxWidthSetting(ref DataGridView dataGridView, int checkBoxObjWidth, int textBoxObjWidth)
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
            return dataGridViewRow.DefaultCellStyle.BackColor == Constant.CHECK_BOX_ON_COLOR ? Constant.CHECK_BOX_OFF_COLOR : Constant.CHECK_BOX_ON_COLOR;

        }

        public string getDbConnectionString()
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

        public string getDbPath()
        {
            System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
            string appConfigPath;
            appConfigPath = System.IO.Path.GetDirectoryName(asm.Location) + @"\WordConverter.exe.config";
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.Load(appConfigPath);
            System.Xml.XmlNode node = doc["configuration"]["connectionStrings"];
            string dbPath = "";
            foreach (System.Xml.XmlNode n in doc["configuration"]["connectionStrings"])
            {
                if (n.Name == "add")
                {
                    if (n.Attributes.GetNamedItem("name").Value == "MyContext")
                    {
                        dbPath = n.Attributes.GetNamedItem("connectionString").Value;
                        break;
                    }
                }
            }
            dbPath = dbPath.Replace("Data Source=", "");
            dbPath = dbPath.Replace(";foreign keys=true;", "");
            return dbPath;
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

        public string nullAble(string str)
        {
            if (String.IsNullOrEmpty(str))
            {
                return "";
            }
            return str;
        }

        public string nullAble(object p)
        {
            if (p == null)
            {
                return "";
            }
            if (String.IsNullOrEmpty(p.ToString()))
            {
                return "";
            }
            return p.ToString();
        }


        public int nullAbleInt(object p)
        {
            if (p == null)
            {
                return 0;
            }
            if (p.ToString().ToIntType() < 0)
            {
                return 0;
            }
            return p.ToString().ToIntType();
        }
    }
}
