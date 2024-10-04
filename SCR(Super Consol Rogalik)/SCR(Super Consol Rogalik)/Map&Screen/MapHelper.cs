using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCR_Super_Consol_Rogalik_.Map_Screen
{
    public static class MapHelper
    {
        public static char GetTile(this MapObjects obj) => obj switch
        {
            MapObjects.WallHeavy => '█',
            MapObjects.Wall => '▓',//█
            MapObjects.WallDamaged => '▒',
            MapObjects.WallChipped => '░',
            MapObjects.Water => '~',
            MapObjects.DeepWater => '~',
            MapObjects.Ground => '·',
            MapObjects.Gobline => 'G',
            _ => ' '
        };
        // УТИЛЬ
        public static MapObjects GetName( char ch) => ch switch
        {
            '█' => MapObjects.WallHeavy,
            '▓' => MapObjects.Wall,
            '▒' => MapObjects.WallDamaged,
            '░' => MapObjects.WallChipped,
            '~' => MapObjects.Water,
            'D' => MapObjects.DeepWater,
            '·' => MapObjects.Ground,
            'G' => MapObjects.Gobline,
            _ => MapObjects.Ground
        };
        
        public static bool IsWall(this MapObjects obj) => obj switch
        {
            MapObjects.Wall => true,
            MapObjects.WallDamaged => true,
            MapObjects.WallChipped => true,
            MapObjects.WallHeavy => true,
            MapObjects.DeepWater=> true,
            _ => false
        };
    }
}
