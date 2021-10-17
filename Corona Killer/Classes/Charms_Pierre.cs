using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corona_Killer
{
    class Charms_Pierre
    {
        String Name;
        String Type;
        public Charms_Pierre(String sName, String sType)
        {
            Type = sType;
            Name = sName;
        }
        public string getName()
        {
            return this.Name;
        }
        public String getType()
        {
            return Type;
        }
        
    }
}
