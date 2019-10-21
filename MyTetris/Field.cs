using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTetris
{

    /// <summary>
    /// отображение поля и элементов на нем
    /// </summary>
    class Board
    {
        int fieldrows;
        int fieldcolumns;
        public Cells[][] field;

        public int pfieldrows
        {
            get
            {
                return fieldrows;
            }
            private set
            {
                fieldrows = value;
            }
        }

        public int pfieldcolumns
        {
            get
            {
                return fieldcolumns;
            }
            private set
            {
                fieldcolumns = value;
            }
        }

        private int lines;
        private int score;
        public int plines
        {
            get
            {
                return lines;
            }
            set
            {
                lines = value;
            }
        }

        public int pscore
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
            }
        }

        public Board()
        {
            fieldrows = 24;
            fieldcolumns = 10;
            lines = 0;
            score = 0;

            initField();
            fillField();
        }

        /// <summary>
        /// инициализация поля массивом элементов типа Cells
        /// </summary>
        private void initField()
        {
            field = new Cells[fieldrows][];

            for (int i = 0; i < fieldrows; i++)
            {
                field[i] = new Cells[fieldcolumns];
            }
        }

        /// <summary>
        /// заполнение поля элементами: пустыми ячейками и границей
        /// </summary>
        private void fillField()
        {
            for (int i = 0; i < fieldrows - 1; i++)
            {
                for (int j = 1; j < fieldcolumns - 1; j++)
                {
                    field[i][j] = new Cells(CellsType.Emptycell);
                }
            }

            for (int i = 0; i < fieldrows - 1; i++)
            {
                field[i][0] = new Cells(CellsType.Bordercell);
                field[i][fieldcolumns - 1] = new Cells(CellsType.Bordercell);
            }

            for (int j = 0; j < fieldcolumns; j++)
            {
                field[fieldrows - 1][j] = new Cells(CellsType.Bordercell);
            }
        }

        /// <summary>
        /// вывод поля на экран
        /// </summary>
        public void ShowField()
        {
            for (int i = 0; i < fieldrows; i++)
            {
                Console.SetCursorPosition(0, i);
                for (int j = 0; j < fieldcolumns; j++)
                {
                    Console.Write(field[i][j]);
                }
            }
            Console.SetCursorPosition(20, 10);
            Console.WriteLine("Линий: {0}", plines);
            Console.SetCursorPosition(20, 12);
            Console.WriteLine("Очков: {0}", pscore);
        }

        public override string ToString()
        {
            ShowField();
            return String.Empty;
        }
    }
}
