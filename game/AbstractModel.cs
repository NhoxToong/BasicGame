using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    public abstract class AbstractModel
    {
        public abstract void Update(GameTime gameTime, float X, float Y);
        public abstract void Draw(GameTime gameTime, object handler);
    }
}
