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
        /// Previous room that the player must comme from
        /// </summary>
        public string PreviousRoom { get; set; } = String.Empty;


        /// <summary>
        /// Loading
        /// </summary>
        public override void Load()
        {
            if (String.IsNullOrEmpty(this.PreviousRoom) || PlatformerHost.PreviousRoom == this.PreviousRoom)
            {
                PlatformerHost.Player = Add(new Player());
                PlatformerHost.Player.TranslateTo(this.Location);
            }
        }
    }
}
