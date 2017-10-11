using game.EventArg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game.Input
{
    internal abstract class input
    {
        private event EventHandler<NewInputEventArgs> newInput;
        private double counter;
        private double cooldown;

        public event EventHandler<NewInputEventArgs> NewInput
        {
            add { newInput += value; }
            remove { newInput -= value; }
        }

        protected input()
        {
            counter = 0;
            cooldown = 0;
        }

        public void Update(double gameTime)
        {
            if(cooldown > 0)
            {
                counter += gameTime;
                if (counter > gameTime)
                {
                    counter = 0;
                    cooldown = 0;
                }
                else return;
            }

            CheckInput(gameTime);
        }

        protected abstract void CheckInput(double gameTime);

        protected void SendNewInput(GameInput gameInput)
        {
            newInput?.Invoke(this, new NewInputEventArgs(gameInput));
        }
    }
}
