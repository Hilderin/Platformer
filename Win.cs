using FNAEngine2D;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
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
            Add(new TextRender("WIN", "fonts\\Roboto-Bold", 60, GameHost.Rectangle, Color.Green, TextHorizontalAlignment.Center, TextVerticalAlignment.Middle));
            Add(new Button("RETRY", new Rectangle(GameHost.CenterX - 100, GameHost.CenterY + 200, 200, 60), Retry));


            GameHost.GetContent<SoundEffect>("sfx\\win").Play();

            MediaPlayer.Stop();

            MouseManager.ShowMouse();

        }

        /// <summary>
        /// Restart the game
        /// </summary>
        public void Retry()
        {
            if(PongGame.Instance != null)
                PongGame.Instance.Restart();
        }
    }
}
