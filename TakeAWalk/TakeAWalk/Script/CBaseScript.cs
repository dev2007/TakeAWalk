using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
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
        private ContentManager contentManager;
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
        /// Tool function for get resource by the resource's name.
        /// </summary>
        /// <param name="pathWithName">resource's full path & name.</param>
        /// <returns></returns>
        protected Texture2D Get2D(string pathWithName)
        {
            return contentManager.Load<Texture2D>(pathWithName);
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
