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
        bool jump = false;
        bool doubleJump = false;
        int jumpTime;
        int doubleJumpTime;

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
                position.X += 3;
            if (a.IsKeyDown(Keys.A))
                position.X -= 3;
            if (a.IsKeyDown(Keys.Space) && jump == true && jumpTime > 0)
            {
                velocity.Y = -3;
                jumpTime --;
            }

            if (a.IsKeyUp(Keys.Space) && jumpTime != 20)
                jump = false;

            if (a.IsKeyDown(Keys.Space) && jump == false && doubleJump == true && doubleJumpTime > 0)
            {
                velocity.Y = -3;
                doubleJumpTime--;
            }

            if (a.IsKeyUp(Keys.Space) && doubleJumpTime != 20)
                jump = false;

            velocity.Y += 9.81f * 1f / 60f;
            position.Y += velocity.Y;

            platform = new Rectangle(position.ToPoint(), platform.Size);
        }
        public void Collision()
        {
            velocity.Y = 0;
            jump = true;
            doubleJump = true;
            jumpTime = 20;
            doubleJumpTime = 20;
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, platform, Color.Red);
        }
    }
}
