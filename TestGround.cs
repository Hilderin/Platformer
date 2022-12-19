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
    /// Test ground
    /// </summary>
    public class TestGround: GameObject
    {

        /// <summary>
        /// Loading
        /// </summary>
        public override void Load()
        {


            //Floor...
            Add(new TextureRender("pixel", new Rectangle(0, 300, GameHost.Width, 2000)))
                .EnableCollider();

            //Player...
            Add(new Player());
        }
    }
}
