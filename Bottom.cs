using FNAEngine2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public class Bottom: GameObject
    {
        /// <summary>
        /// Load of the object
        /// </summary>
        public override void Load()
        {
            this.Y = GameHost.Height;
            this.Width = GameHost.Width;
            this.Height = 100;

            this.EnableCollider();
        }
    }
}
