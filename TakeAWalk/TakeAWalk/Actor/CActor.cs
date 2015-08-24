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
    public class CActor:CBaseActor
    {
        
        public CActor(Texture2D texture, Vector2 drawPosition, float layerDepth)
            : base(texture, drawPosition, layerDepth)
        {
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Microsoft.Xna.Framework.GameTime gameTime)
        {
            spriteBatch.Draw(texture, drawPosition, drawRect, Color.White, 0, Vector2.Zero, textureScale, SpriteEffects.None, layerDepth);
            //spriteBatch.Draw(texture, destinationRectangle, Color.White);
            //spriteBatch.Draw(texture,destinationRectangle, null, maskColor, 0f, Vector2.Zero, SpriteEffects.None, layerDepth);
        }

        public void SetDrawRect(int drawWidth,int drawHeight,Vector2? newDrawPosition = null)
        {
            if (newDrawPosition != null)
                drawPosition = newDrawPosition.Value;
            ObjectRect = new Rectangle((int)drawPosition.X, (int)drawPosition.Y, drawWidth, drawHeight);
        }
    }
}
