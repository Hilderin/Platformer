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
            GameHost.DefaultCamera = new Camera();
            GameHost.DefaultCamera.Location = new Vector2(GameHost.CenterX, GameHost.CenterY);

            Camera camera2 = new Camera();
            camera2.LayerMask = (int)Layers.Layer2;
            GameHost.ExtraCameras.Add(camera2);


            //Background
            Add(new TextureRender("backgrounds\\night"));


            //Floor...
            //Add(new TextureRender("animations\\character_run_right"));
            //Add(new SpriteAnimationRender("animations\\character_run_right")).ResizeTo(96, 96);

            //Floor...
            int floorY = GameHost.Height - 20;
            Add(new TextureRender("pixel", new Rectangle(-1000, floorY, 2000, 30)))
                .EnableCollider();

            //Obstacle
            Add(new TextureRender("pixel", new Rectangle(300, floorY - Player.HEIGHT, Player.HEIGHT, Player.HEIGHT), Color.Blue))
                .EnableCollider();

            //Obstacle
            Add(new TextureRender("pixel", new Rectangle(100, floorY - Player.HEIGHT - 10, 100, 10), Color.Blue))
                .EnableCollider();

            //Text...
            var t = Add(new TextRender("LEVEL 1", "fonts\\Roboto-Bold", 10, new Rectangle(0, 0, GameHost.Width, 25), Color.Red, TextHorizontalAlignment.Center, TextVerticalAlignment.Middle));
            t.LayerMask = (int)Layers.Layer2;

            //Player...
            Add(new Player());
        }

    }
}
