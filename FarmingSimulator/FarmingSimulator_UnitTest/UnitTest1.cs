using System;
using EntityFramework_DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FarmingSimulator_UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void HoeveelheidVoertuig_WaardeGroterDanNul_HoeveelheidGelijkAanWaarde()
        {
            //Arrange
            a_Voertuig voertuig = new a_Voertuig();
            //Act
            voertuig.Hoeveelheid = 3;
            //Assert
            Assert.AreEqual(3, voertuig.Hoeveelheid);
        }
    }
}
