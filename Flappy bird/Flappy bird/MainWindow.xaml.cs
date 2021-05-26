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
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {

        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {

        }

        private void StartGame() //StartGame will be loading all the default values for the game
        {

        }

        private void EndGame() //EndGame will be called when the game ends
        {

        }
    }
}