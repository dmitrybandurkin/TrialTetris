using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MyTetris
{
    public enum Directions
    {
        Left,
        Right,
        Down,
        InstantlyDown,
        Rotate
    }

    /// <summary>
    /// Управление функционалом игры
    /// </summary>
    class Game
    {
        private Board board;

        private Tetraminoids tetraminoids;

        private Tetramino currenttetramino;

        private int shift;
        private int lines;
        private int score;

        Timer timer;

        public Game()
        {
            InitView();
            lines = 0;
            shift = 1;

            board = new Board();
            tetraminoids = new Tetraminoids();
            currenttetramino = tetraminoids.GetRandomTetramino();

            timer = new Timer { Interval = 1000, Enabled = true };
            timer.Elapsed += TimerTick;

            while (!EndGame())
            {
                Move();
            }

            Console.SetCursorPosition(0, 26);
            Console.WriteLine("Игра окончена");
            Console.ReadKey();
        }

        private void InitView()
        {
            Console.CursorVisible = false;
            Console.WindowHeight = 25;
            Console.WindowWidth = 30;
        }

        private void TimerTick(object sender, ElapsedEventArgs e)
        {
            if (EndGame()) return;
            MoveDirection(Directions.Down);
        }

        /// <summary>
        /// условие окончания игры
        /// </summary>
        /// <returns></returns>
        private bool EndGame()
        {
            bool end = false;
            for (int i = 1; i < board.pfieldcolumns - 2; i++)
            {
                if (board.field[4][i].pBorderorblock) end = true;
            }
            return end;
        }


        private void Move()
        {
            ConsoleKey key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    MoveDirection(Directions.Left);
                    break;

                case ConsoleKey.RightArrow:
                    MoveDirection(Directions.Right);
                    break;

                case ConsoleKey.DownArrow:
                    MoveDirection(Directions.Down);
                    break;

                case ConsoleKey.Spacebar:
                    MoveDirection(Directions.InstantlyDown);
                    break;

                case ConsoleKey.UpArrow:
                    MoveDirection(Directions.Rotate);
                    break;
            }
        }

        private void MoveDirection(Directions direction)
        {
            PlaceTetramino(false);
            switch (direction)
            {
                case Directions.Left:
                    if (PossibilitytoChange(-shift, 0, currenttetramino))
                    {
                        Shift(-shift);
                    }
                    break;

                case Directions.Right:

                    if (PossibilitytoChange(shift, 0, currenttetramino))
                    {

                        Shift(shift);
                    }

                    break;

                case Directions.Down:

                    if (PossibilitytoChange(0, shift, currenttetramino))
                    {
                        Down(shift);
                    }
                    else
                    {
                        Transform();
                        Clear();
                    }
                    break;

                case Directions.InstantlyDown:
                    Down(InstantlyDown());
                    Transform();
                    Clear();
                    break;

                case Directions.Rotate:
                    if (PossibilitytoChange(0, 0, Rotate(currenttetramino)))
                    {
                        currenttetramino = Rotate(currenttetramino);
                    }
                    break;
            }
            PlaceTetramino(true);
        }


        private bool PossibilitytoChange(int shift, int down, Tetramino tetramino)
        {
            for (int i = 0; i < 4; i++)
            {
                if (tetramino.tetrids[i].pRow + down > board.pfieldrows - 2) return false;
                if (tetramino.tetrids[i].pRow < 0) return false;
                if (tetramino.tetrids[i].pColumn + shift < 1) return false;
                if (tetramino.tetrids[i].pColumn + shift > board.pfieldcolumns - 2) return false;
                if (board.field[tetramino.tetrids[i].pRow + down][tetramino.tetrids[i].pColumn + shift].pBorderorblock) return false;
            }
            return true;
        }

        /// <summary>
        /// механизм смещения тетрамино
        /// </summary>
        /// <param name="shift"></param>
        private void Shift(int shift)
        {
            for (int i = 0; i < 4; i++)
            {
                currenttetramino.tetrids[i].pColumn += shift;
            }
        }

        /// <summary>
        /// движение вниз
        /// </summary>
        /// <param name="shift">шаг вниз</param>
        private void Down(int shift)
        {
            for (int i = 0; i < 4; i++)
            {
                currenttetramino.tetrids[i].pRow += shift;
            }
        }

        /// <summary>
        /// падение
        /// </summary>
        /// <returns></returns>
        private int InstantlyDown()
        {
            int step = 0;

            for (int i = 0; i < board.pfieldrows; i++)
            {
                bool candown = true;
                for (int j = 0; j < 4; j++)
                {
                    if (board.field[currenttetramino.tetrids[j].pRow + step + 1][currenttetramino.tetrids[j].pColumn].pBorderorblock) candown = false;
                }

                if (candown) step++;
                else break;
            }
            return step;
        }

        /// <summary>
        /// вращение
        /// </summary>
        /// <param name="tetramino"></param>
        /// <returns></returns>
        private Tetramino Rotate(Tetramino tetramino)
        {

            Tetramino rotated = new Tetramino();
            rotated = tetraminoids.GetCopy(tetramino);

            int[,] rMatrix = new int[,] { { 0, 1 }, { -1, 0 } };
            int[] tMatrix = new int[] { rotated.tetrids[0].pRow, rotated.tetrids[0].pColumn };

            if (currenttetramino.pTetraminoview != TetraminoView.O)
            {
                for (int i = 1; i < 4; i++)
                {
                    int[] cMatrix = new int[] { rotated.tetrids[i].pRow, rotated.tetrids[i].pColumn };
                    rotated.tetrids[i].pRow = (cMatrix[0] - tMatrix[0]) * rMatrix[0, 0] + (cMatrix[1] - tMatrix[1]) * rMatrix[0, 1] + tMatrix[0];
                    rotated.tetrids[i].pColumn = (cMatrix[0] - tMatrix[0]) * rMatrix[1, 0] + (cMatrix[1] - tMatrix[1]) * rMatrix[1, 1] + tMatrix[1];
                }

            }
            return rotated;
        }

        /// <summary>
        /// образование блока
        /// </summary>
        private void Transform()
        {
            int row;
            int column;
            bool transform = false;
            for (int i = 0; i < 4; i++)
            {
                row = currenttetramino.tetrids[i].pRow + 1;
                column = currenttetramino.tetrids[i].pColumn;
                if (board.field[row][column].pBorderorblock) transform = true;
            }

            if (transform)
            {
                for (int i = 0; i < 4; i++)
                {
                    row = currenttetramino.tetrids[i].pRow;
                    column = currenttetramino.tetrids[i].pColumn;
                    board.field[row][column].pCelltype = CellsType.Blockcell;
                }
                currenttetramino = tetraminoids.GetRandomTetramino();
            }
        }

        /// <summary>
        /// очистка
        /// </summary>
        private void Clear()
        {
            bool clear = true;
            int row = 0;
            int combo = 0;

            while (clear)
            {
                for (int i = board.pfieldrows - 2; i > 0; i--)
                {
                    clear = true;
                    for (int j = 1; j < board.pfieldcolumns - 1; j++)
                    {
                        if (board.field[i][j].pCelltype != CellsType.Blockcell) clear = false;
                    }
                    if (clear)
                    {
                        row = i;
                        lines++;
                        break;
                    }
                }

                if (clear)
                {
                    for (int i = row; i > 4; i--)
                    {
                        for (int j = 1; j < board.pfieldcolumns - 1; j++)
                        {
                            if (board.field[i][j].pCelltype != CellsType.Blockcell) continue;
                            board.field[i][j].pCelltype = board.field[i - 1][j].pCelltype;
                        }
                    }
                    combo++;
                }
            }
            score += GetScore(combo);
            board.pscore = score;
            board.plines = lines;
        }


        /// <summary>
        /// начисление очков
        /// </summary>
        /// <param name="combo"></param>
        /// <returns></returns>
        private int GetScore(int combo)
        {
            if (combo > 2) return 80 * combo * combo;
            return 80 * combo;
        }

        /// <summary>
        /// вывод фигуры на экран
        /// </summary>
        /// /// <param name="current">рабочий экземпляр тетрамино</param>
        private void PlaceTetramino(bool show)
        {
            if (show)
            {
                for (int i = 0; i < 4; i++)
                {
                    board.field[currenttetramino.tetrids[i].pRow][currenttetramino.tetrids[i].pColumn].pCelltype = CellsType.Fugurecell;
                }
            }
            else
            {
                for (int i = 0; i < board.pfieldrows - 1; i++)
                {
                    for (int j = 1; j < board.pfieldcolumns - 1; j++)
                    {
                        if (board.field[i][j].pCelltype == CellsType.Fugurecell) board.field[i][j].pCelltype = CellsType.Emptycell;
                    }
                }
            }
            Console.Write(board);
        }
    }
}
