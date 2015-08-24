using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TakeAWalk.Actor
{
    public class CBlock:CActor
    {
        private int moveVelocity;
        private int moveFrameCount;
        public Rectangle NextRect
        {
            get
            {
                return new Rectangle(ObjectRect.X - moveVelocity,ObjectRect.Y,ObjectRect.Width, ObjectRect.Height);
            }
        }
        public CBlock(Texture2D texture, Vector2 drawPosition, float layerDepth)
            : base(texture, drawPosition, layerDepth)
        {
            moveVelocity = 2;
            moveFrameCount = Global.MILLISECONDS_PER_FRAME;
            textureScale = 0.5f;
        }

        public override void Update(GameTime gameTime)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if(timeSinceLastFrame > moveFrameCount)
            {
                timeSinceLastFrame -= moveFrameCount;
                Input();
            }

        }

        /// <summary>
        /// set move velocity.
        /// </summary>
        /// <param name="velocity"></param>
        public void SetVelocity(int velocity)
        {
            this.moveVelocity = velocity;
        }

        private void Input()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
            if(pressedKeys.Contains(Keys.Right))
            {
                SetDrawRect(texture.Width, texture.Height, new Vector2(drawPosition.X - moveVelocity, drawPosition.Y));
            }
            else if(pressedKeys.Contains(Keys.Left))
            {
                SetDrawRect(texture.Width, texture.Height, new Vector2(drawPosition.X + moveVelocity, drawPosition.Y));
            }
        }
    }
}
