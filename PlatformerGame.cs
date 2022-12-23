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
        /// Instance courante
        /// </summary>
        public static PlatformerGame Instance;

        /// <summary>
        /// Number of lives
        /// </summary>
        public int NbLive = 3;

        /// <summary>
        /// Curent level
        /// </summary>
        public LevelScene Level;


        /// <summary>
        /// Constructeur
        /// </summary>
        public PlatformerGame()
        {
            Instance = this;
        }


        /// <summary>
        /// Restart le level...
        /// </summary>
        public void Restart()
        {
            NbLive = 3;

            //Clearup de scene...
            RemoveAll();

            //Add the level...
            Level = Add(new LevelScene());

            //UI!
            //Add(new UI.HUD());

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

            Add(new UI.Win());
        }


        /// <summary>
        /// GameOver
        /// </summary>
        public void Gameover()
        {
            Level.Paused = true;

            Add(new UI.GameOver());
        }

        /// <summary>
        /// Chargement du contenu
        /// </summary>
        public override void Load()
        {

            Restart();

        }

        /// <summary>
        /// Update of PlatformerGame
        /// </summary>
        public override void Update()
        {

            if (Input.IsKeyPressed(Keys.Escape))
            {
                Level.Paused = true;

                Add(new UI.EscapeMenu());
            }
            
        }




    }
}
