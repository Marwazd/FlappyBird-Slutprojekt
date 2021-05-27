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

        DispatcherTimer gameTimer = new DispatcherTimer(); //variable for the game

        double score;
        int gravity = 8;
        bool gameOver;
        Rect flappyBirdHitBox; //The Rect going to be used as a flappy bird hitbox and describe the height, width and the location of the bird to know when the bird hits the pipe

        public MainWindow()
        {
            InitializeComponent();

            gameTimer.Tick += MainEventTimer;
            gameTimer.Interval = TimeSpan.FromMilliseconds(20); //Makes the timer tick every 20 milliseconds
            StartGame();

        }

        private void MainEventTimer(object sender, EventArgs e)
        {
            txtScore.Content = "Score: " + score; //this will always update the score

            flappyBirdHitBox = new Rect(Canvas.GetLeft(flappyBird), Canvas.GetTop(flappyBird), flappyBird.Width, flappyBird.Height); //this will always update the position of the bird and will know exactly where the bird is

            Canvas.SetTop(flappyBird, Canvas.GetTop(flappyBird) + gravity); //the value of the gravity will pull the bird down, when its minus it will push the bird up


        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                flappyBird.RenderTransform = new RotateTransform(-20, flappyBird.Width / 2, flappyBird.Height / 2); //this will rotate the bird slightly up when the space key is pressed to signify the bird flying upwards. By dividing the birds width and height with 2, the bird will start moving from the center of the canvas
                gravity = -8;
            }
            if (e.Key == Key.R && gameOver == true) 
            {
                StartGame(); //When the R key is pressed and the game is over, this function will set up everything again on the screen
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            flappyBird.RenderTransform = new RotateTransform(5, flappyBird.Width / 2, flappyBird.Height / 2); 
            gravity = 8;
        }

        private void StartGame() //StartGame will be loading all the default values for the game
        {

            MyCanvas.Focus(); //this function will keep the canvas element in focus when the game runs

            int temp = 300;

            score = 0;

            gameOver = false;
            Canvas.SetTop(flappyBird, 190); //the default value of the bird

            foreach (var x in MyCanvas.Children.OfType<Image>()) //foreach loop going to run loop through any image element
            {
                if ((string)x.Tag == "obs1")
                {
                    Canvas.SetLeft(x, 500);
                }
                if ((string)x.Tag == "obs2")
                {
                    Canvas.SetLeft(x, 800);
                }
                if ((string)x.Tag == "obs3")
                {
                    Canvas.SetLeft(x, 1100);
                }
                if ((string)x.Tag == "cloud")
                {
                    Canvas.SetLeft(x, 300 + temp);
                    temp = 800;
                }
            }


            gameTimer.Start();


        }

        private void EndGame() //EndGame will be called when the game ends
        {

        }
    }
}