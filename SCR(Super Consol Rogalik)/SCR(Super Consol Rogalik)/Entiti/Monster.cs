using SCR_Super_Consol_Rogalik_.GameStuf;
using SCR_Super_Consol_Rogalik_.Map_Screen;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SCR_Super_Consol_Rogalik_.Entiti
{
    public enum MonsterMatirial
    {
        bones,
        meat,
        slime
    }
    public class Monster
    {
        public enum Type
        {
            Slime,
            SkeletonLight,
            HeavySkeleton,
            GoblinSpear

        }
       
        public Type type;
        public string Name;
        public char Icon;
        public int y, x;
        public int damage, heal, armorPen, Armor;
        public MonsterMatirial monsterMatirial;
        public Monster(Type type, string name, int x, int y)
        { this.type = type; this.Name = name; this.y = y; this.x = x;
            switch (type)
            {
                case Type.Slime:
                    damage = 1;
                    heal = 3;
                    armorPen = 1;
                    Armor = 0;
                    monsterMatirial = MonsterMatirial.slime;
                    this.Icon = '*';
                    break;
                case Type.SkeletonLight:
                    damage = 2;
                    heal = 10;
                    armorPen = 2;
                    Armor = 1;
                    monsterMatirial = MonsterMatirial.bones;
                    this.Icon = '|';
                    break;
                case Type.HeavySkeleton:
                    damage = 2;
                    heal = 20;
                    armorPen = 5;
                    Armor = 5;
                    monsterMatirial = MonsterMatirial.bones;
                    this.Icon = '&';
                    break;
                case Type.GoblinSpear:
                    damage = 5;
                    heal = 7;
                    armorPen = 0;
                    Armor = 1;
                    monsterMatirial = MonsterMatirial.meat;
                    this.Icon = '%';
                    break;

            }

        }
        public void monsterDo()
        {
            atack();

        }
        private void atack() 
        { Player.Heal = Player.Heal -  Math.Clamp(damage-( Player.Armor-armorPen),0,damage);

            GameLog.addLog("Вы получил " + " \u001b[31m" + (Player.Heal-(Player.Heal - Math.Clamp(damage - (Player.Armor - armorPen), 0, damage))) + "\u001b[0m " + " ед. урона от" + Name);


        }
        
        private void def() { }
        
        public void getDamage(int cutDamage,int crushDamage,int armorPen)
        {

            //cut
            //  int res2 = Heal - Math.Clamp(CutDamage - Math.Clamp(Armor - ArmorPen, 0, Armor), 0, CutDamage);
            //crush
            //  int res1 = Heal - Math.Clamp(CrushDamage - Math.Clamp(Armor - (CrushDamage / 2 + ArmorPen), 0, Armor), 0, CutDamage);
            //ult
            //  int res = Heal - (Math.Clamp(CrushDamage - Math.Clamp(Armor - (CrushDamage / 2 + ArmorPen), 0, Armor), 0, CutDamage) + Math.Clamp(CutDamage - Math.Clamp(Armor - ArmorPen, 0, Armor), 0, CutDamage));
            
            int startHeal = heal;
             int getedCutDamage = Math.Clamp(cutDamage - Math.Clamp(Armor - armorPen, 0, Armor), 0, cutDamage);
             int getedCrushDamage = Math.Clamp(crushDamage - Math.Clamp(Armor - (crushDamage / 2 + armorPen), 0, Armor), 0, cutDamage);
            int antiDamage = 0;
            switch (monsterMatirial)
            {
                case MonsterMatirial.slime:
                    antiDamage = armorPen / 2;
                    heal = heal - Math.Clamp(((getedCrushDamage + getedCutDamage) -armorPen/2),1, getedCrushDamage + getedCutDamage);//пробивать слизь не поможет вам выйграть
                    break;
                case MonsterMatirial.meat:
                   
                
                    heal = heal-(getedCrushDamage+getedCutDamage);
                    break;
                case MonsterMatirial.bones:
                    getedCutDamage = getedCutDamage/2;
                    heal = heal - (getedCrushDamage + getedCutDamage);
                    break;
            }
            GameLog.addLog(Name + " получил " + " \u001b[31m" + (startHeal-heal) + "\u001b[0m " + " ед. урона ");
            GameLog.addLog(Name + " получил " + StufGenerator.GetWeaponTypeColor(WeaponType.crushing)  +getedCrushDamage + "\u001b[0m " + " ед. дробящего урона " +
            StufGenerator.GetWeaponTypeColor(WeaponType.cutting) + getedCutDamage + "\u001b[0m " + " ед. режущего урона ");
        }

        public void monsterMove(int targetX, int targetY)
        {

            if (type == Monster.Type.Slime)
            {
                int nextX = x + Math.Sign(targetX - x);
                int nextY = y + Math.Sign(targetY - y);

                bool monsterCollisionX = false;
                bool monsterCollisionY = false;
                foreach (var monster in Program.visibleMonsters)
                    if (monster != this)
                    {
                        if (!monsterCollisionX)
                            monsterCollisionX = monster.x == nextX;
                        if (!monsterCollisionY)
                            monsterCollisionY = monster.y == nextY;
                    }

                if ((TravalingScreen.map[y, nextX].IsWall() || monsterCollisionX || x == (x = nextX)) && !TravalingScreen.map[nextY, x].IsWall() && !monsterCollisionY)
                    y = nextY;
            }
            else 
            {
                int nextX = x + Math.Sign(targetX - x);
                int nextY = y + Math.Sign(targetY - y);

                bool monsterCollisionX = false;
                bool monsterCollisionY = false;
                foreach (var monster in Program.visibleMonsters)
                    if (monster != this)
                    {
                        if (!monsterCollisionX)
                            monsterCollisionX = monster.x == nextX;
                        if (!monsterCollisionY)
                            monsterCollisionY = monster.y == nextY;
                    }
               

                if ((TravalingScreen.map[y, nextX].IsWall() || monsterCollisionX || x == (x = nextX)) && !TravalingScreen.map[nextY, x].IsWall() && !monsterCollisionY)
                    y = nextY;
                


            }



        }


    }
}
