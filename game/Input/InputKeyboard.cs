using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game.Input
{
    internal class InputKeyboard : input
    {
        private KeyboardState keyboardState;
        private KeyboardState lastKeyboardState;
        private Keys lastKey;
        protected override void CheckInput(double gameTime)
        {
            keyboardState = Keyboard.GetState();
            if(keyboardState.IsKeyUp(lastKey) && lastKey != Keys.None)
            {
                SendNewInput(GameInput.None);
            }

            CheckKeyState(Keys.Right, GameInput.Right);

            lastKeyboardState = keyboardState;
        }

        private void CheckKeyState(Keys key, GameInput sendGameInput)
        {
            if (keyboardState.IsKeyDown(key))
            {
                SendNewInput(sendGameInput);
                lastKey = key;
            }
        }
    }
}
