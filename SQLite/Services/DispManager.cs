using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WordConvTool.Service;

namespace WordConvertTool
{
    class DispManager
    {
        /// <summary>
        /// 
        /// </summary>
        private IStrategyDisp<IBo> inBo;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inBo"></param>
        public DispManager(IStrategyDisp<IBo> inBo)
        {
            this.inBo = inBo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal IBo Execute()
        {
            IBo outBo = this.inBo.Execute();
            return outBo;
        }
    }
}
