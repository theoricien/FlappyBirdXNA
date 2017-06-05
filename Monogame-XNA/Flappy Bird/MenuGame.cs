using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flappy_Bird
{
    public class MenuGame : MenuBase
    {
        // CONST
        private const int HOLE_HEIGHT = 50;

        // FIELDS
        private Sprite getReady;
        private List<Pipe> pipes;
        private Bird player;
        private bool start;
        private int timer;
        private Random random;

        private int score;
        private int baseScoreX;
        private int baseScoreY;
        private int highscore;

        private bool gameover;
        private bool setRotation;
        private bool newScore;
        private bool pause;

        private Sprite gameOver;
        private Sprite newHighscore;
        private Sprite ScoreBox;
        private Sprite background;
        private Sprite pauseScreen;
        private Sprite tutorial;
        private AnimatedSprite Medal;
        private Button retryButton;
        private Button menuButton;

        private Button pauseButton;
        private Button playButton;

        private Ground ground;
        private string bird;

        private SoundEffectInstance instance;

        // CONSTRUCTOR
        public MenuGame(string back)
            : base()
        {
            this.getReady = new Sprite("getready", (Settings.SCREEN_WIDTH - 87) / 2, 75);
            this.pipes = new List<Pipe>();

            this.background = new Sprite(back);

            Random rand = new Random();
            int i = rand.Next(1,4);
            this.bird = "bird" + i.ToString();
            this.player = new Bird(bird , 31, 100);
            this.tutorial = new Sprite("tutorial");

            this.ground = new Ground(0, 200);

            this.start = false;
            this.timer = 0;
            this.random = new Random();
            this.gameover = false;
            this.setRotation = false;

            this.score = 0;
            this.highscore = 0;
            this.newScore = false;

            this.gameOver = new Sprite("gameover", (Settings.SCREEN_WIDTH - 94) / 2, 75);
            int ScoreBoxX = (Settings.SCREEN_WIDTH - 113) / 2;
            int ScoreBoxY = 75 + 34;
            this.ScoreBox = new Sprite("score_box", ScoreBoxX, ScoreBoxY);
            this.Medal = new AnimatedSprite("medals", 22, 22, 0, SheetOrientation.HORIZONTAL, ScoreBoxX + 13, ScoreBoxY + 21);
            this.newHighscore = new Sprite("new", ScoreBoxX + 85 - 16 - 2, ScoreBoxY + 29);

            this.baseScoreX = ScoreBoxX + 95;
            this.baseScoreY = ScoreBoxY + 17;

            this.retryButton = new Button(ScoreBoxX, ScoreBoxY + 58 + 15, 1);
            this.menuButton = new Button(ScoreBoxX + 113 - 40, ScoreBoxY + 58 + 15, 0);

            this.pauseButton = new Button(10, 10, 6, 13);
            this.playButton = new Button(10, 10, 7, 13);
            this.pause = false;
            this.pauseScreen = new Sprite("pause_screen");

            this.instance = Resources.Sounds["background"].CreateInstance();
            this.instance.IsLooped = true;

            if (MenuMain.GetMusic() == true)
                this.instance.Play();
        }

        // METHODS
        private void GameOver(GameTime gameTime)
        {
            if (MenuMain.GetMusic() == true)
                this.instance.Stop();

            this.pause = false;

            Resources.Sounds["pipe_hit2"].Play();

            this.player.SetMaxRotation();
            this.setRotation = true;
            this.player.Update(gameTime, null);

            int medalIndex = -1;
            if (score >= 40)
                medalIndex = 0;
            else if (score >= 30)
                medalIndex = 3;
            else if (score >= 20)
                medalIndex = 2;
            else if (score >= 10)
                medalIndex = 1;

            this.Medal.SetIndex(medalIndex);

            this.highscore = Highscore.GetHighscore();

            if (this.score > this.highscore)
            {
                // NEW HIGHSCORE
                this.newScore = true;
                this.highscore = this.score;
                Highscore.SetHighcore(this.score);
            }

        }

        // UPDATE & DRAW
        public override void Update(GameTime gameTime, Input input, Game1 game)
        {
            base.Update(gameTime, input, game);

            if (!gameover)
            {
                if (this.pause == false)
                {
                    {
                        this.ground.Update(gameTime, input);

                        foreach (Pipe pipe in new List<Pipe>(this.pipes))
                        {
                            pipe.Update(gameTime, input);
                            if (pipe.ToDelete())
                                this.pipes.Remove(pipe);
                            if (this.player.CollisionWith(pipe))
                            {
                                // GAMEOVER : HITED A PIPE
                                this.gameover = true;
                                Resources.Sounds["pipe_hit"].Play();
                                break;
                            }

                            // PASS A PIPE
                            if (!pipe.IsPassed() && this.player.X > pipe.Right && pipe.GetPipeType() == PipeType.TOP)
                            {
                                pipe.SetPassed();
                                score += 1;
                                Resources.Sounds["pipe_pass"].Play();
                            }

                        }

                        this.timer += gameTime.ElapsedGameTime.Milliseconds;

                        if (this.player.CollisionWith(this.ground))
                        {
                            this.gameover = true;
                            this.GameOver(gameTime);
                        }
                        else
                        {
                            this.player.Update(gameTime, input);
                        }

                        if (!start)
                        {
                            if (this.timer >= 3000)
                            {
                                this.start = true;
                                this.timer = 0;
                                this.player.ActiveGravity();
                            }
                        }
                        else // CREATE PIPES
                        {
                            if (this.timer >= 1750)
                            {
                                this.timer = 0;

                                int topPipeY = this.random.Next(-95, 1);
                                int botPipeY = topPipeY + 135 + HOLE_HEIGHT;

                                this.pipes.Add(new Pipe(Settings.SCREEN_WIDTH, topPipeY, PipeType.TOP));
                                this.pipes.Add(new Pipe(Settings.SCREEN_WIDTH, botPipeY, PipeType.BOT));

                            }

                            this.pauseButton.Update(gameTime, input);
                            if (this.pauseButton.IsPressed() || input.IsPPressed())
                            {
                                this.pause = true;
                            }
                        }
                    }
                }
                else
                {
                    // PAUSE BUTTON PRESSED
                    this.playButton.Update(gameTime, input);
                    if (this.playButton.IsPressed() || input.IsPPressed())
                    {
                        this.pause = false;
                    }
                }
            }
            else if (!this.setRotation)
            {
                if (!this.player.CollisionWith(this.ground))
                {
                    this.player.Update(gameTime, null);
                }
                else
                {
                    this.GameOver(gameTime);
                }
            }
            else
            {
                this.retryButton.Update(gameTime, input);
                if (this.retryButton.IsPressed())
                {
                    // RESET THE GAME
                    game.ChangeMenu(Menu.GAME);
                    if (GetMusic() == true)
                        this.instance.Play();
                }

                this.menuButton.Update(gameTime, input);
                if (this.menuButton.IsPressed())
                {
                    game.ChangeMenu(Menu.MAIN);
                    if (GetMusic() == true)
                        this.instance.Stop();
                }
            }

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            this.background.Draw(spriteBatch);
            this.ground.Draw(spriteBatch);
            foreach (Pipe pipe in this.pipes)
            {
                pipe.Draw(spriteBatch);
            }
            if (!this.start && !this.setRotation)
            {
                this.getReady.Draw(spriteBatch);
                this.tutorial.Draw(spriteBatch);
            }
            else
            {
                int nb = 1;
                if (score > 0)
                    nb = (int)Math.Floor(Math.Log10(score) + 1);

                Number.Draw(spriteBatch, NumberSize.LARGE, (Settings.SCREEN_WIDTH - (nb * (Number.LARGE_NUMBER_WIDTH))) / 2, 25, score);


                if (this.pause == false)
                    this.pauseButton.Draw(spriteBatch);
                else
                {
                    this.pauseScreen.Draw(spriteBatch);
                    this.playButton.Draw(spriteBatch);
                }
            }
            this.ground.Draw(spriteBatch);
            this.player.Draw(spriteBatch);

            if(this.setRotation)
            {
                this.gameOver.Draw(spriteBatch);
                this.ScoreBox.Draw(spriteBatch);
                this.Medal.Draw(spriteBatch);
                this.retryButton.Draw(spriteBatch);
                this.menuButton.Draw(spriteBatch);

                int nb = 0;
                if (this.score > 0)
                    nb = (int)Math.Floor(Math.Log10(this.score));

                int nb2 = 0;
                if (this.highscore > 0)
                    nb2 = (int)Math.Floor(Math.Log10(this.highscore));

                Number.Draw(spriteBatch, NumberSize.LARGE, this.baseScoreX - (nb * Number.LARGE_NUMBER_WIDTH), this.baseScoreY, this.score);
                Number.Draw(spriteBatch, NumberSize.LARGE, this.baseScoreX - (nb2 * Number.LARGE_NUMBER_WIDTH), this.baseScoreY + 21, this.highscore);

                if(this.newScore)
                {
                    this.newHighscore.Draw(spriteBatch);
                }

            }
        }
    }
}
