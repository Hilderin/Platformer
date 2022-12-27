using FNAEngine2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer
{
    /// <summary>
    /// Start position of the player
    /// </summary>
    public class PlayerStart: GameObject
    {

        /// <summary>
        /// Loading
        /// </summary>
        public override void Load()
        {
            //Remove the player that could already exists...
            if (PlatformerHost.Player != null && PlatformerHost.Player.Parent != null)
                PlatformerHost.Player.Parent.Remove(PlatformerHost.Player.Parent);


            PlatformerHost.Player = Add(new Player());
            PlatformerHost.Player.TranslateTo(this.Location);
        }
    }
}
