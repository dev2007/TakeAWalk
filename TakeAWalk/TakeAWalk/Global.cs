using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TakeAWalk
{
    public class Global
    {
        /// <summary>
        /// Diy window's width;
        /// </summary>
        public const int WINDOW_WIDTH = 1024;
        /// <summary>
        /// Diy Windows's height.
        /// </summary>
        public const int WINDOW_HEIGHT = 800;
        /// <summary>
        /// Standard animation frame height & width. 
        /// </summary>
        public const int STANDARD_ANIMATION_SIZE = 96;
        /// <summary>
        /// Millsecond per frame.
        /// </summary>
        public const int MILLISECONDS_PER_FRAME = 80;
        /// <summary>
        /// move velocity
        /// </summary>
        public const int VELOCITY_MOVE = 5;
    }

    /// <summary>
    /// Z-Axis default value.
    /// </summary>
    public struct Z_Axis
    {
        public const float ZERO = 0;
        public const float FRONT_STAGE = 0.2f;
        public const float STAGE = 0.4f;
        public const float NEAR_STAGE = 0.6f;
        public const float REMOTE_STAGE = 0.8f;
        public const float BACKGROUND = 1.0f;
    }

    public enum MoveDirect
    {
        HOLD = 0,
        RIGHT = 1,
        LEFT = 2,
        UP = 3,
        DOWN = 4
    }

    public class PhysicWorld
    {
        private static World _world = new World(new Vector2(0, 9.82f));

        public static World World
        {
            get
            {
                return _world;
            }
        }
    }
}
