using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TakeAWalk.Actor;
using TakeAWalk.Utils;

namespace TakeAWalk.Stage
{
    /// <summary>
    /// stage basic class.
    /// </summary>
    public abstract class CStage : ISprite,INotice
    {
        /// <summary>
        /// actors' list.
        /// </summary>
        protected IList<IActor> actorList;
        /// <summary>
        /// director object.
        /// </summary>
        protected CDirector director;

        public CStage()
        {
            actorList = new List<IActor>();
            InitActors();
        }

        /// <summary>
        /// initialize actors on stage.
        /// </summary>
        protected abstract void InitActors();

        protected virtual void Startup()
        {

        }

        protected virtual void Brake()
        {
            StopMusic();
        }

        #region Actor functions
        /// <summary>
        /// add actor.
        /// </summary>
        /// <param name="actor"></param>
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

        /// <summary>
        /// remove actor.
        /// </summary>
        /// <param name="actor"></param>
        public void FireActor(IActor actor)
        {
            actorList.Remove(actor);
            actor.UnRegisterStage(this);
        }
        #endregion

        #region Notify & Register to Director.
        public void ReceiveNotice(Notice notice)
        {
           if(director != null)
           {
               director.ReceiveNotice(notice);
           }
        }

        public void RegisterDirector(CDirector director)
        {
            this.director = director;
            Startup();
        }

        public void UnRegisterDirector()
        {
            this.director = null;
            Brake();
        }
        #endregion

        #region Sprite update & draw.
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
        #endregion

        #region Music functions.
        /// <summary>
        /// play music.
        /// </summary>
        /// <param name="song"></param>
        /// <param name="isRepeating"></param>
        public void PlayMusic(Song song, bool isRepeating=true)
        {
            MediaPlayer.IsRepeating = isRepeating;
            if (MediaPlayer.GameHasControl &&MediaPlayer.State != MediaState.Playing)
                MediaPlayer.Play(song);   
        }

        public void PlayMusic(string songName,bool isRepeating=true)
        {
            MediaPlayer.IsRepeating = isRepeating;
            if (MediaPlayer.GameHasControl && MediaPlayer.State != MediaState.Playing)
                MediaPlayer.Play(AppUtils.LoadSong(songName));  
        }

        /// <summary>
        /// pause music.
        /// </summary>
        public void PauseMusic()
        {
            MediaPlayer.Pause();
        }

        /// <summary>
        /// stop music.
        /// </summary>
        public void StopMusic()
        {
            MediaPlayer.Stop();
        }
        #endregion
    }
}
