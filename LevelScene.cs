using FNAEngine2D;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer
{
    public class LevelScene: GameObject
    {

        /// <summary>
        /// Load the level
        /// </summary>
        public override void Load()
        {

            Add(new SpriteRender("sprites\\character", 0, 1));

            Add(new SpriteAnimationRender("animations\\character_idle"))
                .TranslateTo(new Vector2(0, 200));

            Add(new SpriteAnimationRender("animations\\character_run_left"))
                .TranslateTo(new Vector2(200, 200));

            //Tile[][] tiles = new Tile[100][];

            //for (int x = 0; x < 100; x++)
            //{
            //    Tile[] column = new Tile[100];

            //    for (int y = 0; y < column.Length; y++)
            //    {
            //        column[y] = new Tile(16, 2);
            //    }

            //    tiles[x] = column;
            //}


            //var tileSetRenderer = Add(new TileSetRender("sprites\\tiles2", 16, 32));
            //tileSetRenderer.Tiles = tiles;


        }

        /// <summary>
        /// Reset the player
        /// </summary>
        public void ResetPlayer()
        {
            
        }


    }
}
