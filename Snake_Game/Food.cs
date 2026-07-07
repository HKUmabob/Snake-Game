using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Snake_Game {
    public class Food {
        private Vector2 position;
        private Random rand = new Random();
        private int numRows;
        private int numCols;

        public Food() {
            this.position = new Vector2();
            this.numRows = Constants.WINDOWHEIGHT / Constants.SCALE;
            this.numCols = Constants.WINDOWWIDTH / Constants.SCALE;

            this.changePosition();
        }

        public Vector2 getPosition() {
            return this.position;
        }

        public void changePosition() {
            this.position.X = rand.Next(0, this.numRows) * Constants.SCALE;
            this.position.Y = rand.Next(0, this.numCols) * Constants.SCALE;
        }
    }
}
