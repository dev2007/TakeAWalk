using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TakeAWalk.ActorFactory
{
    public interface IFactory
    {
        IList<ISprite> StageActor();
        IList<ISprite> NearStageActor();
        IList<ISprite> RemoteStageActor();
        List<ISprite> BackgroundActor();
    }
}
