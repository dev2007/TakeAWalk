using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TakeAWalk.Actor;

namespace TakeAWalk.Stage
{
    public class CCityStage : CStage
    {
        public CCityStage()
        {

        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            foreach (ISprite actor in actorList)
            {
                actor.Update(gameTime);
            }
        }

        protected override void InitActors()
        {
            
        }
    }
}
