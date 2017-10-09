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
        AbstractModel _model;

        public VisibleEntity(AbstractModel model)
        {
            this._model = model;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            _model.Update(gameTime);
        }

        public virtual void Draw(GameTime gameTime, object handler)
        {
            _model.Draw(gameTime, handler);
        }
    }
}
