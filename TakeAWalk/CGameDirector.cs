using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using MonoBo.Script;
using MonoBo.Sprite;
using MonoBo.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TakeAWalk.Script;

namespace TakeAWalk
{
    public class CGameDirector : CDirector
    {
        public CGameDirector(IScript storyScript,ContentManager contentManager):base(storyScript,contentManager)
        {

        }

        public override bool Change(Keys[] pressedKey)
        {
            if (this.currentScriptIndex == 0 && Helper.KeyPressed(Keys.Space))
                this.SwitchNextScript(new CFirstScript(contentManager));
            return base.Change(pressedKey);
        }
    }
}
