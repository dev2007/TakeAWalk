using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        /// <param name="gesture"></param>
        void Change(GestureSample gesture);

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
