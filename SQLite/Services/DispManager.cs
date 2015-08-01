using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WordConvertTool
{
    class DispManager
    {
        /// <summary>
        /// 
        /// </summary>
        private IStrategyDisp dispStrategy;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strategy"></param>
        public DispManager(IStrategyDisp strategy)
        {
            this.dispStrategy = strategy;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal DataGridView Execute()
        {
            DataGridView dgv = this.dispStrategy.Execute();
            return dgv;
        }
    }
}
