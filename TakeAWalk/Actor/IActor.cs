using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TakeAWalk.Stage;

namespace TakeAWalk.Actor
{
    /// <summary>
    /// Interface of actor.
    /// </summary>
    public interface IActor
    {
        void RegisterStage(CStage stage);
        void UnRegisterStage(CStage stage);
        void NotifyStage(Notice notice);
    }
}
