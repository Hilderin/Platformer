﻿using FNAEngine2D;
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
            GameHost.MainCamera = new Camera();
            //GameHost.MainCamera.Location = new Vector2(GameHost.CenterX, GameHost.CenterY);
            GameHost.MainCamera.Location = new Vector2(-50, 50);
            GameHost.MainCamera.LayerMask = Layers.Layer1;

            //GameHost.MainCamera.ViewLocation = new Point(10, 10);
            //GameHost.MainCamera.Size = new Point(GameHost.Width - 20, GameHost.Height - 20);

            GameHost.ExtraCameras.Clear();

            Camera camera2 = new Camera();
            camera2.LayerMask = Layers.Layer2;
            GameHost.ExtraCameras.Add(camera2);

            int minimapSize = 100;
            Camera cameraMinimap = new Camera();
            cameraMinimap.LayerMask = Layers.Layer1;
            GameHost.ExtraCameras.Add(cameraMinimap);
            cameraMinimap.ViewLocation = new Point(GameHost.Width - (minimapSize + 10), 10);
            cameraMinimap.Size = new Point(minimapSize, minimapSize);
            //cameraMinimap.Zoom = ((float)minimapSize / GameHost.Height);
            cameraMinimap.Zoom = 0.2f;

            GameHost.BackgroundColor = Color.Black;


            //Background
            Add(new TextureRender("backgrounds\\night"));


            //Floor...
            //Add(new TextureRender("animations\\character_run_right"));
            //Add(new SpriteAnimationRender("animations\\character_run_right")).ResizeTo(96, 96);

            ////Floor...
            //int floorY = GameHost.Height - 20;
            //Add(new TextureRender("pixel", new Rectangle(-1000, floorY, 2000, 30)))
            //    .EnableCollider();

            ////Obstacle
            //Add(new TextureRender("pixel", new Rectangle(300, floorY - Player.HEIGHT, Player.HEIGHT, Player.HEIGHT), Color.Blue))
            //    .EnableCollider();

            ////Obstacle
            //Add(new TextureRender("pixel", new Rectangle(100, floorY - Player.HEIGHT - 10, 100, 10), Color.Blue))
            //    .EnableCollider();

            //Text...
            //var t = Add(new TextRender("LEVEL 1", "fonts\\Roboto-Bold", 10, new Rectangle(0, 0, GameHost.Width, 25), Color.Red, TextHorizontalAlignment.Center, TextVerticalAlignment.Middle));
            //t.LayerMask = Layers.Layer2;


            Add(new GameContentContainer("gamecontent\\test_ground"));
            //Add(new GameContentContainer("gamecontent\\test_ground_no_enemy"));
            

            //Player...
            Add(new Player()).TranslateTo(new Vector2(100, 0));

            ////Enemy
            //Add(new Enemy()).TranslateTo(new Vector2(0, 228));

            Add(new UI.HUD());

        }

    }
}
