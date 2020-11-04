using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template
{
    class Player : BaseClass
    {
        Vector2 velocity = Vector2.Zero;

        public Player(Texture2D texture, Vector2 playerPos, Point size)
        {
            this.texture = texture;
            position = playerPos;
            platform = new Rectangle(playerPos.ToPoint(), size);
        }
        public override void Update()
        {
            KeyboardState a = Keyboard.GetState();

            if (a.IsKeyDown(Keys.D))
                position.X += 10;
            if (a.IsKeyDown(Keys.A))
                position.X -= 10;
            if (a.IsKeyDown(Keys.Space))
                position.Y -= 5 ;

            velocity.Y += 9.81f * 1f / 60f;
            position.Y += velocity.Y;

            platform = new Rectangle(position.ToPoint(), platform.Size);
        }
        public void Collision()
        {
            velocity.Y = 0;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, platform, Color.Red);
        }
    }
}
