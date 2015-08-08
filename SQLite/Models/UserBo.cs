using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordConverter.Form
{
    public class UserBo
    {
        public long USER_ID { get; set; }
        public string USER_NAME { get; set; }
        public string KENGEN { get; set; }
        public string SANKA_KAHI { get; set; }
        public string MAIL_ID { get; set; }
        public string MAIL_ADDRESS { get; set; }
        public string PASSWORD { get; set; }
        public int DELETE_FLG { get; set; }
        public int VERSION { get; set; }
    }
}
