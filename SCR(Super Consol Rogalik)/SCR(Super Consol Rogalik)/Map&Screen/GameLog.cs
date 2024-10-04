using SCR_Super_Consol_Rogalik_.Entiti;
using SCR_Super_Consol_Rogalik_.GameStuf;
using SCR_Super_Consol_Rogalik_.Map_Screen.AnimationClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCR_Super_Consol_Rogalik_.Map_Screen
{
    public static class GameLog
    {
        private static int schetchik=0;
        private static int logSize = 25;
        private static List<String> logList = new List<String>() { 
            "|-----------------","|-----------------","|-----------------","|-----------------","|-----------------","|-----------------","|-----------------","|-----------------","|-----------------",
            "|-----------------","|-----------------","|-----------------","|-----------------","|-----------------","|-----------------","|-----------------","|-----------------","|-----------------",
            "|-----------------","|-----------------","|-----------------","|-----------------","|-----------------","|-----------------","|-----------------","|-----------------","|-----------------",
            "|-----------------","|-----------------","|-----------------","|-----------------","|-----------------","|-----------------","|-----------------","|-----------------","|-----------------",
            "|-----------------","|-----------------","|-----------------","|-----------------","|-----------------","|-----------------","|-----------------","|-----------------","|-----------------",};

        private static string emp = "                                                   ";
        public static void addLog(string log) { schetchik = schetchik + 1; logList.Add(normalize("│|" + schetchik+"| "+log)); }
        private static string normalize(string log) 
        {
           int size = 105;
            string str=log;
            for (int i = log.Length; i < size; i++) 
            { str = str + "-"; }
            return str;
        }
        public static void visible() 
        {
            


            for (int i = 0; i < logSize; i++)
            {
                Console.SetCursorPosition((TravalingScreen.visRadius*2)*3+3, i);
                Console.Write(logList[logList.Count - (i + 1)]);
             }
            
            
        }
        //═══════════════=─=───- -   -  ──-=──==═══════════════
        //.   .   .   .   .   .   .   .   .   .   .   .   .   .
        public static void visStatPlayer()
        {
            string buff = ".   .   .   .   .   .   .   .   .   .   .   .   .   .";
            string emp = "                                                     ";
            string head = "╔═══════════════=─=───- -   -  ──-=──==═══════════════╗";

            // Console.WriteLine(buff);

            /*
                Console.WriteLine($"{"Player",-10}{monster.Name,50}");
            Console.WriteLine($"{" \u001b[32m" + Player.Heal + "<Heal>" + "\u001b[0m ",-10}{" \u001b[32m" + monster.heal + "<Heal>" + "\u001b[0m ",50}                {"       ",0}");
            Console.WriteLine($"{" \u001b[31m" + Player.Damage + "<Damage>" + "\u001b[0m ",-10}{" \u001b[31m" + monster.damage + "<Damage>" + "\u001b[0m ",50}        {"       ",0}");
            Console.WriteLine($"{" \u001b[36m" + Player.Armor + "<Armor>"+ "\u001b[0m",-10} {" \u001b[36m" + monster.Armor + "<Armor>" + "\u001b[0m ",50}             {"       ",0}");
            Console.WriteLine($"{" \u001b[37m" + Player.ArmorPen + "<ArmorPen>" + "\u001b[0m ",-10}{" \u001b[37m" + monster.armorPen + "<ArmorPen>" + "\u001b[0m ",50}{"       ",0} ");

              */

            Console.SetCursorPosition(0,TravalingScreen.visRadius*2+1);
            Console.WriteLine("╔═══════════════=─=─═══════════════=─-═════════════==─-─=─=──--─- -   -");
            Console.SetCursorPosition(0, TravalingScreen.visRadius * 2 + 2);
            Console.WriteLine("║" +"                               <Player>" +emp); 
            Console.SetCursorPosition(0, TravalingScreen.visRadius * 2 + 3);
            Console.WriteLine("║" + " \u001b[32m" + Player.Heal + "<Heal>" + "\u001b[0m " + emp );
            Console.SetCursorPosition(0, TravalingScreen.visRadius * 2 + 4);
            Console.WriteLine("█" + $"{StufGenerator.GetWeaponTypeColor(WeaponType.cutting) + "<Cut_Damage> " + Player.CutDamage + "\u001b[0m " + StufGenerator.GetWeaponTypeColor(WeaponType.crushing) + "<Crush_Damage> " + Player.CrushDamage + "\u001b[0m " + emp,-10}");
          //  Console.WriteLine("║" + " \u001b[31m" + (Player.CutDamage+Player.CrushDamage) + "<Damage>" + "\u001b[0m " + emp);
            Console.SetCursorPosition(0, TravalingScreen.visRadius * 2 + 5);
            Console.WriteLine("│" + " \u001b[36m" + Player.Armor + "<Armor>" + "\u001b[0m " + emp);
            Console.SetCursorPosition(0, TravalingScreen.visRadius * 2 + 6);
            Console.WriteLine("│" + " \u001b[37m" + Player.ArmorPen + "<ArmorPen>" + "\u001b[0m " + emp);
            Console.SetCursorPosition(0, TravalingScreen.visRadius * 2 + 7);
            Console.WriteLine("|" + emp);
            Console.SetCursorPosition(0, TravalingScreen.visRadius * 2 + 8);
            Console.WriteLine("|"+" Weapon > " +Player.getWeaponName()+ "\u001b[0m " + "▒ " + Player.getWeaponIcon() + " ▒" + emp);
            Console.SetCursorPosition(0, TravalingScreen.visRadius * 2 + 9);
            Console.WriteLine("|" + emp);
            Console.SetCursorPosition(0, TravalingScreen.visRadius * 2 + 10);
            Console.WriteLine("|"+" Armor  > " + Player.getArmorName() + "\u001b[0m " + "▒ " + Player.getArmorIcon() + " ▒" + emp);




        }

        public static void importToFile()
        {
            String path = "Logs\\logs.txt";
            using StreamWriter file = new(path);

            foreach(string log in logList)
            {
                file.WriteLine(log);
            }
            
           
        }

        
    }
   
}
