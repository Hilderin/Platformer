using FNAEngine2D;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.Levels
{
    public class Level1 : GameObject, ILevel
    {
        /// <summary>
        /// Level 1
        /// </summary>
        public int Number => 1;

        /// <summary>
        /// Chargement du contenu
        /// </summary>
        public override void Load()
        {
            //Background...
            Add(new TextureRender("backgrounds\\plain", new Rectangle(0, 0, GameHost.Width, GameHost.Height)));

            LevelHelper.AddSidesDefault(this);

            LoadBlocks();

            //Song music = GameHost.GetContent<Song>("music\\Armin-van-Buuren-Ping-Pong");
            //MediaPlayer.IsRepeating = true;
            //MediaPlayer.Volume = 0.4f;
            //MediaPlayer.Play(music);

        }

        /// <summary>
        /// Chargement des blocks
        /// </summary>
        private void LoadBlocks()
        {
            const int nbBlocksCols = 10;
            const int nbBlocksRows = 6;

            int totalX = nbBlocksCols * Block.BlockSize.X;
            int offsetX = (GameHost.Width / 2) - (totalX / 2);
            int offsetY = LevelHelper.SIDE_WIDTH;


            for (int x = 0; x < nbBlocksCols; x++)
            {
                for (int y = 0; y < nbBlocksRows; y++)
                {

                    Block block = Add(new Block());
                    block.Translate(offsetX + (x * Block.BlockSize.X), offsetY + (y * Block.BlockSize.Y));

                }
            }

        }
    }
}
