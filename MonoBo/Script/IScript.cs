using MonoBo.Sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoBo.Script
{
    /// <summary>
    /// Script interface.
    /// </summary>
    public interface IScript
    {
        /// <summary>
        /// create stage.
        /// </summary>
        /// <returns></returns>
        CStage CreateStage();
    }
}
