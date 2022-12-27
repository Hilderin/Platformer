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
        public const int JUMP_HEIGHT = 50;
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
        /// Charactor animator
        /// </summary>
        private SpriteAnimator<CharacterAnimations> _charactorAnimator;

        /// <summary>
        /// Fire animator
        /// </summary>
        private SpriteAnimator<FireAnimations> _fireAnimator;

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

        /// <summary>
        /// Fire sound effect player
        /// </summary>
        private Content<SoundEffect> _fireSfx;

        /// <summary>
        /// Health
        /// </summary>
        public int Health { get; set; } = 100;


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
            _input.FireKey = Keys.Space;
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

            //Animator...
            _charactorAnimator = Add(new SpriteAnimator<CharacterAnimations>("animations"));
            _fireAnimator = Add(new SpriteAnimator<FireAnimations>("animations"));
            _fireAnimator.Loop = false;
            _fireAnimator.PlayOnStart = false;


            //Footsteps........
            _footstepPlayer = Add(new SoundEffectPlayer());
            _footstepPlayer.Volume = 0.2f;
            _footstepPlayer.MinimumRateSeconds = 0.5f;

            //_footstepSfx = _footstepPlayer.GetContent("sfx\\footsteps\\metal");
            //_landSfx = _footstepPlayer.GetContent("sfx\\footsteps\\metal");
            _footstepSfx = _footstepPlayer.GetContent("sfx\\footsteps\\dirt");
            _landSfx = _footstepPlayer.GetContent("sfx\\footsteps\\dirt");


            //Jump...
            _jumpPlayer = Add(new SoundEffectPlayer());
            _jumpPlayer.Volume = 0.4f;
            _jumpSfx = _footstepPlayer.GetContent("sfx\\footsteps\\jump");


            //Fire
            _fireSfx = SoundManager.GetSfx("sfx\\fire");


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

                //nextPosition = new Vector2(100, 0);
                this.Health--;

                if (this.Health <= 0)
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

            //-------------------
            //Firing...
            if (_isGrounded && _input.IsNewFire)
            {
                //Firing...
                Fire();
            }


            //Updating du animation...
            UpdateAnimation();

            //Update sfx for footsteps...
            UpdateFootstepsSfx();

            //Update sfx for jumping...
            UpdateJumpSfx();


            _isLastGrounded = _isGrounded;

            PlatformerHost.MainCamera.Location = nextPosition + OFFSET_CAMERA - new Vector2(GameHost.CenterX, GameHost.CenterY);
            
            if(PlatformerHost.MinimapCamera != null)
                PlatformerHost.MinimapCamera.Location = GameHost.MainCamera.Location;

        }

        /// <summary>
        /// Fire a bullet
        /// </summary>
        private void Fire()
        {
            Bullet bullet = Add(new Bullet());

            if (_lastMoveWasRight)
            {
                bullet.Location = new Vector2(this.Bounds.Right - 3, this.Location.Y + 18);
                bullet.Direction = new Vector2(1, 0);
                _fireAnimator.Play(FireAnimations.fire_right);
            }
            else
            {
                bullet.Location = new Vector2(this.Location.X + 3, this.Location.Y + 18);
                bullet.Direction = new Vector2(-1, 0);
                _fireAnimator.Play(FireAnimations.fire_left);
            }
            bullet.SpeedMps = 10;
            SoundManager.PlaySfx(_fireSfx);
            

        }

        /// <summary>
        /// Be sure du active que right animation...
        /// </summary>
        private void UpdateAnimation()
        {
            CharacterAnimations animationToUse;


            if (_input.IsLeft)
            {
                //Left....
                animationToUse = CharacterAnimations.character_run_left;
                _lastMoveWasRight = false;
            }
            else if (_input.IsRight)
            {
                //Right....
                animationToUse = CharacterAnimations.character_run_right;
                _lastMoveWasRight = true;
            }
            else if (_lastMoveWasRight)
            {
                animationToUse = CharacterAnimations.character_idle_right;
            }
            else
            {
                animationToUse = CharacterAnimations.character_idle_left;
            }

            if (!_isGrounded)
            {
                //Jumping or falling...
                if (_lastMoveWasRight)
                    animationToUse = CharacterAnimations.character_jump_right;
                else
                    animationToUse = CharacterAnimations.character_jump_left;
            }

            if (animationToUse != _charactorAnimator.CurrentAnimation)
            {
                //We change animation...
                _charactorAnimator.Play(animationToUse);

                //Stopping firing animation to be sure to not display crap on screen on the wrong side of the player
                _fireAnimator.Stop();
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
