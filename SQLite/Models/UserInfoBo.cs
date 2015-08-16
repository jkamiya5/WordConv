using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordConverter.Form
{
    public class UserInfoBo
    {
        public int role { get; set; }
        public long userId { get; set; }
        public Boolean pascal { get; set; }
        public Boolean camel { get; set; }
        public Boolean snake { get; set; }
        public int dispNumber { get; set; }
    }
}
