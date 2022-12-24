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
        /// Text for number of lives
        /// </summary>
        private TextRender _textNbLive;

        /// <summary>
        /// Loading
        /// </summary>
        public override void Load()
        {
            
            Add(new GameContentContainer("gamecontent\\hud"));

            var fps = Add(new FPSRender("fonts\\Roboto-Bold", 12, Color.Yellow));
            fps.LayerMask = Layers.Layer2;

            _textNbLive = Find<TextRender>("NbLife");
        }

        /// <summary>
        /// Update
        /// </summary>
        public override void Update()
        {
            if(Player.Current != null)
                _textNbLive.Text = Player.Current.NbLive.ToString() + " UP";
        }

    }
}
