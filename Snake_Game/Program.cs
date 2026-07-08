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
            Snake snake = new Snake(foodSource);
            List<Vector2> body = snake.getBody();

            Raylib.InitWindow(Constants.WINDOWWIDTH, Constants.WINDOWHEIGHT, "Snek Game");
            Raylib.SetTargetFPS(10);
            bool isGameOver = false;

            float hueIncrement = 15;

            while (!Raylib.WindowShouldClose()) {

                if (isGameOver) {
                    if (Raylib.IsKeyPressed(KeyboardKey.R)) {
                        // Restart the game by resetting the objects and flag
                        foodSource = new Food();
                        snake = new Snake(foodSource);
                        body = snake.getBody();
                        isGameOver = false;
                    }

                }else {

                    snake.update();

                    if (snake.isDead()) {
                        isGameOver = true;
                    }


                    if (snake.canEat()) {
                        snake.eat();
                    }
                }

                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.Black);

                if (isGameOver) {
                    Raylib.DrawText("GAME OVER", Constants.WINDOWWIDTH / 2 - 100, Constants.WINDOWHEIGHT / 2 - 40, 30, Color.Red);
                    Raylib.DrawText($"Score: {snake.getScore()}", Constants.WINDOWWIDTH / 2 - 50, Constants.WINDOWHEIGHT / 2 + 10, 20, Color.White);
                    Raylib.DrawText("Press [R] to Restart", Constants.WINDOWWIDTH / 2 - 95, Constants.WINDOWHEIGHT / 2 + 50, 16, Color.DarkGray);
                
                } else {

                    Vector2 foodPosition = foodSource.getPosition();

                    //drawing food
                    Raylib.DrawRectangle(
                        (int) foodPosition.X, 
                        (int) foodPosition.Y, 
                        (int) (Constants.SCALE), 
                        (int) (Constants.SCALE), 
                        Color.Red);

                    //drawing snake
                    for (int i = 0; i < body.Count(); i++) {
                        Raylib.DrawRectangle(
                            (int) body[i].X,
                            (int) body[i].Y,
                            Constants.SCALE,
                            Constants.SCALE,
                            Color.FromHSV(i * hueIncrement, 100, 100));
                    }
                }
                Raylib.EndDrawing();
                

            }

            Raylib.CloseWindow();
        }
    }
}
