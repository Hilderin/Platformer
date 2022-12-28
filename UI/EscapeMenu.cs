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
            this.Depth = Constants.UI_DEPTH;

            GameContentManager.Apply(this, "gamecontent\\escape_menu");

            Find<Button>("ContinueButton").OnClick = Continue;
            Find<Button>("QuitButton").OnClick = Quit;

            MouseManager.ShowMouse();

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
