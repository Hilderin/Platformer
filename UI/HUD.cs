using FNAEngine2D;
using FNAEngine2D.Aseprite;
using FNAEngine2D.GameObjects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.UI
{
    public class HUD: GameObject, IUpdate
    {

        /// <summary>
        /// Current game
        /// </summary>
        private PlatformerGame _game;

        /// <summary>
        /// Text for number of lives
        /// </summary>
        private Label _textNbLive;

        /// <summary>
        /// Last Health
        /// </summary>
        private int _lastHealth = -1;

        /// <summary>
        /// Loading
        /// </summary>
        protected override void Load()
        {
            _game = this.Game.RootGameObject as PlatformerGame;

            this.Depth = Constants.UI_DEPTH;

            Add(new GameContentContainer("gamecontent\\hud"));

            //Add(new FPSRender("fonts\\Roboto-Bold", 12, Color.Yellow))
            //    .SetLayerMask(PlatformerHost.UICamera.LayerMask);

            _textNbLive = Find<Label>("Health");
        }

        /// <summary>
        /// Update
        /// </summary>
        public void Update()
        {
            //No need to recalculte the text at each frame!
            if (_game != null && _game.Player != null)
            {
                if (_lastHealth != _game.Player.Health)
                {
                    _lastHealth = _game.Player.Health;
                    int health = _lastHealth;
                    if (health < 0)
                        health = 0;
                    _textNbLive.Text = "HEALTH: " + health.ToString();
                }
            }
        }

    }
}
