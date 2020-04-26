using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EISAI_BLL
{    
    public class DepartmentModel
    {
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public string DeptCode { get; set; }
        public bool Isactive { get; set; }
    }
}
