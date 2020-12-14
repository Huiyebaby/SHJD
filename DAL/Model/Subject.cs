using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHJD.UserManage.DAL.Model
{
    [Table("Subject")]
    public class Subject
    {
        public int id { get; set; }
        public string SubjectName { get; set; }
        public string SubjectCode { get; set; }
    }
}
