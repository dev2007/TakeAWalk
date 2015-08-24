using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TakeAWalk.Actor
{
    public class CRole : CAnimation
    {
        private Dictionary<RoleDirect, Texture2D> roleTextureList;
        private RoleDirect currentDirect;
        private bool isJump;
        private float jumpVelocity;
        private double gravity;
        private double jumpTime;
        private Vector2 sourcePosition;
        private int walkFrameCount;
        private int jumpFramCount;

        public CRole(Texture2D texture, Vector2 vector, float layerDepth)
            : base(texture, vector, layerDepth)
        {
            roleTextureList = new Dictionary<RoleDirect, Texture2D>();
            roleTextureList.Add(RoleDirect.HOLDON, texture);
            this.currentDirect = RoleDirect.HOLDON;
            jumpVelocity = 30f;
            gravity = -9.8f;
            sourcePosition = drawPosition;
            walkFrameCount = Global.MILLISECONDS_PER_FRAME;
            jumpFramCount = Global.MILLISECONDS_PER_FRAME;
        }

        public void AddTexture(Texture2D texture, RoleDirect direct)
        {
            roleTextureList.Add(direct, texture);
        }

        public void SetFrameCount(int frameCount=0,int walkFrameCount=0)
        {
            if (jumpFramCount != 0)
                this.jumpFramCount = frameCount;
            if (walkFrameCount != 0)
                this.walkFrameCount = walkFrameCount;
        }

        private void SwitchHold()
        {
            if (currentDirect != RoleDirect.HOLDON)
            {
                frameCount = Global.MILLISECONDS_PER_FRAME;
                this.currentDirect = RoleDirect.HOLDON;
                texture = roleTextureList[currentDirect];
            }
        }

        private void SwitchForward()
        {
            if (currentDirect != RoleDirect.FORWARD)
            {
                frameCount = walkFrameCount;
                this.currentDirect = RoleDirect.FORWARD;
                texture = roleTextureList[currentDirect];
            }
        }

        private void SwichUp()
        {
            if (currentDirect != RoleDirect.UP)
            {
                frameCount = jumpFramCount;
                this.currentDirect = RoleDirect.UP;
                texture = roleTextureList[currentDirect];
            }
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            Input();
            if (!isRunning)
            {
                frameIndex = 0;
            }
            else if (timeSinceLastFrame > frameCount)
            {
                timeSinceLastFrame -= frameCount;
                frameIndex++;
                if (frameIndex >= texture.Width / frameWidthSize)
                    frameIndex = 0;

                if (isJump)
                {
                    jumpTime += 1;
                    drawPosition.Y = sourcePosition.Y - (float)(jumpVelocity * jumpTime + 0.5*gravity * Math.Pow(jumpTime,2.0));
                    ObjectRect = new Rectangle((int)drawPosition.X, (int)drawPosition.Y, texture.Width, texture.Height);
                    if (drawPosition.Y >= sourcePosition.Y)
                    {
                        isJump = false;
                        jumpTime = 0;
                        drawPosition = sourcePosition;
                    }
                }
            }
            drawRect = new Rectangle(frameIndex * frameWidthSize, 0, frameWidthSize, texture.Height);
        }

        private void Input()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
            if (pressedKeys.Contains(Keys.Right))
            {
                SwitchForward();
            }

            //if (pressedKeys.Contains(Keys.Left))
            //{
            //    SwitchForward();
            //}
            
            if(pressedKeys.Contains(Keys.Up))
            {
                isJump = true;
                SwichUp();
            }
            
            if (Keyboard.GetState().IsKeyUp(Keys.Left) 
                && Keyboard.GetState().IsKeyUp(Keys.Right) 
                && (Keyboard.GetState().IsKeyUp(Keys.Up) && !isJump))
            {
                SwitchHold();
            }
        }
    }

    public enum RoleDirect
    {
        HOLDON = 0,
        FORWARD = 1,
        UP = 2
    }
}
