using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TakeAWalk
{
    /// <summary>
    /// Interface of notice.
    /// Transfer message from actor to director.
    /// </summary>
    public interface INotice
    {
        void ReceiveNotice(Notice notice);
    }

    /// <summary>
    /// Actors notify director's flag.
    /// </summary>
    public enum Notice
    {
        /// <summary>
        /// Nothing
        /// </summary>
        NOTHING = 0,
        /// <summary>
        /// Current action finish.
        /// </summary>
        ACTION_FINISH = 1,
        /// <summary>
        /// switch stage
        /// </summary>
        SWTICH_STAGE = 2,
        /// <summary>
        /// new action.
        /// </summary>
        ACTION_START = 3,
        /// <summary>
        /// play music.
        /// </summary>
        PLAY_MUSIC = 4,
        /// <summary>
        /// pause music.
        /// </summary>
        PAUSE_MUSIC=5
    }
}
