using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SCR_Super_Consol_Rogalik_.GameStuf
{
    public enum rares
        { }
    public enum WeaponType
    {
        cutting ,crushing,universal
    }
    
    public enum quality
    {low, lowMed, med, highMed, high }
    public static class StufGenerator
    {
       // public static Material = ;
        public static string GetWeaponTypeColor(WeaponType type)
        {if (type == WeaponType.cutting) return "\u001b[38;5;1m";
            else if (type == WeaponType.crushing) return "\u001b[38;5;3m";
            else if (type == WeaponType.universal) return "\u001b[38;5;202m";
            else return"";
        }

        private static int LowDamage=3,LowMedDamage=5,MedDamage=7,MedHighDamage=8, HighDamage=11;



        private static List<String> names = new List<string>();

        public static Material[] materialsRofl = { new Material("хлебный мякиш", 10,-4,"230"), new Material("Глина", 20,-3, "131"), new Material("Дерево", 50,-2, "136"), new Material("Стекло", 10,1, "14")
                , new Material("Воображаемый", 1,-1000, "234")

        };
        public static Material[] materialsNorm = { new Material("Ржавый лом", 100,-1, "130"), new Material("Повреждённый лом", 90,-1, "95"),new Material("Тупой лом", 120,-1, "94"),
            new Material("Металлический лом", 200,-1, "137"), new Material("Медь", 200,0, "36"), new Material("Бронза", 300,1, "209"),
            new Material("Висмутовая бронза", 300,1, "30"),new Material("Оловянная бронза", 300,1, "215"),new Material("Свинцовая бронза", 300,1, "180"),
            new Material("Олово", 300,1, "188"),new Material("Железный лом", 300,1, "138")
        };
        public static Material[] materialsGood = { new Material("сталь", 1000,2,"245"), 
        };
        public static Material[] materialsHigh = { new Material("Нефрил", 1500,4, "2"), 
        };
        
       
          private static string[] namesArrLow = {"Ветка","Палка","Сук","Ветвь","Хворост","Росток","Хлам","Киянка"
                    ,"Ножка стула","Ножка стола","Ножка большого гриба","Ножка","Камень","Веник","Качерыжка",
            "качерга","Табличка","Неспелый кабачок",
            "репа","гнилые сливы","Заточка","Протвень","Сковорода","Ложка",
            "Сломанный меч","повреждённый меч","сломанный кинжал","повреждённый нож","кастет"                    };
        private static string[] namesArrLowMed = {"Годэндак","Полэкс","Багор","Альшпис","Пика","Контарион","Лэнс","Тесак"
                    ,"Кинжал","Нож","Клинок","Дрын","Металлический прут","Конеруб","Вакидзасе","Остов меча","Остов булавы"
                    ,"Остов алибарды","Хламо-меч","Фалькс","Сакс","Джамбия","Топорик","Дэссак","Брус","Колбен","Кама"

            };
        private static string[] namesArrMed = {"Гвизар","Фальшион","Меч","Топор","Рогатина","Чинкуэда","Наваха","Крис","Подсаадачный нож","Мэнкечер"
                ,"Кацбальгер","Скъявона","Шпага","Рапира","Спата","Валашка","Бердыш","Пернач","Бан","Чекан","Кистень","Цеп","Клевец","Алибарда"

            };
        private static string[] namesArrHighMed = { "Составной топор","Протазан","Цвайхендер","Шашка","Молотило" };
        private static string[] namesArrHigh = {  "Падающее солнце", "Восходящая луна" };

        //cut

        private static string[] namesArrCutLow = { "Заточка", "Сломанный меч", "повреждённый меч", "сломанный кинжал", "повреждённый нож" };
        private static string[] namesArrCutLowMed = { "Тесак", "Кинжал", "Нож", "Клинок", "Конеруб", "Вакидзасе", "Фалькс", "Сакс", "Джамбия", "Дюссак", "Кама" };
        private static string[] namesArrCutMed = { "Фальшион", "Меч", "Чинкуэда", "Наваха", "Крис", "Подсаадачный нож", "Кацбальгер", "Скьявона", "Шпага", "Рапира", "Спата" };
        private static string[] namesArrCutHighMed = { "Цвайхендер", "Шашка", };
        private static string[] namesArrCutHigh = { "Падающее солнце", "Восходящая луна" };

        //crush
        private static string[] namesArrCrushLow = { "Ветка", "Палка", "Сук", "Ветвь", "Хворост", "Росток", "Хлам", "Киянка", "Ножка стула", "Ножка стола", "Ножка большого гриба", "Ножка", "Камень", "Веник", "Качерыжка", "качерга", "Табличка", "Неспелый кабачок", "репа", "гнилые сливы", "Протвень", "Сковорода", "кастет" };
        private static string[] namesArrCrushLowMed = { "Дрын", "Металлический прут", "Остов булавы", "Брус", "Колбен" };
        private static string[] namesArrCrushMed = { "Бан", "Цеп" };
        private static string[] namesArrCrushHighMed = { "Молотило" };
        private static string[] namesArrCrushHigh = { "Булава пристова" };

        //universal
        private static string[] namesArrUnivLow = { "Ложка" };
        private static string[] namesArrUnivLowMed = { "Годэндак", "Полэкс", "Багор", "Альшпис", "Пика", "Контарион", "Лэнс", "Остов меча", "Остов алибарды", "Хламо-меч", "Топорик", };
        private static string[] namesArrUnivMed = { "Гвизарма", "Топор", "Рогатина", "Мэнкечер", "Валашка", "Бердыш", "Пернач", "Чекан", "Кистень", "Клевец", "Алибарда" };
        private static string[] namesArrUnivHighMed = { "Топор палача", "Протазан" };
        private static string[] namesArrUnivHigh = { "Составной топор" };


        private static StufMod empModWeapon = new StufMod("", Category.weapon, 0,0, 0, 0);
        private static StufMod empModArmor = new StufMod("", Category.armor, 0,0, 0, 0);
        private static StufMod[] modsWeaponArr = { new StufMod("Гнилой",Category.weapon,-1,0,0,0),
             new StufMod("Скверный",Category.weapon,-1,0,0,0), new StufMod("Странно пахнущий",Category.weapon,-1,0,0,0),
             new StufMod("Гоблинский",Category.weapon,1,0,-1,0), new StufMod("Грубый",Category.weapon,-1,0,1,0),
             new StufMod("Холодный",Category.weapon,1,0,0,-1), new StufMod("Тяжёлый",Category.weapon,-1,2,2,-1),
             new StufMod("Повреждённый",Category.weapon,-1,-1,0,0), new StufMod("Проклятый",Category.weapon,-5,0,-1,-1),
             new StufMod("Заградительный",Category.weapon,0,0,1,1), new StufMod("Защитный",Category.weapon,0,1,0,1),
             new StufMod("Стойкий",Category.weapon,0,0,0,2), new StufMod("Дробящий",Category.weapon,0,2,1,0),
             new StufMod("Весомый",Category.weapon,0,2,1,0), new StufMod("Увесистый",Category.weapon,0,1,2,0),
             new StufMod("Бронепробивающий",Category.weapon,0,3,5,0), new StufMod("Рвущий",Category.weapon,2,0,-1,0),
             new StufMod("Лёгкий",Category.weapon,1,0,-1,0), new StufMod("Разрывающий",Category.weapon,3,0,-1,0),
             new StufMod("Гнетущий",Category.weapon,1,0,1,0), new StufMod("Грязный",Category.weapon,0,0,0,0),
             new StufMod("Смертоносный",Category.weapon,4,0,0,0), new StufMod("Смертельный",Category.weapon,3,0,0,0),
             new StufMod("Убийственный",Category.weapon,2,0,0,0), new StufMod("Калечащий",Category.weapon,1,2,0,0),
             new StufMod("Модифицированный",Category.weapon,1,2,1,1), new StufMod("Сверх тяжёлый",Category.weapon,0,2,10,0),
             new StufMod("Липкий",Category.weapon,0,0,-1,0), new StufMod("Молитвенный",Category.weapon,0,0,0,1),
             new StufMod("Острейший",Category.weapon,3,0,-1,0), new StufMod("Самопальный",Category.weapon,-2,1,0,0),
             new StufMod("Горящий",Category.weapon,1,0,0,0), new StufMod("Тёплый",Category.weapon,0,0,1,0),
             new StufMod("Полыхающий",Category.weapon,1,0,1,0), new StufMod("Раскалённый",Category.weapon,2,0,2,0),
             new StufMod("Гниющий",Category.weapon,-1,-1,-1,0), new StufMod("Знахарский",Category.weapon,1,0,0,0),
             new StufMod("Тошнотворный",Category.weapon,0,0,0,-1), new StufMod("червивый",Category.weapon,-1,0,0,0),
             new StufMod("Бандитский",Category.weapon,2,1,-1,0), new StufMod("Вонючий",Category.weapon,0,0,-1,0),
             new StufMod("Ржавеющий",Category.weapon,-2,-1,-1,0), new StufMod("Ржавый",Category.weapon,-1,0,-1,0),
             new StufMod("Бронебойный",Category.weapon,0,2,2,0), new StufMod("Сверх острый",Category.weapon,5,0,0,0),
             new StufMod("Специальный",Category.weapon,1,1,1,1), new StufMod("Мастерский",Category.weapon,2,2,2,1),
             new StufMod("Ужасный",Category.weapon,-1,-1,-1,-1), new StufMod("Хороший",Category.weapon,1,1,0,0),
             new StufMod("Старый",Category.weapon,-1,0,-1,0), new StufMod("Плохой",Category.weapon,-1,-1,-1,0),
             new StufMod("Сбалансированный",Category.weapon,2,1,1,0), new StufMod("Нестабильный",Category.weapon,4,2,-2,-1),



        };
        /*
         
>?!/│♦$)}>l[]{~|\i
cut  : │ / | \ ) ( ├ ┼ ┤ ╡ ╞ l
crush: i ! 1 ] [ ▌ ╫ ╬ ╣ ╠ ║ ¶
uni  : ? 7 > Z z I y Y { } p P

$)}>
○♦♠•◘○☼
         */

        private static char[] miniIconCut =   { '│','/','|','\\',')','(','├','┼', '┤', '╡', '╞' ,'l' }; 
        private static char[] miniIconCrush = { 'i','!','1',']','[','▌','╫','╬', '╣', '╠', '║' ,'¶' }; 
        private static char[] miniIconUni = { '?','7','>','Z','z','I','y','Y', '{', '}', 'p' ,'P' }; 

        
        public static Stuf GenWeapon()
        {
            
                string name;
                int rare = Convert.ToInt32(new Random().NextInt64(0, 1001));
                int modsChans = Convert.ToInt32(new Random().NextInt64(0, 1001));
           List<StufMod> mods = new List<StufMod>();
                int matirialRare = Convert.ToInt32(new Random().NextInt64(0, 1001));
                int weaponTypeChanse = Convert.ToInt32(new Random().NextInt64(0, 3));
            Material material = null;

            if(matirialRare >= 950)
            {
                material = materialsHigh[Convert.ToInt32(new Random().NextInt64(0, materialsHigh.Length))];
            }
            else if(matirialRare >= 700)
            {
                material = materialsGood[Convert.ToInt32(new Random().NextInt64(0, materialsGood.Length))];
            }
            else if (matirialRare >= 100)
            {
                material = materialsNorm[Convert.ToInt32(new Random().NextInt64(0, materialsNorm.Length))];
            }
            else
            {
                material = materialsRofl[Convert.ToInt32(new Random().NextInt64(0, materialsRofl.Length))];
            }

            //MODS
            if (modsChans >=950)
            {
                for(int i = 0;i<3;i++)
                {
                    mods.Add(modsWeaponArr[Convert.ToInt32(new Random().NextInt64(0, modsWeaponArr.Length))]);
                }
            }
            else if(modsChans >= 750)
            {
                for (int i = 0; i < 2; i++)
                {
                    mods.Add(modsWeaponArr[Convert.ToInt32(new Random().NextInt64(0, modsWeaponArr.Length))]);
                }
            }
            else if(modsChans >=350)
            {
                mods.Add(modsWeaponArr[Convert.ToInt32(new Random().NextInt64(0, modsWeaponArr.Length))]);
            }
            else
            {
                mods.Add(empModWeapon); 
            }
            
                Console.WriteLine(rare);

            Stuf result = null;
            Random rd = new Random();
            //TIRLIST_WEAPON
           if (rare >= 975)
            {
                if(weaponTypeChanse ==0)
                 result = new Stuf(namesArrCutHigh[rd.NextInt64(0, namesArrCutHigh.Length)], "это обычная палка", Category.weapon, "l~-7-*-", miniIconCut[rd.Next(0,miniIconCut.Length)], material, rd.Next(MedHighDamage,HighDamage)*2, rd.Next(MedHighDamage, HighDamage)/2, rd.Next(MedHighDamage, HighDamage)/2, 0);
                else if(weaponTypeChanse ==1)
                    result = new Stuf(namesArrCrushHigh[rd.NextInt64(0, namesArrCrushHigh.Length)], "это обычная палка", Category.weapon, "l~-7-*-", miniIconCrush[rd.Next(0, miniIconCrush.Length)], material, rd.Next(MedHighDamage, HighDamage)/2, rd.Next(MedHighDamage, HighDamage) * 2, rd.Next(MedHighDamage, HighDamage), 0);
                else
                    result = new Stuf(namesArrUnivHigh[rd.NextInt64(0, namesArrUnivHigh.Length)], "это обычная палка", Category.weapon, "l~-7-*-", miniIconUni[rd.Next(0, miniIconUni.Length)], material, rd.Next(MedHighDamage, HighDamage), rd.Next(MedHighDamage, HighDamage) , rd.Next(MedHighDamage, HighDamage), 0);
            }
            else if(rare >= 900)
            {
                if (weaponTypeChanse == 0)
                    result = new Stuf(namesArrCutHighMed[rd.NextInt64(0, namesArrCutHighMed.Length)], "это обычная палка", Category.weapon, "l~-7-*-", miniIconCut[rd.Next(0, miniIconCut.Length)], material, rd.Next( MedDamage, MedHighDamage)*2, rd.Next(MedDamage, MedHighDamage)/2, 0, 0, WeaponType.cutting);
                else if (weaponTypeChanse == 1)
                    result = new Stuf(namesArrCrushHighMed[rd.NextInt64(0, namesArrCrushHighMed.Length)], "это обычная палка", Category.weapon, "l~-7-*-", miniIconCrush[rd.Next(0, miniIconCrush.Length)], material, rd.Next(MedDamage, MedHighDamage) / 2, rd.Next(MedDamage, MedHighDamage) * 2, 0, 0, WeaponType.crushing);
                else
                    result = new Stuf(namesArrUnivHighMed[rd.NextInt64(0, namesArrUnivHighMed.Length)], "это обычная палка", Category.weapon, "l~-7-*-", miniIconUni[rd.Next(0, miniIconUni.Length)], material, rd.Next(MedDamage, MedHighDamage) , rd.Next(MedDamage, MedHighDamage) , 0, 0, WeaponType.universal);
            }
            else if(rare >= 700)
            {
                
                if (weaponTypeChanse == 0)
                    result = new Stuf(namesArrCutMed[rd.NextInt64(0, namesArrCutMed.Length)], "это обычная палка", Category.weapon, "l~-7-*-", miniIconCut[rd.Next(0, miniIconCut.Length)], material, rd.Next(LowMedDamage,MedDamage) * 2, rd.Next(LowMedDamage, MedDamage) / 2, 0, 0, WeaponType.cutting);
                else if (weaponTypeChanse == 1)                                                                                                                                                             
                    result = new Stuf(namesArrCrushMed[rd.NextInt64(0, namesArrCrushMed.Length)], "это обычная палка", Category.weapon, "l~-7-*-", miniIconCrush[rd.Next(0, miniIconCrush.Length)], material, rd.Next(LowMedDamage,MedDamage) / 2, rd.Next(LowMedDamage,MedDamage) * 2, 0, 0, WeaponType.crushing);
                else                                                                                                                                                                                        
                    result = new Stuf(namesArrUnivMed[rd.NextInt64(0, namesArrUnivMed.Length)], "это обычная палка", Category.weapon, "l~-7-*-", miniIconUni[rd.Next(0, miniIconUni.Length)], material, rd.Next(LowMedDamage, MedDamage),    rd.Next(LowMedDamage,MedDamage), 0, 0, WeaponType.universal);
            }
            else if(rare >= 400)
            {
                
                if (weaponTypeChanse == 0)
                    result = new Stuf(namesArrCutLowMed[rd.NextInt64(0, namesArrCutLowMed.Length)], "это обычная палка", Category.weapon, "l~-7-*-", miniIconCut[rd.Next(0, miniIconCut.Length)], material, rd.Next(LowDamage,LowMedDamage) * 2, rd.Next(LowDamage,LowMedDamage) / 2, 0, 0, WeaponType.cutting);
                else if (weaponTypeChanse == 1)                                                                                                                                                              
                    result = new Stuf(namesArrCrushLowMed[rd.NextInt64(0, namesArrCrushLowMed.Length)], "это обычная палка", Category.weapon, "l~-7-*-", miniIconCrush[rd.Next(0, miniIconCrush.Length)], material, rd.Next(LowDamage,LowMedDamage) / 2, rd.Next(LowDamage,LowMedDamage) * 2, 0, 0, WeaponType.crushing);
                else                                                                                                                                                                                         
                    result = new Stuf(namesArrUnivLowMed[rd.NextInt64(0, namesArrUnivLowMed.Length)], "это обычная палка", Category.weapon, "l~-7-*-", miniIconUni[rd.Next(0, miniIconUni.Length)], material, rd.Next(LowDamage, LowMedDamage),    rd.Next(LowDamage, LowMedDamage), 0, 0, WeaponType.universal);
            }
            else 
            {
                 

                if (weaponTypeChanse == 0)
                    result = new Stuf(namesArrCutLow[rd.NextInt64(0, namesArrCutLow.Length)], "это обычная палка", Category.weapon, "l~-7-*-", miniIconCut[rd.Next(0, miniIconCut.Length)], material, rd.Next(1,LowDamage) * 2, rd.Next(1, LowDamage) / 2, 0, 0, WeaponType.cutting);
                else if (weaponTypeChanse == 1)                                                                                                                       
                    result = new Stuf(namesArrCrushLow[rd.NextInt64(0, namesArrCrushLow.Length)], "это обычная палка", Category.weapon, "l~-7-*-", miniIconCrush[rd.Next(0, miniIconCrush.Length)], material, rd.Next(1,LowDamage) / 2, rd.Next(1, LowDamage) * 2, 0, 0, WeaponType.crushing);
                else                                                                                                                                                    
                    result = new Stuf(namesArrUnivLow[rd.NextInt64(0, namesArrUnivLow.Length)], "это обычная палка", Category.weapon, "l~-7-*-", miniIconUni[rd.Next(0, miniIconUni.Length)], material, rd.Next(1, LowDamage), rd.Next(1, LowDamage), 0, 0,WeaponType.universal);
            }

              

                foreach(StufMod mod in mods) 
                {
                result.Name = mod.modName +" "+result.Name;
                result.CutDamage = result.CutDamage + mod.cutDamage;
                result.CrushDamage = result.CrushDamage + mod.crushDamage;
                result.ArmorPening = result.ArmorPening + mod.armorPen;
                result.ArmorResist = result.ArmorResist + mod.armor;
                }
                //type cuting crushing uni ++

                //if(result.ArmorPening>result.Damage*1.5)
                //{
                //result.StufType = WeaponType.crushing;
                //}
                //else if(result.Damage > result.ArmorPening * 1.5)
                //{
                //result.StufType= WeaponType.cutting;
                //}
                //else 
                //{
                //result.StufType = WeaponType.universal;
                //}
                return result;

        }
        
    }
}
