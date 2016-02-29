using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using MonoBo.Sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonoBo.Script
{
    /// <summary>
    /// Script base class.
    /// provide basic functions.
    /// </summary>
    public class CBaseScript : IScript
    {
        /// <summary>
        /// stage object.
        /// </summary>
        protected CStage stage;
        /// <summary>
        /// contentmanager object.
        /// </summary>
        protected ContentManager contentManager;

        public CBaseScript(ContentManager contentManager)
        {
            this.contentManager = contentManager;
            stage = new CStage();
            BuildScene();
        }

        /// <summary>
        /// Create stage scene.
        /// </summary>
        protected virtual void BuildScene()
        {

        }

        /// <summary>
        /// Get the stage object.
        /// </summary>
        /// <returns>CStage object.</returns>
        public virtual CStage CreateStage()
        {
            return stage;
        }

        /// <summary>
        /// Helper function for get Texture2D object.
        /// </summary>
        /// <param name="pathWithName">resource file name.</param>
        /// <returns>Texture2D object.</returns>
        protected Texture2D Get2D(string pathWithName)
        {
            return contentManager.Load<Texture2D>(pathWithName);
        }

        /// <summary>
        /// Helper function for get Song object.
        /// </summary>
        /// <param name="pathWithName">resource file name.</param>
        /// <returns>Song object.</returns>
        protected Song GetSong(string pathWithName)
        {
            return contentManager.Load<Song>(pathWithName);
        }
    }
}
