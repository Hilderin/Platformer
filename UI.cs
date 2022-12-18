using FNAEngine2D;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public class UI: GameObject
    {
        /// <summary>
        /// Text for current level
        /// </summary>
        private TextRender _textCurrentLevel;

        /// <summary>
        /// Text où s'affiche le nombre de balls
        /// </summary>
        private TextRender _textNbBalls;

        /// <summary>
        /// Text for NbPts
        /// </summary>
        private TextRender _textNbPts;

        /// <summary>
        /// Chargement du contenu
        /// </summary>
        public override void Load()
        {
            const int borderX = 60;
            const int borderWidth = 150;

            //Level
            var borderLevel = Add(new TextureRender("border", new Rectangle(borderX, 50, borderWidth, 50)));
            _textCurrentLevel = Add(new TextRender(String.Empty, "fonts\\Roboto-Bold", 22, borderLevel.Bounds, Color.DarkRed, TextHorizontalAlignment.Center, TextVerticalAlignment.Middle));

            //Border for nb balls
            var borderNbBalls = Add(new TextureRender("border", new Rectangle(borderX, 150, borderWidth, 50)));
            _textNbBalls = Add(new TextRender(String.Empty, "fonts\\Roboto-Bold", 22, borderNbBalls.Bounds, Color.DarkRed, TextHorizontalAlignment.Center, TextVerticalAlignment.Middle));

            //Border for nb pts
            var boderNbPts = Add(new TextureRender("border", new Rectangle(borderX, 250, borderWidth, 50)));
            _textNbPts = Add(new TextRender(String.Empty, "fonts\\Roboto-Bold", 22, boderNbPts.Bounds, Color.DarkRed, TextHorizontalAlignment.Center, TextVerticalAlignment.Middle));

        }

        /// <summary>
        /// Update
        /// </summary>
        public override void Update()
        {
            _textCurrentLevel.Text = "LEVEL" + PongGame.Instance.Level.CurrentLevelNumber.ToString();
            _textNbBalls.Text = PongGame.Instance.NbBalls.ToString() + " UP";
            _textNbPts.Text = PongGame.Instance.NbPts.ToString("000000");
        }

    }
}
