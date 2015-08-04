using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WordConvertTool
{
    /// <summary>
    /// 
    /// </summary>
    interface IStrategyDisp<T>
    {
        T Execute();
    }
}
