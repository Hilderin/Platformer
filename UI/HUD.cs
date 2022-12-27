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
        /// Last Health
        /// </summary>
        private int _lastHealth = -1;

        /// <summary>
        /// Loading
        /// </summary>
        public override void Load()
        {
            
            Add(new GameContentContainer("gamecontent\\hud"));

            Add(new FPSRender("fonts\\Roboto-Bold", 12, Color.Yellow))
                .SetLayerMask(PlatformerHost.UICamera.LayerMask);

            _textNbLive = Find<TextRender>("Health");
        }

        /// <summary>
        /// Update
        /// </summary>
        public override void Update()
        {
            //No need to recalculte the text at each frame!
            if (PlatformerHost.Player != null)
            {
                if (_lastHealth != PlatformerHost.Player.Health)
                {
                    _lastHealth = PlatformerHost.Player.Health;
                    _textNbLive.Text = "HEALTH: " + _lastHealth.ToString();
                }
            }
        }

    }
}
