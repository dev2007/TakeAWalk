using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TakeAWalk.Stage;

namespace TakeAWalk.Script
{
    /// <summary>
    /// Interface for story script.
    /// It creates a stage which contains some actors for director.
    /// </summary>
    public interface IScript
    {
        CStage CreateStage();
    }
}
