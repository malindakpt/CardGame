using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Threading;

namespace Card_Game
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        public Boolean skip = false;
        public Boolean isRunning = true;
        public Boolean stop_song = false;
        public Boolean done = false;
        public int curernt = -1;
        public int mod = 2;
        Thread BUupdater;
        public Thread updater;
         
        public Boolean vidPlay=true;

        public Boolean trump_my = false;
        public Boolean trump_open = false;
        public Boolean my_chance = false;
        public String nowCard = null;
        public Boolean ready_send_myChoice = false;
        public Boolean me_given = false;
        public Boolean is_starter = false;
        public Boolean trump_discovered = false;
        public Boolean allow_draw = false;
        public int given_card_count = 0;
        public int round = 0;
        public int updateNo = 0;

        const float volume = .2f;
        public String game_trump = "";

        public String m0 = "";
        public String m1 = "";
        public String m2 = "";
        public String m3 = "";

        public Card my_given_card = null;
        public Card p1_given_card = null;
        public Card p2_given_card = null;
        public Card p3_given_card = null;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        const int SCRWIDTH = 1000;
        const int SCRHEIGHT = 600;
        const int CARD_WIDTH = 90;
        const int CARD_HEIGHT = 120;
        public string game_id;
        public string player_id;

        public Boolean trumpChooser = false;
        public Boolean AllBided = false;
        public Boolean MeBided = false;
        public Boolean is_my_chance = false;
        public String game_result = null;

        public String trump_player = "";
        SpriteFont font, font2, font3;

        public int game_bid; 
        public int myPos =0; 
        public Card myTrump = null;

        private static Texture2D[] cardsImages;
        private static Texture2D[] thurumpuImages;
        private static Song backSong,last ;
        SoundEffect okTrack,errorTrack;

        Video video;
        VideoPlayer player;
        Texture2D videoTexture;

        Trump[] thurumpu;
        public Card[] myCards;

        public Trump gameTrump;
 
        int middleX;
        int middleY;

        Texture2D backgroundTexture,frontCard,black,rectImg,rectImg2,back304;
        public string myBid = "0";
 
        public int MiddleCardCount=Codes.NO_OF_CARDS;
        public int EastCardCount = 0;
        public int NorthCardCount = 0;
        public int WestCardCount = 0;
        public int myCardCount = 0;

        public Boolean EastCardGave = true;
        public Boolean NorthCardGave = true;
        public Boolean WestCardGave = true;
        public Boolean myCardGave = true;
        public Boolean drawIndicate = false;

        public String p0Name = null;
        public String p1Name = null;
        public String p2Name = null;
        public String p3Name = null;

        private Boolean lastPlayed = false;

        public Boolean giveFirstCards = false;
        public Boolean giveAllCards = false;
        public Boolean middleThurumpu = false;
        public Boolean gamaStarted = false;
        public Boolean drawMiddle=false;

        private Boolean bidderShown = false;
        public static string p0bid = "PLAYER 1";
        public static string p1bid = "PLAYER 2";
        public static string p2bid = "PLAYER 3";
        public static string p3bid = "PLAYER 4";
        Bidder BD;
        public int game_trump_player=-1;

        public int widthX = 190;
        public int widthXMAX = 190;


        public int startupcnt = 35;

        public void new_round()
        {
             my_given_card = null;
             p1_given_card = null;
             p2_given_card = null;
             p3_given_card = null;
             nowCard = null;
        }

        private void draw_connection()
        { 
            if (game_result == null)
            {

                widthX--;
                if (widthX > 15)
                { 
                    Rectangle rect = new Rectangle(20, 18, widthX, 18);
                    spriteBatch.Draw(rectImg, rect, Color.White); 
                    spriteBatch.DrawString(font3, "SYNCHRONIZING OTHER MEMBERS", new Vector2(35, 20), Color.Black);
                }
                else
                {
                    if (widthX % 10 == 0 || widthX % 10 == 1 || widthX % 10 == 2 || widthX % 10 == 3 || widthX % 10 == 4 || widthX % 10 == 5 || widthX % 10 == 6 || widthX % 10 == 7 || widthX % 10 == 8)
                    {
                        Rectangle rect = new Rectangle(20, 18, 195, 18);
                        spriteBatch.Draw(rectImg2, rect, Color.White);
                    }
                    spriteBatch.DrawString(font3, "INTERNET CONNECTION PROBLEM", new Vector2(35, 20), Color.Black);
                }
            }
        }

        public Boolean comeUp = false;
        public int gap1 = 200;
        public int gap = 200;
        int skip_x=880;
        int skip_y = 570;
        
        protected override void Draw(GameTime gameTime)
        {
             
            Window.Title = "Card Game "+player_id;
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            DrawScenery();
            ///////////////////////////////////
            if (vidPlay)
            {
                if (player.State != MediaState.Stopped)
                    videoTexture = player.GetTexture();

                Rectangle screenRectangle = new Rectangle(0, 0, SCRWIDTH, SCRHEIGHT);

                if (videoTexture != null)
                    spriteBatch.Draw(videoTexture, screenRectangle, Color.White);

                spriteBatch.DrawString(font, "SKIP INTRO", new Vector2(skip_x, skip_y), Color.White);
            }
            else if (comeUp)
            { 
                player.Stop();
                Rectangle screenRectangle = new Rectangle(0, 0, SCRWIDTH, SCRHEIGHT);
                spriteBatch.Draw(back304, screenRectangle, Color.White);

                int sx = (SCRWIDTH - 200) / 2-280;
                int sy = SCRHEIGHT / 2 + 100;
                Rectangle screenRectangle2 = new Rectangle(sx+gap, sy, 25, 25);
                spriteBatch.Draw(rectImg, screenRectangle2, Color.White);
            }
            else if(gameOk)
            {
                MediaPlayer.Play(backSong);
                new GAmeController(this);
                gameOk = false;
            }
            ////////////////////////////////////
            
            ///////////////////////////////////
            if (drawMiddle) 
                drawMiddleCards();
            
            if (giveFirstCards)
            {
                drawCollapsedCardSet(EastCardCount, Codes.Pos.EAST);
                drawCollapsedCardSet(NorthCardCount, Codes.Pos.NORTH);
                drawCollapsedCardSet(WestCardCount, Codes.Pos.WEST);
                drawMyCardSet();
            }
 
            if (gameTrump!=null && gameTrump.getImage() != null)  
                 drawTrump();
           
            if (!trumpChooser)
                 BD.Hide();
         
            BD.P1.Text = "PLAYER 1\n" + p0bid;
            BD.P2.Text = "PLAYER 2\n" + p1bid;
            BD.P3.Text = "PLAYER 3\n" + p2bid;
            BD.P4.Text = "PLAYER 4\n" + p3bid;
            ////////////////////////////////////////////////////////
           if(AllBided)
                spriteBatch.DrawString(font, "BID : "+game_bid , new Vector2(20, 45), Color.Black);

           if (stop_song && !done)
           {
               done = true;
               MediaPlayer.Stop();
           }

            if (game_result != null)
            {
                if (!lastPlayed)
                {
                    MediaPlayer.Play(last);
                    lastPlayed = true;
                }
                spriteBatch.DrawString(font2, "YOUR TEAM  " + game_result + " ! ! !", new Vector2(350, 450), Color.Red);
            }
            else if (updateNo > 0)
            {
                if (my_chance)
                    spriteBatch.DrawString(font, "YOUR CHANCE !!! \n                PICK A CARD", new Vector2(700, 20), Color.Red);
                else
                    spriteBatch.DrawString(font, "WAIT FOR YOUR CHANCE TO PLAY", new Vector2(650, 20), Color.Blue);
            }
             
            ////////////////////////////////////////////////////////

            if (p0Name != null) drawPlayerName(getPoint(0), p0Name + "\n" + m0);
            if (p1Name != null) drawPlayerName(getPoint(1), p1Name + "\n" + m1);
            if (p2Name != null) drawPlayerName(getPoint(2), p2Name + "\n" + m2);
            if (p3Name != null) drawPlayerName(getPoint(3), p3Name + "\n" + m3);

            drawGivenCardPending();
            /////////////////////////////////////////////////////////
            if (my_given_card != null) 
                drawGivenCard(my_given_card.getImage(), Codes.Pos.SOUTH);
 
            /////////////////////////////////////////////////////////
            if (p1_given_card != null)
            {
                drawGivenCard(p1_given_card.getImage(), Codes.Pos.EAST);
                if (EastCardGave)
                {
                    EastCardCount--;
                    EastCardGave = false;
                }
            }
            else
            {
                EastCardGave = true;
            }
            /////////////////////////////////////////////////////////
            if (p2_given_card != null)
            {
                drawGivenCard(p2_given_card.getImage(), Codes.Pos.NORTH);
                if (NorthCardGave)
                {
                    NorthCardCount--;
                    NorthCardGave = false;
                }
            }
            else
            {
                NorthCardGave = true;
            }
            /////////////////////////////////////////////////////////
            if (p3_given_card != null)
            {
                drawGivenCard(p3_given_card.getImage(), Codes.Pos.WEST);
                if (WestCardGave)
                {
                    WestCardCount--;
                    WestCardGave = false;
                }
            }
            else
            {
                WestCardGave = true;
            }
 
            if(done)
                draw_connection();
         
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public Boolean gameOk = false;
      

        private void drawPlayerName(int n, String name)
        {
            if (n == 0 && game_result != null)
                spriteBatch.DrawString(font, name, new Vector2((SCRWIDTH - 100) / 2, SCRHEIGHT / 2 + 220), Color.Black);
            if (n == 1)
                spriteBatch.DrawString(font, name, new Vector2((SCRWIDTH - 100) / 2 + 420, SCRHEIGHT / 2 +65), Color.Black);
            if (n == 2)
                spriteBatch.DrawString(font, name, new Vector2((SCRWIDTH - 100) / 2 - 140, 55), Color.Black);
             if (n == 3)
                spriteBatch.DrawString(font, name, new Vector2((SCRWIDTH - 100) / 2 - 420, SCRHEIGHT / 2 + 65), Color.Black);
        }

        public void giveCardtoEast()
        {
            if (MiddleCardCount > 0)
            {
                MiddleCardCount--;
                EastCardCount++;
            }
        }
        public void giveCardtoNorth()
        {
            if (MiddleCardCount > 0)
            {
                MiddleCardCount--;
                NorthCardCount++;
            }
        }
        public void giveCardtoWest()
        {
            if (MiddleCardCount > 0)
            {
                MiddleCardCount--;
                WestCardCount++;
            }
        }
        public void giveCardtoMe()
        {
            if (MiddleCardCount > 0)
            {
                MiddleCardCount--;
                myCardCount++;
            }
        }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        public static Texture2D getCardImage(int no)
        {
            return cardsImages[no];
        }
        public static Texture2D getThurumpuImage(int no)
        { 
            return thurumpuImages[no];
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferHeight = SCRHEIGHT;
            graphics.PreferredBackBufferWidth = SCRWIDTH;
            graphics.ApplyChanges();
            Window.Title = "Card Game";
            base.Initialize();

            this.TargetElapsedTime = TimeSpan.FromSeconds(1.0f / 10.0f);

            font = Content.Load<SpriteFont>("my_font");
            font2 = Content.Load<SpriteFont>("my_font2");
            font3 = Content.Load<SpriteFont>("my_font3");
            BD = new Bidder(this);

            backSong = Content.Load<Song>("backSong");
            last = Content.Load<Song>("last");
            okTrack = Content.Load<SoundEffect>("okTrack");
            errorTrack = Content.Load<SoundEffect>("errorTrack");
 
            MediaPlayer.IsRepeating = true;
           // MediaPlayer.Play(backSong);
            MediaPlayer.Volume = volume;

            this.IsMouseVisible = true;
            cardsImages = new Texture2D[52];
            thurumpuImages = new Texture2D[4];
 
            thurumpuImages[0] = Content.Load<Texture2D>("C");
            thurumpuImages[1] = Content.Load<Texture2D>("D");
            thurumpuImages[2] = Content.Load<Texture2D>("H");
            thurumpuImages[3] = Content.Load<Texture2D>("S");

            

            myCards = new Card[Codes.CARDS_PER_PLAYER];

            thurumpu = new Trump[4];
            thurumpu[0] = new Trump(Codes.Symbols.C.ToString());
            thurumpu[1] = new Trump(Codes.Symbols.D.ToString());
            thurumpu[2] = new Trump(Codes.Symbols.H.ToString());
            thurumpu[3] = new Trump(Codes.Symbols.S.ToString());

            for (int i = 0; i < 52; i++)
            {
                cardsImages[i] = Content.Load<Texture2D>(XMLReader.getCardName(i));
            }

 
        }

        protected override void OnExiting(object sender, EventArgs args)
        {
            try
            {
                isRunning = false;
                MediaPlayer.Stop();
                player.Stop();
                BUupdater.Suspend();
                updater.Suspend();

            }
            catch (Exception e) { }
            base.OnExiting(sender, args);
        }
     

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            backgroundTexture = Content.Load<Texture2D>("back");
            back304 = Content.Load<Texture2D>("back304");
            frontCard = Content.Load<Texture2D>("CARD");
            black = Content.Load<Texture2D>("black");
            rectImg = Content.Load<Texture2D>("rect");
            rectImg2 = Content.Load<Texture2D>("rect2");
            Server.set(this);

            spriteBatch = new SpriteBatch(GraphicsDevice);
            video = Content.Load<Video>("aaa");
            player = new VideoPlayer();

            player.Play(video);

            videoThread vt = new videoThread(this);
            Thread vtt = new Thread(new ThreadStart(vt.start));
            vtt.Start();
            
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

           //  TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
 
            processMouse(); 
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// 
        public Boolean vid_done = false;
        private void processMouse()
        {
           MouseState mouseState = Mouse.GetState();

            if (mouseState.LeftButton.ToString().Equals("Pressed"))
            {
                if ( mouseState.X < SCRWIDTH && mouseState.X > 0 && mouseState.Y < SCRHEIGHT && mouseState.Y > 0)
                {
                    ///////////////////////SKIP VIDEO////////////////////////////
                    if (vidPlay)
                    {
                        if (mouseState.X > skip_x && mouseState.Y > skip_y && !vid_done)
                        {
                            skip = true;
                            vid_done = true;
                            videoThread2 vt2 = new videoThread2(this);
                            Thread vtt = new Thread(new ThreadStart(vt2.start));
                            vtt.Start();
                        }
                    } 
                    ///////////////////////giving card////////////////////////////
                    else if (my_chance && !me_given)
                    {
                        my_given_card = chkCard(mouseState.X, mouseState.Y);
                        if (my_given_card != null)
                        {
                            Console.WriteLine(my_given_card.getName()); 
                            ready_send_myChoice = true;
                            me_given = true;
                        }
                    }
                    /////////////////////////trump chooser////////////////////////
                    else if (trumpChooser && !bidderShown)
                    {
                        this.myTrump = chkCard(mouseState.X, mouseState.Y);

                        if (this.myTrump != null)
                         { 
                            if (!bidderShown)
                            {
                                //////FOR UI PURPOSE////////////
                                bidderShown = true;
                                ///////////////////////////////

                                BiddingUpdater BU = new BiddingUpdater(this,game_id, player_id, 0);
                                BUupdater = new Thread(new ThreadStart(BU.start));
                                BUupdater.Start();

                                BD.Show(); 
                            }
 
                        }
                    }
                } 
            }

        }
        private void ProcessKeyboard()
        {
             KeyboardState keybState = Keyboard.GetState();
             MouseState mouseState = Mouse.GetState();
        }
 
        public Boolean cards_over()
        {
            foreach (Card c in myCards)
            {
                if (c != null)
                    return false;
            } 
            return true;
        }

        private Boolean haveTrumps()
        {
            if (myCards != null)
            {
                foreach (Card c in myCards)
                {
                   if(nowCard!=null)
                        {
                            String tr = nowCard.Substring(0, 1);
                            if(c!=null && c.getSymbol().ToString().Equals(tr))
                            {
                                return true;
                            }
                        }
                }
            }
            return false;

        }

        private Card chkCard(int x,int y)
        {
              
            if (myCards != null)
            {
                int i = 0;
                foreach (Card c in myCards)
                {
                    //GIVING A CARD
                    if (c!= null && my_chance && c.isMe(x, y))
                    {
                        if (nowCard == null && myPos == game_trump_player && round == 0)
                        {
                            String tr = game_trump.Substring(0, 1);
                            if ((c.getSymbol().ToString().Equals(tr) &&  !game_trump.Equals(c.getName())))
                            {
                                //myCards[i] = null;
                                //okTrack.Play();
                                //chk_open_trump_game(c);
                                return null;
                            }

                        }
                        if (nowCard != null)
                        {
                            String tr = nowCard.Substring(0, 1);
                            if ((c.getSymbol().ToString().Equals(tr) && haveTrumps()) || !haveTrumps())
                            {
                                myCards[i] = null;
                                 okTrack.Play();
                                chk_open_trump_game(c);
                                return c;
                            }
                        }
                        else
                        {
                            myCards[i] = null;
                            okTrack.Play();
                            chk_open_trump_game(c);
                            return c;
                        } 
                    }
                        //For trumop chooser
                    else 
                    {
                        if (c != null && c.isMe(x, y))
                        {
                            okTrack.Play();
                            //chk_open_trump_game(c);
                            return c;
                        }
                    } 
                    i++;
                }
            }
            //errorTrack.Play();
            return null;
        }
        private void chk_open_trump_game(Card card)
        { 
            if(card.getName().Equals(game_trump))
                Server.set_open_trump(this, game_id, card.getSymbol().ToString());
          
        }

        private Trump chkThurumpu(int x, int y)
        {
            if (thurumpu != null)
            {
                foreach (Trump t in thurumpu)
                {
                    if (t != null && t.isMe(x, y)) return t;
                }
            }
            return null;
        }
 

        private void drawTrump()
        {
            int length = 50;

            int CX = (SCRWIDTH - length) / 2;
            int CY = (SCRHEIGHT - length) / 2;
       
            if (gameTrump!=null)
            {  
                Rectangle rect = new Rectangle(CX, CY, length, length);
                spriteBatch.Draw(gameTrump.getImage(), rect, Color.White);
            }

            
        }

        private void drawMiddleCards()
        {
            int count = MiddleCardCount;
            int gap=8;
            int length = (count - 1) * gap * mod + CARD_WIDTH;

            int CX = (SCRWIDTH - length) / 2;
            int CY = (SCRHEIGHT - CARD_HEIGHT)/ 2 ;

            for (int i = 0; i < count; i++)
            {
                Rectangle rect = new Rectangle(CX+gap*i, CY, CARD_WIDTH, CARD_HEIGHT);
                spriteBatch.Draw(frontCard, rect, Color.White);
            }
            middleX = CX;
            middleY = CY;
        }

        private void showAnimationEast(Point start, Point end)
        {
            if(start.X < end.X)   start.X++;
        }

        private int getPoint(int t)
        {
            if (myPos == 0)     return t;
            else if (myPos == 1)  return next(t+2); 
            else if (myPos == 2) return next(t + 1);
            else return next(t );
        }

        private int next(int t)
        {
            return (t + 1) % 4;
        }



        private void drawGivenCardPending()
        {
             if (game_result == null)
            {
                int nowPlaying;
                if (curernt == -1)
                    nowPlaying = -1;
                else
                    nowPlaying = getPoint(curernt);
                int Xgap = 100;
                int Ygap = 65;

                if (nowPlaying == 0)
                {
                    int CX = (SCRWIDTH - CARD_WIDTH) / 2; ;
                    int CY = (SCRHEIGHT - CARD_HEIGHT * 2 + Ygap) / 2 + CARD_HEIGHT;

                    Rectangle rect = new Rectangle(CX, CY, CARD_WIDTH, CARD_HEIGHT);

                    if (nowPlaying == 0)
                    {

                        Rectangle recte = new Rectangle(CX, CY, CARD_WIDTH, CARD_HEIGHT);
                        DrawBorder(recte, 5, Color.Black);
                    }

                }

                else if (nowPlaying == 2)
                {
                    int CX = (SCRWIDTH * mod - CARD_WIDTH) / 2;
                    int CY = (SCRHEIGHT * mod - CARD_HEIGHT * 2 - Ygap) / 2;

                    Rectangle rect = new Rectangle(CX, CY, CARD_WIDTH, CARD_HEIGHT);

                    if (nowPlaying == 2)
                    {

                        Rectangle recte = new Rectangle(CX, CY, CARD_WIDTH, CARD_HEIGHT);
                        DrawBorder(recte, 5, Color.Black);
                    }

                }

                else if (nowPlaying == 1)
                {
                    int CY = (SCRHEIGHT - CARD_HEIGHT) / 2; ;
                    int CX = (SCRWIDTH - CARD_WIDTH * 2 + Xgap) / 2 + CARD_WIDTH;

                    Rectangle rect = new Rectangle(CX, CY, CARD_WIDTH, CARD_HEIGHT);

                    if (nowPlaying == 1)
                    {

                        Rectangle recte = new Rectangle(CX, CY, CARD_WIDTH, CARD_HEIGHT);
                        DrawBorder(recte, 5, Color.Black);
                    }
                }
                else if (nowPlaying == 3)
                {
                    int CY = (SCRHEIGHT - CARD_HEIGHT) / 2;
                    int CX = (SCRWIDTH - CARD_WIDTH * 2 - Xgap) / 2;

                    Rectangle rect = new Rectangle(CX, CY, CARD_WIDTH, CARD_HEIGHT);

                    if (nowPlaying == 3)
                    {

                        Rectangle recte = new Rectangle(CX, CY, CARD_WIDTH, CARD_HEIGHT);
                        DrawBorder(recte, 5, Color.Black);
                    }
                }
            }
        }

        private void DrawBorder(Rectangle rectangleToDraw, int thicknessOfBorder, Color borderColor)
        {
            Texture2D pixel;

            // Somewhere in your LoadContent() method:
            pixel = new Texture2D(GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            pixel.SetData(new[] { Color.White });
            // Draw top line
            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y, rectangleToDraw.Width, thicknessOfBorder), borderColor);

            // Draw left line
            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y, thicknessOfBorder, rectangleToDraw.Height), borderColor);

            // Draw right line
            spriteBatch.Draw(pixel, new Rectangle((rectangleToDraw.X + rectangleToDraw.Width - thicknessOfBorder),
                                            rectangleToDraw.Y,
                                            thicknessOfBorder,
                                            rectangleToDraw.Height), borderColor);
            // Draw bottom line
            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X,
                                            rectangleToDraw.Y + rectangleToDraw.Height - thicknessOfBorder,
                                            rectangleToDraw.Width,
                                            thicknessOfBorder), borderColor);
        }
        private void drawGivenCard(Texture2D card, Codes.Pos pos)
        {
            
            int Xgap = 100;
            int Ygap = 65;

            String tr="A";
            
            if(nowCard!=null)
                 tr= nowCard.Substring(0, 1);

            if (pos == Codes.Pos.SOUTH)
            {
                int CX = (SCRWIDTH - CARD_WIDTH) / 2; ;
                int CY = (SCRHEIGHT - CARD_HEIGHT * 2 + Ygap) / 2 + CARD_HEIGHT;

                Rectangle rect = new Rectangle(CX, CY, CARD_WIDTH, CARD_HEIGHT);

         
                if (!trump_discovered && !tr.Equals(my_given_card.getSymbol().ToString()) && !is_starter && !allow_draw)
                {
                    spriteBatch.Draw(frontCard, rect, Color.White);
                }
                else
                {
                    spriteBatch.Draw(card, rect, Color.White);
                }
            }

            else if (pos == Codes.Pos.NORTH)
            {
                int CX = (SCRWIDTH * mod - CARD_WIDTH) / 2;
                int CY = (SCRHEIGHT * mod - CARD_HEIGHT * 2 - Ygap) / 2;

                Rectangle rect = new Rectangle(CX, CY, CARD_WIDTH, CARD_HEIGHT);

           
                if (!trump_discovered && !tr.Equals(p2_given_card.getSymbol().ToString()) && !is_starter && !allow_draw)
                {
                    
                    spriteBatch.Draw(frontCard, rect, Color.White);
                }
                else
                {
                    spriteBatch.Draw(card, rect, Color.White);
                }
            }

            else if (pos == Codes.Pos.EAST)
            {
                int CY = (SCRHEIGHT - CARD_HEIGHT) / 2; ;
                int CX = (SCRWIDTH - CARD_WIDTH * 2 + Xgap) / 2 + CARD_WIDTH;

                Rectangle rect = new Rectangle(CX, CY, CARD_WIDTH, CARD_HEIGHT);

            

                if (!trump_discovered && !tr.Equals(p1_given_card.getSymbol().ToString()) && !is_starter && !allow_draw)
                {
                    spriteBatch.Draw(frontCard, rect, Color.White);
                }
                else
                {
                    spriteBatch.Draw(card, rect, Color.White);
                }
            }
            else
            {
                int CY = (SCRHEIGHT - CARD_HEIGHT) / 2;
                int CX = (SCRWIDTH - CARD_WIDTH * 2 - Xgap) / 2;

                Rectangle rect = new Rectangle(CX, CY, CARD_WIDTH, CARD_HEIGHT);
 
                if (!trump_discovered && !tr.Equals(p3_given_card.getSymbol().ToString()) && !is_starter && !allow_draw)
                {
                    spriteBatch.Draw(frontCard, rect, Color.White);
                }
                else
                {
                    spriteBatch.Draw(card, rect, Color.White);
                }
            }
        }

        public void setMyCardset(Card[] cards)
        {
            myCards = cards;
        }

        private void drawMyCardSet()
        { 
            int DISY = 340;
            int gap=10;
            int count = myCardCount;
            int length = gap * (count - 1) + CARD_WIDTH;
           
                gap *= 10;
                int CX = SCRWIDTH / 2 - (gap * (count - 1) + CARD_WIDTH) / 2;
                int CY = (SCRHEIGHT - DISY - CARD_HEIGHT * 2) / 2+DISY+CARD_HEIGHT;
             
                for (int i = 0; i < count; i++)
                {
                    int X=CX + gap * i;
                    int Y=CY;

                    if (myCards[i] != null)
                    { 
                       if (myTrump == myCards[i]  && myPos == game_trump_player)
                        {
                            Rectangle recte = new Rectangle(X * mod - 5, Y  - 5, CARD_WIDTH + 10, CARD_HEIGHT + 10);
                            spriteBatch.Draw(black, recte, Color.White);
                        }
 
                        Rectangle rect = new Rectangle(X, Y*mod, CARD_WIDTH, CARD_HEIGHT);
                        spriteBatch.Draw(myCards[i].getImage(), rect, Color.White);

                        myCards[i].setPos(X, X + CARD_WIDTH, Y, Y + CARD_HEIGHT);
                    }
                }
           
        }
        private void drawCollapsedCardSet(int count,Codes.Pos pos)
        {
            int DISX = 500;
            int DISY = 340;
            int gap=10;
            int length = gap * (count - 1) + CARD_WIDTH;

            if (pos == Codes.Pos.NORTH)
            {
                int CX = SCRWIDTH / 2 - length/2;
                int CY = (SCRHEIGHT - DISY - CARD_HEIGHT * 2)/2;

                for (int i = 0; i < count; i++)
                {
                    Rectangle rect = new Rectangle(CX+gap*i,CY, CARD_WIDTH,CARD_HEIGHT);
                    spriteBatch.Draw(frontCard, rect, Color.White);
                }
            }


            else if (pos == Codes.Pos.EAST)
            {
                int CX = (SCRWIDTH - DISX - length * 2) / 2 + DISX + length;
                int CY = (SCRHEIGHT - CARD_HEIGHT) / 2;

                for (int i = 0; i < count; i++)
                {
                    Rectangle rect = new Rectangle(CX + gap * i, CY, CARD_WIDTH, CARD_HEIGHT);
                    spriteBatch.Draw(frontCard, rect, Color.White);
                }
            }
            else
            {
                int CX = (SCRWIDTH - DISX - length * 2) / 2;
                int CY = (SCRHEIGHT - CARD_HEIGHT) / 2;

                for (int i = 0; i < count; i++)
                {
                    Rectangle rect = new Rectangle(CX + gap * i, CY, CARD_WIDTH, CARD_HEIGHT);
                    spriteBatch.Draw(frontCard, rect, Color.White);
                
                }
            }
        }
        private void DrawScenery()
        {
            Rectangle screenRectangle = new Rectangle(0, 0, SCRWIDTH    ,SCRHEIGHT);
            spriteBatch.Draw(backgroundTexture, screenRectangle, Color.White); 
          //  Rectangle rect = new Rectangle(20, 20, 90,120); 
        }

        private void DrawSceneryTemp()
        {
            Rectangle screenRectangle = new Rectangle(0, 0, SCRWIDTH, SCRHEIGHT);
            spriteBatch.Draw(back304, screenRectangle, Color.White);
          //  Rectangle rect = new Rectangle(20, 20, 90, 120);
        }

        private void drawThurumpuChooser()
        {
            int sx = 40;
          
            int length = 70;
            int ygap = 40;

            int sy = (SCRHEIGHT - ( ygap *3+length*4))/2;


           
                for (int i = 0; i < 4; i++)
                {
                    int ssy=sy + (ygap + length) * i;
                    Rectangle rect = new Rectangle(sx, ssy, length, length);
                    spriteBatch.Draw(thurumpuImages[i], rect, Color.White);
                    thurumpu[i].setPos(sx, sx + length, ssy, ssy + length);
                }
           
        }
    }
}
