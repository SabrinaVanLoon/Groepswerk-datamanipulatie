using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarmingSimulator_MODELS;

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
                    return "Hoeveelheid moet een positief getal zijn!";
                }
                return "";
            }
        }

        public int Hoeveelheid { get; set; }
    }
}
