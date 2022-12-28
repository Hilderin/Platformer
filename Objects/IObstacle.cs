using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Objects
{
    /// <summary>
    /// Obstable
    /// </summary>
    public interface IObstacle
    {

        /// <summary>
        /// Hit the player
        /// </summary>
        void Hit(Player player);

    }
}
