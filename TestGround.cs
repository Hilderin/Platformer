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
            Add(new TextureRender("backgrounds\\night", GameHost.Bounds));

            //Floor...
            //Add(new TextureRender("animations\\character_run_right"));
            //Add(new SpriteAnimationRender("animations\\character_run_right")).ResizeTo(96, 96);

            //Floor...
            int floorY = GameHost.Height - 20;
            Add(new TextureRender("pixel", new Rectangle(0, floorY, GameHost.Width, 2000)))
                .EnableCollider();

            //Obstacle
            Add(new TextureRender("pixel", new Rectangle(300, floorY - Player.HEIGHT, Player.HEIGHT, Player.HEIGHT), Color.Blue))
                .EnableCollider();

            //Player...
            Add(new Player());
        }
    }
}
