using SCR_Super_Consol_Rogalik_.GameStuf;
using SCR_Super_Consol_Rogalik_.Map_Screen;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace SCR_Super_Consol_Rogalik_
{
    public enum Direction
    {
        Up, Down, Left, Right
    }

    public static class Player
    {
        private static bool ride = false;
        public static int x = 4; public static int y = 5;//position on map
        public static List<Stuf> Inventory { get; set; } = new List<Stuf>();
        public static char avatar = '☺';
        public static int CutDamage = 1, CrushDamage = 1, Armor = 0, ArmorPen = 0, Heal = 1, DefResist = (Armor + 1) * 3;
        // public static int equpCutDamageStat = 0, equpCrushDamageStat = 0, equdArmorPenStat = 0, equpArmorStat = 0; 
        public static Stuf equpArmor = null, equpWeapon = null, equpTool = null, equpHelp = null;
        public static bool IsMining = false, IsDead = false;


        public static void UpdateStats()
        {
            CutDamage = 1; CrushDamage = 1; Armor = 0; ArmorPen = 0;
            if (equpWeapon != null)
            {
                CutDamage = CutDamage + equpWeapon.CutDamage;
                CrushDamage = CrushDamage + equpWeapon.CrushDamage;
                Armor = Armor + equpWeapon.ArmorResist;
                ArmorPen = ArmorPen + equpWeapon.ArmorPening;
            }
            if (equpArmor != null)
            {
                CutDamage = CutDamage + equpArmor.CutDamage;
                CrushDamage = CrushDamage + equpArmor.CrushDamage;
                Armor = Armor + equpArmor.ArmorResist;
                ArmorPen = ArmorPen + equpArmor.ArmorPening;
            }
            if (equpHelp != null)
            {
                equpHelp.Material.heal = equpHelp.Material.heal - 1;
                Heal = Heal + equpHelp.CutDamage;
                
            }
        }

        public static string getWeaponIcon()
        {
            if (equpWeapon != null)
                return equpWeapon.Icon;
            return ".";
        }
        public static string getArmorIcon()
        {
            if (equpArmor != null)
                return equpArmor.Icon;
            return ".";
        }
        public static string getWeaponName()
        {
            if (equpWeapon != null)
                return equpWeapon.Name;
            return "None";
        }
        public static string getArmorName()
        {
            if (equpArmor != null)
                return equpArmor.Name;
            return "None";
        }


        // Console.WriteLine("\u001b[34m" + (Inventory[i].Name) + "\u001b[0m");
        // Console.Write("\r\n— ——╔═══════════════╗— —— \r\n——══╣ ‹ ÌÑVÉÑT0RŸ › ╠══—— \r\n — —╚═══════════════╝——   \n");

        /*
          switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Escape or ConsoleKey.I:Console.Clear(); return; break;



                    case ConsoleKey.UpArrow or ConsoleKey.W:
                        {

                        }
                    break;
                    case ConsoleKey.DownArrow or ConsoleKey.S:
                        {

                        }
                    break;
                }
        */


        public static void inventory()
        {

            void giveStatsItem(Stuf stuf)
            {
                if (stuf.Category == Category.weapon)
                {

                }
                else if (stuf.Category == Category.armor)
                {

                }
                else if (stuf.Category == Category.help)
                {

                }
            }
            void clereStatsStuf()
            {
                string emp = "                                                                 ";
                Console.SetCursorPosition(60, 4);//1-255
                Console.WriteLine(emp);
                Console.SetCursorPosition(60, 5);//1-255
                Console.WriteLine(emp);
                Console.SetCursorPosition(60, 6);
                Console.WriteLine(emp);
                Console.SetCursorPosition(60, 7);//1-255
                Console.WriteLine(emp);
                Console.SetCursorPosition(60, 8);//1-255
                Console.WriteLine(emp);
                Console.SetCursorPosition(60, 9);//1-255
                Console.WriteLine(emp);
                Console.SetCursorPosition(60, 10);
                Console.WriteLine(emp);
                Console.SetCursorPosition(60, 11);
                Console.WriteLine(emp);
                Console.SetCursorPosition(60, 12);
                Console.WriteLine(emp);
                Console.SetCursorPosition(60, 13);
                Console.WriteLine(emp);
            }

            void viseStatsStuf(Stuf stuf)
            {
                if (stuf.Category == Category.weapon)
                {
                    string emp = "                                     ";
                    clereStatsStuf();
                    Console.SetCursorPosition(60, 4);//1-255
                    Console.WriteLine("▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
                    Console.SetCursorPosition(60, 5);//1-255
                    Console.WriteLine("█" + $"{"\u001b[38;5;195m" + "< " + stuf.Name + " >" + "\u001b[0m " + emp,-10}");
                    Console.SetCursorPosition(60, 6);
                    Console.WriteLine("█" + $"{"< Type > " + StufGenerator.GetWeaponTypeColor(stuf.WeaponType) + stuf.WeaponType + Material.defaltColor + emp,-10}");
                    Console.SetCursorPosition(60, 7);//1-255
                    Console.WriteLine("█" + "< material > " + stuf.Material.color + stuf.Material.name + Material.defaltColor + emp);
                    Console.SetCursorPosition(60, 8);//1-255
                    Console.WriteLine("█" + "< durability > " + stuf.Material.maxHeal + "/" + stuf.Material.heal + emp);
                    Console.SetCursorPosition(60, 9);//1-255
                    Console.WriteLine("█" + $"{"< " + " \u001b[38;5;95m" + stuf.Icon + "\u001b[0m " + " >=< " + " \u001b[38;5;95m" + stuf.MiniIcon + "\u001b[0m " + " > " + emp,-10}");
                    Console.SetCursorPosition(60, 10);
                    Console.WriteLine("█" + $"{StufGenerator.GetWeaponTypeColor(WeaponType.cutting) + "<Cut_Damage> " + stuf.CutDamage + "\u001b[0m " + StufGenerator.GetWeaponTypeColor(WeaponType.crushing) + "<Crush_Damage> " + stuf.CrushDamage + "\u001b[0m " + emp,-10}");
                    Console.SetCursorPosition(60, 11);
                    Console.WriteLine("█" + $"{" \u001b[36m" + stuf.ArmorResist + "<Armor>" + "\u001b[0m" + emp,-10} ");
                    Console.SetCursorPosition(60, 12);
                    Console.WriteLine("█" + $"{" \u001b[37m" + stuf.ArmorPening + "<ArmorPen>" + "\u001b[0m " + emp,-10} ");
                    Console.SetCursorPosition(60, 13);
                    Console.WriteLine("█" + $"{" \u001b[38;5;220m" + stuf.Cost + "<Cost>" + "\u001b[0m " + emp,-10} ");
                    Console.SetCursorPosition(60, 14);
                    Console.WriteLine("▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀");

                    Console.SetCursorPosition(124, 5);
                    Console.WriteLine("█");
                    Console.SetCursorPosition(124, 6);
                    Console.WriteLine("█");
                    Console.SetCursorPosition(124, 7);
                    Console.WriteLine("█");
                    Console.SetCursorPosition(124, 8);
                    Console.WriteLine("█");
                    Console.SetCursorPosition(124, 9);
                    Console.WriteLine("█");
                    Console.SetCursorPosition(124, 10);
                    Console.WriteLine("█");
                    Console.SetCursorPosition(124, 11);
                    Console.WriteLine("█");
                    Console.SetCursorPosition(124, 12);
                    Console.WriteLine("█");
                    Console.SetCursorPosition(124, 13);
                    Console.WriteLine("█");

                }
                else if (stuf.Category == Category.armor)
                {
                    string emp = "                                     ";
                    clereStatsStuf();
                    Console.SetCursorPosition(60, 4);//1-255
                    Console.WriteLine("▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
                    Console.SetCursorPosition(60, 5);//1-255
                    Console.WriteLine("█" + $"{"\u001b[38;5;195m" + "< " + stuf.Name + " >" + "\u001b[0m " + emp,-10}");
                    Console.SetCursorPosition(60, 6);
                    Console.WriteLine("█" + $"{"< Type > " + StufGenerator.GetWeaponTypeColor(stuf.WeaponType) + stuf.WeaponType + Material.defaltColor + emp,-10}");
                    Console.SetCursorPosition(60, 7);//1-255
                    Console.WriteLine("█" + "< material > " + stuf.Material.color + stuf.Material.name + Material.defaltColor + emp);
                    Console.SetCursorPosition(60, 8);//1-255
                    Console.WriteLine("█" + "< durability > " + stuf.Material.maxHeal + "/" + stuf.Material.heal + emp);
                    Console.SetCursorPosition(60, 9);//1-255
                    Console.WriteLine("█" + $"{"< " + " \u001b[38;5;95m" + stuf.Icon + "\u001b[0m " + " >=< " + " \u001b[38;5;95m" + stuf.MiniIcon + "\u001b[0m " + " > " + emp,-10}");
                    Console.SetCursorPosition(60, 10);
                    Console.WriteLine("█" + $"{StufGenerator.GetWeaponTypeColor(WeaponType.cutting) + "<Cut_Damage> " + stuf.CutDamage + "\u001b[0m " + StufGenerator.GetWeaponTypeColor(WeaponType.crushing) + "<Crush_Damage> " + stuf.CrushDamage + "\u001b[0m " + emp,-10}");
                    Console.SetCursorPosition(60, 11);
                    Console.WriteLine("█" + $"{" \u001b[36m" + stuf.ArmorResist + "<Armor>" + "\u001b[0m" + emp,-10} ");
                    Console.SetCursorPosition(60, 12);
                    Console.WriteLine("█" + $"{" \u001b[37m" + stuf.ArmorPening + "<ArmorPen>" + "\u001b[0m " + emp,-10} ");
                    Console.SetCursorPosition(60, 13);
                    Console.WriteLine("█" + $"{" \u001b[38;5;220m" + stuf.Cost + "<Cost>" + "\u001b[0m " + emp,-10} ");
                    Console.SetCursorPosition(60, 14);
                    Console.WriteLine("▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀");

                    Console.SetCursorPosition(124, 5);
                    Console.WriteLine("█");
                    Console.SetCursorPosition(124, 6);
                    Console.WriteLine("█");
                    Console.SetCursorPosition(124, 7);
                    Console.WriteLine("█");
                    Console.SetCursorPosition(124, 8);
                    Console.WriteLine("█");
                    Console.SetCursorPosition(124, 9);
                    Console.WriteLine("█");
                    Console.SetCursorPosition(124, 10);
                    Console.WriteLine("█");
                    Console.SetCursorPosition(124, 11);
                    Console.WriteLine("█");
                    Console.SetCursorPosition(124, 12);
                    Console.WriteLine("█");
                    Console.SetCursorPosition(124, 13);
                    Console.WriteLine("█");

                }

                else{ return; }

            }

            GameLog.addLog("Открытие инвентаря ");
            //Respred po categoriuam
            Console.Clear();
            int selectedItem = 0, selectCategory = 0;
            List<Stuf> Weapon = new List<Stuf>(), Armor = new List<Stuf>(), Help = new List<Stuf>(), Tool = new List<Stuf>();
            bool exit = false;


            foreach (Stuf item in Inventory)
            {
                if (item.Category == Category.weapon)
                    Weapon.Add(item);
                else if (item.Category == Category.armor)
                    Armor.Add(item);
                else if (item.Category == Category.help)
                    Help.Add(item);
                else if (item.Category == Category.tool)
                    Tool.Add(item);
            }
            while (true)
            {
                if (exit) return;

                if (selectCategory == 0)
                    inventoryUsing(Weapon);


                if (selectCategory == 1)
                    inventoryUsing(Armor);


                if (selectCategory == 2)
                    inventoryUsing(Help);


                if (selectCategory == 3)
                    inventoryUsing(Tool);

            }

            void inventoryUsing(List<Stuf> list)
            {
                if (list.Count > 0)
                    viseStatsStuf(list[selectedItem]);
                else
                    clereStatsStuf();

                Console.SetCursorPosition(0, 0);
                Console.Write("\r\n— ——╔═══════════════╗— —— \r\n——══╣   ÌÑVÉÑT0RŸ   ╠══—— \r\n — —╚═══════════════╝——   \n");
                if (selectCategory == 0)
                    Console.WriteLine("  ——══╣  WEAPON › ╠══——");
                else if (selectCategory == 1)
                    Console.WriteLine("  ——══╣ ‹ ARMOR › ╠══——");
                else if (selectCategory == 2)
                    Console.WriteLine("  ——══╣ ‹ HELP  › ╠══——");
                else if (selectCategory == 3)
                    Console.WriteLine("  ——══╣ ‹ Tool    ╠══——");
                if (list.Count > 0)
                {
                    Console.WriteLine(">────────%-· ·   ·");
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (selectedItem == i && equpArmor == list[i] || equpWeapon == list[i] || equpTool == list[i])
                        { Console.BackgroundColor = ConsoleColor.Yellow; Console.WriteLine("| " + "\u001b[34m" + (list[i].Name) + " ♦" + "\u001b[0m"); Console.ResetColor(); Console.WriteLine(">────────%-· ·   ·"); }
                        else if (equpArmor == list[i] || equpWeapon == list[i] || equpTool == list[i])
                        { Console.WriteLine("| " + (list[i].Name) + " ♦"); Console.WriteLine(">────────%-· ·   ·"); }
                        else if (selectedItem == i)
                        { Console.BackgroundColor = ConsoleColor.White; Console.WriteLine("| " + "\u001b[34m" + (list[i].Name) + "\u001b[0m"); Console.ResetColor(); Console.WriteLine(">────────%-· ·   ·"); }
                        else
                        { Console.WriteLine("| " + (list[i].Name)); Console.WriteLine(">────────%-· ·   ·"); }
                    }
                }
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Escape or ConsoleKey.I: Console.Clear(); exit = true; return; break;



                    case ConsoleKey.UpArrow or ConsoleKey.W:
                        {
                            if (selectedItem >= 1 && list.Count > 0)
                                selectedItem = selectedItem - 1;
                        }
                        break;
                    case ConsoleKey.DownArrow or ConsoleKey.S:
                        {
                            if (selectedItem < list.Count - 1 && list.Count > 0)
                                selectedItem = selectedItem + 1;
                        }
                        break;
                    case ConsoleKey.LeftArrow or ConsoleKey.A://<<
                        {
                            if (selectCategory >= 1)
                            {

                                selectCategory = selectCategory - 1;
                                selectedItem = 0;
                                Console.Clear();
                            }
                        }
                        break;
                    case ConsoleKey.RightArrow or ConsoleKey.D://>>
                        {
                            if (selectCategory < 4 - 1)
                            {
                                selectCategory = selectCategory + 1;
                                selectedItem = 0;

                                Console.Clear();
                            }
                        }
                        break;
                    case ConsoleKey.Enter or ConsoleKey.E://use
                        {
                            Console.Clear();
                            if (list.Count > 0 && Category.armor == list[selectedItem].Category)
                            {
                                if (equpArmor == list[selectedItem])
                                { equpArmor = null; GameLog.addLog("Снят Доспех : " + " \u001b[36m" + list[selectedItem].Name + " \u001b[0m"); }
                                else
                                {
                                    equpArmor = list[selectedItem];

                                    GameLog.addLog("Экипирован доспех : " + " \u001b[36m" + list[selectedItem].Name + " \u001b[0m");

                                    UpdateStats();
                                }
                            }
                            else if (list.Count > 0 && Category.weapon == list[selectedItem].Category)
                            {

                                if (equpWeapon == list[selectedItem])
                                { equpWeapon = null; GameLog.addLog("Снято оружие : " + " \u001b[36m" + list[selectedItem].Name + " \u001b[0m"); }
                                else
                                {
                                    equpWeapon = list[selectedItem];
                                    GameLog.addLog("Экипировано оружие : " + " \u001b[36m" + list[selectedItem].Name + " \u001b[0m");

                                    UpdateStats();
                                }
                            }
                            else if (list.Count > 0 && Category.tool == list[selectedItem].Category)
                            {
                                if (equpTool == list[selectedItem])
                                { equpTool = null; GameLog.addLog("Снят инструмент : " + " \u001b[36m" + list[selectedItem].Name + " \u001b[0m"); }
                                else
                                {


                                    equpTool = list[selectedItem];
                                    GameLog.addLog("Экипирован инструмент : " + " \u001b[36m" + list[selectedItem].Name + " \u001b[0m");

                                    UpdateStats();
                                }

                            }

                            else if (list.Count > 0 && Category.help == list[selectedItem].Category)
                            {
                                     equpHelp = list[selectedItem];
                                     GameLog.addLog("Применён : " + " \u001b[36m" + list[selectedItem].Name + " \u001b[0m");

                                UpdateStats();
                                if (equpHelp.Material.heal <= 0)
                                {
                                    Help.Remove(equpHelp);
                                    Inventory.Remove(equpHelp);
                                    equpHelp = null;
                                }
                                
                                
                                    
                                

                            }


                        }
                        break;

                }
                if (list.Count > 0)
                    viseStatsStuf(list[selectedItem]);
                else
                    clereStatsStuf();


            }

        }



        public static bool CanMove(Direction direction)
        {
            if ((TravalingScreen.map.GetLength(1) <= x || TravalingScreen.map.GetLength(0) <= y) || (0 > x || 0 > y))
                return false;


            MapObjects obj = direction switch
            {
                Direction.Up => y - 1 >= 0 ? TravalingScreen.map[y - 1, x] : MapObjects.Wall,
                Direction.Left => x - 1 >= 0 ? TravalingScreen.map[y, x - 1] : MapObjects.Wall,
                Direction.Down => y + 1 < TravalingScreen.map.GetLength(0) ? TravalingScreen.map[y + 1, x] : MapObjects.Wall,
                Direction.Right => x + 1 < TravalingScreen.map.GetLength(1) ? TravalingScreen.map[y, x + 1] : MapObjects.Wall,
                _ => MapObjects.Ground,
            };
            return !obj.IsWall();
        }
        public static bool CanChip(Direction direction)
        {

            if ((TravalingScreen.map.GetLength(1) <= x || TravalingScreen.map.GetLength(0) <= y) || (0 > x || 0 > y))
                return false;
            switch (direction)
            {
                case Direction.Up:

                    if (y - 1 >= 0)
                        return false;
                    break;
                case Direction.Left:
                    if (x - 1 >= 0)
                        return false;
                    break;
                case Direction.Down:
                    if (y + 1 < TravalingScreen.map.GetLength(0))
                        return false;
                    break;
                case Direction.Right:
                    if (x + 1 < TravalingScreen.map.GetLength(1))
                        return false;
                    break;


            }

            return true;
        }




        public static void move(TravalingScreen map)
        {
            IsMining = false;
            GameLog.visible();
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.W or ConsoleKey.UpArrow:
                    if (equpTool != null && !CanChip(Direction.Up))
                    { map.ChipWall(y - 1, x); }

                    if (CanMove(Direction.Up) && !IsMining)
                    {
                       
                        if (equpArmor != null && equpArmor.Name == "Каляска")
                            if (ride)
                            { GameLog.addLog("Пошло поехало /\\"); y -= 1;ride = false; }
                            else
                            { ride = true; GameLog.addLog("Прогрев колёс"); }


                        else
                        {
                            GameLog.addLog("Игрок ходит /\\");
                            y -= 1;
                        }
                    }
                    break;

                case ConsoleKey.A or ConsoleKey.LeftArrow:
                    if (equpTool != null && !CanChip(Direction.Left))
                    { map.ChipWall(y, x - 1); }


                    if (CanMove(Direction.Left) && !IsMining)
                    {
                        
                        if (equpArmor != null && equpArmor.Name == "Каляска")
                            if (ride)
                            { GameLog.addLog("Пошло поехало <<"); x -= 1; ride = false; }
                            else
                            { ride = true; GameLog.addLog("Прогрев колёс"); }
                        else
                        {
                            GameLog.addLog("Игрок ходит <<");
                            x -= 1;
                        }

                    }
                    break;
                case ConsoleKey.S or ConsoleKey.DownArrow:
                    if (equpTool != null && !CanChip(Direction.Down))
                    { map.ChipWall(y + 1, x); }


                    if (CanMove(Direction.Down) && !IsMining)
                    {
                        
                        if (equpArmor != null && equpArmor.Name == "Каляска")
                            
                        if(ride)
                        { GameLog.addLog("Пошло поехало \\/");  y += 1; ride = false; }
                        else
                        { ride = true; GameLog.addLog("Прогрев колёс"); }
                        else
                        {
                            GameLog.addLog("Игрок ходит \\/");
                            y += 1;
                        }

                    }
                    break;


                case ConsoleKey.D or ConsoleKey.RightArrow:
                    if (equpTool != null && !CanChip(Direction.Right))
                    { map.ChipWall(y, x + 1); }


                    if (CanMove(Direction.Right) && !IsMining)
                    {

                        if (equpArmor != null && equpArmor.Name == "Каляска")
                            if (ride)
                            {
                                GameLog.addLog("Пошло поехало >>");
                                x += 1;
                                ride = false;
                            }
                            else
                            { ride = true; GameLog.addLog("Прогрев колёс"); }
                        else
                        {
                            GameLog.addLog("Игрок ходит >>");
                            x += 1;
                        }

                    }
                    break;


                case ConsoleKey.I:
                    inventory();
                    return;

                case ConsoleKey.L:
                    GameLog.importToFile();
                    return;
                default:
                    return;

            }
            for (int i = 0; i < Program.visibleMonsters.Count; i++)
            {
                int rad = 5;
                if (y - rad <= Program.visibleMonsters[i].y && y + rad >= Program.visibleMonsters[i].y
                && x - rad <= Program.visibleMonsters[i].x && x + rad >= Program.visibleMonsters[i].x)
                    Program.visibleMonsters[i].monsterMove(x, y);
                Program.Event(Program.visibleMonsters[i]);
            }
        }
    }
}
