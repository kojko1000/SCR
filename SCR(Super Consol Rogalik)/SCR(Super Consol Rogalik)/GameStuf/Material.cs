using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCR_Super_Consol_Rogalik_.GameStuf
{
    public class Material
    {
        public string name;
        public string color;
        public static string defaltColor= "\u001b[0m";
        public int maxHeal;
        public int bonus;
        public int heal;

        public Material(string name, int maxheal, int bonus,string color)

        {
            this.name = name;
            this.maxHeal = maxheal;
            this.bonus = bonus;
            this.heal = maxheal;
            this.color ="\u001b[38;5;"+ color+"m"; 
        }

    }
}
