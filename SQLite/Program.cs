using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordConvertTool
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Program.createDb();
            BaseForm baseForm = new BaseForm();
            Application.Run();
        }

        private static void createDb()
        {
            ExecuteDDL();

        }

        static void ExecuteDDL()
        {
            var path = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "WordConverter.db");

            //if (File.Exists(path))
            //{
            //    return;
            //}

            System.Data.SQLite.SQLiteConnection.CreateFile(path);
            System.Diagnostics.Debug.Write(path);
            var cnStr = new System.Data.SQLite.SQLiteConnectionStringBuilder() { DataSource = path };

            using (var cn = new System.Data.SQLite.SQLiteConnection(cnStr.ToString()))
            {
                cn.Open();

                //  テーブル名は複数形で指定する(Wordではなく、Words)
                var sql = "CREATE TABLE WORD_DIC( ";
                sql += "  WORD_ID INTEGER PRIMARY KEY AUTOINCREMENT";
                sql += "  , RONRI_NAME1 TEXT";
                sql += "  , RONRI_NAME2 TEXT";
                sql += "  , BUTSURI_NAME TEXT";
                sql += "  , USER_ID INTEGER";
                sql += "  , VERSION INTEGER";
                sql += "  , CRE_DATE INTEGER";
                sql += "  , FOREIGN KEY (USER_ID) REFERENCES USER_MST(USER_ID)";
                sql += "); ";
                sql += "CREATE TABLE WORD_SHINSEI( ";
                sql += "  SHINSEI_ID INTEGER PRIMARY KEY AUTOINCREMENT";
                sql += "  , RONRI_NAME1 TEXT";
                sql += "  , RONRI_NAME2 TEXT";
                sql += "  , BUTSURI_NAME TEXT";
                sql += "  , WORD_ID INTEGER";
                sql += "  , STATUS INTEGER";
                sql += "  , USER_ID INTEGER";
                sql += "  , VERSION INTEGER";
                sql += "  , CRE_DATE INTEGER";
                sql += "  , FOREIGN KEY (USER_ID) REFERENCES USER_MST(USER_ID)";
                sql += "); ";
                sql += "CREATE TABLE USER_MST( ";
                sql += "  USER_ID INTEGER PRIMARY KEY AUTOINCREMENT";
                sql += "  , USER_NAME TEXT";
                sql += "  , ROLE INTEGER";
                sql += "  , MAIL_ID TEXT";
                sql += "  , PASSWORD TEXT";
                sql += "  , MAIL_ADDRESS TEXT";
                sql += "  , SANKA_KAHI INTEGER";
                sql += "  , DELETE_FLG INTEGER";
                sql += "  , VERSION INTEGER";
                sql += "); ";

                var cmd = new System.Data.SQLite.SQLiteCommand(sql, cn);
                cmd.ExecuteNonQuery();

                cn.Close();
            }
        }
    }

    //[Table("WORD_DIC")]
    //public class WordDic
    //{
    //    [Key]
    //    public long WORD_ID { get; set; }
    //    public string RONRI_NAME1 { get; set; }
    //    public string RONRI_NAME2 { get; set; }
    //    public string BUTSURI_NAME { get; set; }
    //    public long USER_ID { get; set; }
    //    public int VERSION { get; set; }
    //    public int CRE_DATE { get; set; }
    //    public virtual UserMst User { get; set; }
    //}

    //[Table("WORD_SHINSEI")]
    //public class WordShinsei
    //{
    //    [Key]
    //    public long SHINSEI_ID { get; set; }
    //    public string RONRI_NAME1 { get; set; }
    //    public string RONRI_NAME2 { get; set; }
    //    public string BUTSURI_NAME { get; set; }
    //    public long WORD_ID { get; set; }
    //    public int STATUS { get; set; }
    //    public int USER_ID { get; set; }
    //    public int VERSION { get; set; }
    //    public int CRE_DATE { get; set; }
    //    public virtual UserMst User { get; set; }
    //}

    //[Table("USER_MST")]
    //public class UserMst
    //{
    //    [Key]
    //    public long USER_ID { get; set; }
    //    public string USER_NAME { get; set; }
    //    public int ROLE { get; set; }
    //    public string MAIL_ID { get; set; }
    //    public string PASSWORD { get; set; }
    //    public string MAIL_ADDRESS { get; set; }
    //    public int SANKA_KAHI { get; set; }
    //    public int DELETE_FLG { get; set; }
    //    public int VERSION { get; set; }
    //    public virtual ICollection<WordDic> Words { get; set; }
    //    public virtual ICollection<WordShinsei> Shinseis { get; set; }
    //}

    //public class ItemCatalog : System.Data.Entity.DbContext
    //{
    //    public System.Data.Entity.DbSet<WordDic> WordDic { get; set; }
    //    public System.Data.Entity.DbSet<WordShinsei> WordShinsei { get; set; }
    //    public System.Data.Entity.DbSet<UserMst> UserMst { get; set; }
    //}
}

