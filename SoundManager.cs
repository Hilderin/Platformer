using FNAEngine2D;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer
{
    /// <summary>
    /// Sound Manager
    /// </summary>
    public class SoundManager
    {

        /// <summary>
        /// Play a SFX
        /// </summary>
        public static void PlaySfx(Content<SoundEffect> sfx)
        {
            sfx.Data.Play(0.8f, 0f, 0f);
        }

        /// <summary>
        /// get a SFX
        /// </summary>
        public static Content<SoundEffect> GetSfx(string assetName)
        {
            return GameHost.GetContent<SoundEffect>(assetName);
        }

    }
}
