using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Corona_Killer
{
    class Field_Pierre
    {
        String Type;
        public Field_Pierre(string sType)
        {
            this.Type = sType;
        }
        public double CalculateMutator()
        {
            if (Type == "Grass")
            {
                return 1;
            }
            else if (Type == "Thorns")
            {
                return 0.995;
            }
            return 0;
        }
        public string getType()
        {
            return this.Type;
        }
    }
}
