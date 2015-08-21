using Microsoft.Xna.Framework.Input.Touch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TakeAWalk.Script;
using TakeAWalk.Stage;

namespace TakeAWalk
{
    /// <summary>
    /// class Director.
    /// It draw the stage which is created by one story script.
    /// </summary>
    public class CDirector  : ISprite
    {
        private CStage stage;

        public CDirector(IScript storyScript)
        {
            stage = storyScript.GetStage();
        }

        public void SwitchScript(IScript storyScript)
        {
            stage = storyScript.GetStage();
        }

        public void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            stage.Update(gameTime);
        }

        public void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Microsoft.Xna.Framework.GameTime gameTime)
        {
            stage.Draw(spriteBatch, gameTime);
        }
    }
}
