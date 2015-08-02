using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace WordConvertTool
{
    class StrategyDispBase
    {
        /// <summary>
        /// 
        /// </summary>
        protected System.Windows.Forms.DataGridView dataGridView = new DataGridView();
        private static WordConvTool.CommonFunction common = new WordConvTool.CommonFunction();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        protected DataGridView executeSql(string sql)
        {
            List<ShinseiBo> shinsei = new List<ShinseiBo>();
            using (SQLiteConnection cn = new SQLiteConnection(ConfigurationManager.AppSettings.Get("DataSource")))
            {
                cn.Open();
                SQLiteCommand cmd = cn.CreateCommand();
                cmd.CommandText = sql;

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    int i = 0;
                    while (reader.Read())
                    {
                        if (!String.IsNullOrWhiteSpace(Convert.ToString(reader["RONRI_NAME1"])))
                        {
                            shinsei.Add(new ShinseiBo(reader["RONRI_NAME1"], reader["RONRI_NAME2"], reader["BUTSURI_NAME"], reader["STATUS"]));
                            i++;
                        }
                    }
                }
                cn.Close();
            }

            this.dataGridView.DataSource = shinsei;

            common.addCheckBox(ref this.dataGridView);
            common.viewWidthSetting(ref this.dataGridView, 20, 65);

            return this.dataGridView;
        }
    }
}
