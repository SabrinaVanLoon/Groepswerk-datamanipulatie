using FarmingSimulator_MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_DAL
{
    public partial class a_Speler : Basisklasse
    {
        public override string this[string columnName]
        {
            get
            {
                if (columnName == "naam" && naam == null)
                {
                    return "Naam mag niet null zijn!";
                }
                return "";

            }
        }
    }
}
