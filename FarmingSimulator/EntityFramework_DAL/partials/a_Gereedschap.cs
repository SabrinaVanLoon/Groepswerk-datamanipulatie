using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarmingSimulator_MODELS;

namespace EntityFramework_DAL
{
    public partial class a_Gereedschap : Basisklasse
    {
        public override string this[string columnName]
        {
            get
            {
                if (columnName  == "naam" && naam.Length <= 2)
                {
                    return "Naam is niet lang genoeg!";
                }
                if (columnName == "type" && type.Length <= 2)
                {
                    return "type is niet lang genoeg!";
                }
                return "";
            }
        }
    }
}
