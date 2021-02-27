using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using ARS.BOL;

namespace ARS.DAL
{
    public class MaterialDb : RepoBase
    {
        public bool CreateMaterial(Material M)
        {
            //string cmdStr = @"insert into  [ARS].[Material] (MaterialPath,WorkShopId)
            //values  (@MaterialPath,@WorkShopId)";
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("SP_CreateMaterial", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaterialPath", M.MaterialPath);
            cmd.Parameters.AddWithValue("@WorkShopId", M.WorkShopId);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }
        public List<WorkShopMaterial> GetMaterials()
        {
            try
            {
                List<WorkShopMaterial> Ls;
                Ls = new List<WorkShopMaterial>();
                //string cmdStr = @"SELECT  M.MaterialId,M.MaterialDescription,M. MaterialPath, W.WorkShopTitle 
                //FROM  [ARS].[Material] M join [ARS].[WorkShop] W on M.WorkShopId=W.WorkShopId";
                SqlConnection con = new SqlConnection(conStr);
                SqlCommand cmd = new SqlCommand("SP_GetMaterials", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    WorkShopMaterial Mt = new WorkShopMaterial();
                    Mt.MaterialId = int.Parse(dr["MaterialId"].ToString());
                    Mt.WorkShopTitle = dr["WorkShopTitle"].ToString();
                    Mt.MaterialDescription = dr["MaterialDescription"].ToString();
                    Mt.MaterialPath = dr["MaterialPath"].ToString();
                    Ls.Add(Mt);
                }
                dr.Close();
                con.Close();
                return Ls;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
