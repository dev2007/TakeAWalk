using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TakeAWalk.Stage;

namespace TakeAWalk.Script
{
    /// <summary>
    /// Base script class.
    /// Provide base functions for subclass.
    /// </summary>
    public class CBaseScript : IScript
    {
        /// <summary>
        /// Stage for draw.
        /// </summary>
        protected CStage stage;
        /// <summary>
        /// Contentmanager for get resources.
        /// </summary>
        protected ContentManager contentManager;
        /// <summary>
        /// Constructor.
        /// Initialize contentmanager & create one default CStage object.
        /// </summary>
        /// <param name="contentManager"></param>
        public CBaseScript(ContentManager contentManager)
        {
            this.contentManager = contentManager;
            this.stage = new CStage();
        }

        /// <summary>
        /// Tool function for getting Texture2D resource by the resource's name.
        /// </summary>
        /// <param name="pathWithName">resource's full path & name.</param>
        /// <returns></returns>
        protected Texture2D Get2D(string pathWithName)
        {
            return contentManager.Load<Texture2D>(pathWithName);
        }

        /// <summary>
        /// Tool function for getting music resource by the rerource's name.
        /// </summary>
        /// <param name="pathWithName"></param>
        /// <returns></returns>
        protected Song GetSong(string pathWithName)
        {
            return contentManager.Load<Song>(pathWithName);
        }

        /// <summary>
        /// Return the Stage object created by the script.
        /// </summary>
        /// <returns>CStage object.</returns>
        public CStage GetStage()
        {
            CreateStage();
            return stage;
        }

        /// <summary>
        /// Virtual function that needed implement by subclass.
        /// We add actors and others' resources into stage.
        /// </summary>
        protected virtual void CreateStage()
        {
        }
    }
}
