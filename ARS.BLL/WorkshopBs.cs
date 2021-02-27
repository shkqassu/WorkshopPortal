using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARS.BOL;
using ARS.DAL;

namespace ARS.BLL
{
    public class WorkshopBs : ServiceBase
    {
        public bool InsertWorkshop(WorkShop Wp /*List<int> Ls*/)
        {
            //Workshopdate should be greater than current date
            if (Wp.WorkShopDate > DateTime.Now)
            {

                WD.InsertWorkshop(Wp /*Ls*/);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<WorkShop> GetWorkshops()
        {


            return WD.GetWorkshops();
        }

        public WorkShop GetWorkshopById(int WorkShopId)
        {


            WorkShop Wp = WD.GetWorkshopById(WorkShopId);
            return Wp;
        }

        public List<WorkShopRequest> GetWorkshopRequest()
        {

            return WD.GetWorkshopRequest();
        }

        public bool AppOrRejectWorkshopRequest(Student_WorkShop_Mapping swp)
        {
            return WD.AppOrRejectWorkshopRequest(swp);
        }

        public bool UpdateWorkshopById(WorkShop Wp, int WorkShopId)
        {

            if (Wp.WorkShopDate > DateTime.Now)
            {
                WD.UpdateWorkshopById(Wp, WorkShopId);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteWorkshopById(int WorkShopId)
        {
            WD.DeleteWorkshopById(WorkShopId);
            return true;
        }

        public bool AssignTrainersToWorkShop(List<Trainer_WorkShop_Mapping> Ls)
        {
            WD.AssignTrainersToWorkShop(Ls);
            return true;
        }

        public List<WorkShopByUser> GetWorkShopByUser(int StudentId)
        {
            return WD.GetWorkShopByUser(StudentId);
        }

    }
}
