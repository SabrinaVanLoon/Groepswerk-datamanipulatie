using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

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


        public static List<a_GehuurdGereedschap> OphalenGehuurdGereedschap()
        {
            using (MyFarmEntities entities = new MyFarmEntities())
            {
                var query = entities.a_GehuurdGereedschap
                .Include(x => x.a_Gereedschap)
                .Include(x => x.a_Speler);
                return query.ToList();
            }
        }

        public static int ToevoegenGehuurdGereedschap(a_GehuurdGereedschap gehuurdgereedschap)
        {
            using (MyFarmEntities entities = new MyFarmEntities())
            {
                entities.a_GehuurdGereedschap.Add(gehuurdgereedschap); //meervoud gaat niet


                return entities.SaveChanges();
            }
        }

        public static int VerwijderGehuurdGereedschapHuurlijst(a_GehuurdGereedschap gehuurdgereedschap)
        {

            using (MyFarmEntities entities = new MyFarmEntities())
            {
                entities.Entry(gehuurdgereedschap).State = EntityState.Deleted;
                return entities.SaveChanges();
            }

        }

        public static int VerwijderGehuurdVoertuigHuurlijst(a_GehuurdVoertuig gehuurdvoertuig)
        {

            using (MyFarmEntities entities = new MyFarmEntities())
            {
                entities.Entry(gehuurdvoertuig).State = EntityState.Deleted;
                return entities.SaveChanges();
            }

        }
        public static int ToevoegenGekochtGereedschap(a_GekochtGereedschap gekochtgereedschap)
        {
            using (MyFarmEntities entities = new MyFarmEntities())
            {
                entities.a_GekochtGereedschap.Add(gekochtgereedschap); //meervoud gaat niet


                return entities.SaveChanges();
            }
        }


        public static List<a_Speler> OphalenSpelers()
        {
            using (MyFarmEntities entities = new MyFarmEntities())
            {
                var query = entities.a_Speler;
                return query.ToList();
            }
        }

        public static List<a_Dier> OphalenDieren()
        {
            using (MyFarmEntities entities = new MyFarmEntities())
            {
                var query = entities.a_Dier;
                return query.ToList();
            }
        }

        public static int ToevoegenSpeler(a_Speler speler)
        {
            using (MyFarmEntities farmSimulatorEntities = new MyFarmEntities())
            {
                farmSimulatorEntities.a_Speler.Add(speler);
                return farmSimulatorEntities.SaveChanges();
            }
        }
    
        public static int ToevoegenGekochtVoertuig(a_GekochtVoertuig gekochtvoertuig)
        {
            try
            {
                using (MyFarmEntities entities = new MyFarmEntities())
                {
                    entities.a_GekochtVoertuig.Add(gekochtvoertuig);
                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.FoutLoggen(ex);
                return 0;
            }
        }
        public static int ToevoegenGehuurdVoertuig(a_GehuurdVoertuig gehuurdVoertuig)
        {
            try
            {
                using (MyFarmEntities entities = new MyFarmEntities())
                {
                    entities.a_GehuurdVoertuig.Add(gehuurdVoertuig);
                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.FoutLoggen(ex);
                return 0;
            }
        }
        public static List<a_GekochtVoertuig> OphalenGekochteVoertuigen()
        {
            using (MyFarmEntities entities = new MyFarmEntities())
            {
                var query = entities.a_GekochtVoertuig
                .Include(x => x.a_Voertuig)
                .Include(x => x.a_Speler);
                return query.ToList();
            }
        }


        public static List<a_GehuurdVoertuig> OphalenGehuurdVoertuig()
        {
            using (MyFarmEntities entities = new MyFarmEntities())
            {
                var query = entities.a_GehuurdVoertuig
                .Include(x => x.a_Voertuig)
                .Include(x => x.a_Speler);
                return query.ToList();
            }
        }

        public static List<a_Opdracht> OphalenGegevensOpdracht()
        {
            using (MyFarmEntities entities = new MyFarmEntities())
            {
                var query = entities.a_Opdracht /*&& entities.a_Weersomstandigheid*/
                    .Include(x => x.a_Graansoort);
                return query.ToList();

            }
        }

        public static int PersonaliseerMijnVoertuig(a_Voertuig voertuig)
        {
            try
            {
                using (MyFarmEntities entities = new MyFarmEntities())
                {
                    entities.Entry(voertuig).State = EntityState.Modified;
                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.FoutLoggen(ex);
                return 0;
            }
        }
      
    }
}
