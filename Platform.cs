using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Template
{
    class Platform : BaseClass
    {
        public Platform(Texture2D texture, Vector2 platformPos, Point size)
        {
            this.texture = texture;
            position = platformPos;
            platform = new Rectangle(platformPos.ToPoint(),size);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, platform, Color.White);
        }
    }
}
