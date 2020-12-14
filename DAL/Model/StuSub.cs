using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHJD.UserManage.DAL.Model
{
    [Table("StuSub")]
    public class StuSub
    {
        public int id { get; set; }
        public string Code { get; set; }
        public string Sno { get; set; }
        public decimal Achievement { get; set; }

        public string Batch { get; set; }
    }
}
