using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using MonoBo.Script;
using MonoBo.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoBo.Sprite
{
    /// <summary>  
    /// Director class.  
    /// Manage the stage which is created by one story script.  
    /// </summary>  
    public class CDirector : ISprite
    {
        protected ContentManager contentManager;
        protected CStage stage;
        protected IList<IScript> scriptList;
        protected int currentScriptIndex = 0;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="storyScript">the script for creating stage to display.</param>
        /// <param name="contentManager">content manager object.</param>
        public CDirector(IScript storyScript,ContentManager contentManager)
        {
            this.contentManager = contentManager;
            stage = storyScript.CreateStage();
            scriptList = new List<IScript>();
            scriptList.Add(storyScript);
        }

        /// <summary>
        /// Switch to other script.
        /// </summary>
        /// <param name="storyScript"></param>
        public void SwitchNextScript(IScript storyScript)
        {
            stage = storyScript.CreateStage();
            scriptList.Add(storyScript);
            currentScriptIndex++;
        }


        /// <summary>
        /// Stage change.
        /// </summary>
        /// <param name="gesture">gesture event.</param>
        /// <returns>true,event is transfer.</returns>
        public virtual bool Change(GestureSample gesture)
        {
            return stage.Change(gesture);
        }

        /// <summary>
        /// Stage  change.
        /// </summary>
        /// <param name="pressedKeys">press keyboard.</param>
        /// <returns>true,event is transfer.</returns>
        public virtual bool Change(Keys[] pressedKeys)
        {
            return stage.Change(pressedKeys);
        }

        /// <summary>
        /// Stage stage update.
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            stage.Update(gameTime);
        }

        /// <summary>
        /// Stage draw.
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="gameTime"></param>
        public void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Microsoft.Xna.Framework.GameTime gameTime)
        {
            stage.Draw(spriteBatch, gameTime);
        }
    }
}
