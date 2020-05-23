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
        
        ////[TestMethod]
        ////[DataSource("System.Data.SqlClient", "provider=System.Data.SqlClient;Data Source=edudb.thomasmore.be,3000;Initial Catalog=DB_r0794089;Persist Security Info=True", "a_Opdracht", DataAccessMethod.Sequential)]
        ////public void DataDrivenOpdrachtTest_KrijgLijst()
        ////{
        ////    //Arrange
        ////    a_Opdracht opdracht = new a_Opdracht();
        ////    //Act
        ////    opdracht.taakomschrijving = Test.DataRow["taakomschrijving"].ToString();
        ////    //Assert
        ////    Assert.IsNotNull(opdracht.taakomschrijving);
        ////}
    }
}
