using SCR_Super_Consol_Rogalik_.Entiti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Media;

namespace SCR_Super_Consol_Rogalik_.muz
{
    public static class PlaySound
    {
       // private static string filePath = "Sounds/monsterHaveDamage.wav";
        private static string filePath = "Sounds/PlayerWalking.wav";
        private static string filePath1 = "Sounds/PlayerWalking.wav";
       // public static 
      //  private static MediaPlayer m_mediaPlayer;
        public static SoundPlayer monsterHaveDamage = new SoundPlayer(filePath);
        public static SoundPlayer playerWalk = new SoundPlayer(filePath1);
        public static void over()
        {
            
        }
    }
}
