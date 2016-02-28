using Microsoft.Xna.Framework.Input.Touch;
using MonoBo.Script;
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
        private CStage stage;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="storyScript">the script for creating stage to display.</param>
        public CDirector(IScript storyScript)
        {
            stage = storyScript.CreateStage();
        }

        /// <summary>
        /// Switch to other script.
        /// </summary>
        /// <param name="storyScript"></param>
        public void SwitchScript(IScript storyScript)
        {
            stage = storyScript.CreateStage();
        }

        /// <summary>
        /// Stage stage change.
        /// </summary>
        /// <param name="gesture"></param>
        public void Change(GestureSample gesture)
        {
            stage.Change(gesture);
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
