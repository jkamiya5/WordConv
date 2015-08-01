using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WordConvertTool
{
    class ShinseiBo
    {
        public object RONRI_NAME1 { get; set; }
        public object RONRI_NAME2 { get; set; }
        public object BUTSURI_NAME { get; set; }
        public object STATUS { get; set; }

        public ShinseiBo(object p1, object p2, object p3, object p4)
        {
            this.RONRI_NAME1 = p1;
            this.RONRI_NAME2 = p2;
            this.BUTSURI_NAME = p3;
            this.STATUS = p4;
        }
    }
}
