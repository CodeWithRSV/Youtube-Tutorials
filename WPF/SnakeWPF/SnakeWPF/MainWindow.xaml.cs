using System.Speech.Synthesis;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SnakeWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int snakeSquareSize = 20;
        private List<SnakePart> snakeParts = new List<SnakePart>();
        const int startSnakeLength = 3;
        private int snakeLength;
        const int snakeStartSpeed = 400;
        const int snakeSpeedThreshold = 100;
        private SolidColorBrush snakeBodyBrush = Brushes.Red;
        private SolidColorBrush snakeHeadBrush = Brushes.Brown;
        public enum SnakeDirection { Up, Down, Left, Right }
        public SnakeDirection snakeDirection = SnakeDirection.Right;
        private System.Windows.Threading.DispatcherTimer gameTickTimer = new System.Windows.Threading.DispatcherTimer();
        private SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
        private int currentScore = 0;
        private UIElement snakeFood = null;
        private SolidColorBrush snakeFoodBrush = Brushes.Black;
        private Random rnd = new Random();

        public MainWindow()
        {
            InitializeComponent();
            gameTickTimer.Tick += GameTickTimer_Tick;
        }

        private void GameTickTimer_Tick(object? sender, EventArgs e)
        {
            MoveSnake();
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            DrawGameArea();
        }

        private void StartNewGame()
        {
            bdrWelcomeMessage.Visibility = Visibility.Collapsed;
            bdrEndOfGame.Visibility = Visibility.Collapsed;
            foreach (SnakePart snakePart in snakeParts)
            {
                if(snakePart.UiElement != null)
                    GameArea.Children.Remove(snakePart.UiElement);
            }
            snakeParts.Clear();
            if(snakeFood != null)
                GameArea.Children.Remove(snakeFood);

            currentScore = 0;
            snakeLength = startSnakeLength;
            snakeParts.Add(new SnakePart() { Position = new Point(snakeSquareSize * 5, snakeSquareSize * 5) });
            gameTickTimer.Interval = TimeSpan.FromMilliseconds(snakeStartSpeed);
            DrawSnake();
            DrawSnakeFood();
            UpdateGameStatus();
            gameTickTimer.IsEnabled = true;
        }

        private void DrawSnakeFood()
        {
            Point foodPosition = GetNextFoodPosition();
            snakeFood = new Ellipse()
            {
                Width = snakeSquareSize,
                Height = snakeSquareSize,
                Fill = snakeFoodBrush
            };
            GameArea.Children.Add(snakeFood);
            Canvas.SetTop(snakeFood, foodPosition.Y);
            Canvas.SetLeft(snakeFood, foodPosition.X);
        }

        private Point GetNextFoodPosition()
        {
            int maxX = (int)(GameArea.ActualWidth / snakeSquareSize);
            int maxY = (int)(GameArea.ActualHeight / snakeSquareSize);
            int foodX = rnd.Next(0, maxX) * snakeSquareSize;
            int foodY = rnd.Next(0, maxY) * snakeSquareSize;

            foreach (SnakePart snakePart in snakeParts)
            {
                if ((snakePart.Position.X == foodX) && (snakePart.Position.Y == foodY))
                    return GetNextFoodPosition();
            }

            return new Point(foodX, foodY);
        }

        private void DrawSnake()
        {
            foreach (SnakePart snakePart in snakeParts)
            {
                if (snakePart.UiElement == null)
                {
                    snakePart.UiElement = new Rectangle()
                    {
                        Width = snakeSquareSize,
                        Height = snakeSquareSize,
                        Fill = (snakePart.IsHead ? snakeHeadBrush : snakeBodyBrush)
                    };
                    GameArea.Children.Add(snakePart.UiElement);
                    Canvas.SetTop(snakePart.UiElement, snakePart.Position.Y);
                    Canvas.SetLeft(snakePart.UiElement, snakePart.Position.X);
                }
            }
        }
        private void MoveSnake()
        {
            if(snakeParts.Count >= snakeLength)
            {
                GameArea.Children.Remove(snakeParts[0].UiElement);
                snakeParts.RemoveAt(0);
            }
            SnakePart snakeHead = snakeParts.Last();

            (snakeHead.UiElement as Rectangle).Fill = snakeBodyBrush;
            snakeHead.IsHead = false;

            double nextX = snakeHead.Position.X;
            double nextY = snakeHead.Position.Y;
            switch (snakeDirection)
            {
                case SnakeDirection.Left:
                    nextX -= snakeSquareSize;
                    break;
                case SnakeDirection.Right:
                    nextX += snakeSquareSize;
                    break;
                case SnakeDirection.Up:
                    nextY -= snakeSquareSize;
                    break;
                case SnakeDirection.Down:
                    nextY += snakeSquareSize;
                    break;
            }
            snakeParts.Add(new SnakePart() { Position = new Point(nextX, nextY), IsHead = true });
            DrawSnake();
            DoCollisionCheck();
        }

        private void DoCollisionCheck()
        {

            SnakePart snakeHead = snakeParts[snakeParts.Count - 1];

            if ((snakeHead.Position.X == Canvas.GetLeft(snakeFood)) && (snakeHead.Position.Y == Canvas.GetTop(snakeFood)))
            {
                EatSnakeFood();
                return;
            }

            if ((snakeHead.Position.Y < 0) || (snakeHead.Position.Y >= GameArea.ActualHeight) ||
            (snakeHead.Position.X < 0) || (snakeHead.Position.X >= GameArea.ActualWidth))
            {
                EndGame();
            }

            foreach (SnakePart snakeBodyPart in snakeParts)
            {
                if ((snakeHead.Position.X == snakeBodyPart.Position.X) && (snakeHead.Position.Y == snakeBodyPart.Position.Y) && snakeHead != snakeBodyPart)
                    EndGame();
            }
        }

        private void EndGame()
        {
            speechSynthesizer.SpeakAsync("oh no! You died.");
            gameTickTimer.IsEnabled = false;
            tbFinalScore.Text = currentScore.ToString();
            bdrEndOfGame.Visibility = Visibility.Visible;
        }

        private void EatSnakeFood()
        {
            speechSynthesizer.SpeakAsync("Yummy");
            snakeLength++;
            currentScore++;
            int timerInterval = Math.Max(snakeSpeedThreshold, (int)gameTickTimer.Interval.TotalMilliseconds - (currentScore * 2));
            GameArea.Children.Remove(snakeFood);
            DrawSnakeFood();
            UpdateGameStatus();
        }

        private void UpdateGameStatus()
        {
            this.tbStatusScore.Text = currentScore.ToString();
            this.tbStatusSpeed.Text = gameTickTimer.Interval.TotalMilliseconds.ToString();
        }

        private void DrawGameArea()
        {
            int nextX = 0,nextY=0;
            int rowCounter = 0;
            bool isEven = true;
            while(nextY < GameArea.ActualHeight)
            {
                Rectangle rect = new Rectangle
                {
                    Width = snakeSquareSize,
                    Height = snakeSquareSize,
                    Fill = isEven ? Brushes.White : Brushes.DarkGray
                };
                GameArea.Children.Add(rect);
                Canvas.SetTop(rect, nextY);
                Canvas.SetLeft(rect, nextX);
                isEven = !isEven;
                nextX += snakeSquareSize;
                if(nextX >= GameArea.ActualWidth)
                {
                    nextX = 0;
                    nextY += snakeSquareSize;
                    rowCounter++;
                    if (GameArea.ActualWidth / snakeSquareSize % 2 == 0)
                        isEven = !isEven;
                }
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {

            SnakeDirection originalSnakeDirection = snakeDirection;
            switch (e.Key)
            {
                case Key.Up:
                    if (snakeDirection != SnakeDirection.Down)
                        snakeDirection = SnakeDirection.Up;
                    break;
                case Key.Down:
                    if (snakeDirection != SnakeDirection.Up)
                        snakeDirection = SnakeDirection.Down;
                    break;
                case Key.Left:
                    if (snakeDirection != SnakeDirection.Right)
                        snakeDirection = SnakeDirection.Left;
                    break;
                case Key.Right:
                    if (snakeDirection != SnakeDirection.Left)
                        snakeDirection = SnakeDirection.Right;
                    break;
                case Key.Space:
                    StartNewGame();
                    break;
            }
            if(snakeDirection!= originalSnakeDirection)
            {
                MoveSnake();
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
    public class SnakePart
    {
        public UIElement UiElement { get; set; }

        public Point Position { get; set; }

        public bool IsHead { get; set; }
    }
}