using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    public class Unit : VisibleEntity
    {
        private float _left;
        private float _top;
        private float _width;
        private float _height;
        private int nCount;
        private IList<Texture2D> _texture;

        int idx;
        public Unit(IList<Texture2D> texture, float left, float top)
        {
            idx = 0;
            _left = left;
            _top = top;
            this.Texture = texture;
        }

        public virtual void Update(GameTime gameTime)
        {
            idx = (idx + 1)%nCount;
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch handler)
        {
            handler.Draw(_texture[idx], new Vector2(_left, _top), Color.White);
        }

        #region properties
        public float Left
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
