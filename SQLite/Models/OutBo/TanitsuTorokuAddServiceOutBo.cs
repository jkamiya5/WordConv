﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordConvTool.Service;

namespace WordConverter.Models.OutBo
{
    public class TanitsuTorokuAddServiceOutBo : IBo
    {
        public List<WordConvertTool.HenshuWordBo> wordList { get; set; }
        public string errorMessage { get; set; }
    }
}