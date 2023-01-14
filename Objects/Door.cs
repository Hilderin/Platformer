using FNAEngine2D;
using FNAEngine2D.GameObjects;
using Microsoft.Xna.Framework.Audio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Objects
{
    /// <summary>
    /// A door
    /// </summary>
    public class Door: GameObject, IHittable, IPlayerActionCollide
    {

        /// <summary>
        /// Current game
        /// </summary>
        private PlatformerGame _game;

        /// <summary>
        /// Animation render
        /// </summary>
        private SpriteAnimationRender _spriteAnimationRender;

        /// <summary>
        /// Door is opening?
        /// </summary>
        private bool _isOpening = false;

        /// <summary>
        /// Inverted on the X axis
        /// </summary>
        private bool _invertedX = false;

        /// <summary>
        /// The door is opened?
        /// </summary>
        [JsonIgnore]
        public bool Opened { get; set; } = false;

        /// <summary>
        /// Next room
        /// </summary>
        public string NextRoom { get; set; }

        /// <summary>
        /// Inverted on the X axis
        /// </summary>
        [DefaultValue(false)]
        public bool InvertedX
        {
            get { return _invertedX; }
            set
            {
                if (_invertedX != value)
                {
                    _invertedX = value;

                    if (_spriteAnimationRender != null)
                        _spriteAnimationRender.InvertedX = value;
                }
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public Door()
        {
            //Default sizes...
            this.Width = Constants.TILE_SIZE;
            this.Height = Constants.TILE_SIZE * 4;      //64
            this.Collidable = true;
        }

        /// <summary>
        /// Loading
        /// </summary>
        protected override void Load()
        {
            _game = this.Game.RootGameObject as PlatformerGame;

            _spriteAnimationRender = Add(new SpriteAnimationRender("animations\\door_yellow", false, false, false));
            _spriteAnimationRender.Location = this.Location;
            _spriteAnimationRender.InvertedX = _invertedX;
        }

        /// <summary>
        /// Update
        /// </summary>
        protected override void Update()
        {
            if (_isOpening)
            {
                if (_spriteAnimationRender.Ended)
                {
                    //This opened!
                    this.Opened = true;
                    _isOpening = false;

                }
            }
        }

        /// <summary>
        /// Enemy hit
        /// </summary>
        public void Hit(int hitPoint)
        {
            Open();            
        }

        /// <summary>
        /// Open the door
        /// </summary>
        public void Open()
        {
            if (!Opened && !_isOpening)
            {
                GetContent<SoundEffect>("sfx\\door").Data.Play();

                _isOpening = true;
                _spriteAnimationRender.Play();
            }
        }

        /// <summary>
        /// The player reach the door
        /// </summary>
        public void Collide(Player player)
        {
            if (Opened)
            {
                if (!String.IsNullOrEmpty(NextRoom))
                    _game.LoadRoom(NextRoom);
            }


        }
    }
}
