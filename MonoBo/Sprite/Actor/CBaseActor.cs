using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoBo.Sprite.Actor
{
    /// <summary>
    /// BaseActor class.
    /// </summary>
    public class CBaseActor : ISprite, IActor
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
        /// sprite is scale.
        /// </summary>
        protected bool isScale = false;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="texture">teture for drawing.</param>
        /// <param name="vector">position vector for drawing.</param>
        /// <param name="layerDepth">layer depth for drawing.</param>
        public CBaseActor(Texture2D texture, Vector2 vector, float layerDepth)
        {
            this.isRunning = true;
            this.timeSinceLastFrame = 0;
            this.layerDepth = layerDepth;
            this.texture = texture;
            this.drawPosition = vector;
            this.drawRect = new Rectangle(new Point(0, 0), new Point(texture.Width, texture.Height));
        }

        /// <summary>
        /// Constructor for scale draw.
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="positionVector"></param>
        /// <param name="scaleWidth"></param>
        /// <param name="scaleHeight"></param>
        /// <param name="layerDepth"></param>
        public CBaseActor(Texture2D texture, Vector2 positionVector, int scaleWidth, int scaleHeight, float layerDepth)
            : this(texture, positionVector, layerDepth)
        {
            this.isScale = true;
            this.drawRect = new Rectangle(new Point(0, 0), new Point(scaleWidth, scaleHeight));
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
        /// Animation start moving.  
        /// </summary>  
        public void Startup()
        {
            isRunning = true;
        }

        /// <summary>  
        /// Animation stop moving.  
        /// </summary>  
        public void Brake()
        {
            isRunning = false;
        }

        /// <summary>
        /// Actor draw.
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="gameTime"></param>
        public void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Microsoft.Xna.Framework.GameTime gameTime)
        {
            if (isScale)
            {
                spriteBatch.Draw(texture, drawRect, Color.White);
            }
            else
                spriteBatch.Draw(texture, drawPosition, drawRect, Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, layerDepth);

        }

        /// <summary>
        /// Actor change.
        /// </summary>
        /// <param name="gesture">gesture event.</param>
        /// <returns>true,event is not transfer.</returns>
        public virtual bool Change(Microsoft.Xna.Framework.Input.Touch.GestureSample gesture)
        {
            return false;
        }


        /// <summary>
        /// Actor change.
        /// </summary>
        /// <param name="pressedKeys">press keys.</param>
        /// <returns>true,event is not transfer.</returns>
        public virtual bool Change(Keys[] pressedKeys)
        {
            return false;
        }


        /// <summary>
        /// Actor update.
        /// </summary>
        /// <param name="gameTime"></param>
        public virtual void Update(GameTime gameTime)
        {

        }
    }
}
