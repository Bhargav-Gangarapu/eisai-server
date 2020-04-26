using EISAI_BLL;
using EISAI_DAL.Interface;
using EISAI_DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EISAI_WEBAPI.Controllers
{
    public class DepartmentController : ApiController
    {
        IDepartment obj = new DepartmentRepo();

        [Route("api/departments/saveDepartmentDetails")]
        [HttpPost]        
        public IHttpActionResult InsertDepartment(DepartmentModel departmentModel)
        {
            var result = obj.InsertDepartment(departmentModel);
            if (result == 1)
            {
                return this.Ok("Department Added Successfully");
            }
            else
            {
                return this.BadRequest("Department Could not be added");
            }
        }

        [Route("api/departments/updateDepartmentDetails")]
        [HttpPost]
        public IHttpActionResult UpdateDepartment(DepartmentModel departmentModel)
        {
            var result = obj.UpdateDepartment(departmentModel);
            if (result == 1)
            {
                return this.Ok("Department Updated Successfully");
            }
            else
            {
                return this.BadRequest("Department Could not be Updated");
            }
        }

        [Route("api/departments/deleteDepartmentDetails")]
        [HttpPost]
        public IHttpActionResult DeleteDepartment(DepartmentModel departmentModel)
        {
            var result = obj.DeleteDepartment(departmentModel);
            if (result == 1)
            {
                return this.Ok("Department deleted Successfully");
            }
            else
            {
                return this.BadRequest("Department Could not be Deleted");
            }
        }

        [Route("api/departments/getDepartmentDetails")]
        [HttpGet]
        public IEnumerable<DepartmentModel> GetDepartmentDetails()
        {
            List<DepartmentModel> lstdept = new List<DepartmentModel>();
            lstdept = obj.GetDepartmentDetails();
            return lstdept;
        }
    }
}
