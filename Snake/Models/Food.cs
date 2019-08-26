namespace Snake.Models
{
    public class Food : Point
    {
        private char FoodSyimbol = '$';
        public int Score { get; }

        public override void Render()
        {
            Visualise(X, Y, FoodSyimbol);
        }

        public Food(int x, int y) : base(x, y)
        {
            Visualise(X, Y, FoodSyimbol);
            Score = 1;
        }
    }
}