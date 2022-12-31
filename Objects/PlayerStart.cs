using FNAEngine2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Objects
{
    /// <summary>
    /// Start position of the player
    /// </summary>
    public class PlayerStart: GameObject
    {

        /// <summary>
        /// Current game
        /// </summary>
        private PlatformerGame _game;

        /// <summary>
        /// Previous room that the player must comme from
        /// </summary>
        public string PreviousRoom { get; set; } = String.Empty;


        /// <summary>
        /// Loading
        /// </summary>
        public override void Load()
        {
            _game = this.Game.RootGameObject as PlatformerGame;

            if (_game != null)
            {
                if (String.IsNullOrEmpty(this.PreviousRoom) || _game.PreviousRoom == this.PreviousRoom)
                {
                    _game.Player = Add(new Player());
                    _game.Player.TranslateTo(this.Location);
                }
            }
        }
    }
}
