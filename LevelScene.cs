using FNAEngine2D;
using Pong.Levels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public class LevelScene: GameObject
    {

        /// <summary>
        /// Ball game object
        /// </summary>
        private Ball _ball;

        /// <summary>
        /// Racket game object
        /// </summary>
        private Racket _racket;

        /// <summary>
        /// Current level
        /// </summary>
        private ILevel _currentLevel;

        /// <summary>
        /// Get the current level
        /// </summary>
        public int CurrentLevelNumber { get { return _currentLevel.Number; } }

        /// <summary>
        /// Load the level
        /// </summary>
        public override void Load()
        {

            _currentLevel = Add(new Level1());

            //The ball and the racket...
            _ball = Add(new Ball());
            _racket = Add(new Racket());

        }

        /// <summary>
        /// Reset the ball
        /// </summary>
        public void ResetBall()
        {
            _ball.ResetPosition();
        }


    }
}
