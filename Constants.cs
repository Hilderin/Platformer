using FNAEngine2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer
{
    /// <summary>
    /// Game constants
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// Types of the walls collider objects
        /// </summary>
        public static readonly Type[] TYPE_COLLIDER_WALLS = new Type[] { typeof(TileGameObject) };

        /// <summary>
        /// Types of the enemies
        /// </summary>
        public static readonly Type[] TYPE_ENEMIES = new Type[] { typeof(Enemy) };

    }
}
