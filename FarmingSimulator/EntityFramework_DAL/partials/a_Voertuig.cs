using FarmingSimulator_MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_DAL
{
    public partial class a_Voertuig : Basisklasse
    {
        public override string this[string columnName]
        {
            get
            {
                if (columnName == "Hoeveelheid" && Hoeveelheid < 0)
                {
                    return $"Hoeveelheid moet een positief getal zijn! {Environment.NewLine}" ;
                }
                if (columnName == "naam" && naam.Length < 5)
                {
                    return "Geef je voertuig een leuke naam van minstens 5 karakters";
                }
                return "";
            }
        }

        public int Hoeveelheid { get; set; }
    }
}
