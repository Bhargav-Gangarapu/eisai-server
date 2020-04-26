using EISAI_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EISAI_DAL.Interface
{
    public interface IDepartment
    {
        int InsertDepartment(DepartmentModel departmentModel);

        int UpdateDepartment(DepartmentModel departmentModel);

        int DeleteDepartment(DepartmentModel departmentModel);

        List<DepartmentModel> GetDepartmentDetails();
    }
}
