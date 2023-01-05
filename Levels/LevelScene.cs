using FNAEngine2D;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Levels
{
    public class LevelScene: GameObject
    {
        /// <summary>
        /// Room name
        /// </summary>
        private string _roomName;

        /// <summary>
        /// Constructor
        /// </summary>
        public LevelScene(string roomName)
        {
            _roomName = roomName;
        }

        /// <summary>
        /// Load the level
        /// </summary>
        protected override void Load()
        {
            Add(new GameContentContainer("gamecontent\\" + _roomName));
        }


    }
}
