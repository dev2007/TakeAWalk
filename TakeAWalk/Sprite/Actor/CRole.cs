using FarseerPhysics;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TakeAWalk.Utils;

namespace TakeAWalk.Sprite.Actor
{
    public class CRole : CAnimation
    {
        private Body body;
        private Vector2 _groundOrigin;
        private Keys lastKey = Keys.None;
        private int doubleJump = 0;
        private MoveDirect moveDirect = MoveDirect.HOLD;
        private Dictionary<MoveDirect, Texture2D> spriteList;
        public Vector2 BasicVelocity { get; private set; }

        public CRole(string spriteName, Vector2 centerPosition, int splitCount, Vector2 basicVelocity, float layerDepth, float scale = 1f)
            : base(spriteName, centerPosition, layerDepth, scale)
        {
            spriteList = new Dictionary<MoveDirect, Texture2D>();
            //SetFrameSplitCount(splitCount);
            Vector2 groundPosition = ConvertUnits.ToSimUnits(centerPosition);
            body = BodyFactory.CreateRectangle(PhysicWorld.World, ConvertUnits.ToSimUnits(frameWidthSize), ConvertUnits.ToSimUnits(frameWidthSize), 1f, groundPosition, 0, BodyType.Dynamic);
            body.Restitution = 0.3f;
            body.Friction = 0.5f;
            _groundOrigin = new Vector2(frameWidthSize / 2f, frameWidthSize / 2f);
            this.BasicVelocity = basicVelocity;
        }

        public void Add(MoveDirect direct, string spriteName)
        {
            spriteList.Add(direct, AppUtils.LoadContent(spriteName));
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Right))
            {
                if (ValueCloseToZero(body.LinearVelocity.Y))
                {
                    moveDirect = MoveDirect.RIGHT;
                }
                lastKey = Keys.Right;
                body.LinearVelocity = new Vector2(BasicVelocity.X, body.LinearVelocity.Y);
                NotifyStage(Notice.PLAY_MUSIC);
            }
            if (state.IsKeyDown(Keys.Up))
            {
                moveDirect = MoveDirect.UP;
                //body.ApplyLinearImpulse(new Vector2(0, -1));
                if (ValueCloseToZero(body.LinearVelocity.Y) && doubleJump <2)
                {
                    body.ApplyLinearImpulse(new Vector2(0, -10)); 
                    doubleJump++;
                }
            }

            if (state.IsKeyUp(Keys.Right)
                && ValueCloseToZero(body.LinearVelocity.Y))
            {
                moveDirect = MoveDirect.HOLD;
                body.LinearVelocity = Vector2.Zero;
                NotifyStage(Notice.PAUSE_MUSIC);
                lastKey = Keys.None;
            }

            if(state.IsKeyUp(Keys.Up))
            {
                doubleJump = 0;
            }

            sprite = spriteList[moveDirect];
        }

        private bool ValueCloseToZero(float value)
        {
            return value >= -0.1 && value <= 0.1;
        }

        private bool ContainsKeys(Keys key)
        {
            return key == Keys.Up || key == Keys.Right;
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(sprite, ConvertUnits.ToDisplayUnits(body.Position), spriteDrawRect, Color.White, 0f, _groundOrigin, spriteScale, SpriteEffects.None, 0f);
        }
    }
}
