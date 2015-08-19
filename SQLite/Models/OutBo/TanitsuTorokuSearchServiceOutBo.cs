using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordConvTool.Service;

namespace WordConverter.Models.OutBo
{
    class TanitsuTorokuSearchServiceOutBo : IBo
    {
        public List<WordConvertTool.HenshuWordBo> wordList { get; set; }
    }
}
