using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TakeAWalk.Actor;
using TakeAWalk.ActorFactory;

namespace TakeAWalk.Script
{
    public class CCityScript : CBaseScript
    {
        public CCityScript(ContentManager contentManager)
            : base(contentManager)
        {

        }

        protected override void CreateStage()
        {
            CCityFactory factory = new CCityFactory(contentManager);
            foreach(IActor actor in factory.StageActor())
            {
                stage.HireActor(actor);
            }
        }
    }
}
