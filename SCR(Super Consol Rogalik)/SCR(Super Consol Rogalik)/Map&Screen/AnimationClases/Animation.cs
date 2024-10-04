using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCR_Super_Consol_Rogalik_.Map_Screen.AnimationClasses
{
    public class Animation
    {
        private List<string> _animationFrames;

        public Animation(List<string> animationFrames) { _animationFrames = new(animationFrames); }

        public string this[int i] { get => _animationFrames[i]; }
        
        public int FramesCount { get => _animationFrames.Count; }

    }

}
