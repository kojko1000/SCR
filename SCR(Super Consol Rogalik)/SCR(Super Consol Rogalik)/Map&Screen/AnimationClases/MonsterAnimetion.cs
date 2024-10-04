using SCR_Super_Consol_Rogalik_.Entiti;

namespace SCR_Super_Consol_Rogalik_.Map_Screen.AnimationClasses
{
    public static class MonsterAnimetion
    {
        private static int _frameIndex = 0;
        static private AnimationLoader _animationLoader = new AnimationLoader();
        private static int schetchikAnim = 0;
         private static int sbros = 250;
        public static string playIdleAnimation(Monster.Type type)
        {
            switch (type)
            {

                case Monster.Type.Slime:
                    //78
                    if (_frameIndex >= _animationLoader.SlimeAnimation.FramesCount)
                        _frameIndex = 0;
                    if (schetchikAnim == sbros)
                    {
                        schetchikAnim = 0;
                        return _animationLoader.SlimeAnimation[_frameIndex++];
                    }
                    else
                        schetchikAnim++;
                    return _animationLoader.SlimeAnimation[_frameIndex];

                case Monster.Type.SkeletonLight:
                    //78
                    if (_frameIndex >= _animationLoader.SkeletonLight.FramesCount)
                        _frameIndex = 0;
                    if (schetchikAnim == sbros)
                    {
                        schetchikAnim = 0;
                        return _animationLoader.SkeletonLight[_frameIndex++];
                    }
                    else
                        schetchikAnim++;
                    return _animationLoader.SkeletonLight[_frameIndex];


                case Monster.Type.HeavySkeleton:
                    //78
                    if (_frameIndex >= _animationLoader.HeavySkeleton.FramesCount)
                        _frameIndex = 0;
                    if (schetchikAnim == sbros)
                    {
                        schetchikAnim = 0;
                        return _animationLoader.HeavySkeleton[_frameIndex++];
                    }
                    else
                        schetchikAnim++;
                    return _animationLoader.HeavySkeleton[_frameIndex];


                case Monster.Type.GoblinSpear:
                    //78
                    if (_frameIndex >= _animationLoader.GoblinSpear.FramesCount)
                        _frameIndex = 0;
                    if (schetchikAnim == sbros)
                    {
                        schetchikAnim = 0;
                        return _animationLoader.GoblinSpear[_frameIndex++];
                    }
                    else
                        schetchikAnim++;
                    return _animationLoader.GoblinSpear[_frameIndex];


                default: return "☺";

            }
        }




    }
}
