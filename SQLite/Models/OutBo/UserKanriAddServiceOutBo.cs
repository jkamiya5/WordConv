﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordConvTool.Service;

namespace WordConverter.Models.OutBo
{
    class UserKanriAddServiceOutBo : IBo
    {
        public object userList { get; set; }
        public string errorMessage { get; set; }
    }
}
