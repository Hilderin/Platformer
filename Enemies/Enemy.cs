using FNAEngine2D;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Platformer.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Enemies
{
    /// <summary>
    /// Basic enemy object
    /// </summary>
    public class Enemy: GameObject, IHittable
    {
        /// <summary>
        /// RigidBody
        /// </summary>
        private RigidBody _rigidBody;

        /// <summary>
        /// Constructor
        /// </summary>
        public Enemy()
        {
            this.Width = 22;
            this.Height = 28;
        }


        /// <summary>
        /// Loading...
        /// </summary>
        protected override void Load()
        {
            var animation = Add(new SpriteAnimationRender("animations\\enemy"));
            animation.Bounds = this.Bounds.CenterBottom(animation.Width, animation.Height);

            this.EnableCollider();

            _rigidBody = AddComponent<RigidBody>();
            _rigidBody.SpeedMps = 2;
            _rigidBody.ColliderTypes = Constants.TYPE_COLLIDER_WALLS;
            _rigidBody.Movement = new Vector2(1, 0);    //Right

        }

        /// <summary>
        /// Updating...
        /// </summary>
        protected override void Update()
        {
            if (_rigidBody.Collistion != null)
            {
                //Check if the enemy hit a wall...
                if (this.Location.X == _rigidBody.LastLocation.X)
                {
                    _rigidBody.Movement *= new Vector2(-1, 0);
                }
                else
                {
                    //Checking if enemy at the end of the floor by checking one pixel left or right
                    Vector2 postionToCheckTheEmptinessOfTheVoid;
                    if (_rigidBody.Movement.X < 0)
                        postionToCheckTheEmptinessOfTheVoid = new Vector2(this.Location.X - 1, this.Location.Y + this.Height + 1);
                    else
                        postionToCheckTheEmptinessOfTheVoid = new Vector2(this.Location.X + this.Width + 1, this.Location.Y + this.Height + 1);

                    if (this.GetCollision(postionToCheckTheEmptinessOfTheVoid, Vector2.One, Constants.TYPE_COLLIDER_WALLS) == null)
                    {
                        _rigidBody.Movement *= new Vector2(-1, 0);
                    }
                }
            }
        }

        /// <summary>
        /// Enemy hit
        /// </summary>
        public void Hit(int hitPoint)
        {
            GetContent<SoundEffect>("sfx\\hit").Data.Play();
            this.Destroy();
        }
    }
}
