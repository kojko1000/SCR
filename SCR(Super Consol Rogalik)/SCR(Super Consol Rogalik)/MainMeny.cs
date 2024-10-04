using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SCR_Super_Consol_Rogalik_
{
    public class MainMeny
    {
        public int state;

        public MainMeny()
        { this.state = 0; }

        public void start(){ this.state = 0;
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(" ╔═══════════════╗ \r\n›║     START     ║‹\r\n ╚═══════════════╝ ");
            Console.ResetColor();
            Console.WriteLine(" ┌───────────────┐ \r\n │   reference   │ \r\n └───────────────┘ ");
            Console.WriteLine(" ┌───────────────┐ \r\n │     exit      │ \r\n └───────────────┘ ");
        }
        public void seting()
        {
            this.state = 1;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(" ┌───────────────┐ \r\n │     start     │ \r\n └───────────────┘ ");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(" ╔═══════════════╗ \r\n›║   REFERENCE   ║‹\r\n ╚═══════════════╝ ");
            Console.ResetColor();
            Console.WriteLine(" ┌───────────────┐ \r\n │     exit      │ \r\n └───────────────┘ ");
        }
        public void exit(){ this.state = 2;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(" ┌───────────────┐ \r\n │     start     │ \r\n └───────────────┘ ");
            Console.WriteLine(" ┌───────────────┐ \r\n │   reference   │ \r\n └───────────────┘ ");
            Console.ForegroundColor =ConsoleColor.Black;
            Console.BackgroundColor =ConsoleColor.White;
            Console.WriteLine(" ╔═══════════════╗ \r\n›║     EXIT      ║‹\r\n ╚═══════════════╝ ");
            Console.ResetColor();
        }
        //
        public int startMeny()
        {
            start();
            while(true) {
                switch (Console.ReadKey(true).Key)
                {
                    //up meny active meny button
                    case ConsoleKey.W://w "wSystem.ConsoleKeyInfo"
                        switch (state)
                        {
                            case 1:
                                start();
                                break;
                            case 2:
                                seting();
                                break;
                        }
                    break;
                    //up meny active meny button
                    case ConsoleKey.UpArrow://\
                        switch (state)
                        {
                            case 1:
                                start();
                                break;
                            case 2:
                                seting();
                                break;
                        }
                        break;
                    //up meny active meny button
                    case ConsoleKey.S://s
                        switch (state)
                        {
                            case 0:
                                seting();
                                break;
                            case 1:
                                exit();
                                break;

                        }
                    break;
                    case  ConsoleKey.DownArrow://\/
                        switch (state)
                        {
                            case 0:
                                seting();
                                break;
                            case 1:
                                exit();
                                break;

                        }
                    break;

                    //Enter
                    case ConsoleKey.Enter:
                        return state;
                    case ConsoleKey.Spacebar:
                        return state;
                        break;
                }

            }
            
        }


    }
}
