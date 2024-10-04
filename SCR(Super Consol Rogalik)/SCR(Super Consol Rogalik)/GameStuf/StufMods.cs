using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCR_Super_Consol_Rogalik_.GameStuf
{
    public class StufMod
    {
       public string modName;
       public Category category;
       public int cutDamage,crushDamage, armorPen, armor;
        
        public StufMod(string modName,Category category, int cutDamage,int crushDamage, int armorPen , int armor)
        {
            this.modName = modName;
            this.category = category;
            this.cutDamage = cutDamage;
            this.crushDamage = crushDamage;
            this.armorPen = armorPen;
            this.armor = armor;
        }

    }
}
