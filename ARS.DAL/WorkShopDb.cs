using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARS.BOL;
using System.Data;
using System.Data.SqlClient;

namespace ARS.DAL
{
    public class WorkShopDb : RepoBase
    {
        #region Get
        public List<WorkShop> GetWorkshops()
        {
            List<WorkShop> Ls;
            Ls = new List<WorkShop>();

            // string conStr = "Data Source=.;Initial Catalog=WorkShop;Integrated Security=True";
            //string cmdStr = "select * from [ARS].[WorkShop]";
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("SP_GetWorkshops", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                WorkShop Wp = new WorkShop();
                Wp.WorkShopId = int.Parse(dr["WorkShopId"].ToString());
                Wp.WorkShopTitle = dr["WorkShopTitle"].ToString();
                Wp.WorkShopDate = DateTime.Parse(dr["WorkShopDate"].ToString());
                Wp.WorkShopDuration = dr["WorkShopDuration"].ToString();
                Wp.WorkShopTopics = dr["WorkShopTopics"].ToString();

                Ls.Add(Wp);
            }
            dr.Close();
            con.Close();
            return Ls;

        }

        public List<WorkShopByUser> GetWorkShopByUser(int StudentId)
        {
            List<WorkShopByUser> Ls;
            Ls = new List<WorkShopByUser>();

            //string cmdStr = @"select sw.WorkShopId,sw.StudentId,w.WorkShopTitle,w.WorkShopDate,w.WorkShopDuration,w.WorkShopTopics from [ARS].[WorkShop] w inner join
            //[ARS].[Student_WorkShop_Mapping] sw on w.WorkShopId=sw.WorkShopId
            // where StudentId=@StudentId";
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("SP_GetWorkShopByUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@StudentId", StudentId);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                WorkShopByUser Wp = new WorkShopByUser();
                Wp.WorkShopId = int.Parse(dr["WorkShopId"].ToString());
                Wp.WorkShopTitle = dr["WorkShopTitle"].ToString();
                Wp.WorkShopDate = DateTime.Parse(dr["WorkShopDate"].ToString());
                Wp.WorkShopDuration = dr["WorkShopDuration"].ToString();
                Wp.WorkShopTopics = dr["WorkShopTopics"].ToString();
                Ls.Add(Wp);
            }
            dr.Close();
            con.Close();
            return Ls;
        }

        public WorkShop GetWorkshopById(int WorkShopId)
        {
            WorkShop Wp = null;

            //string conStr = "Data Source=.;Initial Catalog=WorkShop;Integrated Security=True";
            //string cmdStr = "select * from [ARS].[WorkShop] where WorkShopId=@WorkShopId";
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("SP_GetWorkshopById", con);
            cmd.Parameters.AddWithValue("@WorkShopId", WorkShopId);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Wp = new WorkShop();
                Wp.WorkShopId = int.Parse(dr["WorkShopId"].ToString());
                Wp.WorkShopTitle = dr["WorkShopTitle"].ToString();
                Wp.WorkShopDate = DateTime.Parse(dr["WorkShopDate"].ToString());
                Wp.WorkShopDuration = dr["WorkShopDuration"].ToString();
                Wp.WorkShopTopics = dr["WorkShopTopics"].ToString();
            }
            dr.Close();
            con.Close();
            return Wp;

        }
        #endregion


        #region Post
        public bool InsertWorkshop(WorkShop Wp /*List<int> Ls*/)
        {
            // string conStr = "Data Source=.;Initial Catalog=WorkShop;Integrated Security=True";
            SqlConnection con = new SqlConnection(conStr);

            con.Open();
            SqlTransaction SqTrans = con.BeginTransaction();
            try
            {
                //@ Inserting Workshop
                SqlCommand cmd = new SqlCommand("SP_InsertWorkshop", con, SqTrans);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@WorkShopTitle", Wp.WorkShopTitle);
                cmd.Parameters.AddWithValue("@WorkShopDate", Wp.WorkShopDate);
                cmd.Parameters.AddWithValue("@WorkShopDuration", Wp.WorkShopDuration);
                cmd.Parameters.AddWithValue("@WorkshopTopics", Wp.WorkShopTopics);
                cmd.ExecuteNonQuery();

                //@ Reading WorkshopId returned from Scope_Identity

                /*int WorkShopId = 0;
                if (dr.Read())
                {
                    WorkShopId = int.Parse(dr[0].ToString());
                }
                dr.Close();*/

                //@ Inserting multiple records in tbl_Trainer_Workshop_Mapping 
                //with retrived WorkshopId from Scope_Identity
                //And TrainerIds from Ls

                /*if (WorkShopId != 0)
                {
                    foreach (var TrainerId in Ls)
                    {
                        SqlCommand cmd2 = new SqlCommand("SP_InsertIntoTrainerWorkshopMapping", con, SqTrans);
                        cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.Parameters.AddWithValue("@TrainerId", TrainerId);
                        cmd2.Parameters.AddWithValue("@WorkshopId", WorkShopId);
                        cmd2.ExecuteNonQuery();
                    }
                }*/

                //@ If Every thing is successful then commiting the transaction
                SqTrans.Commit();
                con.Close();
                return true;
            }
            catch
            {
                //@ If any thing goes wrong then Rolling back the transaction
                SqTrans.Rollback();
                return false;
            }
        }

        public bool UpdateWorkshopById(WorkShop Wp, int WorkShopId)
        {
            try
            {
                //  string conStr = "Data Source=.;Initial Catalog=WorkShop;Integrated Security=True";
                //string cmdStr = @"Update [ARS].[WorkShop] 
                //Set WorkShopTitle=@WorkShopTitle,WorkShopDate=@WorkShopDate,
                //WorkShopDuration=@WorkShopDuration,WorkshopTopics=@WorkshopTopics 
                //where  WorkShopId=@WorkShopId";
                SqlConnection con = new SqlConnection(conStr);
                SqlCommand cmd = new SqlCommand("SP_UpdateWorkshopById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@WorkShopTitle", Wp.WorkShopTitle);
                cmd.Parameters.AddWithValue("@WorkShopDate", Wp.WorkShopDate);
                cmd.Parameters.AddWithValue("@WorkShopDuration", Wp.WorkShopDuration);
                cmd.Parameters.AddWithValue("@WorkshopTopics", Wp.WorkShopTopics);
                cmd.Parameters.AddWithValue("@WorkShopId", WorkShopId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteWorkshopById(int WorkShopId)
        {
            try
            {
                //string conStr = "Data Source=.;Initial Catalog=WorkShop;Integrated Security=True";
                //string cmdStr = @"Delete from [ARS].[WorkShop] where  WorkShopId=@WorkShopId";
                SqlConnection con = new SqlConnection(conStr);
                SqlCommand cmd = new SqlCommand("SP_DeleteWorkshopById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@WorkShopId", WorkShopId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AssignTrainersToWorkShop(List<Trainer_WorkShop_Mapping> Ls)
        {
            //string conStr = "Data Source=.;Initial Catalog=Workshop;Integrated Security=True";
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            SqlTransaction SqTrans = con.BeginTransaction();
            try
            {
                foreach (var item in Ls)
                {
                    //string cmdStr = "insert into [ARS].[Trainer_WorkShop_Mapping] values(@TrainerId,@WorkShopId,null,null,null,null) ";
                    //SqlCommand cmd = new SqlCommand(cmdStr, con);
                    SqlCommand cmd = new SqlCommand("SP_InsertIntoTrainerWorkshopMapping", con, SqTrans);
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (item.TrainerId == 1)
                    {
                        cmd.Parameters.AddWithValue("@TrainerId", item.TrainerId);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@TrainerId", "");
                    }

                    cmd.Parameters.AddWithValue("@WorkshopId", item.WorkShopId);
                    cmd.ExecuteNonQuery();
                }
                SqTrans.Commit();
                con.Close();
                return true;
            }
            catch (Exception EX)
            {
                SqTrans.Rollback();
                EX.Message.ToString();
                return false;
            }
        }

        public List<WorkShopRequest> GetWorkshopRequest()
        {
            List<WorkShopRequest> Ls;
            Ls = new List<WorkShopRequest>();

            //string cmdStr = @"SELECT  UD.UserId, UD.UserName_Email,WS.WorkShopId,
            //WS.WorkShopTitle, SWP.IsApproved      
            //FROM    [ARS].[Student_WorkShop_Mapping] SWP Left outer JOIN      
            //[ARS].[UserDetail] UD ON UD.UserId = SWP.StudentId Left outer JOIN      
            //[ARS].[WorkShop] WS ON SWP.WorkShopId = WS.WorkShopId";
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("SP_GetWorkshopRequest", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                WorkShopRequest Wp = new WorkShopRequest();
                Wp.SerialNo = int.Parse(dr["SerialNo"].ToString());
                Wp.UserId = int.Parse(dr["UserId"].ToString());
                Wp.UserName_Email = dr["UserName_Email"].ToString();
                Wp.WorkShopId = int.Parse(dr["WorkShopId"].ToString());
                Wp.WorkShopTitle = dr["WorkShopTitle"].ToString();
                Wp.IsApproved = (dr["IsApproved"].ToString() == "") ? false : bool.Parse(dr["IsApproved"].ToString());
                Ls.Add(Wp);
            }
            dr.Close();
            con.Close();
            return Ls;

        }

        public bool AppOrRejectWorkshopRequest(Student_WorkShop_Mapping swp)
        {
            try
            {
                //string cmdStr = @"Update [ARS].[Student_WorkShop_Mapping] 
                //Set IsApproved=@IsApproved
                //where  SerialNo=@SerialNo";
                SqlConnection con = new SqlConnection(conStr);
                SqlCommand cmd = new SqlCommand("SP_AppOrRejectWorkshopRequest", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IsApproved", swp.IsApproved == true ? 1 : 0);
                cmd.Parameters.AddWithValue("@SerialNo", swp.SerialNo);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}
