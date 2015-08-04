using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WordConvTool.Service;

namespace WordConvertTool
{
    /// <summary>
    /// 
    /// </summary>
    class StrategyKoushin : StrategyDispBase, IStrategyDisp<IBo>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inBo"></param>
        public StrategyKoushin(IBo inBo)
        {
            base.inBo = inBo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IBo Execute()
        {
            IBo outBo = executeQuery(2);
            return outBo;

        }
    }
}
