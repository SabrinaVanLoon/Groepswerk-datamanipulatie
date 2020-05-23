using System;
using EntityFramework_DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace FarmingSimulator_UnitTest
{
    [TestClass]
    public class UnitTest1 
    {
        private TestContext _test;
        public TestContext Test
        {
            get { return _test; }
            set { _test = value; }
        }
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
        
        [TestMethod]
        public void DataDrivenOpdrachtTest_KrijgLijst()
        {
            //Arrange
            a_Opdracht opdracht = new a_Opdracht();
            //Act
            opdracht.taakomschrijving = Test.DataRow["taakomschrijving"].ToString();
            //Assert
            Assert.IsNotNull(opdracht.taakomschrijving);
        }
    }
}
