using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmingSimulator_MODELS
{
    public static class GehuurdGereedschap
    {
        public static int Id { get; set; }
        public static int speler_Id { get; set; }
        public static Nullable<int> gereedschap_Id { get; set; }

        public static string naam { get; set; }

        //public virtual a_Gereedschap a_Gereedschap { get; set; }
        //public virtual a_Speler a_Speler { get; set; }
    }
}
