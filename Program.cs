using FNAEngine2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer
{
    internal class Program
    {
        public static void Main()
        {

            //Keep 16:9 resolution
#if DEBUG
            GameHost.SetResolution(1280, 720, 640, 360, false);
#else
            GameHost.SetResolution(1280, 720, 640, 360, true);
#endif

            GameHost.NbPixelPerMeter = 60;

            //GameHost.Run(new Win());
            //GameHost.Run(new GameOver());
            //GameHost.Run(new Test());
            //GameHost.Run(new EscapeMenu());
            GameHost.Run(new TestGround());
            //GameHost.Run(new PlatformerGame());
        }
    }
}
