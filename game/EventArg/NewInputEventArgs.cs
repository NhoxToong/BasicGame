using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game.EventArg
{
    internal class NewInputEventArgs : EventArgs
    {
        public GameInput GameInput { get; set; }
        public NewInputEventArgs(GameInput gameInput)
        {
            GameInput = gameInput;
        }

    }
}
