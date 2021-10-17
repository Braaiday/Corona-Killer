using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Corona_Killer
{
    class Ingredients_Pierre
    {
        String Name;
        String Type;
        double Poetency;
        int Count;

        public Ingredients_Pierre(string sName, string sType)
        {
            this.Name = sName;
            this.Type = sType;
            this.Poetency = 0;
            this.Count = 0;
        }

        public void setPoetency()
        {
            if (Type == "Berries")
            {
                Poetency = 60;
            }
            else if (Type == "Roots")
            {
                Poetency = 40;
            }
            else if (Type == "Flowers")
            {
                Poetency = 80;
            }
        }
        public string GetName()
        {
            return  Name;
        }
        public void DecreasePoetency()
        {
            Poetency = Poetency * (0.99);
        }
        public void IncreasePoetency()
        {
            Poetency = Poetency * 1.10;
        }
        public double getPoetency()
        {
            return Poetency;
        }
        public void SetCount(int Count)
        {
            this.Count = Count;
        }
        public int GetCount()
        {
            return this.Count;
        }
        public void ModifyPoetency(double number)
        {
            Poetency = number;
        }
    }
}
