using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FarmingSimulator_MODELS
{
    public abstract class Basisklasse : IDataErrorInfo
    {
        public abstract string this[string columnName] { get; }

        public bool IsGeldig()
        {
            return string.IsNullOrWhiteSpace(Error);

        }
        public string Error
        {
            get
            {
                string meldingen = "";

                foreach (var item in this.GetType().GetProperties())  
                {
                    if (item.CanRead)
                    {
                        string fout = this[item.Name];
                        if (!string.IsNullOrWhiteSpace(fout))
                        {
                            meldingen += fout + Environment.NewLine;
                        }
                    }
                }
                return meldingen;
            }
        }
    }
}
