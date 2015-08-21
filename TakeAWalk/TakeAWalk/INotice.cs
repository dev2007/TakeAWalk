using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TakeAWalk
{
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
        ACTION_FINISH = 1
    }
}
