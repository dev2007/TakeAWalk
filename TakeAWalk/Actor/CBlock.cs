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
    class CBlock : CActor
    {
        private Body body;
        private Vector2 blockOrigin;
        private Vector2 spriteRealRect;


        public CBlock(string spriteName, Vector2 centerPosition, float layerDepth, float scale = 1f)
            : base(spriteName, centerPosition, layerDepth, scale)
        {
            spriteRealRect.X = sprite.Width * spriteScale;
            spriteRealRect.Y = sprite.Height * spriteScale;
            Vector2 groundPosition = ConvertUnits.ToSimUnits(centerPosition);
            body = BodyFactory.CreateRectangle(PhysicWorld.World, ConvertUnits.ToSimUnits(spriteRealRect.X), 
                ConvertUnits.ToSimUnits(spriteRealRect.Y), 1f, groundPosition, 0, BodyType.Static);
            body.Restitution = 0.3f;
            body.Friction = 0.5f;
            blockOrigin = new Vector2(spriteRealRect.X / 2f, spriteRealRect.Y / 2f);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.D) || state.IsKeyDown(Keys.Right))
            {
            }

        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(sprite, ConvertUnits.ToDisplayUnits(body.Position), null, Color.White, 0f, blockOrigin, spriteScale, SpriteEffects.None, 0f);
        }
    }
}
