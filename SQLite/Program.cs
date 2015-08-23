using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordConverter.Common;

namespace WordConvertTool
{
    static class Program
    {
        private static System.Threading.Mutex _mutex;

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Mutexクラスの作成
            _mutex = new System.Threading.Mutex(false, "WordConverter");
            //ミューテックスの所有権を要求する
            if (_mutex.WaitOne(0, false) == false)
            {
                //すでに起動していると判断して終了
                MessageBox.Show("WordConverterの多重起動はできません。");
                return;
            }

            Program.ExecuteDDL();
            BaseForm baseForm = new BaseForm();
            Application.Run();
        }


        static void ExecuteDDL()
        {
            var path = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "WordConverter.db");

            if (File.Exists(path))
            {
                return;
            }

            System.Data.SQLite.SQLiteConnection.CreateFile(path);
            var cnStr = new System.Data.SQLite.SQLiteConnectionStringBuilder() { DataSource = path };

            CommonFunction common = new CommonFunction();
            common.setDbPath(path);

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
                sql += "  , CRE_DATE TEXT";
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
                sql += "  , CRE_DATE TEXT";
                sql += "  , FOREIGN KEY (USER_ID) REFERENCES USER_MST(USER_ID)";
                sql += "); ";
                sql += "CREATE TABLE USER_MST( ";
                sql += "  USER_ID INTEGER PRIMARY KEY AUTOINCREMENT";
                sql += "  , EMP_ID INTEGER UNIQUE ";
                sql += "  , USER_NAME TEXT";
                sql += "  , KENGEN INTEGER";
                sql += "  , MAIL_ID TEXT";
                sql += "  , PASSWORD TEXT";
                sql += "  , MAIL_ADDRESS TEXT";
                sql += "  , SANKA_KAHI INTEGER";
                sql += "  , DELETE_FLG INTEGER";
                sql += "  , VERSION INTEGER";
                sql += "  , CRE_DATE TEXT";
                sql += "); ";
                sql += "insert into USER_MST(USER_ID,EMP_ID,USER_NAME,KENGEN,MAIL_ID,PASSWORD,MAIL_ADDRESS,SANKA_KAHI,DELETE_FLG,VERSION) values (1,999, 'Admin',0,'999','admin@co.jp','admin@co.jp',0,0,0);";

                var cmd = new System.Data.SQLite.SQLiteCommand(sql, cn);
                cmd.ExecuteNonQuery();

                cn.Close();
            }
        }
    }
}

