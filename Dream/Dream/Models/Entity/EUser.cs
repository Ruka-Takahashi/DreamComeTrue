using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dream.Models.Entity
{
    public class EUser
    {
        public string emp_cd { get; set; }
        public string last_nm { get; set; }
        public string first_nm { get; set; }
        public string last_nm_kana { get; set; }
        public string first_nm_kana { get; set; }
        public int gender_cd { get; set; }
        public string section_cd { get; set; }
    }
}