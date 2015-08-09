using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordConvTool.Service;

namespace WordConverter.Form
{
    public class UserKanriSearchServiceInBo : IBo
    {
        public string userName { get; set; }
        public string userId { get; set; }
        public int kengenSelectedIndex { get; set; }
    }
}
