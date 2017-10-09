using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace game
{
    public abstract class Character : VisibleEntity
    {
        int hp;
        int mp;
        int stm;
        int damage;

        Unit sprite2d;

        public Character(Unit sprite2d, int hp=100, int mp=100, int stm =5) :base(sprite2d)
        {
            this.damage = 200;
            this.hp = hp;
            this.mp = mp;
            this.stm = stm;
            this.sprite2d = sprite2d;
        }

        public override void Draw(GameTime gameTime, object handler)
        {
            sprite2d.Draw(gameTime, handler);
        }

        public override void Update(GameTime gameTime)
        {
            sprite2d.Update(gameTime);
        }
    }
}
