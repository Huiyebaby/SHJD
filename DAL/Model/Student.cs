using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHJD.UserManage.DAL.Model
{
    [Table("Student")]
    public class Student
    {
        public int id { get; set; }
        public string Sno { get; set; }
        public string Sname { get; set; }
        public bool Ssex { get; set; }

        public string Stel { get; set; }

        public int Sage { get; set; }
        public string Sgrade { get; set; }
        [NotMapped]
        public string SexName { get { return Ssex ? "男" : "女"; } }
    }
}
