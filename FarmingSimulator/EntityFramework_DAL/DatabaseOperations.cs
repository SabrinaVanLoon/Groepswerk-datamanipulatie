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

        public static int AanpassenGereedschap(a_Gereedschap gereedschap)
        {
            try
            {
                using (MyFarmEntities entities = new MyFarmEntities())
                {
                    entities.Entry(gereedschap).State = EntityState.Modified;
                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.FoutLoggen(ex);
                return 0;
            }
        }

        public static int ToevoegenGehuurdGereedschap(a_GehuurdGereedschap gehuurdgereedschap)
        {
            try
            {
                using (MyFarmEntities entities = new MyFarmEntities())
                {
                    entities.a_GehuurdGereedschap.Add(gehuurdgereedschap); //meervoud gaat niet
                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.FoutLoggen(ex);
                return 0;
            }
            
        }

        public static int VerwijderGehuurdGereedschapHuurlijst(a_GehuurdGereedschap gehuurdgereedschap)
        {
            try
            {
                using (MyFarmEntities entities = new MyFarmEntities())
                {
                    entities.Entry(gehuurdgereedschap).State = EntityState.Deleted;
                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.FoutLoggen(ex);
                return 0;
            }
        }

        public static int VerwijderGekochtVoertuig(a_GekochtVoertuig gekochtVoertuig)
        {
            using (MyFarmEntities entities = new MyFarmEntities())
            {
                entities.Entry(gekochtVoertuig).State = EntityState.Deleted;
                return entities.SaveChanges();
            }
        }

        public static int VerwijderGekochtGereedschap(a_GekochtGereedschap gekochtGereedschap)
        {
            using (MyFarmEntities entities = new MyFarmEntities())
            {
                entities.Entry(gekochtGereedschap).State = EntityState.Deleted;
                return entities.SaveChanges();
            }
        }

        public static int VerwijderGekochtDier(a_Gekocht_dier gekochtDier)
        {
            using (MyFarmEntities entities = new MyFarmEntities())
            {
                entities.Entry(gekochtDier).State = EntityState.Deleted;
                return entities.SaveChanges();
            }

        }

        public static int VerwijderSpeler(a_Speler speler)
        {
            using (MyFarmEntities entities = new MyFarmEntities())
            {
                entities.Entry(speler).State = EntityState.Deleted;
                return entities.SaveChanges();
            }

        }

        public static int VerwijderGehuurdVoertuigHuurlijst(a_GehuurdVoertuig gehuurdvoertuig)
        {
            try
            {
                using (MyFarmEntities entities = new MyFarmEntities())
                {
                    entities.Entry(gehuurdvoertuig).State = EntityState.Deleted;
                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.FoutLoggen(ex);
                return 0;
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

        public static int ToevoegenGekochtDier(a_Gekocht_dier gekochtdier)
        {
            using (MyFarmEntities entities = new MyFarmEntities())
            {
                entities.a_Gekocht_dier.Add(gekochtdier); //meervoud gaat niet


                return entities.SaveChanges();
            }
        }

        public static int ToevoegenGekochtVoertuig(a_GekochtVoertuig gekochtvoertuig)
        {
            using (MyFarmEntities entities = new MyFarmEntities())
            {
                entities.a_GekochtVoertuig.Add(gekochtvoertuig);
                return entities.SaveChanges();
            }
        }
        public static int ToevoegenGehuurdVoertuig(a_GehuurdVoertuig gehuurdVoertuig)
        {
            using (MyFarmEntities entities = new MyFarmEntities())
            {
                entities.a_GehuurdVoertuig.Add(gehuurdVoertuig);
                return entities.SaveChanges();
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

        public static List<a_GekochtGereedschap> OphalenGekochteGereedschappen()
        {
            using (MyFarmEntities entities = new MyFarmEntities())
            {
                var query = entities.a_GekochtGereedschap
                .Include(x => x.a_Gereedschap)
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


        public static List<a_Gekocht_dier> OphalenGekochteDieren()
        {
            using (MyFarmEntities entities = new MyFarmEntities())
            {
                var query = entities.a_Gekocht_dier
                .Include(x => x.a_Dier)
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
        public static List<a_Graansoort> OphalenGraansoortenEnWeerseffect(int id)
        {
            using (MyFarmEntities entities = new MyFarmEntities())
            {
                var query = entities.a_Graansoort
                   .Where(a => a.a_Opdrachten.Any(b => b.Id == id))
                   .Include(x => x.a_Opdrachten)
                   .Include(x => x.a_Weerseffectten.Select(sub => sub.a_Weersomstandigheid));
                return query.ToList();
            }
        }
    }
}
