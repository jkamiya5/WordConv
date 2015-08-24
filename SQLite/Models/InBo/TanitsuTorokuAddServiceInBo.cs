using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordConvTool.Service;

namespace WordConverter.Models.InBo
{
    public class TanitsuTorokuAddServiceInBo : IBo
    {
        public string ronrimei1TextBox { get; set; }
        public string ronrimei2TextBox { get; set; }
        public string butsurimeiTextBox { get; set; }
        public System.Windows.Forms.DataGridView tanitsuDataGridView { get; set; }
    }
}
