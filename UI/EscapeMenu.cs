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
        /// Current game
        /// </summary>
        private PlatformerGame _game;

        /// <summary>
        /// Loading
        /// </summary>
        protected override void Load()
        {
            _game = this.Game.RootGameObject as PlatformerGame;

            this.Depth = Constants.UI_DEPTH;

            GameContentManager.Apply(this, "gamecontent\\escape_menu");

            Find<Button>("ContinueButton").OnClick = Continue;
            Find<Button>("QuitButton").OnClick = Quit;

            this.Mouse.ShowMouse();

        }


        /// <summary>
        /// Continue
        /// </summary>
        public void Continue()
        {
            if(_game != null)
                _game.Continue();

        }

        /// <summary>
        /// Quit
        /// </summary>
        public void Quit()
        {
            this.Game.Quit();
        }
    }
}
