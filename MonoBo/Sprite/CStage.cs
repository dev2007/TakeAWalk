using Microsoft.Xna.Framework.Input.Touch;
using MonoBo.Sprite.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoBo.Sprite
{
    /// <summary>
    /// Stage class.
    /// Manage stage's actor.
    /// </summary>
    public class CStage : ISprite
    {
        /// <summary>
        /// container for actors.
        /// </summary>
        private IList<IActor> actorList;

        /// <summary>
        /// Constructor.
        /// </summary>
        public CStage()
        {
            actorList = new List<IActor>();
        }

        /// <summary>
        /// add an actor .
        /// </summary>
        /// <param name="actor">the actor.</param>
        public void HireActor(IActor actor)
        {
            if (actorList.Contains(actor))
            {
                throw new Exception("ex:re-add same actor.");
            }
            else
            {
                actorList.Add(actor);
            }
        }

        /// <summary>
        /// remove an actor.
        /// </summary>
        /// <param name="actor">the actor.</param>
        public void FireActor(IActor actor)
        {
            actorList.Remove(actor);
        }

        /// <summary>
        /// Stage change.
        /// </summary>
        /// <param name="gesture">the gesture.</param>
        public void Change(GestureSample gesture)
        {
            foreach (ISprite actor in actorList)
            {
                actor.Change(gesture);
            }
        }

        /// <summary>
        /// Stage update.
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            foreach (ISprite actor in actorList)
            {
                actor.Update(gameTime);
            }
        }

        /// <summary>
        /// Stage draw.
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="gameTime"></param>
        public void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Microsoft.Xna.Framework.GameTime gameTime)
        {
            foreach (ISprite actor in actorList)
            {
                actor.Draw(spriteBatch, gameTime);
            }
        }
    }
}
