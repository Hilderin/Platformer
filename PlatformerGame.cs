using FNAEngine2D;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Platformer.Levels;
using Platformer.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer
{
    /// <summary>
    /// Game de Platformer
    /// </summary>
    public class PlatformerGame : GameObject
    {
        
        /// <summary>
        /// Curent level
        /// </summary>
        public LevelScene Level;

        /// <summary>
        /// Camera for the UI
        /// </summary>
        public Camera UICamera;

        /// <summary>
        /// Camera for the Minimap
        /// </summary>
        public Camera MinimapCamera;

        /// <summary>
        /// Current Player
        /// </summary>
        public Player Player;

        /// <summary>
        /// Current room
        /// </summary>
        public string CurrentRoom { get; private set; } = "level1";

        /// <summary>
        /// Previous room
        /// </summary>
        public string PreviousRoom { get; private set; } = "start";


        /// <summary>
        /// Constructeur
        /// </summary>
        public PlatformerGame()
        {
        }


        /// <summary>
        /// Restart le level...
        /// </summary>
        public void ReloadRoom()
        {
            //Clearup de scene...
            RemoveAll();

            //Add the level...
            Level = Add(new LevelScene(this.CurrentRoom));

            //UI!
            Add(new UI.HUD());

            this.Mouse.HideMouse();
        }

        /// <summary>
        /// Restart le level...
        /// </summary>
        public void Continue()
        {
            Remove(typeof(UI.EscapeMenu));

            Level.Paused = false;

            this.Mouse.HideMouse();
        }

        /// <summary>
        /// On a gagné!
        /// </summary>
        public void Win()
        {
            Level.Paused = true;

            if (Find<UI.Win>() == null)
                Add(new UI.Win());
        }


        /// <summary>
        /// GameOver
        /// </summary>
        public void GameOver()
        {
            Level.Paused = true;

            if(this.Player != null)
                this.Player.Destroy();

            if(Find<UI.GameOver>() == null)
                Add(new UI.GameOver()); 
        }

        /// <summary>
        /// Load a room
        /// </summary>
        public void LoadRoom(string room)
        {
            PreviousRoom = CurrentRoom;
            CurrentRoom = room;

            ReloadRoom();
        }

        /// <summary>
        /// Chargement du contenu
        /// </summary>
        public override void Load()
        {
            SetupCamera();

            ReloadRoom();

        }

        /// <summary>
        /// Update of PlatformerGame
        /// </summary>
        public override void Update()
        {

            if (Input.IsKeyPressed(Keys.Escape))
            {
                if (Find<UI.EscapeMenu>() == null)
                {
                    Level.Paused = true;
                    Add(new UI.EscapeMenu());
                }
                else
                {
                    Continue();
                }
            }
            
        }






        /// <summary>
        /// Setup cameras
        /// </summary>
        private void SetupCamera()
        {
            this.Game.ResetCameras();

            //Main camera that follow the player...
            this.Game.MainCamera.LayerMask = Layers.Layer1;

            //UI camera...
            Camera uiCamera = new Camera(this.Game.Width, this.Game.Height);
            uiCamera.LayerMask = Layers.Layer2;
            this.Game.AddCamera(uiCamera);
            this.UICamera = uiCamera;


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
