using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceRace
{
    public partial class Form1 : Form
    {
        //Set the spin cooldown
        int cooldownTime = 25;

        //Initialize Spin Class
        public class rocketSpin
        {
            public int spinTime;
            public int cooldown;
            public String direction;
        }

        //Set up blue rocket
        Rectangle rocketBlue = new Rectangle();
        Rectangle rocketBlueStartingPosition = new Rectangle();
        int rocketBlueSize = 15;
        SolidBrush rocketBlueBrush = new SolidBrush(Color.Blue);

        int rocketBlueSpeedX = 1;
        int rocketBlueSpeedY = 1;
        int rocketBlueStoredSpeedX = 0;
        int rocketBlueStoredSpeedY = 0;

        rocketSpin rocketBlueSpin = new rocketSpin();

        //Set up red rocket
        Rectangle rocketRed = new Rectangle();
        Rectangle rocketRedStartingPosition = new Rectangle();
        int rocketRedSize = 15;
        SolidBrush rocketRedBrush = new SolidBrush(Color.Red);

        int rocketRedSpeedX = 1;
        int rocketRedSpeedY = 1;
        int rocketRedStoredSpeedX = 0;
        int rocketRedStoredSpeedY = 0;

        rocketSpin rocketRedSpin = new rocketSpin();

        //Check keypress
        bool wDown = false;
        bool aDown = false;
        bool sDown = false;
        bool dDown = false;
        bool iDown = false;
        bool jDown = false;
        bool kDown = false;
        bool lDown = false;
        bool enterDown = false;
        bool escapeDown = false;
        bool upDown = false;
        bool downDown = false;

        //Set spin time
        int spinTime = 10;

        //Set Move Holders
        int moveHolderRocketBlueX = 0;
        int moveHolderRocketBlueY = 0;

        int moveHolderRocketRedX = 0;
        int moveHolderRocketRedY = 0;

        //Set Orientations
        int rocketBlueOrientation = 1;
        bool rocketBlueOrientPositive = true;

        int rocketRedOrientation = 1;
        bool rocketRedOrientPositive = false;

        Image[] p1Orient = new Image[29];
        Image[] p2Orient = new Image[29];

        //Hold hits
        bool rocketRedHit = false;
        bool rocketBlueHit = false;

        //Set max spawns (I know there's a typo)
        int maxSpwanPerTick = 15;

        //Track Score
        int redScore = 0;
        int blueScore = 0;

        //Set Up Sounds
        SoundPlayer USA = new SoundPlayer(Properties.Resources.UnitedStates);
        SoundPlayer Soviet = new SoundPlayer(Properties.Resources.Soviet);
        SoundPlayer hit = new SoundPlayer(Properties.Resources.Hit);
        SoundPlayer thrust = new SoundPlayer(Properties.Resources.Thrusters);
        SoundPlayer JFK = new SoundPlayer(Properties.Resources.JFK);

        //Help with sounds being played
        bool played = false;

        //Set Up Objects
        public struct Projectiles
        {
            public Rectangle area;
            public int xSpeed;
            public int ySpeed;
            public int xStoredSpeed;
            public int yStoredSpeed;
            public int bounce;
            public bool directionY;
            public bool directionX;
            public int r;
            public int g;
            public int b;
        }

        List<Projectiles> projectileList = new List<Projectiles>();
        List<Projectiles> projectileCollisionList = new List<Projectiles>();

        Random rnd = new Random();

        int maxProjectileOnScreen = 25;

        Stopwatch gameTimeCounter = new Stopwatch();

        public Form1()
        {
            InitializeComponent();
            //Initialize p1 and p2
            rocketBlue = new Rectangle(rocketBlueSize * 10, (this.Height / 2) - (rocketBlueSize), 35, 50);
            rocketRed = new Rectangle(this.Width - rocketRedSize * 10, (this.Height / 2) - (rocketRedSize), 35, 50);
            rocketBlueStartingPosition = new Rectangle(rocketBlueSize * 10, (this.Height / 2) - (rocketBlueSize), 35, 50);
            rocketRedStartingPosition = new Rectangle(this.Width - rocketRedSize * 10, (this.Height / 2) - (rocketRedSize), 35, 50);

            //Initialize animations
            p1Orient[0] = Properties.Resources._1_1;
            p1Orient[1] = Properties.Resources._1_2;
            p1Orient[2] = Properties.Resources._1_3;
            p1Orient[3] = Properties.Resources._1_4;
            p1Orient[4] = Properties.Resources._1_5;
            p1Orient[5] = Properties.Resources._1_6;
            p1Orient[6] = Properties.Resources._1_7;
            p1Orient[7] = Properties.Resources._1_8;
            p1Orient[8] = Properties.Resources._1_9;
            p1Orient[9] = Properties.Resources._1_10;
            p1Orient[10] = Properties.Resources._1_11;
            p1Orient[11] = Properties.Resources._1_12;
            p1Orient[12] = Properties.Resources._1_13;
            p1Orient[13] = Properties.Resources._1_14;
            p1Orient[14] = Properties.Resources._1_15;
            p1Orient[15] = Properties.Resources._1_16;
            p1Orient[16] = Properties.Resources._1_17;
            p1Orient[17] = Properties.Resources._1_18;
            p1Orient[18] = Properties.Resources._1_19;
            p1Orient[19] = Properties.Resources._1_20;
            p1Orient[20] = Properties.Resources._1_21;
            p1Orient[21] = Properties.Resources._1_22;
            p1Orient[22] = Properties.Resources._1_23;
            p1Orient[23] = Properties.Resources._1_24;
            p1Orient[24] = Properties.Resources._1_25;
            p1Orient[25] = Properties.Resources._1_26;
            p1Orient[26] = Properties.Resources._1_27;
            p1Orient[27] = Properties.Resources._1_28;
            p1Orient[28] = Properties.Resources._1_29;

            p2Orient[0] = Properties.Resources._2___1_;
            p2Orient[1] = Properties.Resources._2___2_;
            p2Orient[2] = Properties.Resources._2___3_;
            p2Orient[3] = Properties.Resources._2___4_;
            p2Orient[4] = Properties.Resources._2___5_;
            p2Orient[5] = Properties.Resources._2___6_;
            p2Orient[6] = Properties.Resources._2___7_;
            p2Orient[7] = Properties.Resources._2___8_;
            p2Orient[8] = Properties.Resources._2___9_;
            p2Orient[9] = Properties.Resources._2___10_;
            p2Orient[10] = Properties.Resources._2___11_;
            p2Orient[11] = Properties.Resources._2___12_;
            p2Orient[12] = Properties.Resources._2___13_;
            p2Orient[13] = Properties.Resources._2___14_;
            p2Orient[14] = Properties.Resources._2___15_;
            p2Orient[15] = Properties.Resources._2___16_;
            p2Orient[16] = Properties.Resources._2___17_;
            p2Orient[17] = Properties.Resources._2___18_;
            p2Orient[18] = Properties.Resources._2___19_;
            p2Orient[19] = Properties.Resources._2___20_;
            p2Orient[20] = Properties.Resources._2___21_;
            p2Orient[21] = Properties.Resources._2___22_;
            p2Orient[22] = Properties.Resources._2___23_;
            p2Orient[23] = Properties.Resources._2___24_;
            p2Orient[24] = Properties.Resources._2___25_;
            p2Orient[25] = Properties.Resources._2___26_;
            p2Orient[26] = Properties.Resources._2___27_;
            p2Orient[27] = Properties.Resources._2___28_;
            p2Orient[28] = Properties.Resources._2___29_;

            Refresh();
            Reset();
            systemOperator.Enabled = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
                case Keys.I:
                    iDown = true;
                    break;
                case Keys.J:
                    jDown = true;
                    break;
                case Keys.K:
                    kDown = true;
                    break;
                case Keys.L:
                    lDown = true;
                    break;
                case Keys.Enter:
                    enterDown = true;
                    break;
                case Keys.Escape:
                    escapeDown = true;
                    break;
                case Keys.Up:
                    upDown = true;
                    break;
                case Keys.Down:
                    downDown = true;
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
                case Keys.I:
                    iDown = false;
                    break;
                case Keys.J:
                    jDown = false;
                    break;
                case Keys.K:
                    kDown = false;
                    break;
                case Keys.L:
                    lDown = false;
                    break;
                case Keys.Enter:
                    enterDown = false;
                    break;
                case Keys.Escape:
                    escapeDown = false;
                    break;
                case Keys.Up:
                    upDown = false;
                    break;
                case Keys.Down:
                    downDown = false;
                    break;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //Move Players
            p1.Location = new Point(rocketBlue.X, rocketBlue.Y);
            p2.Location = new Point(rocketRed.X, rocketRed.Y);

            //Paint Projectiles
            for (int i = 0; i < projectileList.Count; i++)
            {
                e.Graphics.FillPie(new SolidBrush(Color.FromArgb(255, projectileList[i].r, projectileList[i].g, projectileList[i].b)), projectileList[i].area, rnd.Next(0, 360), rnd.Next(0, 360));
            }

            for (int i = 0; i < projectileCollisionList.Count; i++)
            {
                e.Graphics.FillPie(new SolidBrush(Color.FromArgb(255, projectileCollisionList[i].r, projectileCollisionList[i].g, projectileCollisionList[i].b)), projectileCollisionList[i].area, rnd.Next(0, 360), rnd.Next(0, 360));
            }

            //Draw Mid Line
            e.Graphics.DrawLine(new Pen(Color.Purple, 10), new Point(this.Width / 2, 0), new Point(this.Width / 2, this.Height));

            //Draw Status Bars
            if (rocketBlueHit == false)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Purple), new Rectangle(0, this.Height - p1.Height * 2, this.Width / 2, p1.Height * 2));
                rocketBlueOrientPositive = true;
            }
            else if (rocketBlueHit == true)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Red), new Rectangle(0, this.Height - p1.Height * 2, this.Width / 2, p1.Height * 2));
                rocketBlueOrientPositive = false;
            }

            if (rocketRedHit == false)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Purple), new Rectangle(this.Width / 2, this.Height - p1.Height * 2, this.Width / 2, p1.Height * 2));
                rocketRedOrientPositive = false;
            }
            else if (rocketRedHit == true)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Red), new Rectangle(this.Width / 2, this.Height - p1.Height * 2, this.Width / 2, p1.Height * 2));
                rocketRedOrientPositive = true;
            }
        }

        private void gameOperator_Tick(object sender, EventArgs e)
        {
            if (rocketBlueHit == false)
            {
                //Change Stored
                if (wDown == false && sDown == false && rocketBlueStoredSpeedY != 0)
                {
                    if (rocketBlueStoredSpeedY < 0)
                    {
                        rocketBlueStoredSpeedY++;
                    }
                }

                if (aDown == false && dDown == false && rocketBlueStoredSpeedX != 0)
                {
                    if (rocketBlueStoredSpeedX > 0)
                    {
                        rocketBlueStoredSpeedX--;
                    }
                    else
                    {
                        rocketBlueStoredSpeedX++;
                    }
                }

                if (rocketBlueStoredSpeedY > 25)
                {
                    rocketBlueStoredSpeedY = 25;
                }

                moveHolderRocketBlueX += rocketBlueStoredSpeedX;
                moveHolderRocketBlueY += rocketBlueStoredSpeedY;

                if (sDown == true)
                {
                    if (rocketBlueStoredSpeedY < 0)
                    {
                        rocketBlueStoredSpeedY += 5;
                    }
                }

                //Move
                if (wDown == true)
                {
                    moveHolderRocketBlueY -= rocketBlueSpeedY;
                    rocketBlueStoredSpeedY--;
                }
                else
                {
                    rocketBlueStoredSpeedY++;
                }

                if (rocketBlueSpin.cooldown == 0)
                {
                    if (rocketBlueSpin.spinTime == 0)
                    {
                        if (aDown == true)
                        {
                            rocketBlueSpin.spinTime = spinTime;
                            rocketBlueSpin.direction = "LEFT";
                        }

                        if (dDown == true)
                        {
                            rocketBlueSpin.spinTime = spinTime;
                            rocketBlueSpin.direction = "RIGHT";
                        }
                    }
                    else
                    {
                        if (rocketBlueSpin.direction == "RIGHT")
                        {
                            rocketBlueStoredSpeedX += 2;
                            moveHolderRocketBlueX += rocketBlueStoredSpeedX;
                            moveHolderRocketBlueX += rocketBlueSpeedX;

                        }
                        else if (rocketBlueSpin.direction == "LEFT")
                        {
                            rocketBlueStoredSpeedX -= 2;
                            moveHolderRocketBlueX += rocketBlueStoredSpeedX;
                            moveHolderRocketBlueX -= rocketBlueSpeedX;
                        }
                        rocketBlueSpin.spinTime--;

                        if (rocketBlueSpin.spinTime == 0)
                        {
                            rocketBlueSpin.cooldown = cooldownTime;
                            if (rocketBlueSpin.direction == "LEFT" && dDown == true)
                            {
                                rocketBlueStoredSpeedX = 25;
                            }
                            else if (rocketBlueSpin.direction == "RIGHT" && aDown == true)
                            {
                                rocketBlueStoredSpeedX = -25;
                            }
                            else if (rocketBlueSpin.direction == "LEFT")
                            {
                                rocketBlueStoredSpeedX = -15;
                            }
                            else
                            {
                                rocketBlueStoredSpeedX = 15;
                            }
                        }
                    }
                }
                else
                {
                    rocketBlueSpin.cooldown--;

                    if (rocketBlueStoredSpeedX > 0)
                    {
                        rocketBlueStoredSpeedX -= 10;
                    }
                    else if (rocketBlueStoredSpeedX < 0)
                    {
                        rocketBlueStoredSpeedX += 10;
                    }
                }
            }

            else
            {
                rocketBlueStoredSpeedY++;
                if (rocketBlue.Y > this.Height - rocketBlue.Height * 3)
                {
                    rocketBlueHit = false;
                    rocketBlue.Y = this.Height - rocketBlue.Height * 2;
                }
                moveHolderRocketBlueY += rocketBlueStoredSpeedY;
            }
            rocketBlue.X += moveHolderRocketBlueX;
            rocketBlue.Y += moveHolderRocketBlueY;
            rocketBlue.Y += rocketBlueSpeedY;

            //Restart moveholder
            moveHolderRocketBlueX = 0;
            moveHolderRocketBlueY = 0;

            //Check Wall Collision
            if (rocketBlue.Y > this.Height - rocketBlue.Height * 2)
            {
                rocketBlue.Y = this.Height - rocketBlue.Height * 2;
            }

            if (rocketBlue.X > this.Width / 2 - rocketBlue.Width / 2)
            {
                rocketBlue.X = this.Width / 2 - rocketBlue.Width / 2;
            }

            if (rocketBlue.X < 0)
            {
                rocketBlue.X = 0;
            }

            //Change Stored
            if (iDown == false && kDown == false && rocketRedStoredSpeedY != 0)
            {
                if (rocketRedStoredSpeedY < 0)
                {
                    rocketRedStoredSpeedY++;
                }
            }

            if (jDown == false && lDown == false && rocketRedStoredSpeedX != 0)
            {
                if (rocketRedStoredSpeedX > 0)
                {
                    rocketRedStoredSpeedX--;
                }
                else
                {
                    rocketRedStoredSpeedX++;
                }
            }

            if (rocketRedStoredSpeedY > 25)
            {
                rocketRedStoredSpeedY = 25;
            }

            moveHolderRocketRedX += rocketRedStoredSpeedX;
            moveHolderRocketRedY += rocketRedStoredSpeedY;

            if (kDown == true)
            {
                if (rocketRedStoredSpeedY < 0)
                {
                    rocketRedStoredSpeedY += 5;
                }
            }

            //Move
            if (iDown == true)
            {
                moveHolderRocketRedY -= rocketRedSpeedY;
                rocketRedStoredSpeedY--;
            }
            else
            {
                rocketRedStoredSpeedY++;
            }

            if (rocketRedHit == false)
            {
                if (rocketRedSpin.cooldown == 0)
                {
                    if (rocketRedSpin.spinTime == 0)
                    {
                        if (jDown == true)
                        {
                            rocketRedSpin.spinTime = spinTime;
                            rocketRedSpin.direction = "LEFT";
                        }

                        if (lDown == true)
                        {
                            rocketRedSpin.spinTime = spinTime;
                            rocketRedSpin.direction = "RIGHT";
                        }
                    }
                    else
                    {
                        if (rocketRedSpin.direction == "RIGHT")
                        {
                            rocketRedStoredSpeedX += 2;
                            moveHolderRocketRedX += rocketRedStoredSpeedX;
                            moveHolderRocketRedX += rocketRedSpeedX;

                        }
                        else if (rocketRedSpin.direction == "LEFT")
                        {
                            rocketRedStoredSpeedX -= 2;
                            moveHolderRocketRedX += rocketRedStoredSpeedX;
                            moveHolderRocketRedX -= rocketRedSpeedX;
                        }
                        rocketRedSpin.spinTime--;

                        if (rocketRedSpin.spinTime == 0)
                        {
                            rocketRedSpin.cooldown = cooldownTime;
                            if (rocketRedSpin.direction == "LEFT" && lDown == true)
                            {
                                rocketRedStoredSpeedX = 25;
                            }
                            else if (rocketRedSpin.direction == "RIGHT" && jDown == true)
                            {
                                rocketRedStoredSpeedX = -25;
                            }
                            else if (rocketRedSpin.direction == "LEFT")
                            {
                                rocketRedStoredSpeedX = -15;
                            }
                            else
                            {
                                rocketRedStoredSpeedX = 15;
                            }
                        }
                    }
                }
                else
                {
                    rocketRedSpin.cooldown--;

                    if (rocketRedStoredSpeedX > 0)
                    {
                        rocketRedStoredSpeedX -= 5;
                    }
                    else if (rocketRedStoredSpeedX < 0)
                    {
                        rocketRedStoredSpeedX += 5;
                    }
                }
            }
            else
            {
                rocketRedStoredSpeedY++;
                if (rocketRed.Y > this.Height - rocketRed.Height * 3)
                {
                    rocketRedHit = false;
                    rocketRed.Y = this.Height - rocketRed.Height * 2;
                }
                moveHolderRocketRedY += rocketRedStoredSpeedY;
            }

            rocketRed.X += moveHolderRocketRedX;
            rocketRed.Y += moveHolderRocketRedY;
            rocketRed.Y += rocketRedSpeedY;

            //Restart moveholder
            moveHolderRocketRedX = 0;
            moveHolderRocketRedY = 0;

            //Check Wall Collision
            if (rocketRed.Y > this.Height - rocketRed.Height * 2)
            {
                rocketRed.Y = this.Height - rocketRed.Height * 2;
            }

            if (rocketRed.X > this.Width - rocketRed.Width * 2)
            {
                rocketRed.X = this.Width - rocketRed.Width * 2;
            }

            if (rocketRed.X < this.Width / 2)
            {
                rocketRed.X = this.Width / 2;
            }

            //Orient Rocket
            p1.BackgroundImage = p1Orient[rocketBlueOrientation];
            p2.BackgroundImage = p2Orient[rocketRedOrientation];

            if (rocketBlueOrientPositive == true)
            {
                rocketBlueOrientation++;
                if (rocketBlueOrientation > 28)
                {
                    rocketBlueOrientation = 0;
                }
            }
            else
            {
                rocketBlueOrientation--;
                if (rocketBlueOrientation < 0)
                {
                    rocketBlueOrientation = 28;
                }
            }

            if (rocketRedOrientPositive == true)
            {
                rocketRedOrientation++;
                if (rocketRedOrientation > 28)
                {
                    rocketRedOrientation = 0;
                }
            }
            else
            {
                rocketRedOrientation--;
                if (rocketRedOrientation < 0)
                {
                    rocketRedOrientation = 28;
                }
            }

            //Check for rockets colliding
            if (rocketRed.IntersectsWith(rocketBlue) || rocketBlue.IntersectsWith(rocketRed))
            {
                if (rocketBlueStoredSpeedX + rocketBlueStoredSpeedY > rocketRedStoredSpeedX + rocketRedStoredSpeedY)
                {
                    rocketRedHit = true;
                    hit.Play();

                    if (rocketBlue.X < rocketRed.X)
                    {
                        rocketRedStoredSpeedX = 25;
                    }
                    else
                    {
                        rocketRedStoredSpeedX = -25;
                    }
                }
                else if (rocketBlueStoredSpeedX + rocketBlueStoredSpeedY < rocketRedStoredSpeedX + rocketRedStoredSpeedY)
                {
                    rocketBlueHit = true;
                    hit.Play();

                    if (rocketBlue.X < rocketRed.X)
                    {
                        rocketBlueStoredSpeedX = -25;
                    }
                    else
                    {
                        rocketBlueStoredSpeedX = 25;
                    }
                }
                else
                {
                    rocketRedHit = true;
                    rocketBlueHit = true;
                    hit.Play();

                    if (rocketBlue.X < rocketRed.X)
                    {
                        rocketBlueStoredSpeedX = -25;
                        rocketRedStoredSpeedX = 25;
                    }
                    else
                    {
                        rocketBlueStoredSpeedX = 25;
                        rocketRedStoredSpeedX = -25;
                    }
                }
            }

            //If projectiles are low, Spawn
            if (projectileList.Count < 5)
            {
                SpawnObject();
            }

            //Move Projectiles
            for (int i = 0; i < projectileList.Count; i++)
            {
                Projectiles projectileStorer = projectileList[i];

                projectileStorer.area.X += projectileStorer.xSpeed;
                projectileStorer.area.X += projectileStorer.xStoredSpeed;
                projectileStorer.area.Y += projectileStorer.ySpeed;
                projectileStorer.area.Y += projectileStorer.yStoredSpeed;

                if (projectileStorer.xSpeed > 0)
                {
                    projectileStorer.xStoredSpeed++;
                }
                if (projectileStorer.xSpeed < 0)
                {
                    projectileStorer.xStoredSpeed--;
                }

                if (projectileStorer.ySpeed > 0)
                {
                    projectileStorer.yStoredSpeed++;
                }
                if (projectileStorer.ySpeed < 0)
                {
                    projectileStorer.yStoredSpeed--;
                }

                //Change Colour Slightly
                int randOper = rnd.Next(0, 2);
                switch (randOper)
                {
                    case 0:
                        projectileStorer.r += 25;
                        if (projectileStorer.r > 255)
                        {
                            projectileStorer.r = 255;
                        }
                        break;
                    case 1:
                        projectileStorer.r -= 25;
                        if (projectileStorer.r < 0)
                        {
                            projectileStorer.r = 0;
                        }
                        break;
                }

                randOper = rnd.Next(0, 2);
                switch (randOper)
                {
                    case 0:
                        projectileStorer.g += 25;
                        if (projectileStorer.g > 255)
                        {
                            projectileStorer.g = 255;
                        }
                        break;
                    case 1:
                        projectileStorer.g -= 25;
                        if (projectileStorer.g < 0)
                        {
                            projectileStorer.g = 0;
                        }
                        break;
                }

                randOper = rnd.Next(0, 2);
                switch (randOper)
                {
                    case 0:
                        projectileStorer.b += 25;
                        if (projectileStorer.b > 255)
                        {
                            projectileStorer.b = 255;
                        }
                        break;
                    case 1:
                        projectileStorer.b -= 25;
                        if (projectileStorer.b < 0)
                        {
                            projectileStorer.b = 0;
                        }
                        break;
                }

                int accelerationDepleter = rnd.Next(1, 11);

                if (projectileStorer.area.X < 0)
                {
                    if (projectileStorer.bounce > 0)
                    {
                        projectileStorer.area.X = 0;
                        projectileStorer.xSpeed *= -1;
                        projectileStorer.xStoredSpeed *= -1;
                        projectileStorer.xStoredSpeed /= accelerationDepleter;
                        projectileStorer.bounce--;
                    }
                    else
                    {
                        if (projectileStorer.bounce < 0 == false && projectileList.Count < maxProjectileOnScreen)
                        {
                            SpawnObject();
                            projectileStorer.bounce--;
                        }
                        else if (projectileStorer.bounce < 0 == false)
                        {
                            projectileStorer.bounce--;
                        }
                    }
                }

                if (projectileStorer.area.X > this.Width - projectileStorer.area.Width)
                {
                    if (projectileStorer.bounce > 0)
                    {
                        projectileStorer.area.X = this.Width - projectileStorer.area.Width;
                        projectileStorer.xSpeed *= -1;
                        projectileStorer.xStoredSpeed *= -1;
                        projectileStorer.xStoredSpeed /= accelerationDepleter;
                        projectileStorer.bounce--;
                    }
                    else
                    {
                        if (projectileStorer.bounce < 0 == false && projectileList.Count < maxProjectileOnScreen)
                        {
                            SpawnObject();
                            projectileStorer.bounce--;
                        }
                        else if (projectileStorer.bounce < 0 == false)
                        {
                            projectileStorer.bounce--;
                        }
                    }
                }

                if (projectileStorer.area.Y < 0)
                {
                    if (projectileStorer.bounce > 0)
                    {
                        projectileStorer.area.Y = 0;
                        projectileStorer.ySpeed *= -1;
                        projectileStorer.yStoredSpeed *= -1;
                        projectileStorer.yStoredSpeed /= accelerationDepleter;
                        projectileStorer.bounce--;
                    }
                    else
                    {
                        if (projectileStorer.bounce < 0 == false && projectileList.Count < maxProjectileOnScreen)
                        {
                            SpawnObject();
                            projectileStorer.bounce--;
                        }
                        else if (projectileStorer.bounce < 0 == false)
                        {
                            projectileStorer.bounce--;
                        }
                    }
                }

                if (projectileStorer.area.Y > this.Height - projectileStorer.area.Height)
                {
                    if (projectileStorer.bounce > 0)
                    {
                        projectileStorer.area.Y = this.Height - projectileStorer.area.Height;
                        projectileStorer.ySpeed *= -1;
                        projectileStorer.yStoredSpeed *= -1;
                        projectileStorer.yStoredSpeed /= accelerationDepleter;
                        projectileStorer.bounce--;
                    }
                    else
                    {
                        if (projectileStorer.bounce < 0 == false && projectileList.Count < maxProjectileOnScreen)
                        {
                            SpawnObject();
                            projectileStorer.bounce--;
                        }
                        else if (projectileStorer.bounce < 0 == false)
                        {
                            projectileStorer.bounce--;
                        }
                    }
                }


                if (projectileStorer.bounce < 0 == false)
                {
                    projectileList[i] = projectileStorer;
                }
                else
                {
                    projectileList.Remove(projectileList[i]);
                }
            }

            //Change the values of a Collision Projectile
            for (int i = 0; i < projectileCollisionList.Count; i++)
            {
                Projectiles projectileStorer = projectileCollisionList[i];

                projectileStorer.area.X += projectileStorer.xSpeed;
                projectileStorer.area.X += projectileStorer.xStoredSpeed;
                projectileStorer.area.Y += projectileStorer.ySpeed;
                projectileStorer.area.Y += projectileStorer.yStoredSpeed;

                if (projectileStorer.xSpeed > 0)
                {
                    projectileStorer.xStoredSpeed++;
                }
                if (projectileStorer.xSpeed < 0)
                {
                    projectileStorer.xStoredSpeed--;
                }

                if (projectileStorer.ySpeed > 0)
                {
                    projectileStorer.yStoredSpeed++;
                }
                if (projectileStorer.ySpeed < 0)
                {
                    projectileStorer.yStoredSpeed--;
                }

                //Change Colour Slightly
                int randOper = rnd.Next(0, 2);
                switch (randOper)
                {
                    case 0:
                        projectileStorer.r += 25;
                        if (projectileStorer.r > 255)
                        {
                            projectileStorer.r = 255;
                        }
                        break;
                    case 1:
                        projectileStorer.r -= 25;
                        if (projectileStorer.r < 0)
                        {
                            projectileStorer.r = 0;
                        }
                        break;
                }

                randOper = rnd.Next(0, 2);
                switch (randOper)
                {
                    case 0:
                        projectileStorer.g += 25;
                        if (projectileStorer.g > 255)
                        {
                            projectileStorer.g = 255;
                        }
                        break;
                    case 1:
                        projectileStorer.g -= 25;
                        if (projectileStorer.g < 0)
                        {
                            projectileStorer.g = 0;
                        }
                        break;
                }

                randOper = rnd.Next(0, 2);
                switch (randOper)
                {
                    case 0:
                        projectileStorer.b += 25;
                        if (projectileStorer.b > 255)
                        {
                            projectileStorer.b = 255;
                        }
                        break;
                    case 1:
                        projectileStorer.b -= 25;
                        if (projectileStorer.b < 0)
                        {
                            projectileStorer.b = 0;
                        }
                        break;
                }

                int accelerationDepleter = rnd.Next(1, 11);

                if (projectileStorer.area.X < 0)
                {
                    if (projectileStorer.bounce > 0)
                    {
                        projectileStorer.area.X = 0;
                        projectileStorer.xSpeed *= -1;
                        projectileStorer.xStoredSpeed *= -1;
                        projectileStorer.xStoredSpeed /= accelerationDepleter;
                        projectileStorer.bounce--;
                    }
                    else
                    {
                        if (projectileStorer.bounce < 0 == false)
                        {
                            projectileStorer.bounce--;
                        }
                    }
                }

                if (projectileStorer.area.X > this.Width - projectileStorer.area.Width)
                {
                    if (projectileStorer.bounce > 0)
                    {
                        projectileStorer.area.X = this.Width - projectileStorer.area.Width;
                        projectileStorer.xSpeed *= -1;
                        projectileStorer.xStoredSpeed *= -1;
                        projectileStorer.xStoredSpeed /= accelerationDepleter;
                        projectileStorer.bounce--;
                    }
                    else
                    {
                        if (projectileStorer.bounce < 0 == false)
                        {
                            projectileStorer.bounce--;
                        }
                    }
                }

                if (projectileStorer.area.Y < 0)
                {
                    if (projectileStorer.bounce > 0)
                    {
                        projectileStorer.area.Y = 0;
                        projectileStorer.ySpeed *= -1;
                        projectileStorer.yStoredSpeed *= -1;
                        projectileStorer.yStoredSpeed /= accelerationDepleter;
                        projectileStorer.bounce--;
                    }
                    else
                    {
                        if (projectileStorer.bounce < 0 == false)
                        {
                            projectileStorer.bounce--;
                        }
                    }
                }

                if (projectileStorer.area.Y > this.Height - projectileStorer.area.Height)
                {
                    if (projectileStorer.bounce > 0)
                    {
                        projectileStorer.area.Y = this.Height - projectileStorer.area.Height;
                        projectileStorer.ySpeed *= -1;
                        projectileStorer.yStoredSpeed *= -1;
                        projectileStorer.yStoredSpeed /= accelerationDepleter;
                        projectileStorer.bounce--;
                    }
                    else
                    {
                        if (projectileStorer.bounce < 0 == false)
                        {
                            projectileStorer.bounce--;
                        }
                    }
                }


                if (projectileStorer.bounce < 0 == false)
                {
                    projectileCollisionList[i] = projectileStorer;
                }
                else
                {
                    projectileCollisionList.Remove(projectileCollisionList[i]);
                }
            }

            //Check Collision
            for (int i = 0; i < projectileList.Count; i++)
            {
                for (int o = i + 1; o < projectileList.Count; o++)
                {
                    if (projectileList[i].area.IntersectsWith(projectileList[o].area) && o <= projectileList.Count - 1)
                    {
                        SpawnCollisionObject(projectileList[i].area.X, projectileList[i].area.Y);
                        projectileList.RemoveAt(i);
                        projectileList.RemoveAt(o - 1);
                    }
                }
            }

            for (int i = 0; i < projectileList.Count; i++)
            {
                if (projectileList[i].area.IntersectsWith(rocketBlue) && rocketBlueSpin.spinTime <= 0)
                {
                    rocketBlueHit = true;
                    hit.Play();
                }

                if (projectileList[i].area.IntersectsWith(rocketRed) && rocketRedSpin.spinTime <= 0)
                {
                    rocketRedHit = true;
                    hit.Play();
                }
            }

            for (int i = 0; i < projectileCollisionList.Count; i++)
            {
                if (projectileCollisionList[i].area.IntersectsWith(rocketBlue) && rocketBlueSpin.spinTime <= 0)
                {
                    rocketBlueHit = true;
                    hit.Play();
                }

                if (projectileCollisionList[i].area.IntersectsWith(rocketRed) && rocketRedSpin.spinTime <= 0)
                {
                    rocketRedHit = true;
                    hit.Play();
                }
            }

            //Check for Score 
            if (rocketBlue.Y < 0 && rocketBlueHit == false)
            {
                rocketBlueHit = true;
                thrust.Play();
                blueScore++;
            }

            if (rocketRed.Y < 0 && rocketRedHit == false)
            {
                rocketBlueHit = true;
                thrust.Play();
                redScore++;
            }

            //Update Score
            p1ScoreLabel.Text = $"{blueScore}";
            p2ScoreLabel.Text = $"{redScore}";

            Refresh();
        }

        public void SpawnObject()
        {
            //Determine Random Spawn
            int spawnRate = rnd.Next(0, maxSpwanPerTick + 2);
            for (int i = 1; i <= spawnRate; i++)
            {
                //Determine Limits
                //Ints for changing spawn limits
                int maxSpeed = 5 + 1;
                int maxBounce = 5 + 1;

                int randomOperator = rnd.Next(0, 2);

                bool directionX = true;
                switch (randomOperator)
                {
                    case 0:
                        directionX = true;
                        break;
                    case 1:
                        directionX = false;
                        break;
                }

                randomOperator = rnd.Next(0, 2);
                bool directionY = true;
                switch (randomOperator)
                {
                    case 0:
                        directionY = true;
                        break;
                    case 1:
                        directionY = false;
                        break;
                }

                int maxWidth = 55;
                int minWidth = 25;
                int maxHeight = maxWidth * 2;
                int minHeight = minWidth * 2;

                int projectileWidth = rnd.Next(minWidth, maxWidth);
                int projectileHeight = rnd.Next(minHeight, maxHeight);

                //Genrate Projectile based on Y direction
                if (directionY == true)
                {
                    Rectangle generator = new Rectangle(0, rnd.Next(0, this.Height - projectileHeight - (p1.Height * 5)), projectileWidth, projectileHeight);
                    Projectiles projectileGenerator = new Projectiles();
                    projectileGenerator.area = generator;
                    projectileGenerator.xSpeed = rnd.Next(1, maxSpeed);
                    projectileGenerator.ySpeed = rnd.Next(1, maxSpeed);
                    projectileGenerator.xStoredSpeed = rnd.Next(1, maxSpeed);
                    projectileGenerator.yStoredSpeed = rnd.Next(1, maxSpeed);
                    projectileGenerator.bounce = rnd.Next(1, maxBounce);
                    projectileGenerator.directionX = directionX;
                    projectileGenerator.directionX = directionY;
                    projectileGenerator.r = rnd.Next(1, 255);
                    projectileGenerator.g = rnd.Next(1, 255);
                    projectileGenerator.b = rnd.Next(1, 255);
                    projectileList.Add(projectileGenerator);
                }
                else
                {
                    Rectangle generator = new Rectangle(this.Width - projectileWidth, rnd.Next(0, this.Height - projectileHeight - (p1.Height * 5)), projectileWidth, projectileHeight);
                    Projectiles projectileGenerator = new Projectiles();
                    projectileGenerator.area = generator;
                    projectileGenerator.xSpeed = rnd.Next(-maxSpeed, 1);
                    projectileGenerator.ySpeed = rnd.Next(-maxSpeed, 1);
                    projectileGenerator.xStoredSpeed = rnd.Next(-maxSpeed, 1);
                    projectileGenerator.yStoredSpeed = rnd.Next(-maxSpeed, 1);
                    projectileGenerator.bounce = rnd.Next(5, maxBounce + 1);
                    projectileGenerator.directionX = directionX;
                    projectileGenerator.directionX = directionY;
                    projectileList.Add(projectileGenerator);
                }
            }
        }

        public void SpawnCollisionObject(int x, int y)
        {
            //Spawn random number of projectiles
            int spawnRate = rnd.Next(0, 10);
            for (int i = 1; i <= spawnRate; i++)
            {
                //Determine proper Limits
                //Ints for changing spwan limits
                int maxSpeed = 5 + 1;
                int maxBounce = 1;

                int randomOperator = rnd.Next(0, 2);

                bool directionX = true;
                switch (randomOperator)
                {
                    case 0:
                        directionX = true;
                        break;
                    case 1:
                        directionX = false;
                        break;
                }

                randomOperator = rnd.Next(0, 2);
                bool directionY = true;
                switch (randomOperator)
                {
                    case 0:
                        directionY = true;
                        break;
                    case 1:
                        directionY = false;
                        break;
                }

                int maxWidth = 30;
                int minWidth = 10;
                int maxHeight = maxWidth;
                int minHeight = minWidth;

                int projectileWidth = rnd.Next(minWidth, maxWidth);
                int projectileHeight = rnd.Next(minHeight, maxHeight);

                //Generate Projectile Based on Y direction
                if (directionY == true)
                {
                    Rectangle generator = new Rectangle(x, y, projectileWidth, projectileHeight);
                    Projectiles projectileGenerator = new Projectiles();
                    projectileGenerator.area = generator;
                    projectileGenerator.xSpeed = rnd.Next(1, maxSpeed);
                    projectileGenerator.ySpeed = rnd.Next(1, maxSpeed);
                    projectileGenerator.xStoredSpeed = rnd.Next(1, maxSpeed);
                    projectileGenerator.yStoredSpeed = rnd.Next(1, maxSpeed);
                    projectileGenerator.bounce = rnd.Next(0, maxBounce + 2);
                    projectileGenerator.directionX = directionX;
                    projectileGenerator.directionX = directionY;
                    projectileGenerator.r = rnd.Next(1, 255);
                    projectileGenerator.g = rnd.Next(1, 255);
                    projectileGenerator.b = rnd.Next(1, 255);
                    projectileCollisionList.Add(projectileGenerator);
                }
                else
                {
                    Rectangle generator = new Rectangle(x, y, projectileWidth, projectileHeight);
                    Projectiles projectileGenerator = new Projectiles();
                    projectileGenerator.area = generator;
                    projectileGenerator.xSpeed = rnd.Next(-maxSpeed, 1);
                    projectileGenerator.ySpeed = rnd.Next(-maxSpeed, 1);
                    projectileGenerator.xStoredSpeed = rnd.Next(-maxSpeed, 0);
                    projectileGenerator.yStoredSpeed = rnd.Next(-maxSpeed, 0);
                    projectileGenerator.bounce = rnd.Next(0, maxBounce + 2);
                    projectileGenerator.directionX = directionX;
                    projectileGenerator.directionX = directionY;
                    projectileCollisionList.Add(projectileGenerator);
                }
            }
        }

        void Reset()
        {
            rocketBlueSpin.spinTime = 0;
            rocketRedSpin.spinTime = 0;
            blueScore = 0;
            redScore = 0;
            gameTimeCounter.Reset();
            played = false;
            rocketBlue = rocketBlueStartingPosition;
            rocketRed = rocketRedStartingPosition;
            projectileList.Clear();
            projectileCollisionList.Clear();
        }

        private void systemOperator_Tick(object sender, EventArgs e)
        {
            if (gameStarter.Tag == "0")
            {
                //Play intro Sound
                if (played == false)
                {
                    JFK.Load();
                    JFK.Play();
                    played = true;
                }

                //Show or Hide Elements
                startPrompt.Text = "SPACE RACE\r\n\r\n:PRESS ENTER TO PLAY:\r\n\r\n:ESC TO EXIT:";

                p1ScoreLabel.Parent = this;
                p2ScoreLabel.Parent = this;

                if (startEndBack.Visible == false)
                {
                    startEndBack.Visible = true;
                }

                if (startPrompt.Visible == false)
                {
                    startPrompt.Visible = true;
                }

                if (gameStarter.Enabled == false)
                {
                    gameStarter.Enabled = true;
                }

                if (gameOperator.Enabled == true)
                {
                    gameOperator.Enabled = false;
                }

                if (gameEnder.Enabled == true)
                {
                    gameEnder.Enabled = false;
                }

                if (upDown == true)
                {
                    maxSpwanPerTick++;
                }

                if (downDown == true)
                {
                    maxSpwanPerTick--;
                }

                if (maxSpwanPerTick < 0)
                {
                    maxSpwanPerTick = 0;
                }

                if (gameWinnerLabel.Visible == true)
                {
                    gameWinnerLabel.Visible = false;
                }

                timeDisplay.Text = $"{gameTimeCounter.ElapsedMilliseconds}";
            }
            else if (gameOperator.Tag == "0")
            {
                //Load Sounds
                thrust.Load();
                hit.Load();

                //Activate, Show, or Hide Elements
                if (gameTimeCounter.IsRunning == false)
                {
                    gameTimeCounter.Start();
                }

                if (startEndBack.Visible == true)
                {
                    startEndBack.Visible = false;
                }

                if (startPrompt.Visible == true)
                {
                    startPrompt.Visible = false;
                }

                if (gameStarter.Enabled == true)
                {
                    gameStarter.Enabled = false;
                }

                if (gameOperator.Enabled == false)
                {
                    gameOperator.Enabled = true;
                }

                if (gameEnder.Enabled == true)
                {
                    gameEnder.Enabled = false;
                }

                if (gameWinnerLabel.Visible == true)
                {
                    gameWinnerLabel.Visible = false;
                }

                timeDisplay.Text = $"{gameTimeCounter.Elapsed}";

                if (gameTimeCounter.ElapsedMilliseconds > 150000)
                {
                    gameOperator.Tag = "1";
                }
            }
            else if (gameEnder.Tag == "0")
            {
                //Activate, Show, or Hide Elements
                if (gameTimeCounter.IsRunning == true)
                {
                    gameTimeCounter.Stop();
                }

                startPrompt.Text = "SPACE RACE\r\n\r\n:PRESS ENTER TO PLAY:\r\n\r\n:ESC TO EXIT:";

                if (startPrompt.Visible == false)
                {
                    startPrompt.Visible = true;
                }

                if (gameStarter.Enabled == true)
                {
                    gameStarter.Enabled = false;
                }

                if (gameOperator.Enabled == true)
                {
                    gameOperator.Enabled = false;
                }

                if (gameEnder.Enabled == false)
                {
                    gameEnder.Enabled = true;
                }

                if (gameWinnerLabel.Visible == false)
                {
                    gameWinnerLabel.Visible = true;
                }

                //Display Winner
                if (redScore > blueScore)
                {
                    gameWinnerLabel.Text = "THE SOVIETS WIN THE SPACE RACE";
                    if (played == false)
                    {
                        Soviet.Play();
                        played = true;
                    }
                }
                else if (redScore < blueScore)
                {
                    gameWinnerLabel.Text = "THE UNITED STATES OF AMERICA WIN THE SPACE RACE";
                    if (played == false)
                    {
                        USA.Play();
                        played = true;
                    }
                }
                else
                {
                    gameWinnerLabel.Text = "IT'S A TIE";
                }

                //Allow for repeat or exit
                if (enterDown == true)
                {
                    gameEnder.Tag = "1";
                    enterDown = false;
                }

                if (escapeDown == true)
                {
                    Application.Exit();
                }
            }
            else
            {
                //Reset Operator
                gameStarter.Tag = "0";
                gameOperator.Tag = "0";
                gameEnder.Tag = "0";
                played = false;
            }
        }

        private void gameStarter_Tick(object sender, EventArgs e)
        {
            //Allow for Start or Exit
            if (enterDown == true)
            {
                played = false;
                gameStarter.Tag = "1";
                Reset();
                Refresh();
            }

            if (escapeDown == true)
            {
                Application.Exit();
            }
        }
    }
}
