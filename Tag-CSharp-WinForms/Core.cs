using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag_CSharp_WinForms
{
    class Core
    {
        int size;
        int[,] gameMap;
        int blankX, blankY;
        static Random random = new Random();

        public Core(int size)
        {
            this.size = size;
            gameMap = new int[size, size];
        }

        public void initGame()
        {
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    gameMap[x, y] = coordsToPos(x, y) + 1;

            blankX = size - 1;
            blankY = size - 1;
            gameMap[blankX, blankY] = 0;
        }

        public int getNumber(int pos)
        {
            int x, y;
            posToCoords(pos, out x, out y);
            if (x < 0 || x >= size) return 0;
            if (y < 0 || y >= size) return 0;
            return gameMap[x, y];
        }

        public void shiftButton(int pos)
        {
            int x, y;
            posToCoords(pos, out x, out y);

            if (Math.Abs(blankX - x) + Math.Abs(blankY - y) != 1)
            {
                return;
            }

            gameMap[blankX, blankY] = gameMap[x, y];
            gameMap[x, y] = 0;
            blankX = x;
            blankY = y;
        }

        public void randomShift()
        {
            int pos = random.Next(0, 4);
            int x = blankX;
            int y = blankY;

            switch (pos)
            {
                case 0:
                    x--;
                    break;
                case 1:
                    x++;
                    break;
                case 2:
                    y--;
                    break;
                case 3:
                    y++;
                    break;
            }
            shiftButton(coordsToPos(x, y));
        }

        private int coordsToPos(int x, int y)
        {
            if (x < 0) x = 0;
            if (x > size - 1) x = size - 1;
            if (y < 0) y = 0;
            if (y > size - 1) y = size - 1;
            return x * size + y;
        }

        private void posToCoords(int position, out int x, out int y)
        {
            if (position < 0) position = 0;
            if (position > size * size - 1) position = size * size - 1;
            y = position % size;
            x = position / size;
        }

        public bool checkForWin()
        {
            if (!(blankX == size - 1 && blankY == size - 1)) return false;
            for(int x = 0; x < size; x++)
            {
                for(int y = 0; y < size; y++)
                {
                    if(!(x == size -1 && y == size - 1))
                       if(gameMap[x, y] != coordsToPos(x, y) + 1)
                            return false;
                }
            }
            return true;
        }
    }
}
