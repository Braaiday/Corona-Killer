using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Timers;
using System.Media;
using System.Drawing.Drawing2D;


namespace Corona_Killer
{
    public partial class Game_Pierre : Form
    {
        ///Making array Lists for each class
        ArrayList Ingredients = new ArrayList();
        ArrayList Charms = new ArrayList();
        ArrayList Fields = new ArrayList();
        /////////
        ArrayList gamelist = new ArrayList(); //This is the array list that will have the randomized postions for Charms, ingredients and Charms.
        double Score = 0;
        Image newImage;
        int Num;
        string GameWin;
        PictureBox clickedPictureBox;
        Boolean HaveClicked = false;
        int Addtime = 60;
        double HighestScore = 0;
        public Game_Pierre()
        {
            //SoundPlayer splayer = new SoundPlayer("Sounds\\BoxCat.wav");
            //splayer.Play();
            InitializeComponent();
            label1.Text = "0";
            NewGameState();
            
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        /// <summary>
        /// The GenerateGameArray Is a arraylist which makes a array of 100 objects with randomized positions for Fields, Charms and ingrediants.
        /// </summary>
        /// 



        public void PopulateGrid()
        {
            // PictureBox firstClicked, secondClicked;

            PictureBox CurPicture;
            int TableCount = tableLayoutPanel1.Controls.Count;
            for (int i = 0; i < TableCount; i++)
            {
                if (tableLayoutPanel1.Controls[i] is PictureBox)
                {
                    CurPicture = (PictureBox)tableLayoutPanel1.Controls[i];
                    newImage = Image.FromFile("Images\\Tan.png");
                    CurPicture.Image = newImage;
                    //////////////////////////////////////////////////////////////////


                }

            }
        }

        /// <summary>
        /// This Part is going to be for doing the click events for all the images, and calling the appropraite methods
        /// And applying all the modifiers that apply to what has been clicked
        /// :) Still in work
        /// </summary>
        public void NewGameState()
        {
            PopulateGrid();         //Insert the base image into the picture boxes
            timer2.Start();         //Start the timer which keeps track of time in seconds
            ClearAllGameArray();    //Clear all objects in all Array List getting them ready for the new shuffle
            GenerateGameArray();    //This is where all the Array list are populating and the main game Arraylist is shuffled
        }






        private void PictureBox_Click(object sender, EventArgs e)
        {
            ////////////This is to ensure, that we hide thorns and grass the next time a player clicks a piece
            if (HaveClicked == true)
            {
                if (gamelist[Num] is Field_Pierre)
                {
                    newImage = Image.FromFile("Images\\Tan.png");
                    clickedPictureBox.Image = newImage;
                }

            }
            ///////////Intiating variables
            ///
            double Mutator;
            int TableCount = tableLayoutPanel1.Controls.Count;
            clickedPictureBox = sender as PictureBox;
            string sName = clickedPictureBox.Name;
            //This is a nice way of getting the number of the picture box
            sName = sName.TrimStart('p', 'i', 'c', 't', 'u', 'r', 'e', 'B', 'o', 'x');
            Num = int.Parse(sName);
            Num = Num - 1;

            /////////////////////Here is where we find out which type of Piece was clicked and apply the appropriate modifiers to the game. as well as
            /////Displaying the correct image.
            if (tableLayoutPanel1.Controls[Num] is PictureBox)
            {

                //////////////////////////////////////////////////////////////////////////////
                if (gamelist[Num] is Ingredients_Pierre)
                {
                    string Name = ((Ingredients_Pierre)gamelist[Num]).GetName();
                    if (Name == "BlueBerry")
                    {
                        newImage = Image.FromFile("Images\\BlueBerry.png");
                      
                    }
                    if (Name == "BlackBerry")
                    {
                        newImage = Image.FromFile("Images\\BlackBerry.png");
                       
                    }
                    if (Name == "RedBerry")
                    {
                        newImage = Image.FromFile("Images\\RedBerry.png");
                      
                    }
                    if (Name == "YellowBerry")
                    {
                        newImage = Image.FromFile("Images\\YellowBerry.png");
                       
                    }
                    if (Name == "Turnips")
                    {
                        newImage = Image.FromFile("Images\\Turnips.png");
                       
                    }
                    if (Name == "Rose")
                    {
                        newImage = Image.FromFile("Images\\Rose.png");
                   
                    }
                    if (Name == "Ginger")
                    {
                        newImage = Image.FromFile("Images\\Ginger.png");
                        
                    }
                    if (Name == "Garlic")
                    {
                        newImage = Image.FromFile("Images\\Garlic.png");
                      
                    }
                    if (Name == "Beets")
                    {
                        newImage = Image.FromFile("Images\\Beets.png");
                       
                    }
                    if (Name == "SweetPotatoes")
                    {
                        newImage = Image.FromFile("Images\\SweetPotatoes.png");
                       
                    }
                    if (Name == "Onion")
                    {
                        newImage = Image.FromFile("Images\\Onion.png");
                        
                    }
                    clickedPictureBox.Image = newImage;
                    Score = Score + ((Ingredients_Pierre)gamelist[Num]).getPoetency();
                    label6.Text = "You found " + Name;
                    //setting the poetecy of the ingredient to 0 because it has been found
                    ((Ingredients_Pierre)gamelist[Num]).ModifyPoetency(0);
                }
                ///////////////////////////////////////////////////////////////
                ///
                if (gamelist[Num] is Field_Pierre)
                {
                    if (((Field_Pierre)gamelist[Num]).getType() == "Thorns")
                    {
                        newImage = Image.FromFile("Images\\Thorns.png");
                        Mutator = ((Field_Pierre)gamelist[Num]).CalculateMutator();
                        Score = Math.Round(Score * Mutator);


                        label6.Text = "You found Thorns, Ouch!";

                    }
                    else
                    {
                        newImage = Image.FromFile("Images\\Grass.png");

                        label6.Text = "Nothing Here, just grass.";

                    }

                    clickedPictureBox.Image = newImage;
                    HaveClicked = true;

                }

                if (gamelist[Num] is Charms_Pierre)
                {
                    string Name = ((Charms_Pierre)gamelist[Num]).getName();
                    if (Name == "Ocean Amulet")
                    {
                        newImage = Image.FromFile("Images\\OceanAmulet.png");
                        clickedPictureBox.Image = newImage;
                        seconds = seconds + Addtime;
                        Addtime = 0;
                    }

                    if (Name == "Rising Sun Amulet")
                    {
                        newImage = Image.FromFile("Images\\RisingSunAmulet.png");
                        clickedPictureBox.Image = newImage;
                        for (int x = 0; x < gamelist.Count; x++)
                        {
                            if (gamelist[x] is Ingredients_Pierre)
                            {
                                /// so if the poetency is equal to its orginal poetency, we will increase the poetency of the ingrediats to ensure it only icreases poetency one time.
                                if (((Ingredients_Pierre)gamelist[x]).getPoetency() == 40  || (((Ingredients_Pierre)gamelist[x]).getPoetency() == 60 || (((Ingredients_Pierre)gamelist[x]).getPoetency() == 80))) 
                                {
                                    ((Ingredients_Pierre)gamelist[x]).IncreasePoetency();
                                }
                            }
                        }
                    }

                    if (Name == "Snake Poison")
                    {
                        newImage = Image.FromFile("Images\\Snakepoison.png");
                        clickedPictureBox.Image = newImage;
                        Score = 0;
                        seconds = 0;
                        SetScore(Score);
                        timer2.Stop();
                        CalculateGameScoreLoose();
                        //Here we making a Messege box so the play can choose to retry or cancel the game
                        MessageBoxButtons buttons = MessageBoxButtons.RetryCancel;
                        DialogResult result = MessageBox.Show(GameWin, "Sake poison", buttons);
                        if (result == DialogResult.Retry) 
                        {
                            seconds = 60;
                            Score = 0;
                            SetHighScore();
                            label1.Text = "0";
                            NewGameState();
                        }
                        else
                        {
                            Application.Exit();
                        }
                        
                    }

                    if (Name == "Magic Crystal")
                    {
                        newImage = Image.FromFile("Images\\MagicCrystal.png");
                        clickedPictureBox.Image = newImage;
                        //Calculations of score when finding Magic Crystal
                        Score = Score + 200 + (seconds * 2);
                        SetScore(Score);
                        timer2.Stop();
                        GameWin = "You have produced a cure with a poetency of " + Score.ToString();

                        //Here we making a Messege box so the play can choose to retry or cancel the game
                        MessageBoxButtons buttons = MessageBoxButtons.RetryCancel;
                        DialogResult result = MessageBox.Show(GameWin, "Magic Crystal", buttons);
                        if (result == DialogResult.Retry)
                        {
                            SetHighScore(); ///Checking to see if a highscore was made and assign badge if applicable
                            seconds = 60;
                            Score = 0;
                            label1.Text = "0";
                            NewGameState();
                        }
                        else
                        {
                            Application.Exit();
                        }
                        
                    }
                    label6.Text = "You found " + Name;

                }
                ////////////////////////////////////////////////////////////////
                
                
                label1.Text = Score.ToString();
                

            }






        }

        public void ClearAllGameArray()
        {
            gamelist.Clear();
            Ingredients.Clear();
            Charms.Clear();
            Fields.Clear();
        }





        public void GenerateGameArray()
        {
            
            ///Declaring Variavles to be used for randomizing the Arraylist.
            Random num = new Random();
            int CountIngrediants = 11;
            int CharmsCount = 4;
            int FieldCount = 0;
            ///
            ///Populating Ingrediants arraylist
            ///
            Ingredients_Pierre Ingredient1 = new Ingredients_Pierre("BlueBerry", "Berries");
            Ingredient1.SetCount(1);
            Ingredient1.setPoetency();
            Ingredients.Add(Ingredient1);

            Ingredients_Pierre Ingredient2 = new Ingredients_Pierre("RedBerry", "Berries");
            Ingredient2.SetCount(2);
            Ingredient2.setPoetency();
            Ingredients.Add(Ingredient2);

            Ingredients_Pierre Ingredient3 = new Ingredients_Pierre("BlackBerry", "Berries");
            Ingredient3.SetCount(3);
            Ingredient3.setPoetency();
            Ingredients.Add(Ingredient3);

            Ingredients_Pierre Ingredient4 = new Ingredients_Pierre("YellowBerry", "Berries");
            Ingredient4.SetCount(4);
            Ingredient4.setPoetency();
            Ingredients.Add(Ingredient4);

            Ingredients_Pierre Ingredient5 = new Ingredients_Pierre("Onion", "Roots");
            Ingredient5.SetCount(5);
            Ingredient5.setPoetency();
            Ingredients.Add(Ingredient5);

            Ingredients_Pierre Ingredient6 = new Ingredients_Pierre("SweetPotatoes", "Roots");
            Ingredient6.SetCount(6);
            Ingredient6.setPoetency();
            Ingredients.Add(Ingredient6);

            Ingredients_Pierre Ingredient7 = new Ingredients_Pierre("Turnips", "Roots");
            Ingredient7.SetCount(7);
            Ingredient7.setPoetency();
            Ingredients.Add(Ingredient7);

            Ingredients_Pierre Ingredient8 = new Ingredients_Pierre("Ginger", "Roots");
            Ingredient8.SetCount(8);
            Ingredient8.setPoetency();
            Ingredients.Add(Ingredient8);

            Ingredients_Pierre Ingredient9 = new Ingredients_Pierre("Beets", "Roots");
            Ingredients.Add(Ingredient9);
            Ingredient9.setPoetency();
            Ingredient9.SetCount(9);

            Ingredients_Pierre Ingredient10 = new Ingredients_Pierre("Garlic", "Roots");
            Ingredient10.SetCount(10);
            Ingredient10.setPoetency();
            Ingredients.Add(Ingredient10);

            Ingredients_Pierre Ingredient11 = new Ingredients_Pierre("Rose", "Flowers");
            Ingredient11.SetCount(11);
            Ingredient11.setPoetency();
            Ingredients.Add(Ingredient11);

            ////Populating Charms ArrayList
            ///
            Charms_Pierre Charm1 = new Charms_Pierre("Ocean Amulet", "Water");
            Charms.Add(Charm1);
            Charms_Pierre Charm2 = new Charms_Pierre("Rising Sun Amulet", "Sun");
            Charms.Add(Charm2);
            Charms_Pierre Charm3 = new Charms_Pierre("Snake Poison", "Poison");
            Charms.Add(Charm3);
            Charms_Pierre Charm4 = new Charms_Pierre("Magic Crystal", "Magic Crystal");
            Charms.Add(Charm4);

            ///Populating Field array
            ///
            for (int x = 0; x < 100 - (CountIngrediants) - (CharmsCount); x++)
            {
                int sInt = num.Next(1, 3);
                if (sInt == 1)
                {
                    FieldCount = FieldCount + 1;
                    Field_Pierre Field = new Field_Pierre("Grass");
                    Fields.Add(Field);
                }
                else
                {
                    FieldCount = FieldCount + 1;
                    Field_Pierre Field = new Field_Pierre("Thorns");
                    Fields.Add(Field);
                }

            }

            ///Randomzing and adding all the Pieces into  a single Arraylist
            ///
            //Loop for when all objects still needed to be added
            for (int x = 0; x < 100; x++)
            {
                if ((CountIngrediants > 0) && (CharmsCount > 0) && (FieldCount > 0))
                {
                    int TotalCountLeft = Ingredients.Count + Charms.Count + Fields.Count;
                    int inum = num.Next(1, (TotalCountLeft + 1));

                    if ((inum >= 1) && (inum <= Ingredients.Count))
                    {
                        inum = num.Next(0, (Ingredients.Count - 1));
                        gamelist.Add(Ingredients[inum]);
                        Ingredients.RemoveAt(inum);
                        CountIngrediants = CountIngrediants - 1;

                    }
                    if ((inum > Ingredients.Count) && (inum <= (Ingredients.Count + Charms.Count)))
                    {
                        inum = num.Next(0, (Charms.Count - 1));
                        gamelist.Add(Charms[inum]);
                        Charms.RemoveAt(inum);
                        CharmsCount = CharmsCount - 1;

                    }
                    if ((inum > (Ingredients.Count + Charms.Count)) && (inum <= TotalCountLeft))
                    {
                        inum = num.Next(0, (Fields.Count - 1));
                        gamelist.Add(Fields[inum]);
                        Fields.RemoveAt(inum);
                        FieldCount = FieldCount - 1;

                    }
                }
                //No charms left to be added here
                if ((CountIngrediants > 0) && (CharmsCount == 0) && (FieldCount > 0))
                {
                    int TotalCountLeft = Ingredients.Count + Charms.Count + Fields.Count;
                    int inum = num.Next(1, (TotalCountLeft + 1));
                    if ((inum >= 1) && (inum <= Ingredients.Count))
                    {
                        gamelist.Add(Ingredients[Ingredients.Count - 1]);
                        Ingredients.RemoveAt(Ingredients.Count - 1);
                        CountIngrediants = CountIngrediants - 1;

                    }

                    if ((inum > (Ingredients.Count + Charms.Count)) && (inum <= TotalCountLeft))
                    {
                        inum = num.Next(0, (Fields.Count - 1));
                        gamelist.Add(Fields[inum]);
                        Fields.RemoveAt(inum);
                        FieldCount = FieldCount - 1;

                    }
                }
                //No ingrediants to be added
                if ((CountIngrediants == 0) && (CharmsCount > 0) && (FieldCount > 0))
                {

                    int TotalCountLeft = Ingredients.Count + Charms.Count + Fields.Count;
                    int inum = num.Next(1, (TotalCountLeft + 1));
                    if ((inum > Ingredients.Count) && (inum <= (Ingredients.Count + Charms.Count)))
                    {
                        inum = num.Next(0, (Charms.Count - 1));
                        gamelist.Add(Charms[inum]);
                        Charms.RemoveAt(inum);
                        CharmsCount = CharmsCount - 1;

                    }

                    if ((inum > (Ingredients.Count + Charms.Count)) && (inum <= TotalCountLeft))
                    {
                        inum = num.Next(0, (Fields.Count - 1));
                        gamelist.Add(Fields[inum]);
                        Fields.RemoveAt(inum);
                        FieldCount = FieldCount - 1;

                    }
                }

                //No Fields to be added
                if ((CountIngrediants > 0) && (CharmsCount > 0) && (FieldCount == 0))
                {
                    int TotalCountLeft = Ingredients.Count + Charms.Count + Fields.Count;
                    int inum = num.Next(1, (TotalCountLeft + 1));
                    if ((inum >= 1) && (inum <= Ingredients.Count))
                    {
                        gamelist.Add(Ingredients[Ingredients.Count - 1]);
                        Ingredients.RemoveAt(Ingredients.Count - 1);
                        CountIngrediants = CountIngrediants - 1;

                    }

                    if ((inum > Ingredients.Count) && (inum <= (Ingredients.Count + Charms.Count)))
                    {
                        inum = num.Next(0, (Charms.Count - 1));
                        gamelist.Add(Charms[inum]);
                        Charms.RemoveAt(inum);
                        CharmsCount = CharmsCount - 1;

                    }
                }

                ////// This is when there is only one type of object remaining to  be added
                ///
                //No ingredients or charms to be added
                if ((CountIngrediants == 0) && (CharmsCount == 0) && (FieldCount > 0))
                {
                    {
                        int inum = num.Next(0, (Fields.Count - 1));
                        gamelist.Add(Fields[inum]);
                        Fields.RemoveAt(inum);
                        FieldCount = FieldCount - 1;

                    }
                }
                //No Ingrediants or Fields left
                if ((CountIngrediants == 0) && (CharmsCount > 0) && (FieldCount == 0))
                {
                    int inum = num.Next(0, (Charms.Count - 1));
                    gamelist.Add(Charms[inum]);
                    Charms.RemoveAt(inum);
                    CharmsCount = CharmsCount - 1;
                }
                //No Charms or Fields
                if ((CountIngrediants > 0) && (CharmsCount == 0) && (FieldCount == 0))
                {
                    int inum = num.Next(0, (Ingredients.Count - 1));
                    gamelist.Add(Ingredients[inum]);
                    Ingredients.RemoveAt(inum);
                    CountIngrediants = CountIngrediants - 1;
                }


            }




        }

        private void button1_Click(object sender, EventArgs e)
        {


        }


        int seconds = 60;
        private void TimerGameplay(object sender, EventArgs e)
        {
            seconds--;
            label4.Text = seconds.ToString();
            if (seconds == 0)
            {
                SetHighScore();
                timer2.Stop();
                CalculateGameScoreWin();
                MessageBoxButtons buttons = MessageBoxButtons.RetryCancel;
                DialogResult result = MessageBox.Show(GameWin, "Time Out", buttons);
                if (result == DialogResult.Retry)
                {
                    seconds = 60;
                    Score = 0;
                    label1.Text = "0";
                    NewGameState();
                    HaveClicked = false;
                    newImage = Image.FromFile("Images\\Tan.png");
                    clickedPictureBox.Image = newImage;
                }
                else
                {
                    
                    Close();
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void CalculateGameScoreWin()
        {
            GameWin = "You have produced a cure with a poetency of " + Score.ToString();
        }
        public void CalculateGameScoreLoose()
        {
            GameWin = "Snake Poison, Game over your score is " + Score.ToString();
        }
        public void SetScore(double dScore)
        {
            label1.Text = dScore.ToString();
        }


        public void SetHighScore()
        {
            if (HighestScore < Score)
            {
                HighestScore = Score;
                label9.Text = HighestScore.ToString();
            }
            if (CalculateBadge() == "Bronze")
            {
                label10.Text = CalculateBadge();
                label10.ForeColor = Color.Peru;
                newImage = Image.FromFile("Images\\Bronze.png");
                pictureBox102.Image = newImage;
            }
            if (CalculateBadge() == "Silver")
            {
                label10.Text = CalculateBadge();
                label10.ForeColor = Color.Silver;
                newImage = Image.FromFile("Images\\Silver.png");
                pictureBox102.Image = newImage;
            }
            if (CalculateBadge() == "Gold")
            {
                label10.Text = CalculateBadge();
                label10.ForeColor = Color.Gold;
                newImage = Image.FromFile("Images\\Gold.png");
                pictureBox102.Image = newImage;
            }
            
        }
        public string CalculateBadge()
        {
            if ((HighestScore >= 200) && (HighestScore < 400))
                return "Bronze";
            if ((HighestScore >= 400) && (HighestScore < 600))
                return "Silver";
            if (HighestScore >= 600)
                return "Gold";
            return "None";
        }

        private void Game_Pierre_Load(object sender, EventArgs e)
        {

        }

        
        
    }
    
}

