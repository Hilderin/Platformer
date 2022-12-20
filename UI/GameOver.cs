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
        /// Loading
        /// </summary>
        public override void Load()
        {
            Add(new TextRender("GAME OVER", "fonts\\Roboto-Bold", 60, GameHost.Rectangle, Color.DarkRed, TextHorizontalAlignment.Center, TextVerticalAlignment.Middle));
            Add(new Button("RETRY", new Rectangle(GameHost.CenterX - 100, GameHost.CenterY + 200, 200, 60), Retry));

            SoundEffectPlayer.Play("sfx\\gameover");

            MediaPlayer.Stop();

            MouseManager.ShowMouse();

        }

        /// <summary>
        /// Restart the game
        /// </summary>
        public void Retry()
        {
            if(PlatformerGame.Instance != null)
                PlatformerGame.Instance.Restart();
        }
    }
}
