using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordConvTool.Service;

namespace WordConvertTool
{
    public class HenshuWordBo : IBo
    {
        public long WORD_ID { get; set; }
        public string RONRI_NAME1 { get; set; }
        public string BUTSURI_NAME { get; set; }
        public string USER_NAME { get; set; }
        public string CRE_DATE { get; set; }
        public int VERSION { get; set; }
        
    }
}
