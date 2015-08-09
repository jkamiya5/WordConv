using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordConvTool.Service;

namespace WordConverter.Services
{
    class UserKanriSearchServiceOutBo : IBo
    {
        public List<Form.UserBo> usersList { get; set; }
    }
}
