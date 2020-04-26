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
    public class RoleController : ApiController
    {
        IRole obj = new RoleRepo();

        [Route("api/roles/getRoleDetails")]
        [HttpGet]
        public IEnumerable<RoleModel> GetRoleDetails()
        {
            List<RoleModel> lstdept = new List<RoleModel>();
            lstdept = obj.GetRoleDetails();
            return lstdept;
        }
        [Route("api/roles/saveRoleDetails")]
        [HttpPost]
        public IHttpActionResult InsertRole(RoleModel roleModel)
        {
            var result = obj.InsertRole(roleModel);
            if (result == 1)
            {
                return this.Ok("Role added successfully");
            }
            else
            {
                return this.BadRequest("Role Could not be added");
            }
        }
        [Route("api/roles/updateRoleDetails")]
        [HttpPost]
        public IHttpActionResult UpdateRole(RoleModel roleModel)
        {
            var result = obj.UpdateRole(roleModel);
            if (result == 1)
            {
                return this.Ok("Role updated successfully");
            }
            else
            {
                return this.BadRequest("Role Could not be updated");
            }
        }
        [Route("api/roles/deleteRoleDetails")]
        [HttpPost]
        public IHttpActionResult DeleteRole(int roleid)
        {
            var result = obj.DeleteRole(roleid);
            if (result == 1)
            {
                return this.Ok("Role deleted successfully");
            }
            else
            {
                return this.BadRequest("Role Could not be deleted");
            }
        }
    }
}
