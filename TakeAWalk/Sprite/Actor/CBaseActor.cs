using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TakeAWalk.Stage;
using TakeAWalk.Utils;

namespace TakeAWalk.Sprite.Actor
{
    /// <summary>
    /// base class of actor.b
    /// </summary>
    public class CBaseActor : ISprite, IActor
    {
        /// <summary>
        /// texture2d resource.
        /// </summary>
        protected Texture2D sprite;
        /// <summary>
        /// sprite center position.
        /// </summary>
        private Vector2 center;
        /// <summary>
        ///  layer depth.
        /// </summary>
        protected float layerDepth;
        /// <summary>
        ///  sprite scale value.
        /// </summary>
        protected float spriteScale;
        /// <summary>
        /// drawing rectangle,part of the image.
        /// </summary>
        protected Rectangle spriteDrawRect;
        /// <summary>
        /// destination drawing rectangle
        /// </summary>
        protected Rectangle destinationRect;
        /// <summary>
        /// animation running flag. 
        /// </summary>
        protected bool isRunning;
        /// <summary>
        /// stage contains this actor. 
        /// </summary>
        private CStage stage;

        public Rectangle SpriteBound
        {
            get
            {
                return sprite.Bounds;
            }
        }

        public CBaseActor(string spriteName, Vector2 centerPosition, float layerDepth,float scale=1f)
        {
            this.sprite = AppUtils.LoadContent(spriteName);
            this.center = centerPosition;
            this.layerDepth = layerDepth;

            this.spriteScale = scale;
            this.spriteDrawRect = new Rectangle(new Point(0, 0), new Point(sprite.Width, sprite.Height));
            this.destinationRect = new Rectangle((int)(center.X - spriteDrawRect.Width / 2), (int)(center.Y - spriteDrawRect.Height / 2),sprite.Width,sprite.Height);
            this.isRunning = true;
        }

        /// <summary>
        /// set the sprite's draw desitination rectangle.
        /// </summary>
        /// <param name="width">draw width</param>
        /// <param name="height">draw height</param>
        /// <param name="x">draw position for x axis.</param>
        /// <param name="y">draw position for y axis.</param>
        public void SetDestinationRect(int width,int height,int x=0,int y=0)
        {
            destinationRect = new Rectangle(x, y, width, height);
            center = new Vector2((width - x) / 2, (height - x) / 2);
        }

        public void SetCenter(int x,int y)
        {
            center = new Vector2(x, y);
            destinationRect = new Rectangle((int)(center.X - spriteDrawRect.Width / 2), (int)(center.Y - spriteDrawRect.Height / 2), sprite.Width, sprite.Height);
        }


        #region Actor running functions. 

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
        #endregion

        public virtual void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Microsoft.Xna.Framework.GameTime gameTime)
        {
            //spriteBatch.Draw(sprite, drawPosition, spriteDrawRect, maskColor, 0, Vector2.Zero, spriteScale, SpriteEffects.None, layerDepth);
            spriteBatch.Draw(sprite,
                new Vector2(center.X - spriteDrawRect.Width / 2, center.Y - spriteDrawRect.Height / 2),
                spriteDrawRect, Color.White,0, Vector2.Zero, spriteScale, SpriteEffects.None, layerDepth);
        }

        public virtual void Update(GameTime gameTime)
        {
        }

        #region  Register to stage & nofity functions.
        /// <summary>
        /// Register stage.
        /// </summary>
        /// <param name="stage"></param>
        public void RegisterStage(CStage stage)
        {
            this.stage = stage;
        }

        /// <summary>
        /// Unregister stage.
        /// </summary>
        /// <param name="stage"></param>
        public void UnRegisterStage(CStage stage)
        {
            this.stage = null;
        }


        /// <summary>
        /// notify the stage.
        /// </summary>
        /// <param name="notice"></param>
        public void NotifyStage(Notice notice)
        {
            if (stage != null)
            {
                stage.ReceiveNotice(notice);
            }
        }
        #endregion
    }
}
