using FNAEngine2D;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.UI
{
    /// <summary>
    /// GameOver
    /// </summary>
    public class GameOver: GameObject
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

            //Add(new TextRender("GAME OVER", "fonts\\Roboto-Bold", 60, GameHost.Rectangle, Color.DarkRed, TextHorizontalAlignment.Center, TextVerticalAlignment.Middle));
            //Add(new Button("RETRY", new Rectangle(GameHost.CenterX - 100, GameHost.CenterY + 200, 200, 60), Retry));

            Add(new GameContentContainer("gamecontent\\gameover"));

            GetContent<SoundEffect>("sfx\\gameover").Data.Play();

            MediaPlayer.Stop();

            this.Mouse.ShowMouse();

        }

        /// <summary>
        /// Restart the game
        /// </summary>
        public void Retry_OnClick()
        {
            if(_game != null)
                _game.ReloadRoom();
        }

        /// <summary>
        /// Restart the game
        /// </summary>
        public void Quit_OnClick()
        {
            this.Game.Quit();
        }
    }
}
