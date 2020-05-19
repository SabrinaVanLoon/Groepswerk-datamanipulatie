
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmingSimulator_MODELS
{
    public static class Gereedschap
    {
        public static int Id { get; set; }
        public static string type { get; set; }
        public static string naam { get; set; }
        public static string inhoud { get; set; }
        public static Nullable<decimal> Kw_nodig { get; set; }
        public static Nullable<decimal> Hp_nodig { get; set; }
        public static Nullable<decimal> breedte { get; set; }
        public static Nullable<int> max_Snelheid { get; set; }
        public static Nullable<decimal> basisprijs { get; set; }
        public static Nullable<decimal> basiskost { get; set; }
        public static Nullable<decimal> kost_uur { get; set; }
        public static Nullable<decimal> kost_dag { get; set; }
        public static string merk { get; set; }
    }
}
