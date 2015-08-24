using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TakeAWalk.Actor;

namespace TakeAWalk.Stage
{
    public class CStage : ISprite,INotice
    {
        protected IList<IActor> actorList;
        protected CDirector director;

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
                actor.RegisterStage(this);
            }
        }

        public void FireActor(IActor actor)
        {
            actorList.Remove(actor);
            actor.UnRegisterStage(this);
        }

        public void ReceiveNotice(Notice notice)
        {
            if(notice == Notice.SWTICH_STAGE)
            {
                StopMusic();
            }

           if(director != null)
           {
               director.ReceiveNotice(notice);
           }
        }

        public void RegisterDirector(CDirector director)
        {
            this.director = director;
        }

        public virtual void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            foreach (ISprite actor in actorList)
            {
                actor.Update(gameTime);
            }
        }

        public virtual void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Microsoft.Xna.Framework.GameTime gameTime)
        {
            foreach (ISprite actor in actorList)
            {
                actor.Draw(spriteBatch, gameTime);
            }
        }

        public void PlayMusic(Song song, bool isRepeating=true)
        {
            MediaPlayer.IsRepeating = isRepeating;
            if (MediaPlayer.GameHasControl &&MediaPlayer.State != MediaState.Playing)
                MediaPlayer.Play(song);   
        }

        public void PauseMusic()
        {
            MediaPlayer.Pause();
        }

        public void StopMusic()
        {
            MediaPlayer.Stop();
        }
    }
}
