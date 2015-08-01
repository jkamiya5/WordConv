using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WordConvertTool
{
    /// <summary>
    /// 
    /// </summary>
    class StrategyShinki : StrategyDispBase, IStrategyDisp
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dgv"></param>
        public StrategyShinki(System.Windows.Forms.DataGridView dgv)
        {
            base.dataGridView = dgv;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataGridView Execute()
        {
            string sql = "SELECT * FROM WORD_SHINSEI where status = 1 order by STATUS desc";
            DataGridView dgv = executeSql(sql);
            return dgv;
        }
    }
}
