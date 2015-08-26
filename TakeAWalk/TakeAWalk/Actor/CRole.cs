using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TakeAWalk.Actor
{
    public class CRole:CAnimation
    {
        public CRole(string spriteName,Vector2 centerPosition,float layerDepth,float scale=1f):base(spriteName,centerPosition,layerDepth,scale)
        {

        }
    }
}
