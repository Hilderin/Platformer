using FNAEngine2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Objects
{
    /// <summary>
    /// Lava
    /// </summary>
    public class Lava: GameObject, IObstacle
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Lava()
        {
            //Collidable par default
            this.Collidable = true;
        }

        /// <summary>
        /// Loading
        /// </summary>
        public override void Load()
        {
            SpriteAnimationRender animRender = Add(new SpriteAnimationRender("animations\\lava"));
            animRender.Bounds = this.Bounds.CenterMiddle(animRender.Width, animRender.Height);
            
        }

        /// <summary>
        /// Hit the player
        /// </summary>
        public void Hit(Player player)
        {
            player.Health -= 2;
        }


    }
}
