using FNAEngine2D;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public class Bullet: GameObject
    {
        public const int BULLET_WIDTH = 4;
        public const int BULLET_HEIGHT = 18;

        /// <summary>
        /// Speed of the bullet
        /// </summary>
        private float _speed = 600f;

        /// <summary>
        /// Type to manage the colliders
        /// </summary>
        private Type[] _colliderTypes = new Type[] { typeof(GameBorder), typeof(Block) };

        /// <summary>
        /// Constructor
        /// </summary>
        public Bullet(int x, int y)
        {
            this.Bounds = new Rectangle(x, y, BULLET_WIDTH, BULLET_HEIGHT);
        }

        /// <summary>
        /// Loading
        /// </summary>
        public override void Load()
        {
            Add(new TextureRender("bullet", this.Bounds));

        }

        /// <summary>
        /// Update
        /// </summary>
        public override void Update()
        {
            int deplacementY = -(int)(_speed * GameHost.ElapsedGameTimeSeconds);

            Collision collision = this.GetCollision(this.X, this.Y + deplacementY, _colliderTypes);
            if (collision != null)
            {
                if (collision.CollidesWith.GameObject is Block)
                {
                    //Collapse avec un block, on va détruire le block...
                    ((Block)collision.CollidesWith.GameObject).Hit();
                    GameHost.GetContent<SoundEffect>("sfx\\hit").Play();
                }

                this.Destroy();
            }
            else
            {
                this.TranslateY(deplacementY);
            }
            



        }
        
    }
}
