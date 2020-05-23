using System;
using EntityFramework_DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestGereedschap.cs
{
    [TestClass]
    public class Gereedschap_test
    {
        [TestMethod]
        public void Aantal_Gereedschap_AantalInvoerGelijk()
        {
            //arrange
            a_Gereedschap gereedschap = new a_Gereedschap();

            //Act
            gereedschap.Hoeveelheid = 5;

            //assert
            Assert.AreEqual(5, gereedschap.Hoeveelheid);
        }

        [TestMethod]
        public void Aanpassen_Naam_LangerDanTweeLetters()
        {
            a_Gereedschap gereedschap = new a_Gereedschap();

            gereedschap.naam = "360";

            Assert.IsTrue( gereedschap.naam.Length >= 2);
        }
    }
}