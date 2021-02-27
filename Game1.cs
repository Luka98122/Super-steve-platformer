using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Super_steve_platformer
{
    public class Game1 : Game
    {
        Texture2D knight;
        Texture2D grassFloor;  

        public static float playerX = 0;
        public static float playerY = 0;
        public static float playerDdy = 1;
        public static float playerDy = 0;
        List<Platform> ListOfPlatforms = new List<Platform>();

        public Platform floor = new Platform();
        public Platform test = new Platform();

        Map map = new Map();
        

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public bool onPlatform()
        {
            for(int i = 0; i < ListOfPlatforms.Count; i++)
            {
                if (playerY <= ListOfPlatforms[i].y && playerY > ListOfPlatforms[i].y-10)
                {
                    playerY = 50;
                    return true;
                }
            }
            return false;
        }

        public void playerInPlatform (int platformX, int platformY, int platformWidth, int platformHeight)
        {
            if(playerX > platformX && playerX < platformX + platformWidth && playerY > platformY && playerY < platformY + platformHeight)
            {
                playerY = platformY;
                playerDy = 0;
            }
        }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {

            //TODO: Add your initialization logic here
            floor.initialize(-200, 220 , 1000, 300);
            //test.initialize(0, 120, 300, 20);
            ListOfPlatforms.Add(floor);
            ListOfPlatforms.Add(test);
            map.initialize();
            map.load("..//..//..//Level1.txt");
            map.save("Map.txt");

            base.Initialize();
        }

        public int playerPlatformDetection (int platformY, int platformHeight, int platformX, int platformWidth)
        {
            for (int i = 0; i<playerY + playerDy;i++)
            {
                if( playerY + playerDy > platformY && playerX > platformX && playerX < platformX + platformWidth)
                {
                    return 1;
                }
            }
            return 0;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            knight = Content.Load<Texture2D>("KnightForPlatformerTake2");
            grassFloor = Content.Load<Texture2D>("Grass floor2");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            var kState = Keyboard.GetState();
            if (kState.IsKeyDown(Keys.Right) == true)
            {
                playerX = playerX + 3;
            }
            if (kState.IsKeyDown(Keys.Left) == true)
            {
                playerX = playerX - 3;
            }
            
            if (kState.IsKeyDown(Keys.Up))
            {
                for (int i = 0; i < ListOfPlatforms.Count; i++)
                {
                    if (onPlatform() == true)
                    {
                        playerDy = -10;
                        
                    }
                    
                }
                
            }
            
            if (onPlatform() == false)
            {
                for (int i = 0; i < ListOfPlatforms.Count; i++) {
                    int nextStep = playerPlatformDetection(ListOfPlatforms[i].y, ListOfPlatforms[i].height, ListOfPlatforms[i].x, ListOfPlatforms[i].width);
                    if (nextStep == 0)
                        playerY = playerY + playerDy;
                    else
                    {
                        break;
                    }
                }
                playerDy = playerDy + playerDdy;
            }
            
            if(onPlatform() == true)
            {
                playerDy = 1;
            }

            for (int i = 0; i < ListOfPlatforms.Count;i++)
            {
                playerInPlatform(ListOfPlatforms[i].x, ListOfPlatforms[i].y, ListOfPlatforms[i].width, ListOfPlatforms[i].height);
            }

            if (kState.IsKeyDown(Keys.Down) == true)
            {
                playerY = playerY + 3;
            }
            for (int i = 0; i < ListOfPlatforms.Count; i++)
            {
                ListOfPlatforms[i].update();
            }
            //test.update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            for (int i = 0; i < 4; i++)
            {
                _spriteBatch.Draw(grassFloor, new Vector2(-1 + 200 * i, _graphics.PreferredBackBufferHeight - 200), Color.White);
            }
           
            _spriteBatch.Draw(knight, new Vector2(playerX, playerY), Color.White);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
