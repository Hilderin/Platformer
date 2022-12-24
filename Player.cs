using FNAEngine2D;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using Platformer.UI;
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
        public const int WIDTH = 26;
        public const int HEIGHT = 48;
        public const int JUMP_HEIGHT = 48;
        public readonly Vector2 OFFSET_CAMERA = new Vector2(WIDTH / 2, HEIGHT / 2);


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
        /// Indicate if the player was grounded on the fast frame
        /// </summary>
        private bool _isLastGrounded = true;

        /// <summary>
        /// Last time was going right
        /// </summary>
        private bool _lastMoveWasRight = true;

        /// <summary>
        /// Player for foot steps
        /// </summary>
        private SoundEffectPlayer _footstepPlayer;

        /// <summary>
        /// Footstep sound effect
        /// </summary>
        private Content<SoundEffect> _footstepSfx;

        /// <summary>
        /// Landing sound effect
        /// </summary>
        private Content<SoundEffect> _landSfx;

        /// <summary>
        /// Player for foot steps
        /// </summary>
        private SoundEffectPlayer _jumpPlayer;

        /// <summary>
        /// Jump sound effect
        /// </summary>
        private Content<SoundEffect> _jumpSfx;

        public static Player Current { get; private set; }

        public int NbLive { get; set; } = 3;


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

            Current = this;

        }

        /// <summary>
        /// Player
        /// </summary>
        public override void Load()
        {
            this.EnableCollider();

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


            //Footsteps........
            _footstepPlayer = Add(new SoundEffectPlayer());
            _footstepPlayer.Volume = 0.2f;
            _footstepPlayer.MinimumRateSeconds = 0.5f;

            _footstepSfx = _footstepPlayer.GetContent("sfx\\footsteps\\metal");
            _landSfx = _footstepPlayer.GetContent("sfx\\footsteps\\metal");


            //Jump...
            _jumpPlayer = Add(new SoundEffectPlayer());
            _jumpPlayer.Volume = 0.4f;
            _jumpSfx = _footstepPlayer.GetContent("sfx\\footsteps\\jump");



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
            Collision collistion = this.GetCollision(nextPosition, Constants.TYPE_COLLIDER_WALLS);
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

            //Check collision with enemies...
            Collision collisionEnemy = this.GetCollision(nextPosition, Constants.TYPE_ENEMIES);
            if (collisionEnemy != null)
            {
                //this.Parent.Add(new GameOver());

                nextPosition = new Vector2(100, 0);
                this.NbLive--;

                if (this.NbLive <= 0)
                {
                    this.Parent.Add(new GameOver());
                    this.Destroy();
                    return;
                }

            }


            this.TranslateTo(nextPosition);



            //--------------------
            //Jumping??
            if (_isGrounded && _input.IsNewJump)
            {
                //Start jumping...
                _rigidBody.AddForce(new Vector2(0, -JUMP_HEIGHT), _rigidBody.SpeedMps * 1.5f);
            }


            //Updating du animation...
            UpdateAnimation();

            //Update sfx for footsteps...
            UpdateFootstepsSfx();

            //Update sfx for jumping...
            UpdateJumpSfx();


            _isLastGrounded = _isGrounded;

            GameHost.MainCamera.Location = nextPosition + OFFSET_CAMERA - new Vector2(GameHost.CenterX, GameHost.CenterY);
            //GameHost.ExtraCameras[0].Location = nextPosition + OFFSET_CAMERA;
            GameHost.ExtraCameras[1].Location = GameHost.MainCamera.Location;
            //GameHost.DefaultCamera.Rotation += 0.01f;

            //if (_input.IsLeft)
            //    GameHost.DefaultCamera.Location = GameHost.DefaultCamera.Location.AddX(-10);
            //else if (_input.IsRight)
            //    GameHost.DefaultCamera.Location = GameHost.DefaultCamera.Location.AddX(10);
            //if (_input.IsUp)
            //    GameHost.DefaultCamera.Location = GameHost.DefaultCamera.Location.AddY(-10);
            //else if (_input.IsDown)
            //    GameHost.DefaultCamera.Location = GameHost.DefaultCamera.Location.AddY(10);
        }


        /// <summary>
        /// Be sure du active que right animation...
        /// </summary>
        private void UpdateAnimation()
        {
            SpriteAnimationRender animationToUse;

            
            if (_input.IsLeft)
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


        /// <summary>
        /// Updating sfx for footsteps
        /// </summary>
        private void UpdateFootstepsSfx()
        {
            if (_isGrounded)
            {
                if (!_isLastGrounded)
                {
                    //Landing...
                    _footstepPlayer.Play(_landSfx);
                }
                else if (_input.IsLeft || _input.IsRight)
                {
                    //Footsteps!
                    _footstepPlayer.Play(_footstepSfx);
                }
            }
        }

        /// <summary>
        /// Updating sfx for jumping
        /// </summary>
        private void UpdateJumpSfx()
        {
            if (!_isGrounded)
            {
                _jumpPlayer.Play(_jumpSfx);
            }
            else if (_isGrounded && _jumpPlayer.IsPlaying)
            {
                _jumpPlayer.Stop();
            }
        }
    }
}
