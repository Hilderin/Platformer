using FNAEngine2D;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.UI
{
    public class EscapeMenu: GameObject
    {

        /// <summary>
        /// Loading
        /// </summary>
        public override void Load()
        {
            
            GameContentManager.Apply(this, "gamecontent\\escape_menu");

            Find<Button>("ContinueButton").OnClick = Continue;
            Find<Button>("QuitButton").OnClick = Quit;

            MouseManager.ShowMouse();

        }

        /// <summary>
        /// Update of PlatformerGame
        /// </summary>
        public override void Update()
        {

            if (Input.IsKeyPressed(Keys.Escape))
            {
                Continue();
            }

        }


        /// <summary>
        /// Continue
        /// </summary>
        public void Continue()
        {
            PlatformerHost.Continue();

        }

        /// <summary>
        /// Quit
        /// </summary>
        public void Quit()
        {
            PlatformerHost.Quit();
        }
    }
}
