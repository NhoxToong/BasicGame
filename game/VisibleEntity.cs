using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    public class VisibleEntity : GameEntity
    {
        Unit _model;

        public VisibleEntity(Unit model)
        {
            this._model = model;
        }

        public void Update(GameTime gameTime, float X, float Y)
        {
            base.Update(gameTime);
            _model.Update(gameTime,X,Y);
        }

        public virtual void Draw(GameTime gameTime, object handler)
        {
            _model.Draw(gameTime, handler);
        }


    }
}
