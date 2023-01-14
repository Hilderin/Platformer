using FNAEngine2D;
using FNAEngine2D.GameObjects;
using FNAEngine2D.TileSets;
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
        //The current standard resolution is 1080p (1080 pixels in the height).
        //To achieve a pixel perfect look, you need a resolution with a 16:9 aspect ratio that scales up to 1080p. 
        //A good standard is a resolution of 480x270 (270p with an aspect ration of 16:9). 270p is 4 times smaller than 1080.
        //Character sprites are treated differently and are generally of the size 16x16, 24x24, 32x32, and 64x64.
        public const int INNER_WIDTH = 480;
        public const int INNER_HEIGHT = 270;

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
