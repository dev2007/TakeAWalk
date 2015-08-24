using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TakeAWalk.Actor;

namespace TakeAWalk.Stage
{
    public class CCityStage: CStage
    {
        public CCityStage()
        {

        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            Rectangle roleRect = new Rectangle();
            Rectangle blockRect = new Rectangle();
            foreach (ISprite actor in actorList)
            {
                if(actor is CRole)
                {
                    roleRect = ((CRole)actor).ObjectRect;
                }
                if(actor is CBlock)
                {
                    blockRect = ((CBlock)actor).NextRect;
                    if(roleRect.Bottom >= blockRect.Top || roleRect.X + roleRect.Width >= blockRect.X)
                    {

                    }
                }
            }

            foreach (ISprite actor in actorList)
            {
                actor.Update(gameTime);
            }
        }
    }
}
