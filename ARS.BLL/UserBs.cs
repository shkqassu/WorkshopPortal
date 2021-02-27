using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARS.BOL;

namespace ARS.BLL
{
    public class UserBs : ServiceBase
    {
        public List<UserDetails> GetTrainers()
        {

            List<UserDetails> Ls = UD.GetTrainers();
            return Ls;
        }

        public bool CreateUserRequest(UserDetails U, int WorkShopId)
    {
        //UserDb UD = new UserDb();
        UD.CreateUserRequest(U, WorkShopId);

        return true;
    }

        public bool CreateTrainer(UserDetails U)
    {
        return UD.CreateTrainer(U);
    }

        public bool ValidateUser(string username, string password)
    {
            return UD.ValidateUser(username, password);
    }

        public List<UserDetails> GetStudents()
    {
        try
        {
            List<UserDetails> Ls = UD.GetStudents();
            return Ls;
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }

        public bool ActiveDeactiveStudents(UserDetails U)
    {
        return UD.ActiveDeactiveStudents(U);
    }

        public bool UpdateStudent(UserDetails U)
    {
        return UD.UpdateStudent(U);
    }

        public UserDetails GetStudentById(string UserName)
    {


            UserDetails U = UD.GetStudentById(UserName);
        return U;
    }

        public bool RegisterStud(UserDetails U)
        {
            return UD.RegisterStud(U);
        }
    }
}
