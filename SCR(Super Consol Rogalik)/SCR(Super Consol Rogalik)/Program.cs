using SCR_Super_Consol_Rogalik_.Entiti;
using SCR_Super_Consol_Rogalik_.Map_Screen;
using System;
using System.Media;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Design;
using System.Threading;
using SCR_Super_Consol_Rogalik_.GameStuf;
using System.Reflection.Metadata.Ecma335;

namespace SCR_Super_Consol_Rogalik_
{
    internal class Program
    {
        public static List<Monster> monsters = new List<Monster>();
        public static List<Monster> visibleMonsters = new List<Monster>();

        //public void play(TravalingScreen map,Player player)
        // { while(true){ map.Visible(player);player.move(); } }

        public static void CheckItems()
        {
            List<Stuf> removeItems = new List<Stuf>();
            foreach (Stuf item in Player.Inventory) 
            {if (item != null&& item.Material.heal<=0)
                { 
                removeItems.Add(item);
                }
            }
            if(Player.equpTool !=null && Player.equpTool.Material.heal<=0) 
            {
            
                Player.equpTool = null;
            }
            if (Player.equpWeapon!= null && Player.equpWeapon.Material.heal <= 0)
            {
                
                Player.equpWeapon = null;
            }
            if (Player.equpArmor != null && Player.equpArmor.Material.heal <= 0)
            {
                
                Player.equpArmor = null;
            }
            foreach (Stuf item in removeItems)
            {
                Player.Inventory.Remove(item);
                GameLog.addLog("Ваш "+ item.Name+" сломан");
                Console.Clear();
            }
            
        }
        public static bool isEvent(Monster monsterr)
        {
            return monsterr.x == Player.x && monsterr.y == Player.y;
        }
        public static bool Event(Monster monster) 
        {
            Monster buffmonstr = null;
            if (isEvent(monster))
            {
                if (monster.x == Player.x && monster.y == Player.y)
                {
                    new Event( monster); buffmonstr = monster; monster.x = 0; monster.y = 0; Console.WriteLine("AAAAAAAAAAAAA"); 
                }
                monsters.Remove(buffmonstr);
                visibleMonsters.Remove(buffmonstr);
                Console.Clear();
                return true;
            }
            else
            {
                GameLog.visStatPlayer();
            }
            return false;
        }
        public static void SpawnPlayer(MapObjects[,] map)
        {
            int W = map.GetLength(0);
            int H = map.GetLength(1);
            int sqverR=3;
            
            int posX=0, posY=0;
            Random rd = new Random();
            while (true) 
            {
                bool IsClear = true;
            posX = rd.Next(sqverR,W-sqverR);
            posY = rd.Next(sqverR,H-sqverR);
            for(int i = posX-sqverR; i < posX+sqverR; i++)
                {
                    for (int j = posY - sqverR; j < posY + sqverR; j++)
                    {
                        if (map[i,j].IsWall())
                            IsClear = false;
                    }
                }
                
            if (IsClear) { Player.y = posX;Player.x = posY; return; }
            }

        }
        static void Main(string[] args)
        {
            MainMeny meny = new MainMeny();
            TravalingScreen map ;

            
           //       monsters.Add(new Monster(Monster.Type.Slime, "Slime Henry", 0, 0));
            //    monsters.Add(new Monster(Monster.Type.Slime, "Slime Malroy", '*', 0, 1));
            //monsters.Add(new Monster(Monster.Type.Slime, "Slime Oliver", '*', 1, 2));
            //monsters.Add(new Monster(Monster.Type.SkeletonLight, "Skeleton GRAG", '&', 5, 7));
            //monsters.Add(new Monster(Monster.Type.HeavySkeleton, "Skeleton Malroy", '▐', 5, 8));
            //monsters.Add(new Monster(Monster.Type.GoblinSpear, "Goblin Mifi", '%', 5, 9));
            //Player.Inventory.Add(new Stuf("None", "Это ваши руки", Category.weapon, ". .", '.', new Material("Плоть", 999999, 0, "255"), 0, 0, 0, 0, WeaponType.crushing));
            //  Player.equpWeapon = Player.Inventory[0];
            /*
            Player.Inventory.Add( new Stuf("Палка", "это обычная палка", Category.weapon, "l~-7-*-",'1', 2, 0, 0));
            Player.Inventory.Add( new Stuf("Палка2", "это обычная палка", Category.weapon, "l~-7-*-", '1', 2, 0, 0));
            Player.Inventory.Add( new Stuf("Палка3", "это обычная палка", Category.weapon, "l~-7-*-", '1', 2, 0, 0));
            Player.Inventory.Add( new Stuf("Бастард", "это обычный ржавый хлам", Category.weapon, "I-=|~~~~-",'│', 10, 4, 0));
            Player.Inventory.Add( new Stuf("Цифровой кукри", "это самый скверный меч, который вы когда либо видели", Category.weapon, "I-=|5--7",'!', 5, 2, 0));
            */
            
            //   Player.Inventory.Add(new Stuf("Броня2", "Броня крутаяйу", Category.armor, "-/\\-/.", '♦', new Material("еда", 1, 0, "1"), 0, 0, 0, 3));
            //  Player.Inventory.Add(new Stuf("Броня3", "Броня крутаяйуйу", Category.armor, "-/\\-/", '■', new Material("еда", 1, 0, "1"), 0, 0, 0, 2));

            
            //  Player.Inventory.Add(new Stuf("Яблоко2", "Вкусное", Category.help, "(|\\)", '♠', new Material("еда", 1, 0, "1"), 1, 0, 0, 0));
            //  Player.Inventory.Add(new Stuf("Яблоко4", "Вкусное", Category.help, "(*\\)", '♠', new Material("еда", 1, 0, "1"), 1, 0, 0, 0));
           // Player.Inventory.Add(StufGenerator.GenWeapon());
           
          


            Console.WindowLeft = 0;
            Console.WindowTop = 0;
            Console.SetWindowSize(180, 60);
            

            
           
            
            Console.CursorVisible = false;

            while (true)
            {
                switch (meny.startMeny())
                {
                    case 0:
                        // Thread a = new Thread(()=> StufGenerator.GenWeapon());
                        Console.Clear();
                        map = new TravalingScreen();
                        Player.x = 10; Player.y = 9;

                        Player.Heal = 10;
                        Player.equpTool = null;
                        Player.equpArmor = null;
                        Player.equpWeapon = null;   
                        Player.UpdateStats();
                        Player.Inventory.Clear();

                        Player.Inventory.Add(new Stuf("Каляска", "калясочка", Category.armor, "|/{0%-{0", '0', new Material("Сталь", 1000, 0, "207"), 0, 0, 0, 0));

                        Player.Inventory.Add(new Stuf("Не прочная кирка", "Ржавеет...", Category.tool, "==}", '>', new Material("дешёвая сталь", 1000, 0, "1000"), 1, 0, 0, 0));
                        //   Player.Inventory.Add(new Stuf("Каляска", "калясочка", Category.armor, "|/{0%-{0", '0', new Material("Сталь", 1000, 0, "207"), 0, 0, 0, 0));
                        Player.Inventory.Add(StufGenerator.GenWeapon());
                        Player.Inventory.Add(new Stuf("Гнилая слива", "Вкусное", Category.help, "(\\)", '♠', new Material("еда", 1, 0, "1"), 1, 0, 0, 0));
                        Player.Inventory.Add(new Stuf("Яблоко", "Вкусное", Category.help, "(\\)", '♠', new Material("еда", 2, 0, "1"), 1, 0, 0, 0));

                        SpawnPlayer(TravalingScreen.map);
                        MonsterGenerator.Generate(250);

                        while (true)
                        {
                            //Console.WriteLine("{152}  | {1,2}");
                            //Console.WriteLine("{100} | {1,2}");
                            //Console.WriteLine("{0,10}|{1,5}",111111,2222222,3333333,4444);

                            // a.Start();
                            // Воспроизводим мелодию

                           
                            CheckItems(); 
                            GameLog.visible();
                            GameLog.visStatPlayer();
                            visibleMonsters.Clear();
                            foreach (var monster in monsters)
                                if (
                                    Player.y - TravalingScreen.visRadius <= monster.y && Player.y + TravalingScreen.visRadius >= monster.y
                                    && Player.x - TravalingScreen.visRadius <= monster.x && Player.x + TravalingScreen.visRadius >= monster.x)
                                    visibleMonsters.Add(monster);
                            map.Visible();
                            if(Player.IsDead) 
                            {
                                Console.Clear();
                                Player.IsDead = false;
                                break;
                            }
                            Player.move(map);
                            GameLog.visible();
                            
                         //   SpawnPlayer(TravalingScreen.map);


                        }
                        break;//play
                    case 1:
                        Console.Clear();
                     //   Console.WriteLine("123123123");
                        Console.WriteLine(
                            "Добро пожаловать в проект SuperConsoleRoglike(SCR)\r\nВ этом проекте вы получите уникальный игровой опыт,\r\nкоторый будет различаться в зависимости от прохождения.\r\nТут вы найдёте справку по игровым механикам и сможете чуть больше узнать о противниках,\r\n видах урона, карте и тд.\r\n\r\nУрон и боевая система:\r\n\r\nВ игре используется 2 типа урона: Дробящий, Режущий.\r\nПомимо этого есть  такие параметры, как Броня и броне пробитие.\r\nВ зависимости от типа материала из которого сделан противник (Кости, плоть, слизь)\r\nНекоторые виды урона могут быть более эффективными, чем другие.\r\nНо в большинстве случаев урон рассчитывается по следующей формуле:\r\nРежущийУрон – (Броня-Бронепробитие)+ ДробящийУрон – (Броня-(Бронепробитие+Дробящий урон/2))\r\nВ случае слизней, ваше броне пробитие будет играть против вас и будет отниматься от вашего урона.\r\nЗа победу над противником есть шанс получить новое уникальное оружие, броню, инструменты, предметы помощи (еда, медицина и тд.)\r\n\r\nКарта и перемещение:\r\n\r\nПри начале забега вы попадаете в случайную часть карты состоящую из скал разной плотности\r\nи озёр состоящих из воды разной глубины.\r\nКрая карты обозначены пустыми клетками и ограничивают перемещение персонажа.\r\nСкалы разных плотностей можно вскапывать с помощью спец. инструментов.\r\nНа добычу скал разной плотности уходит разное количество ходов. Чем плотнее\r\nТем больше.\r\nСамо же перемещение происходит благодаря стрелками или клавишам “W”,”A”,”S”,”D”.\r\n\r\nСистема инвентаря:\r\n\r\nПри нажатии на “I” вы можете открыть ваш инвентарь, в котором находятся все имеющиеся у\r\nвас предметы.\r\nПереключение между категориями происходит нажатиями стрелок << >> или клавиш “A”,”D”.\r\nПереключение между предметами происходит нажатиями стрелок /\\ \\/ или клавиш “W”, ”S”.\r\nЭкипировка или использование предмета происходит по нажатию “Enter”.\r\nВыход из инвентаря происходит по нажатию “Esc” или “I”.\r\n\r\nСтатистика и лог-лист:\r\n\r\nВсе действия произведённые вами внутри проекта записываються и выводяться в игровое поле и в отдельный \r\n.ТХТ файл, что бы вы могли следить за последовательностью ваших действий.\r\nТакже под игровым полем выведены все ваши текущие характеристики и экиперовка влияющая на бой.\r\n\r\n\r\n");
                        Console.WriteLine("\u001b[38;5;239m"+"Нажмите любую кнопку для продолжения"+ "\u001b[0m ");
                        Console.ReadLine();
                        Console.Clear();
                        break;//setings

                    case 2: return; break;//exit
                }

               

            }
        }
    }
}
