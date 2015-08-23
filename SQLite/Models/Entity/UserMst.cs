using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordConvTool.Model
{

    [Table("USER_MST")]
    public class UserMst
    {
        [Key]
        public long USER_ID { get; set; }
        public int EMP_ID { get; set; }
        public string USER_NAME { get; set; }
        public int KENGEN { get; set; }
        public string MAIL_ID { get; set; }
        public string PASSWORD { get; set; }
        public string MAIL_ADDRESS { get; set; }
        public int SANKA_KAHI { get; set; }
        public int DELETE_FLG { get; set; }
        public int VERSION { get; set; }
        public string CRE_DATE { get; set; }
        public virtual ICollection<WordDic> Words { get; set; }
        public virtual ICollection<WordShinsei> Shinseis { get; set; }
    }
}
