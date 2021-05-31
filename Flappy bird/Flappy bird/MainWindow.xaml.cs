using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Windows.Threading; //A threading namespace for the timer using System.Windows.Threading

namespace Flappy_bird
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window 
    {

        DispatcherTimer gameTimer = new DispatcherTimer(); // create a new instance of the timer class "game timer"

        double score; //score keeper with the datatype double
        int gravity = 8; // new gravity integer with the vlaue 8
        bool gameOver; //this will check on the game if its over or not, using boolean
        Rect flappyBirdHitBox; //The Rect going to be used as a flappy bird hitbox and describe the height, width and the location of the bird to know when the bird hits the pipe

        public MainWindow()
        {
            InitializeComponent(); // set the default settings for the timer

            gameTimer.Tick += MainEventTimer; // link the timer tick to the game engine event
            gameTimer.Interval = TimeSpan.FromMilliseconds(20); //Makes the timer tick every 20 milliseconds
            StartGame(); // run the start game function

        }

        private void MainEventTimer(object sender, EventArgs e) // this is the game engine event linked to the timer
        {
            txtScore.Content = "Score: " + score; //this will always update the score with the score integer

            flappyBirdHitBox = new Rect(Canvas.GetLeft(flappyBird), Canvas.GetTop(flappyBird), flappyBird.Width, flappyBird.Height); //this will always update the position of the bird and will know exactly where the bird is

            Canvas.SetTop(flappyBird, Canvas.GetTop(flappyBird) + gravity);//the value of the gravity will pull the bird down, when its minus it will push the bird up

            if (Canvas.GetTop(flappyBird) < -10 || Canvas.GetTop(flappyBird) > 458) //check if the bird has either gone off the screen from top or bottom
            {
                EndGame(); //if it has then we end the game and show the reset game text
            }


            foreach (var x in MyCanvas.Children.OfType<Image>()) //below is the main loop, this loop will go through each image in the canvas, if it finds any image with the tags and follow the instructions with them
            {
                if ((String)x.Tag == "Obs1" || (String)x.Tag == "Obs2" || (String)x.Tag == "Obs3")  //if we found an image with the tag obs1,2 or 3 then we will move it towards left of the scree
                {
                    Canvas.SetLeft(x, Canvas.GetLeft(x) - 5); //the pipe speed

                    if (Canvas.GetLeft(x) < -100) //if the first layer of pipes leave the scene and go to -100 pixels from the left, this will reset the pipe to come back again on the screen
                    {
                        Canvas.SetLeft(x, 800); //reset the pipe to 800 pixels

                        score += .5; //add 1 to the score
                    }

                    Rect pipeHitBox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height); //create a new rect called pipeHitBox and link the rectangles to it

                    if (flappyBirdHitBox.IntersectsWith(pipeHitBox)) //if the flappy rect and the pillars rect collide
                    {
                        EndGame(); // stop the timer, set the game over to true and show the reset text
                    }
                }

                if ((String)x.Tag == "cloud") //if find any of the images with the clouds tag on it
                {
                    Canvas.SetLeft(x, Canvas.GetLeft(x) - 2); //then this will slowly move the cloud towards left of the screen by minus 2 pixels

                    if (Canvas.GetLeft(x) < -250) //if the clouds have reached minus 225 pixels then this will reset it
                    {
                        Canvas.SetLeft(x, 550); //reset the cloud images to 550 pixels
                    }
                }
            }
       
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space) // if the space key is pressed
            {
                flappyBird.RenderTransform = new RotateTransform(-20, flappyBird.Width /2, flappyBird.Height / 2); //this will rotate the bird slightly up (-20 degrees) from the center position, when the space key is pressed, to signify the bird flying upwards. By dividing the birds width and height with 2, the bird will start moving from the center of the canvas
                gravity = -8; //change gravity to minus 8 so the bird image moves upwards instead
            }
            if (e.Key == Key.R && gameOver == true) 
            {
                StartGame(); //When the R key is pressed and the game is over, this function will set up everything again on the screen
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            flappyBird.RenderTransform = new RotateTransform(5, flappyBird.Width / 2, flappyBird.Height / 2); //if the keys are not pressed then the rotation of the flappy bird will change to 5 degrees from the center of the canvas
            gravity = 8; //change the gravity to 8 so the bird image will go down instead of going up
        }

        private void StartGame() //this is the start game function, StartGame will be loading all the default values for the game
        {

            MyCanvas.Focus(); //this function will keep the canvas element in focus when the game runs

            int temp = 300; //a temp integer with the value 300

            score = 0; //this will set the score to 0

            gameOver = false; //sets game over to false
            Canvas.SetTop(flappyBird, 190); //sets the flappy bird top position to 190 pixels, the default value of the bird

            foreach (var x in MyCanvas.Children.OfType<Image>()) //foreach loop going to run loop through any image element, will simply check for each image in this game and set them to their default positions
            {
                if ((string)x.Tag == "Obs1") //set obs2 pipes to its default position
                {
                    Canvas.SetLeft(x, 500);
                }
                if ((string)x.Tag == "Obs2") //set obs2 pipes to its default position
                {
                    Canvas.SetLeft(x, 800);
                }
                if ((string)x.Tag == "Obs3") //set obs3 pipes to its default position
                {
                    Canvas.SetLeft(x, 1100);
                }
                if ((string)x.Tag == "cloud") //set the clouds to its default position
                {
                    Canvas.SetLeft(x, 300 + temp);
                    temp = 800;
                }
            }


            gameTimer.Start(); // start the main game timer


        }

        private void EndGame() //EndGame will be called when the game ends
        {
            gameTimer.Stop();
            gameOver = true;
            txtScore.Content += " Gamer Over! Klick R to restart"; //this text will be shown, when the game ends
        }
    }
}