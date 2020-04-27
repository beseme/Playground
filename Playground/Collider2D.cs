using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace Playground
{
    class Collider2D : Game
    {

        Vector2[] corners = new Vector2[4];

        public Collider2D(Vector2 tl, Vector2 tr, Vector2 bl, Vector2 br)
        {
            corners[0] = tl;
            corners[1] = tr;
            corners[2] = bl;
            corners[3] = br;
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);


        }


        private void CollisionCheck()
        {

        }
    }
}
