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
            //Background
            Add(new TextureRender("pixel", GameHost.Bounds, Color.Black));

            //Floor...
            //Add(new TextureRender("animations\\character_run_right"));
            Add(new SpriteAnimationRender("animations\\character_run_right")).ResizeTo(96, 96);

            //Floor...
            Add(new TextureRender("pixel", new Rectangle(0, 300, GameHost.Width, 2000)))
                .EnableCollider();

            //Obstacle
            Add(new TextureRender("pixel", new Rectangle(300, 300 - Player.HEIGHT, Player.HEIGHT, Player.HEIGHT), Color.Blue))
                .EnableCollider();

            //Player...
            Add(new Player());
        }
    }
}
