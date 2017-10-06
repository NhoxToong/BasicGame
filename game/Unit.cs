using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    class Unit : VisibleEntity
    {
        public Texture2D Texture { get; set; }

        public int Rows { get; set; }

        public int Column { get; set; }

        private int currentFrame;

        private int totalFrame;

        /*public MoveUnit(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Column = columns;
            currentFrame = 0;
            totalFrame = Rows * Column;
        }*/

        public void Update(GameTime gameTime)
        {

        }
    }
}
