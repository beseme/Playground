using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;


namespace Playground
{
    class Asteroid : Game
    {
        private Vector2 position = Vector2.Zero;

        private float speed = 10;


        protected override void LoadContent()
        {

        }

        public Asteroid()
        {

        }

        public void UpdateAsteroid()
        {
            position.X -= speed;
        }
    }
}
