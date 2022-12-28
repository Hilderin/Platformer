using FNAEngine2D;
using Platformer.Enemies;
using Platformer.Objects;
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
        /// Player depth
        /// </summary>
        public const float PLAYER_DEPTH = -1;

        /// <summary>
        /// UI depth
        /// </summary>
        public const float UI_DEPTH = -10000;

        /// <summary>
        /// Size of a tile
        /// </summary>
        public const int TILE_SIZE = 16;

        /// <summary>
        /// Types of the walls collider objects
        /// </summary>
        public static readonly Type[] TYPE_COLLIDER_WALLS = new Type[] { typeof(TileGameObject), typeof(Door) };

        /// <summary>
        /// Types of the enemies
        /// </summary>
        public static readonly Type[] TYPE_ENEMIES = new Type[] { typeof(Enemy) };

        /// <summary>
        /// Types of the obstacles
        /// </summary>
        public static readonly Type[] TYPE_OBSTACLES = new Type[] { typeof(IObstacle) };

        /// <summary>
        /// Types of the hittable objects
        /// </summary>
        public static readonly Type[] TYPE_HITTABLE = new Type[] { typeof(IHittable) };

        /// <summary>
        /// Types of the IPlayerActionCollide
        /// </summary>
        public static readonly Type[] TYPE_PLAYER_ACTION_COLLIDE = new Type[] { typeof(IPlayerActionCollide) };

    }
}
