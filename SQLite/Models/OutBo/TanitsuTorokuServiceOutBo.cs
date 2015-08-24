using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordConvTool.Service;

namespace WordConverter.Models.OutBo
{
    public class TanitsuTorokuInitServiceOutBo : IBo
    {
        public List<WordConvertTool.HenshuWordBo> henshuWordBoList { get; set; }
    }
}
