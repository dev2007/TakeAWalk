using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TakeAWalk
{
    /// <summary>
    /// Interface of Sprite.
    /// Classe must inherit it which needs Draw & Update functions.
    /// </summary>
    public interface ISprite
    {
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch,GameTime gameTime);
    }
}
