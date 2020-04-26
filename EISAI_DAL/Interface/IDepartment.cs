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
        int InsertEmployee(DepartmentModel departmentModel);

        int UpdateEmployee(DepartmentModel departmentModel);

        int DeleteEmployee(DepartmentModel departmentModel);

        List<DepartmentModel> GetEmployeeDetails();
    }
}
