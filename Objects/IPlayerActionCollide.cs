using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Objects
{
    /// <summary>
    /// Action when the player collide with the object
    /// </summary>
    public interface IPlayerActionCollide
    {
        /// <summary>
        /// Player is hover the object
        /// </summary>
        void Collide(Player player);

    }
}
