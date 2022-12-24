using FNAEngine2D;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer
{
    /// <summary>
    /// Basic enemy object
    /// </summary>
    public class Enemy: GameObject
    {
        /// <summary>
        /// RigidBody
        /// </summary>
        private RigidBody _rigidbody;

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
        public override void Load()
        {
            var animation = Add(new SpriteAnimationRender("animations\\enemy"));
            animation.Bounds = this.Bounds.CenterBottom(animation.Width, animation.Height);

            this.EnableCollider();

            _rigidbody = new RigidBody(this);
            _rigidbody.SpeedMps = 2;
            _rigidbody.IsMovingRight = true;
        }

        /// <summary>
        /// Updating...
        /// </summary>
        public override void Update()
        {
            Vector2 nextPositionOrigin = _rigidbody.ApplyPhysics();
            Vector2 nextPosition = nextPositionOrigin;

            Collision collistion = this.GetCollision(nextPositionOrigin, Constants.TYPE_COLLIDER_WALLS);
            if (collistion != null)
            {
                nextPosition = collistion.StopLocation;

                //Check if the enemy hit a wall...
                if (this.Location.X == nextPosition.X)
                {
                    _rigidbody.IsMovingRight = !_rigidbody.IsMovingRight;
                    _rigidbody.IsMovingLeft = !_rigidbody.IsMovingLeft;
                }
                else
                {
                    //Checking if enemy at the end of the floor by checking one pixel left or right
                    Vector2 postionToCheckTheEmptinessOfTheVoid;
                    if (_rigidbody.IsMovingLeft)
                        postionToCheckTheEmptinessOfTheVoid = new Vector2(nextPosition.X - 1, nextPosition.Y + this.Height + 1);
                    else
                        postionToCheckTheEmptinessOfTheVoid = new Vector2(nextPosition.X + this.Width + 1, nextPosition.Y + this.Height + 1);

                    if (this.GetCollision(postionToCheckTheEmptinessOfTheVoid, Vector2.One, Constants.TYPE_COLLIDER_WALLS) == null)
                    {
                        _rigidbody.IsMovingRight = !_rigidbody.IsMovingRight;
                        _rigidbody.IsMovingLeft = !_rigidbody.IsMovingLeft;
                    }
                }
            }


            //And we move the object at the calculated coords...
            this.Location = nextPosition;
        }
    }
}
