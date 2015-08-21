using Microsoft.Xna.Framework.Input.Touch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TakeAWalk.Actor;

namespace TakeAWalk.Stage
{
    public class CStage : ISprite
    {
        private IList<IActor> actorList;

        public CStage()
        {
            actorList = new List<IActor>();
        }

        public void HireActor(IActor actor)
        {
            if(actorList.Contains(actor))
            {
                throw new Exception("ex:re-add same actor.");
            }
            else
            {
                actorList.Add(actor);
            }
        }

        public void FireActor(IActor actor)
        {
            actorList.Remove(actor);
        }

        public void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            foreach (ISprite actor in actorList)
            {
                actor.Update(gameTime);
            }
        }

        public void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Microsoft.Xna.Framework.GameTime gameTime)
        {
            foreach (ISprite actor in actorList)
            {
                actor.Draw(spriteBatch, gameTime);
            }
        }
    }
}
