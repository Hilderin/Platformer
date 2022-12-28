using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Objects
{
    public interface IHittable
    {
        /// <summary>
        /// Hit the object with a bullet
        /// </summary>
        void Hit(int hitPoint);

    }
}
