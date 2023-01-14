using FNAEngine2D;
using FNAEngine2D.Animations;
using FNAEngine2D.Collisions;
using FNAEngine2D.GameObjects;
using Microsoft.Xna.Framework;
using Platformer.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Objects
{
    /// <summary>
    /// Bullet
    /// </summary>
    public class Bullet: GameObject
    {
        /// <summary>
        /// Types to collide with
        /// </summary>
        private static readonly Type[] COLLIDER_TYPES;

        /// <summary>
        /// Time alive
        /// </summary>
        private float _lifeTime = 0f;

        /// <summary>
        /// Direction of the bullet
        /// </summary>
        public Vector2 Direction { get; set; }

        /// <summary>
        /// Speed meter per secondes
        /// </summary>
        public float SpeedMps { get; set; } = 10;


        /// <summary>
        /// Static constructor
        /// </summary>
        static Bullet()
        {
            //Building all the types to collide with
            List<Type> types = new List<Type>();

            types.AddRange(Constants.TYPE_COLLIDER_WALLS);
            //types.AddRange(Constants.TYPE_ENEMIES);
            types.AddRange(Constants.TYPE_HITTABLE);
            

            COLLIDER_TYPES = types.ToArray();
        }


        /// <summary>
        /// Constructor
        /// </summary>
        public Bullet()
        {
            this.Width = 8;
            this.Height = 8;
        }

        /// <summary>
        /// Loading
        /// </summary>
        protected override void Load()
        {
            SpriteAnimator animRender = Add(new SpriteAnimator("animations\\bullet"));
            animRender.Bounds = this.Bounds.CenterMiddle(animRender.Width, animRender.Height);

        }

        /// <summary>
        /// Update
        /// </summary>
        protected override void Update()
        {
            _lifeTime += this.ElapsedGameTimeSeconds;

            //Max time alive...
            if (_lifeTime > 2)
            {
                this.Destroy();
                return;
            }


            //Check if we hit something...
            Vector2 nextPosition = this.Location + (Direction * SpeedMps * this.ElapsedGameTimeSeconds * this.Game.NbPixelPerMeter);

            Collision collision = this.GetCollision(nextPosition, COLLIDER_TYPES);
            if (collision != null)
            {
                this.Destroy();

                foreach (GameObject obj in collision.CollidesWith)
                {
                    if (obj is IHittable)
                    {
                        ((IHittable)obj).Hit(1);
                    }
                }
            }

            this.Location = nextPosition;



        }

    }
}
