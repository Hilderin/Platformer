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
    /// Player
    /// </summary>
    public class Player: GameObject
    {
        /// <summary>
        /// Real sizes
        /// </summary>
        public const int WIDTH = 50;
        public const int HEIGHT = 80;

        /// <summary>
        /// Input control
        /// </summary>
        private CharacterInput _input = new CharacterInput();

        /// <summary>
        /// Rigit body
        /// </summary>
        private RigidBody _rigidBody;

        /// <summary>
        /// Idle animation
        /// </summary>
        private SpriteAnimationRender _idleAnimation;

        /// <summary>
        /// Running left animation
        /// </summary>
        private SpriteAnimationRender _runLeftAnimation;

        /// <summary>
        /// Running right animation
        /// </summary>
        private SpriteAnimationRender _runRightAnimation;

        /// <summary>
        /// Current animation
        /// </summary>
        private SpriteAnimationRender _currentAnimation;

        /// <summary>
        /// Construtor
        /// </summary>
        public Player()
        {
            this.Width = WIDTH;
            this.Height = HEIGHT;
        }

        /// <summary>
        /// Player
        /// </summary>
        public override void Load()
        {
            //Rigidbody to calculate physics (Gravity)
            _rigidBody = new RigidBody(this);
            _rigidBody.SpeedMps = 3;


            //Idle animation...
            _idleAnimation = Add(new SpriteAnimationRender("animations\\character_idle"));
            _idleAnimation.Bounds = this.Bounds.CenterBottom(_idleAnimation.Width, _idleAnimation.Height);
            _currentAnimation = _idleAnimation;

            //Running left animation...
            _runLeftAnimation = Add(new SpriteAnimationRender("animations\\character_run_left"));
            _runLeftAnimation.Bounds = this.Bounds.CenterBottom(_runLeftAnimation.Width, _runLeftAnimation.Height);
            _runLeftAnimation.Enabled = false;

            //Running left animation...
            _runRightAnimation = Add(new SpriteAnimationRender("animations\\character_run_right"));
            _runRightAnimation.Bounds = this.Bounds.CenterBottom(_runRightAnimation.Width, _runRightAnimation.Height);
            _runRightAnimation.Enabled = false;

        }

        /// <summary>
        /// Update each frame
        /// </summary>
        public override void Update()
        {
            //Movement...
            _rigidBody.IsMovingLeft = _input.IsLeft;
            _rigidBody.IsMovingRight = _input.IsRight;

            //Applying physics...
            Vector2 nextPosition = _rigidBody.ApplyPhysics();

            

            //Check for collision...
            Collision collistion = this.GetCollision(nextPosition, null);
            if (collistion != null)
            {
                nextPosition = collistion.StopLocation;
            }

            this.TranslateTo(nextPosition);


            //Updating du animation...
            UpdateAnimation();

        }


        /// <summary>
        /// Be sure du active que right animation...
        /// </summary>
        private void UpdateAnimation()
        {
            SpriteAnimationRender animationToUse;

            if (!_input.IsLeft && !_input.IsRight
                || (_input.IsLeft && _input.IsRight))
            {
                //Not moving...
                animationToUse = _idleAnimation;
            }
            else if (_input.IsLeft)
            {
                //Left....
                animationToUse = _runLeftAnimation;
            }
            else if (_input.IsRight)
            {
                //Left....
                animationToUse = _runRightAnimation;
            }
            else
            {
                animationToUse = _idleAnimation;
            }



            if (animationToUse != _currentAnimation)
            {
                //We change animation...
                _currentAnimation.Enabled = false;
                _currentAnimation = animationToUse;
                animationToUse.Restart();
                animationToUse.Enabled = true;
            }




        }
    }
}
