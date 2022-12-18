using FNAEngine2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.Levels
{
    public interface ILevel
    {
        /// <summary>
        /// Level number
        /// </summary>
        int Number { get; }

    }
}
