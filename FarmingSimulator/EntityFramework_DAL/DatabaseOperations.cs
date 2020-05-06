using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_DAL
{
    public static class DatabaseOperations
    {
        public static List<a_Voertuig> OphalenVoertuigenOpNaam(string naam)
        {
            using (MyFarmEntities entities = new MyFarmEntities())
            {
                var query = entities.a_Voertuig
                .Where(x => x.naam.Contains(naam));
                return query.ToList();
            }
        }
        public static List<a_Voertuig> OphalenVoertuigenOpType(string type)
        {
            using (MyFarmEntities entities = new MyFarmEntities())
            {
                var query = entities.a_Voertuig
                .Where(x => x.type.Contains(type));
                return query.ToList();
            }
        }
        public static List<a_Opdracht> OphalenVolledigeLijstOpdrachten()
        {
            using (MyFarmEntities entities = new MyFarmEntities())
            {
                var query = entities.a_Opdracht;
                return query.ToList();
            }
        }

        public static List<a_Gereedschap> OphalenGereedschapOpNaam(string naam)
        {
            using (MyFarmEntities entities = new MyFarmEntities())
            {
                var query = entities.a_Gereedschap
                    .Where(x => x.naam.Contains(naam));
                return query.ToList();
            }

        }

        public static List<a_Gereedschap> OphalenGereedschapOpType(string type)
        {
            using (MyFarmEntities entities = new MyFarmEntities())
            {
                var query = entities.a_Gereedschap
                .Where(x => x.type.Contains(type));
                return query.ToList();
            }
        }
      
    }
}
