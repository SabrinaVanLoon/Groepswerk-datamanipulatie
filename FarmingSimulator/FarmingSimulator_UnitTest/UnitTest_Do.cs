using EntityFramework_DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FarmingSimulator_UnitTest
{
    [TestClass]
    public class UnitTest_Do 
    {
     

        [TestMethod]
        public void HoeveelheidVoertuig_WaardeGroterDanNul_HoeveelheidGelijkAanWaarde()
        {
            //Arrange
            a_Voertuig voertuig = new a_Voertuig();
            voertuig.naam = "azert";
            //Act
            voertuig.Hoeveelheid = -3;
            //Assert
            Assert.IsFalse( voertuig.IsGeldig());
        }
        
        [TestMethod]
      //  [DataSource("System.Data.SqlClient", "Data Source = edudb.thomasmore.be, 3000;Initial Catalog = DB_r0794089;Persist Security Info = True;User ID = sql_r0794089;Password = sql4you" , "a_Opdracht", DataAccessMethod.Sequential)]
        public void Voertuig_LijstOphalen()
        {
            //Arrange
            List<a_Voertuig> voertuigen = new List<a_Voertuig>();

            //Act
            string type = "auto";
            int aantalRijen = 2;
            voertuigen = DatabaseOperations.OphalenVoertuigenOpType(type);
          
            //Assert
            Assert.AreEqual(aantalRijen, voertuigen.Count);
        }

        [TestMethod]
        public void Gereedschap_GeldigIsTrue()
        {
            //arrange
            a_Gereedschap gereedschap = new a_Gereedschap();

            //Act
            gereedschap.Hoeveelheid = 5;
            gereedschap.naam = "abc";
            gereedschap.type = "abc";

            //assert
            Assert.IsTrue(gereedschap.IsGeldig());
        }

        //[TestMethod]
        //public void Aanpassen_Naam_LangerDanTweeLetters()
        //{
        //    a_Gereedschap gereedschap = new a_Gereedschap();

        //    gereedschap.naam = "360";

        //    Assert.IsTrue(gereedschap.naam.Length >= 2);
        //}

        [TestMethod]
        public void ToevoegenEnVerwijderen_Gereedschap_Huurlijst()
        {
           //arrange
            a_GehuurdGereedschap gehuurdgereedschap = new a_GehuurdGereedschap();
            int speler_Id = 1;
            int gereedschap_Id = 4;
            int verwijderen = -1;
            gehuurdgereedschap.speler_Id = speler_Id;
            gehuurdgereedschap.gereedschap_Id = gereedschap_Id;

            //act
            int resultaat = DatabaseOperations.ToevoegenGehuurdGereedschap(gehuurdgereedschap);//gereedschap toegevoegd

            if (resultaat > 0)
            {
                verwijderen = DatabaseOperations.VerwijderGehuurdGereedschapHuurlijst(gehuurdgereedschap);//gereedschap verwijderd
            }


            //assert
            Assert.IsTrue(verwijderen == 1);
        }

        [TestMethod]
        public void NaamSpeler_IsNull_IsNietGeldig()
        {
            //arrange
            a_Speler nieuweSpeler = new a_Speler();

            //act
            nieuweSpeler.naam = null;

            //assert
            Assert.IsFalse(nieuweSpeler.IsGeldig());
        }

        [TestMethod]
        public void GekochtDier_NaamDier_ZijnGelijk()
        {
            //arrange
            a_Gekocht_dier nieuwGekochtDier = new a_Gekocht_dier();
            List<a_Dier> LijstDieren = DatabaseOperations.OphalenDieren();
            a_Dier vergelijkDier = null;

            //act
            string soort = "paard";
            nieuwGekochtDier.dier_id = 2; //paard
            foreach (a_Dier dier in LijstDieren)
            {
                if (dier.Id == nieuwGekochtDier.dier_id)
                {
                    vergelijkDier = dier;
                }
            }

            //assert
            Assert.AreEqual(soort, vergelijkDier.type);
        }

        //[TestMethod]
        //public void ToevoegenEnVerwijderen_NieuweSpeler()
        //{
        //    //arrange
        //    a_Speler nieuweSpeler = new a_Speler();
        //    nieuweSpeler.naam = "testSpeler";
        //    nieuweSpeler.kapitaal = 10000;
        //    nieuweSpeler.level = 5;
        //    nieuweSpeler.geslacht = "man";
        //    int toegevoegd;
        //    int verwijderd = 0;


        //    //act
        //    toegevoegd = DatabaseOperations.ToevoegenSpeler(nieuweSpeler);
        //    if (toegevoegd > 0)
        //    {
        //        verwijderd = DatabaseOperations.VerwijderSpeler(nieuweSpeler);
        //    }

        //    //assert
        //    Assert.IsTrue(verwijderd == 1);
        //}
    }
}
