using EISAI_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EISAI_DAL.Interface
{
    public interface IRole
    {
        List<RoleModel> GetRoleDetails();
        int InsertRole(RoleModel roleModel);
        int UpdateRole(RoleModel roleModel);
        int DeleteRole(int roleid);
    }
}
