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
        public string RONRI_NAME1 { get; set; }
        public string RONRI_NAME2 { get; set; }
        public string BUTSURI_NAME { get; set; }
        public string USER_ID { get; set; }
    }
}
