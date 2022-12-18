using FNAEngine2D;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public class GameBorder: GameObject
    {
        /// <summary>
        /// Texture name
        /// </summary>
        private string _textureName;

        /// <summary>
        /// Constructor
        /// </summary>
        public GameBorder(string textureName, Rectangle bounds)
        {
            _textureName = textureName;
            this.Bounds = bounds;
        }

        /// <summary>
        /// Loading
        /// </summary>
        public override void Load()
        {
            Add(new TextureRender(_textureName, this.Bounds));
            this.EnableCollider();
        }
    }
}
