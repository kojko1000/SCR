using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SCR_Super_Consol_Rogalik_.Map_Screen
{
    public class Button
    {

        public string text,textSelected;
        public string line1 = "┌───────────────┐", line3 = "└───────────────┘", line1Selected = "╔═══════════════╗", line3Selected = "╚═══════════════╝";
        public string line2 = "", line2Selected = "";
        public string[] lines = new string[3] ;
        public string[] linesSelected = new string[3] ;
        private string line2get(string text111,bool selected)
        { if (text.Length < line1.Length) {
                string line="";
                if (selected)
                     line = "║";
                else
                     line = "│";
                int a1 = (((line1.Length - text.Length))/2)-1;
                int a2 = (((line1.Length - text.Length)-1)-a1)-1;
                for (int i = 0; i < a1; i++) { line = line + " "; }
                line += text111;
                for (int i = 0; i < a2; i++) { line = line + " "; }

                if (selected)
                    line += "║";
                else
                    line += "│";
                
                return line;
            } 
            else return ("???");
        }
      
        public Button(string text,string textSelected) { this.text = text; this.textSelected=textSelected; line2 = line2get(text,false);line2Selected = line2get(textSelected,true);
            lines[0] = line1; lines[1] = line2; lines[2] = line3;
            linesSelected[0] = line1Selected; linesSelected[1] = line2Selected; linesSelected[2] = line3Selected;
                     }
        
    }
}
