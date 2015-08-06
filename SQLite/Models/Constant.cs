using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordConvTool.Model
{
    public static class Constant
    {
        public static string NONE_WORD = "変換候補がありません。";
        public static int TANITSU_TOROKU = 0;
        public static int IKKATSU_TOROKU = 1;
    }

    public enum ShinseiKbn
    {
        申請中 = 0,
        承認 = 1,
        却下 = 2
    }
}
