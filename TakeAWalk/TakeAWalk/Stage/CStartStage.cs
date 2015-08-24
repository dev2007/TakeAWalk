using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TakeAWalk.Stage
{
    public class CStartStage:CStage
    {
        public CStartStage():base()
        {

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
