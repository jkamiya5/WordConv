﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WordConvTool.Service;

namespace WordConverter.Models.InBo
{
    public class TanitsuTorokuRegistServiceInBo : IBo
    {
        public DataGridView tanitsuDataGridView { get; set; }
        public string clipboardText { get; set; }
    }
}
