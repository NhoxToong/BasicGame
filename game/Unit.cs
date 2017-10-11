using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    public class Unit : AbstractModel
    {
        private float _left;
        private float _top;
        private float _width;
        private float _height;
        private int nCount;
        private IList<Texture2D> _texture;

        public int XTilePos { get; set; }
        public int YTilePos { get; set; }

        private int wantedX;
        private int wantedY;

        public bool TransitionOn { get; set; }

        int state = 0;
        int idx;
        public Unit(IList<Texture2D> texture, float left, float top)
        {
            idx = 0;
            _left = left;
            _top = top;
            this.Texture = texture;
        }

        public override void Update(GameTime gameTime, float X, float Y)
        {
            idx = (idx + 1)%nCount;
            _left = X;
            _top = Y;
        }

        /*public void Update()
        {
            if (!TransitionOn)
                return;

            //UpdateTransition();
        }*/

       /* private void UpdateTransition()
        {
            if (wantedX < XTilePos)
            {
                pos.X -= 1;
                if ((pos.X - wantedX * width) == 0)
                {
                    XTilePos--;
                }
            }
            else if (wantedX > XTilePos)
            {
                pos.X -= 1;
                if ((pos.X - wantedX * width) == 0)
                {
                    XTilePos++;
                }
            }
            else if (wantedY < YTilePos)
            {
                pos.Y -= 1;
                if ((pos.Y - wantedY * height) == 0)
                {
                    YTilePos--;
                }
            }
            else if (wantedY > YTilePos)
            {
                pos.Y += 1;
                if ((pos.Y - wantedY * height) == 0)
                {
                    YTilePos++;
                }
            }
            else TransitionOn = false;
        }*/


        public override void Draw(GameTime gameTime, object handler)
        {
            SpriteBatch spriteBatch = handler as SpriteBatch;
            if(state == 1)
                spriteBatch.Draw(_texture[idx], new Vector2(_left,_top), Color.Yellow);
            else
                spriteBatch.Draw(_texture[idx], new Vector2(_left, _top), Color.White);

        }
        


        #region properties
        public float width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }
        public float left
        {
            get
            {
                return _left;
            }
            set
            {
                _left = value;
            }
        }
        public float top
        {
            get
            {
                return _top;
            }
            set
            {
                _top = value;
            }
        }
        public float height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }
        public IList<Texture2D> Texture
        {
            get
            {
                return _texture;
            }
            set
            {
                _texture = value;
                if (_texture == null)
                    throw new Exception("texture cannot be null");
                _width = _texture[0].Width;
                _height = _texture[0].Height;
                nCount = _texture.Count;
            }
        }
        #endregion
    }
}
