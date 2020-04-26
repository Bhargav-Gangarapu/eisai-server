using EISAI_BLL;
using EISAI_DAL.Interface;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EISAI_DAL.Repository
{
    public class RoleRepo : IRole
    {
        Database db;
        SqlDataReader dr = null;

        public int DeleteRole(int roleid)
        {
            int result = 0;
            db = DatabaseFactory.CreateDatabase("EisaiConnection");
            DbCommand cmd = db.GetStoredProcCommand("usp_roles");
            db.AddInParameter(cmd, "@RoleID", DbType.Int32, roleid);
            db.AddInParameter(cmd, "@Type", DbType.String, "Delete");
            try
            {
                result = db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public List<RoleModel> GetRoleDetails()
        {
            List<RoleModel> list = new List<RoleModel>();
            db = DatabaseFactory.CreateDatabase("EisaiConnection");
            DbCommand cmd = db.GetStoredProcCommand("usp_roles");
            db.AddInParameter(cmd, "@Type", DbType.String, "List");
            dr = (SqlDataReader)db.ExecuteReader(cmd);
            while (dr.Read())
            {
                RoleModel record = new RoleModel();
                record.RoleId = Convert.ToInt32(dr["RoleId"]);
                record.RoleName = dr["RoleName"].ToString();
                record.DepartmentID = dr["DepartmentID"].ToString();
                record.Isactive = Convert.ToBoolean(dr["Isactive"]);
                list.Add(record);
            }
            return list;
        }

        public int InsertRole(RoleModel roleModel)
        {
            int result = 0;
            db = DatabaseFactory.CreateDatabase("EisaiConnection");
            DbCommand cmd = db.GetStoredProcCommand("usp_roles");
            db.AddInParameter(cmd, "@RoleName", DbType.String, roleModel.RoleName);
            db.AddInParameter(cmd, "@DepartmentID", DbType.String, roleModel.DepartmentID);
            db.AddInParameter(cmd, "@RoleID", DbType.Int32, roleModel.RoleId);
            db.AddInParameter(cmd, "@Type", DbType.String, "Insert");
            try
            {
                result = db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public int UpdateRole(RoleModel roleModel)
        {
            int result = 0;
            db = DatabaseFactory.CreateDatabase("EisaiConnection");
            DbCommand cmd = db.GetStoredProcCommand("usp_roles");
            db.AddInParameter(cmd, "@RoleName", DbType.String, roleModel.RoleName);
            db.AddInParameter(cmd, "@DepartmentID", DbType.String, roleModel.DepartmentID);
            db.AddInParameter(cmd, "@RoleID", DbType.Int32, roleModel.RoleId);
            db.AddInParameter(cmd, "@Type", DbType.String, "Update");
            try
            {
                result = db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}
