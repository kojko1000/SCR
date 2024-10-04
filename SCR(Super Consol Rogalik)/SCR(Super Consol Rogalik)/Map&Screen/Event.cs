using SCR_Super_Consol_Rogalik_.Entiti;
using SCR_Super_Consol_Rogalik_.GameStuf;
using SCR_Super_Consol_Rogalik_.Map_Screen.AnimationClasses;
using SCR_Super_Consol_Rogalik_.muz;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace SCR_Super_Consol_Rogalik_.Map_Screen
{
    public class Event
    {
        
        public Monster monster;

        //Monster Event
        public Event( Monster monster)
        {
             this.monster = monster;

            //
            Console.Clear();

            var output = Console.Out;

            monsterImage(monster.type, output);

            //
         
            Console.SetOut(output);
            GameLog.visible();
        }
        private void monsterImage(Monster.Type type, TextWriter consoleOutput) 
        {
            bool monsterCan7 = false, isDeff7=false;
            //StringBuilder buff = new();

            
          //  Console.SetOut(new StringWriter(buff));

            Button button1 = new Button("атака", "ATAKA");
            Button button2 = new Button("защита", "ЗАЩИТА");
            Button button3 = new Button("сбежать", "СБЕЖАТЬ");
            Button button4 = new Button("стаф", "СТАФ");
            List<Button> buttons = new List<Button>();
            int selected = 0;
            buttons.Add(button1);
            buttons.Add(button2);
            buttons.Add(button3);
            buttons.Add(button4);

            
           
      
                    while (true)
                    {

                    if (monsterCan7 && monster.heal>0)
                          {
                    monster.monsterDo();
                    monsterCan7 = false;
                          }

                if (Player.Heal<=0)
                        {
                            Console.Clear() ;
                    Console.WriteLine("GAME OVER");
                    Thread.Sleep(1000);
                    Player.IsDead = true;
                    return;
                        }
                    if(monster.heal<=0) 
                    {
                    GameLog.addLog(monster.Name + " Был побеждён ");
                    Player.Inventory.Add(StufGenerator.GenWeapon());
                    return;
                    }


                    Console.SetCursorPosition(0, 0);
              //  buff.Clear();

               

                Console.WriteLine(MonsterAnimetion.playIdleAnimation(type));
                  
                        //Console.WriteLine("-------------------------------------------------------------------");

                        if (Console.KeyAvailable)
                        {
                         if (isDeff7)
                            { Player.Armor = Player.Armor - Player.DefResist; isDeff7 = false; }

                            switch (Console.ReadKey(true).Key)
                            {
                                case ConsoleKey.D or ConsoleKey.RightArrow:
                                    if (selected + 1 < buttons.Count)    
                                              selected++;
                                break;
                                case ConsoleKey.A or ConsoleKey.LeftArrow:
                                    if (selected - 1 >= 0)
                                        selected--;
                                    break;
                                  case ConsoleKey.Spacebar or ConsoleKey.Enter or ConsoleKey.UpArrow:
                            if (selected == 0)//atack
                            {
                                PlaySound.monsterHaveDamage.Play();
                              //  monster.heal = monster.heal -Math.Clamp( (Player.CutDamage - Math.Clamp(monster.Armor- Player.ArmorPen,0,monster.Armor)),0,monster.heal);
                                monster.getDamage(Player.CutDamage,Player.CrushDamage,Player.ArmorPen);
                                monsterCan7 = true;

                                if(Player.equpWeapon != null)
                                     Player.equpWeapon.Material.heal = Player.equpWeapon.Material.heal - (10- Player.equpWeapon.Material.bonus);

                                Program.CheckItems();


                               
                            }
                            else if (selected == 1)//def
                            { Player.Armor = Player.Armor+ Player.DefResist;isDeff7 = true; monsterCan7 = true; }

                            else if (selected == 3)//inv
                            { Player.inventory(); monsterCan7 = false; }

                            else if (selected == 2)//esc
                            {Player.Heal = Player.Heal - new Random().Next(0, monster.damage); return; }

                           

                            break;
                             
                           }
                        }
                          
                        //Clamp(armor
                        //
                        //
                        //)
                        else
                        {
                            
                            for (int i = 0; i < 3; i++)
                            {
                                for (int j = 0; j < buttons.Count; j++)
                                    if (selected==j)
                                {
                                    Console.Write("   " + "\u001b[36m" + (buttons[j].linesSelected[i]) + "\u001b[0m"+"   ");
                                }
                                else
                                {
                                    Console.Write("   " + buttons[j].lines[i] + "   ");
                                }
                                Console.WriteLine();
                            }
                        }

                
                
                     statInf( monster);

                

              //  Console.WriteLine("------------------------------------------------------------");
                        

                       
                       // consoleOutput.Write(buff);
                
                        GameLog.visible();
                    }


                

            
            
        }
        public void statInf( Monster monster)
        {
            string emp = "                                                                                 ";
            Player.UpdateStats();
            Console.WriteLine($"{"Player",-10}{monster.Name,50}");
            Console.WriteLine($"{" \u001b[32m" + Player.Heal + "<Heal>" + "\u001b[0m ",-10}{" \u001b[32m" + monster.heal + "<Heal>" + "\u001b[0m ",50}                {"       ",0}");
            Console.WriteLine($"{" \u001b[31m" + (Player.CutDamage+Player.CrushDamage) + "<Damage>" + "\u001b[0m ",-10}{" \u001b[31m" + monster.damage + "<Damage>" + "\u001b[0m ",50}        {"       ",0}");
            Console.WriteLine($"{" \u001b[36m" + Player.Armor + "<Armor>"+ "\u001b[0m",-10} {" \u001b[36m" + monster.Armor + "<Armor>" + "\u001b[0m ",50}             {"       ",0}");
            Console.WriteLine($"{" \u001b[37m" + Player.ArmorPen + "<ArmorPen>" + "\u001b[0m ",-10}{" \u001b[37m" + monster.armorPen + "<ArmorPen>" + "\u001b[0m ",50}{"       ",0} ");
            Console.WriteLine(emp);
           
           
            //  " \u001b[32m"+""+"\u001b[0m "
            //  " \u001b[31m"+""+"\u001b[0m "
            //  " \u001b[36m"+""+"\u001b[0m "
            //  " \u001b[37m"+""+"\u001b[0m "




        }



    }
}
