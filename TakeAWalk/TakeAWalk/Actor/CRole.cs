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

namespace TakeAWalk.Actor
{
    public class CRole : CAnimation
    {
        private Body body;

        private Vector2 _groundOrigin;

        public CRole(string spriteName, Vector2 centerPosition,int splitCount, float layerDepth, float scale = 1f)
            : base(spriteName, centerPosition, layerDepth, scale)
        {
            SetFrameSplitCount(splitCount);
            Vector2 groundPosition = ConvertUnits.ToSimUnits(centerPosition) + new Vector2(0, 1.25f);
            body = BodyFactory.CreateRectangle(PhysicWorld.World, ConvertUnits.ToSimUnits(frameWidthSize), ConvertUnits.ToSimUnits(frameWidthSize), 1f, groundPosition, 0, BodyType.Dynamic);
            body.Restitution = 0.3f;
            body.Friction = 0.5f;

            _groundOrigin = new Vector2(frameWidthSize / 2f, frameWidthSize / 2f);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.D))
                body.ApplyLinearImpulse(new Vector2(1, 0));
            if(state.IsKeyDown(Keys.A))
                body.ApplyLinearImpulse(new Vector2(-1, 0));
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(sprite, ConvertUnits.ToDisplayUnits(body.Position), spriteDrawRect, Color.White, 0f, _groundOrigin, spriteScale, SpriteEffects.None, 0f);
        }
    }
}
