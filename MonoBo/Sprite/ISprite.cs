using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoBo.Sprite
{
    /// <summary>
    /// Sprite interface.
    /// </summary>
    public interface ISprite
    {
        /// <summary>
        /// state change.
        /// </summary>
        /// <param name="gesture">gesture event.</param>
        /// /// <returns>true,event is not transfer.</returns>
        bool Change(GestureSample gesture);

        /// <summary>
        /// state change.
        /// </summary>
        /// <param name="pressdKeys">press keyboard.</param>
        /// <returns>true,event is not transfer.</returns>
        bool Change(Keys[] pressdKeys);

        /// <summary>
        /// stage update.
        /// </summary>
        /// <param name="gameTime"></param>
        void Update(GameTime gameTime);

        /// <summary>
        /// stage draw.
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="gameTime"></param>
        void Draw(SpriteBatch spriteBatch, GameTime gameTime);
    }
}
