using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TakeAWalk.Actor
{
    /// <summary>
    /// Actor class.
    /// This is used for drawing common image.
    /// </summary>
    public class CActor : CBaseActor
    {

        public CActor(string spriteName, Vector2 centerPosition, float layerDepth, float scale = 1f)
            : base(spriteName, centerPosition, layerDepth, scale)
        {

        }

        /// <summary>
        /// draw function.
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="gameTime"></param>
        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Microsoft.Xna.Framework.GameTime gameTime)
        {
            spriteBatch.Draw(sprite, destinationRect, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, layerDepth);
        }
    }
}
