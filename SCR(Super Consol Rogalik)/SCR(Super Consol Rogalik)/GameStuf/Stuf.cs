using SCR_Super_Consol_Rogalik_.GameStuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCR_Super_Consol_Rogalik_
{
    public enum Category
    { weapon, armor, help, tool }

    public class Stuf
    {
        public string Name { get; set; }
        public string Lore { get; set; }
        public Category Category { get; set; }
        public string Icon { get; set; }
        public char MiniIcon { get; set; }
        public int CrushDamage { get; set; }
        public int CutDamage { get; set; }
        public int ArmorPening { get; set; }
        public int ArmorResist { get; set; }

        public int Cost { get; set; }


        public WeaponType WeaponType { get; set; }

        public Material Material { get; set; }

        public Stuf(string name, string lore, Category category, string icon, char miniicon, Material material, int cutDamage, int crushDamage, int armorPening, int armorResist)
        {



            Name = name;
            Lore = lore;
            Category = category;
            Icon = icon;
            Material = material;
            MiniIcon = miniicon;
            CutDamage = cutDamage + Material.bonus;
            CrushDamage = crushDamage + Material.bonus;
            ArmorPening = armorPening;
            ArmorResist = armorResist + Material.bonus / 2;

            Cost = material.bonus*10+ new Random().Next(0,11);


        }
        public Stuf(string name, string lore, Category category, string icon, char miniicon, Material material, int cutDamage, int crushDamage, int armorPening, int armorResist, WeaponType weaponType)
        {

            Name = name;
            Lore = lore;
            Category = category;
            Icon = icon;
            Material = material;
            MiniIcon = miniicon;
            CutDamage = cutDamage + Material.bonus;
            CrushDamage = crushDamage + Material.bonus;
            ArmorPening = armorPening + Material.bonus / 2;
            ArmorResist = armorResist;
            WeaponType = weaponType;
            
           Cost = Math.Clamp( material.bonus * 10 + new Random().Next(0, 11),0,Math.Abs(material.bonus * 10 + new Random().Next(0, 11)));
        }
     


    }
}
