using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonoBo.Utils
{
    public class Helper
    {
        public static bool ContainKey(Keys[] pressedKeys,Keys targetKey)
        {
            foreach(Keys key in pressedKeys)
            {
                if (targetKey == key)
                    return true;
            }

            return false;
        }

        public static bool KeyPressed(Keys key)
        {
            return Keyboard.GetState().IsKeyDown(key);
        }
    }
}
