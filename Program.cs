using FNAEngine2D;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Platformer
{
    internal class Program
    {
        /// <summary>
        /// Must be STAThread for the Designer
        /// </summary>
        [STAThread]
        public static void Main()
        {

            //The current standard resolution is 1080p (1080 pixels in the height).
            //To achieve a pixel perfect look, you need a resolution with a 16:9 aspect ratio that scales up to 1080p. 
            //A good standard is a resolution of 480x270 (270p with an aspect ration of 16:9). 270p is 4 times smaller than 1080.
            //Character sprites are treated differently and are generally of the size 16x16, 24x24, 32x32, and 64x64.
            const int INNER_WIDTH = 480;
            const int INNER_HEIGHT = 270;
#if DEBUG
            GameHost.DevelopmentMode = true;
            GameHost.SetResolution(INNER_WIDTH * 2, INNER_HEIGHT * 2, INNER_WIDTH, INNER_HEIGHT, false);
#else
            GameHost.DevelopmentMode = false;
            GameHost.SetResolution(INNER_WIDTH * 4, INNER_HEIGHT * 4, INNER_HEIGHT, true);
#endif

            GameHost.NbPixelPerMeter = 60;

            //GameHost.Run(new Win());
            //GameHost.Run(new UI.GameOver());
            //GameHost.Run(new Test());
            //GameHost.Run(new EscapeMenu());
            GameHost.Run(new TestGround());
            //GameHost.Run(new PlatformerGame());
        }
    }
}
