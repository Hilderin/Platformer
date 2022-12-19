using FNAEngine2D;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.UI
{
    public class HUD: GameObject
    {
        /// <summary>
        /// Text où s'affiche le nombre de balls
        /// </summary>
        private TextRender _textNbLive;

        /// <summary>
        /// Chargement du contenu
        /// </summary>
        public override void Load()
        {
            const int borderX = 60;
            const int borderWidth = 150;

            //Border for nb lives
            var borderNbLive = Add(new TextureRender("border", new Rectangle(borderX, 150, borderWidth, 50)));
            _textNbLive = Add(new TextRender(String.Empty, "fonts\\Roboto-Bold", 22, borderNbLive.Bounds, Color.DarkRed, TextHorizontalAlignment.Center, TextVerticalAlignment.Middle));

        }

        /// <summary>
        /// Update
        /// </summary>
        public override void Update()
        {
            _textNbLive.Text = PlatformerGame.Instance.NbLive.ToString() + " UP";
        }

    }
}
