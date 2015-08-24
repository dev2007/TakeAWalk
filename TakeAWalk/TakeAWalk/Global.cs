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
        public const int WINDOW_WIDTH = 800;
        /// <summary>
        /// Diy Windows's height.
        /// </summary>
        public const int WINDOW_HEIGHT = 600;
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
}
