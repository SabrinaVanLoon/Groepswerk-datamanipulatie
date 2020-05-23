using System;
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
        public void DataDrivenOpdrachtTest_KrijgLijst()
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
        public void Aantal_Gereedschap_AantalInvoerGelijk()
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




    }
}
