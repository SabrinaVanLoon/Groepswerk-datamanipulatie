using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmingSimulator_MODELS
{
    public static class Voorwaarden
    {
        public static int Id { get; set; }
        public static int veld_Id { get; set; }
        public static int graansoort_Id { get; set; }
        public static Nullable<int> eigenaar_Id { get; set; }
        public static decimal beloning { get; set; }
        public static string taakomschrijving { get; set; }


        //public Voorwaarden(int Id, int veld_Id, int graansoort_Id, int eigenaar_Id, decimal beloning, string taakomschrijving) : this(veld_Id, graansoort_Id, eigenaar_Id, beloning, taakomschrijving) { }





    }
}
