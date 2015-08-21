using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TakeAWalk.Actor
{
    public class CBaseActor:ISprite,IActor
    {
        /// <summary>
        /// texture2d resource.
        /// </summary>
        protected Texture2D texture;
        /// <summary>
        /// draw position.
        /// </summary>
        protected Vector2 drawPosition;
        /// <summary>
        /// drawing rectangle,part of the image.
        /// </summary>
        protected Rectangle drawRect;
        /// <summary>
        /// layer depth.
        /// </summary>
        protected float layerDepth;
        /// <summary>
        /// count frame time.
        /// </summary>
        protected int timeSinceLastFrame;
        /// <summary>
        /// animation running flag. 
        /// </summary>
        protected bool isRunning;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="texture">Texture2D resource.It is a image which is consist of sequent frame images.</param>
        /// <param name="drawPosition">Draw postion.</param>
        /// <param name="layerDepth">Layer Depth.</param>
        public CBaseActor(Texture2D texture, Vector2 drawPosition, float layerDepth)
        {
            this.isRunning = true;
            this.timeSinceLastFrame = 0;
            this.layerDepth = layerDepth;
            this.texture = texture;
            this.drawPosition = drawPosition; 
            this.drawRect = new Rectangle(new Point(0, 0), new Point(texture.Width, texture.Height));
        }

        /// <summary>
        ///  Set the animation on the new position.
        /// </summary>
        /// <param name="newPosition"></param>
        public void SetDrawVector(Vector2 newPosition)
        {
            this.drawPosition = newPosition;
        }

        /// <summary>
        /// Animation move.
        /// </summary>
        public void Startup()
        {
            isRunning = true;
        }

        /// <summary>
        /// Animation stop.
        /// </summary>
        public void Brake()
        {
            isRunning = false;
        }

        public virtual void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Microsoft.Xna.Framework.GameTime gameTime)
        {
            spriteBatch.Draw(texture, drawPosition,drawRect, Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, layerDepth);
        }

        public virtual void Update(GameTime gameTime)
        {
        }
    }
}
