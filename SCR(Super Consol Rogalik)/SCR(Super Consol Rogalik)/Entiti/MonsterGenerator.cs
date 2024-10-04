using SCR_Super_Consol_Rogalik_.Map_Screen;
using System;

namespace SCR_Super_Consol_Rogalik_.Entiti
{
    public static class MonsterGenerator
    {
        private static int sqverR = 1;
        private static bool IsCanSpawn(int posX, int posY)
        {
            for (int i = posY - sqverR; i <= posY + sqverR; i++)
                for (int j = posX - sqverR; j <= posX + sqverR; j++)
                    if (TravalingScreen.map[i, j].IsWall() || (i == Player.y && j == Player.x))
                        return false;
            return true;
        }

        public static void Generate(int a)
        {
            Random rd = new Random();
            for (int i = 0; i < a; i++)
            {
                int W = TravalingScreen.map.GetLength(1);
                int H = TravalingScreen.map.GetLength(0);

                int posX = rd.Next(sqverR, W - sqverR);
                int posY = rd.Next(sqverR, H - sqverR);
                int chance = rd.Next(1001);
                if (IsCanSpawn(posX, posY))
                {
                    if (chance >= 950)
                    {
                        Program.monsters.Add(new Monster(Monster.Type.SkeletonLight, "Oleg", posX, posY));
                        GameLog.addLog("Сгенерен монстр " + i);
                    }
                    else
                    {
                        Program.monsters.Add(new Monster(Monster.Type.Slime, "Oleg", posX, posY));
                        GameLog.addLog("Сгенерен монстр " + i);
                    }
                }
            }


        }
    }
}
