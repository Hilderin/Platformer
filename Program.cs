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
            GraphicSettings graphicSettings = new GraphicSettings();
            graphicSettings.GameSize = new Point(Constants.INNER_WIDTH, Constants.INNER_HEIGHT);
            graphicSettings.NbPixelPerMeter = 60;
            graphicSettings.BackgroundColor = Color.Black;

#if DEBUG
            GameManager.DevelopmentMode = true;
            graphicSettings.IsFullscreen = false;
            graphicSettings.ScreenSize = new Point(Constants.INNER_WIDTH * 2, Constants.INNER_HEIGHT * 2);
#else
            graphicSettings.IsFullscreen = true;
            graphicSettings.ScreenSize = new Point(INNER_WIDTH * 4, INNER_HEIGHT * 4);

#endif


            //GameHost.Run(new Win());
            //GameHost.Run(new UI.GameOver());
            //GameHost.Run(new Test());
            //GameHost.Run(new EscapeMenu());
            //GameHost.Run(new TestGround());

            GameManager.Run(new PlatformerGame(), graphicSettings);
        }
    }
}
