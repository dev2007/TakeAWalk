using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TakeAWalk.Sprite;
using TakeAWalk.Sprite.Actor;

namespace TakeAWalk.Stage
{
    public class CCityStage : CStage
    {
        public CCityStage():base()
        {

        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            foreach (ISprite actor in actorList)
            {
                actor.Update(gameTime);
            }
        }

        protected override void InitActors()
        {
            CRole role = new CRole(@"Sprites\walk", new Vector2(Global.WINDOW_WIDTH / 2, 0),7,new Vector2(0,0),Z_Axis.STAGE);
            HireActor(role);
            role.Add(MoveDirect.HOLD, @"Sprites\wait");
            role.Add(MoveDirect.RIGHT, @"Sprites\walk");
            role.Add(MoveDirect.UP, @"Sprites\jump");
            CBlock block = new CBlock(@"Blocks\box_2", new Vector2(Global.WINDOW_WIDTH / 2, Global.WINDOW_HEIGHT / 2), Z_Axis.STAGE, 1f);
            HireActor(block);
        }
    }
}
