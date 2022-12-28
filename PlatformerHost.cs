using FNAEngine2D;
using Microsoft.Xna.Framework;
using Platformer.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Platformer
{
    /// <summary>
    /// Host of the Plateformer Game
    /// </summary>
    public static class PlatformerHost
    {
        //The current standard resolution is 1080p (1080 pixels in the height).
        //To achieve a pixel perfect look, you need a resolution with a 16:9 aspect ratio that scales up to 1080p. 
        //A good standard is a resolution of 480x270 (270p with an aspect ration of 16:9). 270p is 4 times smaller than 1080.
        //Character sprites are treated differently and are generally of the size 16x16, 24x24, 32x32, and 64x64.
        public const int INNER_WIDTH = 480;
        public const int INNER_HEIGHT = 270;

        /// <summary>
        /// Main camera that follow the player...
        /// </summary>
        public static Camera MainCamera;

        /// <summary>
        /// Camera for the UI
        /// </summary>
        public static Camera UICamera;

        /// <summary>
        /// Camera for the Minimap
        /// </summary>
        public static Camera MinimapCamera;

        /// <summary>
        /// Root game object
        /// </summary>
        public static PlatformerGame Root;

        /// <summary>
        /// Current Player
        /// </summary>
        public static Player Player;

        /// <summary>
        /// Current room
        /// </summary>
        public static string CurrentRoom { get; private set; } = "level2";

        /// <summary>
        /// Previous room
        /// </summary>
        public static string PreviousRoom { get; private set; } = "level1";


        /// <summary>
        /// Run the game...
        /// </summary>
        public static void Run()
        {
            
#if DEBUG
            GameHost.DevelopmentMode = true;
            GameHost.SetResolution(INNER_WIDTH * 2, INNER_HEIGHT * 2, INNER_WIDTH, INNER_HEIGHT, false);
#else
            GameHost.DevelopmentMode = false;
            GameHost.SetResolution(INNER_WIDTH * 4, INNER_HEIGHT * 4, INNER_WIDTH, INNER_HEIGHT, true);
#endif

            //Number of pixels for 1 meter...
            GameHost.NbPixelPerMeter = 60;
            GameHost.BackgroundColor = Color.Black;

            //Setting up cameras...
            SetupCamera();


            //GameHost.Run(new Win());
            //GameHost.Run(new UI.GameOver());
            //GameHost.Run(new Test());
            //GameHost.Run(new EscapeMenu());
            //GameHost.Run(new TestGround());
            PlatformerHost.Root = new PlatformerGame();
            GameHost.Run(PlatformerHost.Root);
        }


        /// <summary>
        /// Unpause the game
        /// </summary>
        public static void Continue()
        {
            if (Root != null)
                Root.Continue();
        }

        /// <summary>
        /// Restart the level
        /// </summary>
        public static void RestartLevel()
        {
            if(Root != null)
                Root.ReloadRoom();
        }

        /// <summary>
        /// Player lost
        /// </summary>
        public static void GameOver()
        {
            if (Root != null)
                Root.GameOver();
        }

        /// <summary>
        /// Quit the game
        /// </summary>
        public static void Quit()
        {
            GameHost.Quit();
        }

        /// <summary>
        /// Load a room
        /// </summary>
        public static void LoadRoom(string room)
        {
            PreviousRoom = CurrentRoom;
            CurrentRoom = room;

            if (Root != null)
                Root.ReloadRoom();
        }

        /// <summary>
        /// Setup cameras
        /// </summary>
        private static void SetupCamera()
        {
            //Main camera that follow the player...
            GameHost.MainCamera = new Camera();
            GameHost.MainCamera.LayerMask = Layers.Layer1;
            PlatformerHost.MainCamera = GameHost.MainCamera;

            //UI camera...
            Camera uiCamera = new Camera();
            uiCamera.LayerMask = Layers.Layer2;
            GameHost.ExtraCameras.Add(uiCamera);
            PlatformerHost.UICamera = uiCamera;


            //For the minimap...
            //int minimapSize = 100;
            //Camera cameraMinimap = new Camera();
            //cameraMinimap.LayerMask = Layers.Layer1;
            //GameHost.ExtraCameras.Add(cameraMinimap);
            //cameraMinimap.ViewLocation = new Point(GameHost.Width - (minimapSize + 10), 10);
            //cameraMinimap.Size = new Point(minimapSize, minimapSize);
            ////cameraMinimap.Zoom = ((float)minimapSize / GameHost.Height);
            //cameraMinimap.Zoom = 0.2f;
        }


    }
}
