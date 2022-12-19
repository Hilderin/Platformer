using FNAEngine2D;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
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
        public const int JUMP_HEIGHT = 80;

        /// <summary>
        /// Input control
        /// </summary>
        private CharacterInput _input;

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
        /// jumping left animation
        /// </summary>
        private SpriteAnimationRender _jumpLeftAnimation;

        /// <summary>
        /// jumping right animation
        /// </summary>
        private SpriteAnimationRender _jumpRightAnimation;


        /// <summary>
        /// Current animation
        /// </summary>
        private SpriteAnimationRender _currentAnimation;

        /// <summary>
        /// Indicate if the player is grounded
        /// </summary>
        private bool _isGrounded = false;

        /// <summary>
        /// Last time was going right
        /// </summary>
        private bool _lastMoveWasRight = true;



        /// <summary>
        /// Construtor
        /// </summary>
        public Player()
        {
            this.Width = WIDTH;
            this.Height = HEIGHT;

            //Setup the inputs...
            _input = new CharacterInput();
            _input.JumpKey = Keys.W;

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

            //jumping left animation...
            _jumpLeftAnimation = Add(new SpriteAnimationRender("animations\\character_jump_left"));
            _jumpLeftAnimation.Bounds = this.Bounds.CenterBottom(_jumpLeftAnimation.Width, _jumpLeftAnimation.Height);
            _jumpLeftAnimation.Enabled = false;

            //jumping left animation...
            _jumpRightAnimation = Add(new SpriteAnimationRender("animations\\character_jump_right"));
            _jumpRightAnimation.Bounds = this.Bounds.CenterBottom(_jumpRightAnimation.Width, _jumpRightAnimation.Height);
            _jumpRightAnimation.Enabled = false;

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

                //Is grounded?
                _isGrounded = (nextPosition.Y == this.Y);

            }
            else
            {
                //Falling...
                _isGrounded = false;
            }

            this.TranslateTo(nextPosition);

            //Jumping??
            if (_isGrounded && _input.IsJump)
            {
                _rigidBody.AddForce(new Vector2(0, -JUMP_HEIGHT), _rigidBody.SpeedMps * 1.5f);
            }


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
                _lastMoveWasRight = false;
            }
            else if (_input.IsRight)
            {
                //Right....
                animationToUse = _runRightAnimation;
                _lastMoveWasRight = true;
            }
            else
            {
                animationToUse = _idleAnimation;
            }

            if (!_isGrounded)
            {
                //Jumping or falling...
                if (_lastMoveWasRight)
                    animationToUse = _jumpRightAnimation;
                else
                    animationToUse = _jumpLeftAnimation;
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
