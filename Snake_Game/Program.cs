using Raylib_cs;
using System.Numerics;

namespace Snake_Game {

    public static class Constants {
        public const int WINDOWHEIGHT = 900;
        public const int WINDOWWIDTH = 850;
        public const int SCALE = 25;
    }

    internal class Program {
        static void Main(string[] args) {
            Food foodSource = new Food();
            Vector2 foodPosition = foodSource.getPosition();
            Snake snake = new Snake(foodSource);
            List<Vector2> body = snake.getBody();

            Raylib.InitWindow(Constants.WINDOWWIDTH, Constants.WINDOWHEIGHT, "Snek Game");
            Raylib.SetTargetFPS(5);

            while (!Raylib.WindowShouldClose()) {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.Black);
                snake.update();

                //drawing food
                Raylib.DrawRectangle(
                    (int) foodPosition.X, 
                    (int) foodPosition.Y, 
                    (int) (Constants.SCALE), 
                    (int) (Constants.SCALE), 
                    Color.Red);

                //drawing snake
                foreach (Vector2 part in body) {
                    Raylib.DrawRectangle(
                        (int) part.X,
                        (int) part.Y,
                        Constants.SCALE,
                        Constants.SCALE,
                        Color.Gold);
                }
                Raylib.EndDrawing();

            }

            Raylib.CloseWindow();
        }
    }
}
