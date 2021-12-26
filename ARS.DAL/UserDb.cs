using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARS.BOL;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;

namespace ARS.DAL
{
    public class UserDb : RepoBase
    {
        public List<UserDetails> GetTrainers()
        {
            List<UserDetails> Ls;
            Ls = new List<UserDetails>();

            //string conStr = "Data Source=.;Initial Catalog=WorkShop;Integrated Security=True";
            //string cmdStr = @"SELECT U.UserId, U.FirstName,U.LastName
            //FROM            [ARS].[UserDetail] U INNER JOIN
            //[ARS].[Role] R ON U.RoleId = R.RoleId
            //WHERE        (R.RoleName = 'Trainer')";
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("SP_GetTrainers", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                UserDetails Ud = new UserDetails();
                Ud.UserId = int.Parse(dr["UserId"].ToString());
                Ud.UserName_Email = dr["UserName_Email"].ToString();
                Ud.FirstName = dr["FirstName"].ToString();
                Ud.LastName = dr["LastName"].ToString();
                Ud.UserGender = dr["UserGender"].ToString();
                Ud.Mobile = dr["Mobile"].ToString();
                Ud.SkillsSet = dr["SkillsSet"].ToString();
                Ud.Experience = dr["Experience"].ToString();
                Ud.IsActive = (bool.Parse(dr["IsActive"].ToString()));
                
                Ls.Add(Ud);
            }
            dr.Close();
            con.Close();
            return Ls;

        }

        public bool CreateUserRequest(UserDetails U, int WorkShopId)
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            SqlTransaction SqTrans = con.BeginTransaction();
            //string cmdStr = @"insert into [ARS].[UserDetail] (UserName_Email,RoleId) values(@UserName_Email,3);
            //select Scope_Identity() as Id";
            //string cmdStr2 = "insert into [ARS].[Student_WorkShop_Mapping] values(@StudentId,@WorkShopId,NULL) ";
            try
            {
                //@ Inserting Workshop
                SqlCommand cmd = new SqlCommand("SP_InsertIntoUserDetailsOfStudents", con, SqTrans);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName_Email", U.UserName_Email);
                SqlDataReader dr = cmd.ExecuteReader();

                //@ Reading StudentId returned from Scope_Identity
                int StudentId = 0;
                if (dr.Read())
                {
                    StudentId = int.Parse(dr[0].ToString());
                }
                dr.Close();

                //@ Inserting record in tbl_Student_Workshop_Mapping 
                //@ with retrived StudentId from Scope_Identity
                SqlCommand cmd2 = new SqlCommand("SP_InsertIntoStudentWorkshopMapping", con, SqTrans);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@StudentId", StudentId);
                cmd2.Parameters.AddWithValue("@WorkshopId", WorkShopId);
                cmd2.ExecuteNonQuery();

                //@ If Every thing is successful then commiting the transaction
                SqTrans.Commit();
                con.Close();
                return true;
            }
            catch(Exception)
            {
                SqTrans.Rollback();
                return false;
                throw;
            }
        }

        public bool CreateTrainer(UserDetails U)
        {
            //string cmdStr = @"insert into  [ARS].[UserDetail] (UserName_Email,FirstName,LastName,RoleId)
            //values  (@UserName_Email,@FirstName,@LastName,@RoleId)";
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("SP_CreateTrainer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserName_Email", U.UserName_Email);
            cmd.Parameters.AddWithValue("@FirstName", U.FirstName);
            cmd.Parameters.AddWithValue("@LastName", U.LastName);
            cmd.Parameters.AddWithValue("@RoleId", U.RoleId);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }

        public bool RegisterStud(UserDetails U)
        {
            //string cmdStr = @"insert into  [ARS].[UserDetail] (UserName_Email,FirstName,LastName,RoleId)
            //values  (@UserName_Email,@FirstName,@LastName,@RoleId)";
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("SP_RegisterStud", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserName_Email", U.UserName_Email);
            cmd.Parameters.AddWithValue("@Password", U.Password);
            cmd.Parameters.AddWithValue("@FirstName", U.FirstName);
            cmd.Parameters.AddWithValue("@LastName", U.LastName);
            cmd.Parameters.AddWithValue("@UserGender", U.UserGender);
            cmd.Parameters.AddWithValue("@Mobile", U.Mobile);
            cmd.Parameters.AddWithValue("@UserDob", U.UserDob);
            cmd.Parameters.AddWithValue("@IsActive", U.IsActive == true ? 1 : 0);
            cmd.Parameters.AddWithValue("@RoleId", U.RoleId);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                SendMail(U);
                return true;
            }
            catch(Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public bool ValidateUser(string username, string password)
        {
            //string cmdStr = @"SELECT * FROM  [ARS].[UserDetail] 
            //WHERE (UserName_Email=@UserName_Email and Password=@Password)";
            try
            {
                // SqlConnection con = new SqlConnection(conStr);
                // SqlCommand cmd = new SqlCommand("SP_ValidateUser", con);
                // cmd.CommandType = CommandType.StoredProcedure;
                // cmd.Parameters.AddWithValue("@UserName_Email", username);
                // cmd.Parameters.AddWithValue("@Password", password);
                // con.Open();
                // SqlDataReader dr = cmd.ExecuteReader();
                if (entity.UserDetails.Any(x => x.UserName_Email == username & x.Password == password))
                {
                    return true;
                    // UserDetails U = new UserDetails();
                    // U.UserId = int.Parse(dr["UserId"].ToString());
                    // U.UserName_Email = dr["UserName_Email"].ToString();
                    // U.FirstName = dr["FirstName"].ToString();
                    // U.RoleId = int.Parse(dr["RoleId"].ToString());
                }
                else
                    return false;

                // dr.Close();
                // con.Close();
                // return true;
            }
            catch(Exception ex)
            {
                return false;
                throw ex;
            }

        }

        public String GetAuthUser(string username)
        {
            string cmdStr = @"SELECT * FROM  [ARS].[UserDetail] 
            WHERE UserName_Email=@UserName_Email";

            UserDetails U = new UserDetails();
            try
            {
                SqlConnection con = new SqlConnection(conStr);
                SqlCommand cmd = new SqlCommand(cmdStr, con);
                // cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName_Email", username);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    U.UserId = int.Parse(dr["UserId"].ToString());
                    U.UserName_Email = dr["UserName_Email"].ToString();
                    U.FirstName = dr["FirstName"].ToString();
                    U.RoleId = int.Parse(dr["RoleId"].ToString());
                }

                dr.Close();
                con.Close();
                return U.RoleId.ToString();
            }
            catch(Exception)
            {
                throw;
            }

        }

        public List<UserDetails> GetStudents()
        {
            try
            {
                List<UserDetails> Ls;
                Ls = new List<UserDetails>();
                //string cmdStr = @"SELECT        *
                //FROM   [ARS].[UserDetail] U INNER JOIN
                //[ARS].[Role] R ON U.RoleId = R.RoleId
                //WHERE        (R.RoleName = 'Student')";
                SqlConnection con = new SqlConnection(conStr);
                SqlCommand cmd = new SqlCommand("SP_GetStudents", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    UserDetails Ud = new UserDetails();
                    Ud.IsActive = (bool.Parse(dr["IsActive"].ToString()));
                    Ud.UserId = int.Parse(dr["UserId"].ToString());
                    Ud.FirstName = dr["FirstName"].ToString();
                    Ud.LastName = dr["LastName"].ToString();
                    Ud.UserName_Email = dr["UserName_Email"].ToString();
                    Ls.Add(Ud);
                }
                dr.Close();
                con.Close();
                return Ls;
            }
            catch
            {
                throw;
            }
        }

        public bool ActiveDeactiveStudents(UserDetails U)
        {
            try
            {
                string cmdStr = @"Update [ARS].[UserDetail]
                                    Set IsActive=@IsActive
                                    where UserId=@UserId";
                SqlConnection con = new SqlConnection(conStr);
                SqlCommand cmd = new SqlCommand(cmdStr, con);
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IsActive", U.IsActive == true ? 1 : 0);
                cmd.Parameters.AddWithValue("@UserId", U.UserId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                return false;
                throw;
            }
        }

        public bool UpdateStudent(UserDetails U)
        {
            try
            {
                string cmdStr = @"update [ARS].[UserDetail] 
                              set FirstName=@FirstName,LastName=@LastName,UserGender=@UserGender,Mobile=@Mobile,
                              SkillsSet=@SkillsSet,Experience=@Experience,UserDob=@UserDob,RoleId=@RoleId
							  where UserId=@UserId";
                SqlConnection con = new SqlConnection(conStr);
                SqlCommand cmd = new SqlCommand(cmdStr, con);
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", U.UserId);
                cmd.Parameters.AddWithValue("@FirstName", U.FirstName);
                cmd.Parameters.AddWithValue("@LastName", U.LastName);
                cmd.Parameters.AddWithValue("@UserGender", U.UserGender);
                cmd.Parameters.AddWithValue("@Mobile", U.Mobile);
                cmd.Parameters.AddWithValue("@UserDob", U.UserDob);
                //cmd.Parameters.AddWithValue("@SkillsSet", U.SkillSet);
                //cmd.Parameters.AddWithValue("@Experience", U.Experience);
                cmd.Parameters.AddWithValue("@RoleId", U.RoleId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public UserDetails GetUserById(string UserName)
        {
            UserDetails U = null;

            //string conStr = "Data Source=.;Initial Catalog=WorkShop;Integrated Security=True";
            string cmdStr = "Select * from [ARS].[UserDetail] where UserName_Email=@UserName_Email";
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand(cmdStr, con);
            cmd.Parameters.AddWithValue("@UserName_Email", UserName);
            con.Open();
            //cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                U = new UserDetails();
                U.UserName_Email = dr["UserName_Email"].ToString();
                // U.UserDob = (DateTime.Parse(dr["UserDob"].ToString())); // == " ") ? null : DateTime.Parse(dr["UserDob"].ToString();
                U.UserGender = dr["UserGender"].ToString();
                U.FirstName = dr["FirstName"].ToString();
                U.LastName = dr["LastName"].ToString();
                U.Mobile = dr["Mobile"].ToString();
                U.SkillsSet = dr["SkillsSet"].ToString();
                U.Experience = dr["Experience"].ToString();
            }
            dr.Close();
            con.Close();
            return U;
        }

        public void SendMail(UserDetails U)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add("your to email");
            mail.CC.Add("your cc email");
            mail.From = new MailAddress("your from email", "ARS-IT Centre", Encoding.UTF8);
            mail.Subject = "Workshop Portal : Successfully Registered";
            mail.SubjectEncoding = Encoding.UTF8;
            mail.Body = "Dear Sir/Ma'am,<br/><br/> You have successfully registered on Workshop Portal of ARS-IT Centre. Please find below details for your reference.";
            mail.Body += "<br/><br/> UserName or Email : " + U.UserName_Email + "<br/> Password : " + U.Password;
            mail.Body += "<br/><br/> Regards,<br/>ARS-IT Team";
            mail.Body += "<br/><br/><br/> ****  This is an automatically generated email, please do not reply.  ****";
            mail.BodyEncoding = Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("your from email", "your password");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {
                Exception ex2 = ex;
                string errorMessage = string.Empty;
                while (ex2 != null)
                {
                    errorMessage += ex2.ToString();
                    ex2 = ex2.InnerException;
                }
            }
        }
    }
}
