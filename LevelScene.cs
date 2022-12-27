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
            Add(new GameContentContainer("gamecontent\\level1"));
        }


    }
}
