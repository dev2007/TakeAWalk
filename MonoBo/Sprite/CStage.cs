using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
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
        ///  <returns>true,event is not transfer.</returns>
        public bool Change(GestureSample gesture)
        {
            bool flag = false;
            foreach (ISprite actor in actorList)
            {
                flag = actor.Change(gesture);
                if (flag)
                    return flag;
            }
            return false;
        }

        /// <summary>
        /// Stage change.
        /// </summary>
        /// <param name="pressedKeys"></param>
        /// <returns>true,event is done.false,event is not done.</returns>
        public bool Change(Keys[] pressedKeys)
        {
            bool flag = false;
            foreach (ISprite actor in actorList)
            {
                flag = actor.Change(pressedKeys);
                if (flag)
                    return flag;
            }
            return false;
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

        public void PlayMusic(Song song, bool isReapting = true)
        {
            MediaPlayer.IsRepeating = isReapting;
            if (MediaPlayer.GameHasControl)
            {
                if (MediaPlayer.State == MediaState.Playing)
                    MediaPlayer.Stop();
                MediaPlayer.Play(song);
            }

        }

        public void PauseMusic()
        {
            if (MediaPlayer.State == MediaState.Playing)
                MediaPlayer.Pause();
        }

        public void StopMusic()
        {
            if (MediaPlayer.State != MediaState.Stopped)
                MediaPlayer.Stop();
        }
    }
}
