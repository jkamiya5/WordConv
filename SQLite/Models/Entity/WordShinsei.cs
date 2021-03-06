﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordConvTool.Model
{
    [Table("WORD_SHINSEI")]
    public class WordShinsei
    {
        [Key]
        public long SHINSEI_ID { get; set; }
        public string RONRI_NAME1 { get; set; }
        public string RONRI_NAME2 { get; set; }
        public string BUTSURI_NAME { get; set; }
        public int WORD_ID { get; set; }
        public int STATUS { get; set; }
        public long USER_ID { get; set; }
        public int VERSION { get; set; }
        public string CRE_DATE { get; set; }
        public virtual UserMst User { get; set; }
    }
}
