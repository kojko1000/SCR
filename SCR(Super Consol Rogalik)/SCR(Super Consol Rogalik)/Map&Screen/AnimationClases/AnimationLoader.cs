using System.Collections.Generic;
using System.IO;

namespace SCR_Super_Consol_Rogalik_.Map_Screen.AnimationClasses
{
    public class AnimationLoader
    {
        public Animation SlimeAnimation { get; }
        public Animation SkeletonLight { get; }

        public Animation HeavySkeleton { get; }
        public Animation GoblinSpear { get; }
        public AnimationLoader()
        {
            SlimeAnimation = Load("Animations\\slime.txt");
            SkeletonLight = Load("Animations\\LightSkeleton.txt");
            HeavySkeleton = Load("Animations\\HeavySkeleton.txt");
            GoblinSpear = Load("Animations\\Goblin.txt");
        }

        private Animation Load(string path)
        {
            using StreamReader file = new(path);

            List<string> buff = new List<string>();
            string buffString = "";
            while (!file.EndOfStream)
            {
                string line = file.ReadLine();
                if (line != "☺")
                    buffString += line+'\n';
                else
                {
                    buff.Add(buffString);
                    buffString = "";
                }

            }
            buff.Add(buffString);
            return new Animation(buff);
        }
    }

}
