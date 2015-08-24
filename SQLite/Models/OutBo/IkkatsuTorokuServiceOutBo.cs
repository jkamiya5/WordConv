using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordConvertTool;
using WordConvTool.Service;

namespace WordConverter.Models.OutBo
{
    public class IkkatsuTorokuInitServiceOutBo : IBo
    {
        public List<HenshuWordBo> henshuWordBoList { get; set; }
    }
}
