using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_DAL
{
    public partial class a_GehuurdGereedschap
    {
        public override string ToString()
        {
            return base.ToString();
        }

        //public virtual a_Gereedschap a_Gereedschap { get; set; }
        //public virtual a_Speler a_Speler { get; set; }

        public static string naam { get; set; }
    }
}
