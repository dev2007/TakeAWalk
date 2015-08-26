using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TakeAWalk.Actor;

namespace TakeAWalk.Stage
{
    public class CStartStage:CStage
    {
        public CStartStage():base()
        {

        }

        protected override void InitActors()
        {
            CActor actorBack = new CActor(@"Images\officebackground", new Vector2(0, 0), Z_Axis.BACKGROUND);
            actorBack.SetDestinationRect(Global.WINDOW_WIDTH, Global.WINDOW_HEIGHT);
            HireActor(actorBack);

            CActor actorTitle = new CActor(@"Images\title", new Vector2(Global.WINDOW_WIDTH / 2 + 10, Global.WINDOW_HEIGHT /3 -100), Z_Axis.STAGE);
            HireActor(actorTitle);

            CActor actorOffice = new CActor(@"Images\office",
                new Vector2((Global.WINDOW_WIDTH - 20) / 2, (Global.WINDOW_HEIGHT - 20) / 2), Z_Axis.STAGE);
            HireActor(actorOffice);

            CAnimation actorMan = new CAnimation(@"Sprites\start",
                new Microsoft.Xna.Framework.Vector2(Global.WINDOW_WIDTH / 2 + 20, (Global.WINDOW_HEIGHT - 20) / 2 + 10),
                Z_Axis.ZERO);
            actorMan.SetFrameSplitCount(4);
            actorMan.SetFrame(100);
            HireActor(actorMan);

            //Song song = GetSong(@"Music\Sound_keyboard");
            PlayMusic(@"Music\Sound_keyboard");
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            if (Keyboard.GetState().GetPressedKeys().Length > 0)
            {
                ReceiveNotice(Notice.ACTION_FINISH);
            }
            else
                base.Update(gameTime);
        }
    }
}
