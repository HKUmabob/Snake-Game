using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using Raylib_cs;

namespace Snake_Game {
    public class Snake {
        private int length;
        private List<Vector2> body;
        private int headX;
        private int headY;
        private int xDir;
        private int yDir;
        private int speed;
        private Food foodSourse;


        public Snake(Food foodSourse) {
            this.length = 1;
            this.body = new List<Vector2>();
            this.body.Add(new Vector2(Constants.WINDOWWIDTH / 2, Constants.WINDOWHEIGHT / 2));
            this.foodSourse = foodSourse;
            this.speed = Constants.SCALE;
        }

        public bool canEat() {
            if (this.foodSourse.getPosition().Equals(this.body[this.length - 1])) {
                return true;
            }

            return false;
        }

        public void eat() {

            this.body.Add(
                new Vector2(
                    this.body[this.length - 1].X,
                    this.body[this.length - 1].Y
                    )
                );

            this.length++;
            this.foodSourse.changePosition();
        }


        public List<Vector2> getBody() {
            return this.body;
        }

        public void update() {

            if (Raylib.IsKeyDown(KeyboardKey.Up) && this.yDir != 1) {
                this.setDir(0, -1 * this.speed);
            } else if (Raylib.IsKeyDown(KeyboardKey.Down) && this.yDir != -1) {
                this.setDir(0, 1 * this.speed);
            } else if (Raylib.IsKeyDown(KeyboardKey.Right) && this.yDir != -1) {
                this.setDir(1 * this.speed, 0);
            } else if (Raylib.IsKeyDown(KeyboardKey.Left) && this.yDir != 1) {
                this.setDir(-1 * this.speed, 0);
            }

            this.headX = (int)this.body[this.length - 1].X;
            this.headY = (int)this.body[this.length - 1].Y;

            this.headX += this.xDir;
            this.headY += this.yDir;

            this.body.RemoveAt(0);
            this.body.Add(new Vector2(this.headX, this.headY));
        }

        private void setDir(int x, int y) {
            this.xDir = x;
            this.yDir = y;
        }

    }
}
