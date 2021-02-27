using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARS.BOL;
using ARS.DAL;

namespace ARS.BLL
{
    public class MaterialBs : ServiceBase
    {
        public void CreateMaterial(Material M)
        {
            MD.CreateMaterial(M);
        }

        public List<WorkShopMaterial> GetMaterials()
        {
            return MD.GetMaterials(); ;
        }
    }
}
