using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Super_steve_platformer
{
    public class Game1 : Game
    {
        Texture2D knight;
        Texture2D grassFloor;
        Texture2D spriteSheet;
        Texture2D metroidSpriteSheet;
        public static float playerX = 0;
        public static float playerY = 20;
        public static float playerDdy = 1;
        public static float playerDy = 0;
        PlayerAnimator playerAnimator = new PlayerAnimator();

        static public Game1 game;

        const int cameraEdge = 200; 

        public static Map map = new Map();
        MapRenderer mapRenderer = new MapRenderer();

        public SpriteSheetBlockPicker spriteSheetBlockPicker = new SpriteSheetBlockPicker();

        public GraphicsDeviceManager graphics;
        private SpriteBatch _spriteBatch;

        public bool onPlatform()
        {

            Vector2 v2 = new Vector2();
            v2.X = Convert.ToInt32(playerX);
            v2.Y = Convert.ToInt32(playerY);
            v2 = map.pixelCoordsToMapCoords(v2);
            if (map.grid [Convert.ToInt32(v2.X), Convert.ToInt32(v2.Y) ] != Map.TileType.Empty)
            {
                return true;
            }
            return false;
        }

        public void playerInPlatform (int platformX, int platformY, int platformWidth, int platformHeight)
        {
            if(playerX > platformX && playerX < platformX + platformWidth && playerY > platformY && playerY < platformY + platformHeight)
            {
                //playerY = platformY;
                //playerDy = 0;
            }
        }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            Game1.game = this;
            //TODO: Add your initialization logic here
            map.initialize();
            map.load("..//..//..//Level1.txt");
            //map.save("Map.txt");
            mapRenderer.Initialize(Content);
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
            knight = Content.Load<Texture2D>("KnightForPlatformerTake3");
            grassFloor = Content.Load<Texture2D>("Grass floor2");
            spriteSheet = Content.Load<Texture2D>("Overworld");
            //metroidSpriteSheet = Content.Load<Texture2D>("Metroid SpriteSheet");
            playerAnimator.initialize(metroidSpriteSheet);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            var kState = Keyboard.GetState();
            if (kState.IsKeyDown(Keys.Right) == true)
            {
                ;
                if (mapRenderer.cameraX + 0.3f < cameraEdge )
                {
                    mapRenderer.cameraX = mapRenderer.cameraX + 0.3f;
                }
            }
            if (kState.IsKeyDown(Keys.Left) == true)
            {
               
                if(mapRenderer.cameraX - 0.3f > 0)
                    mapRenderer.cameraX = mapRenderer.cameraX - 0.3f;
            }
            
            
            if (kState.IsKeyDown(Keys.Down) == true)
            {
                playerY = playerY + 3;
            }

            if (kState.IsKeyDown(Keys.Up) == true)
            {
                playerY = playerY - 3;
            }
            int platformDetected = 0;
            if(onPlatform() != true)
            {
                playerDy = playerDy + playerDdy;
                for(int i = 0;i< Convert.ToInt32(playerDy/16);i++)
                {
                    if(Convert.ToInt32(playerY/map.tileSize + i) == 29)
                    {
                        platformDetected = 1;
                        break;
                    }
                    if(map.grid[Convert.ToInt32(playerX/map.tileSize), Convert.ToInt32(playerY/map.tileSize + i)] != Map.TileType.Empty)
                    {
                        platformDetected = 1;
                    }
                }
                if (platformDetected == 0)
                {
                    playerY = playerY + playerDy;
                }
            }

            if (onPlatform() == true)
            {
                playerDy = 0;
                if (kState.IsKeyDown(Keys.Up) == true)
                {
                    playerDy = -10;
                }
                
            }
            

            base.Update(gameTime);
        }
        //int test2 = 0;
        //int test3 = 0;
        protected override void Draw(GameTime gameTime)
        {
            //test2++;
            GraphicsDevice.Clear(Color.LightCyan);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            
           
            _spriteBatch.Draw(knight, new Vector2(playerX, playerY), Color.White);
            mapRenderer.draw(map,_spriteBatch, spriteSheetBlockPicker, spriteSheet);
            //spriteSheetBlockPicker.draw(0, 0, spriteSheet, _spriteBatch,73,0);
            Vector2 v2 = new Vector2();
            v2.X = 50;
            v2.Y = 50;
            
            //playerAnimator.draw(v2, _spriteBatch, test2, 0);
            //if(test2>= 20)
            //{
            //    test2 = 4;
            //    test3++;
            //}
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
