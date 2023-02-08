using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BoxBattle
{
    public class BoxBattle : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Rectangle Player1;
        private Rectangle Player2;

        public Texture2D Texture;

        private const int speed = 5;

        public BoxBattle()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            if (Texture == null)
            {   //create texture to draw with if it does not exist
                Texture = new Texture2D(_graphics.GraphicsDevice, 1, 1);
                Texture.SetData<Color>(new Color[] { Color.White });
            }

            Player1 = new Rectangle(50, 150, 20, 20);
            Player2 = new Rectangle(730, 150, 20, 20);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.W))
            {
                Player1.Y -= speed;
            }
            if (GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.S))   
            {
                Player1.Y += speed;
            }
            if (GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.D))
            {
                Player1.X += speed;
            }
            if (GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.A))
            {
                Player1.X -= speed;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                Player2.Y -= speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                Player2.Y += speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                Player2.X += speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                Player2.X -= speed;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp);

            DrawRectangle(_spriteBatch, Player1, Color.White);
            DrawRectangle(_spriteBatch, Player2, Color.Black);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        private void DrawRectangle(SpriteBatch sb, Rectangle Rec, Color color)
        {
            Vector2 pos = new Vector2(Rec.X, Rec.Y);
            sb.Draw(Texture, pos, Rec,
                color * 1.0f,
                0, Vector2.Zero, 1.0f,
                SpriteEffects.None, 0.00001f);
        }
    }
}