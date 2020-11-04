using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template
{
 
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Platform platform;
        Player player;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Texture2D t = new Texture2D(GraphicsDevice, 1, 1);
            t.SetData(new Color[1] { Color.White });
            platform = new Platform(t, new Vector2(0, 400), new Point(600, 50));
            player = new Player(t, new Vector2(100, 100), new Point(15,15));
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState a = Keyboard.GetState();

            if (a.IsKeyDown(Keys.Escape))
                Exit();
            player.Update();
            if (player.Platform.Intersects(platform.Platform))
            {
                player.Collision();
                player.Position = new Vector2(player.Position.X,platform.Position.Y) - new Vector2(0,player.Platform.Height);
               
            }

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            platform.Draw(spriteBatch);
            player.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
