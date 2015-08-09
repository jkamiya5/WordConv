using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordConvTool.Service;

namespace WordConverter.Form
{
    public class UserKanriSearchServiceInBo : IBo
    {
        public String userName { get; set; }
        public String userId { get; set; }
        public int kengenSelectedIndex { get; set; }
    }
}
