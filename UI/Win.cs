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
    /// Win
    /// </summary>
    public class Win : GameObject
    {
        /// <summary>
        /// Loading
        /// </summary>
        public override void Load()
        {
            this.Depth = Constants.UI_DEPTH;

            Add(new TextRender("WIN", "fonts\\Roboto-Bold", 60, GameHost.Rectangle, Color.Green, TextHorizontalAlignment.Center, TextVerticalAlignment.Middle));
            Add(new Button("RETRY", new Rectangle(GameHost.CenterX - 100, GameHost.CenterY + 200, 200, 60), Retry));

            SoundEffectPlayer.PlayStatic("sfx\\win");

            MediaPlayer.Stop();

            MouseManager.ShowMouse();

        }

        /// <summary>
        /// Restart the game
        /// </summary>
        public void Retry()
        {
            PlatformerHost.RestartLevel();
        }
    }
}
