using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHJD.UserManage.DAL.DTO
{
    public class StuSubInfo
    {
        public int id { get; set; }
        public string Sno { get; set; }
        public string Sname { get; set; }
        public string Sgrade
        {
            get; set;
        }
        public string Code { get; set; }
        public decimal Achievement { get; set; }

        public string Batch { get; set; }
        public string SubjectName { get; set; }
    }
}
