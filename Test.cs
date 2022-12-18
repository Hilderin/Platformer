using FNAEngine2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public class Test: GameObject
    {


        public override void Load()
        {

            GameContentManager.Apply(this, "gamecontent\\escape_menu");

            MouseManager.ShowMouse();
        }
    }
}
