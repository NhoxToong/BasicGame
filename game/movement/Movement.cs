using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game.movement
{
    class Movement
    {
        private Unit _sprite;
        private bool _transitionOn;
        private int wantedX;
        private int wantedY;
        private int speed;

        public Movement(Unit sprite)
        {
            _sprite = sprite;
        }

        public void move(int x, int y)
        {
            if (_sprite.XTilePos == x && _sprite.YTilePos == y)
                return;
            wantedX = x;
            wantedY = y;
            _transitionOn = true;
        }

        public void Update()
        {
            if (!_transitionOn)
                return;
            UpdateTransition();
        }

        private void UpdateTransition()
        {
            if (_sprite.TransitionOn)
                return;
            if(_sprite.XTilePos < wantedX)
            {
                _sprite.Move(1, 0);
            }
            else if (_sprite.XTilePos > wantedX)
            {
                _sprite.Move(-1, 0);
            }
            else if (_sprite.YTilePos < wantedY)
            {
                _sprite.Move(0, 1);
            }
            else if (_sprite.YTilePos > wantedY)
            {
                _sprite.Move(0, -1);
            }

            if(_sprite.XTilePos == wantedX && _sprite.YTilePos == wantedY)
            {
                _transitionOn = false;
            }
        }
    }
}
