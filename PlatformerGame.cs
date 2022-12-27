using FNAEngine2D;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
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
        /// Constructeur
        /// </summary>
        public PlatformerGame()
        {
        }


        /// <summary>
        /// Restart le level...
        /// </summary>
        public void RestartLevel()
        {
            //Clearup de scene...
            RemoveAll();

            //Add the level...
            Level = Add(new LevelScene());

            //UI!
            Add(new UI.HUD());

            MouseManager.HideMouse();
        }

        /// <summary>
        /// Restart le level...
        /// </summary>
        public void Continue()
        {
            Remove(typeof(UI.EscapeMenu));

            Level.Paused = false;

            MouseManager.HideMouse();
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

            if(PlatformerHost.Player != null)
                PlatformerHost.Player.Destroy();

            if(Find<UI.GameOver>() == null)
                Add(new UI.GameOver()); 
        }

        /// <summary>
        /// Chargement du contenu
        /// </summary>
        public override void Load()
        {

            RestartLevel();

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




    }
}
