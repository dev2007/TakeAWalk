using FarseerPhysics;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TakeAWalk.Actor
{
    class CBlock : CActor
    {
        private Body body;

        private Vector2 _groundOrigin;

        public CBlock(string spriteName, Vector2 centerPosition, float layerDepth, float scale = 1f)
            : base(spriteName, centerPosition, layerDepth, scale)
        {
            Vector2 groundPosition = ConvertUnits.ToSimUnits(centerPosition) + new Vector2(0, 1.25f);
            body = BodyFactory.CreateRectangle(PhysicWorld.World, ConvertUnits.ToSimUnits(sprite.Width), ConvertUnits.ToSimUnits(sprite.Height), 1f, groundPosition);
            body.IsStatic = true;
            body.Restitution = 0.3f;
            body.Friction = 0.5f;
            _groundOrigin = new Vector2(sprite.Width / 2f, sprite.Height / 2f);
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(sprite, ConvertUnits.ToDisplayUnits(body.Position), null, Color.White, 0f, _groundOrigin, spriteScale, SpriteEffects.None, 0f);
        }
    }
}
