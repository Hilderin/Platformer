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

#if DEBUG
            GameHost.SetResolution(1200, 800, 640, 480, true);
#else
            GameHost.SetResolution(1200, 800, 1200, 800, true);
#endif

            //GameHost.Run(new Win());
            //GameHost.Run(new GameOver());
            //GameHost.Run(new Test());
            //GameHost.Run(new EscapeMenu());
            GameHost.Run(new PlatformerGame());
        }
    }
}
