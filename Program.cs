using FNAEngine2D;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Platformer
{
    internal class Program
    {
        /// <summary>
        /// Must be STAThread for the Designer
        /// </summary>
        [STAThread]
        public static void Main()
        {
            //Start the game..
            PlatformerHost.Run();
        }
    }
}
