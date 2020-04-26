using EISAI_BLL;
using EISAI_DAL.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace EISAI_DAL.Repository
{
    public class DepartmentRepo : IDepartment
    {
        Database db;
        SqlDataReader dr = null;

        public int InsertDepartment(DepartmentModel departmentModel)
        {
            int result = 0;
            db = DatabaseFactory.CreateDatabase("EisaiConnection");
            DbCommand cmd = db.GetStoredProcCommand("usp_departments");
            db.AddInParameter(cmd, "@DepartmentName", DbType.String, departmentModel.DeptName);
            db.AddInParameter(cmd, "@DepartmentCode", DbType.String, departmentModel.DeptCode);
            db.AddInParameter(cmd, "@DepartmentID", DbType.Int32, departmentModel.DeptId);
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

        public int UpdateDepartment(DepartmentModel departmentModel)
        {
            int result = 0;
            db = DatabaseFactory.CreateDatabase("EisaiConnection");
            DbCommand cmd = db.GetStoredProcCommand("usp_departments");
            db.AddInParameter(cmd, "@DepartmentName", DbType.String, departmentModel.DeptName);
            db.AddInParameter(cmd, "@DepartmentCode", DbType.String, departmentModel.DeptCode);
            db.AddInParameter(cmd, "@DepartmentID", DbType.Int32, departmentModel.DeptId);
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

        public int DeleteDepartment(DepartmentModel departmentModel)
        {
            int result = 0;
            db = DatabaseFactory.CreateDatabase("EisaiConnection");
            DbCommand cmd = db.GetStoredProcCommand("usp_departments");
            db.AddInParameter(cmd, "@DepartmentName", DbType.String, departmentModel.DeptName);
            db.AddInParameter(cmd, "@DepartmentCode", DbType.String, departmentModel.DeptCode);
            db.AddInParameter(cmd, "@DepartmentID", DbType.Int32, departmentModel.DeptId);
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

        //public List<DepartmentModel> GetDepartmentDetailsList()
        //{
        //    List<DepartmentModel> lstdept = new List<DepartmentModel>();
        //    con = new SqlConnection(cs);
        //    con.Open();
        //    cmd = new SqlCommand();
        //    DataSet ds = new DataSet();
        //    string str = "select DepartmentID,DepartmentName,DepartmentCode,Isactive from tblDepartment";
        //    SqlDataAdapter sda = new SqlDataAdapter(str, con);
        //    sda.Fill(ds);
        //    foreach (DataRow dr in ds.Tables[0].Rows)
        //    {
        //        lstdept.Add(new DepartmentModel { DepartmentID = Convert.ToInt32(dr["DepartmentID"]), DepartmentName = Convert.ToString(dr["DepartmentName"]), DepartmentCode = Convert.ToString(dr["DepartmentCode"]), Isactive = Convert.ToBoolean(dr["Isactive"]) });
        //    }
        //    con.Close();
        //    return lstdept;
        //}

        public List<DepartmentModel> GetDepartmentDetails()
        {         
            List<DepartmentModel> list = new List<DepartmentModel>();
            db = DatabaseFactory.CreateDatabase("EisaiConnection");
            DbCommand cmd = db.GetStoredProcCommand("usp_departments");
            db.AddInParameter(cmd, "@Type", DbType.String, "GetAll");
            dr = (SqlDataReader)db.ExecuteReader(cmd);
            while (dr.Read()) {
                DepartmentModel record = new DepartmentModel();
                record.DeptId = Convert.ToInt32(dr["DepartmentID"]);
                record.DeptName = dr["DepartmentName"].ToString();
                record.DeptCode = dr["DepartmentCode"].ToString();
                record.Isactive = Convert.ToBoolean(dr["Isactive"]);
                list.Add(record);
            }
            return list;
        }
    }
}
