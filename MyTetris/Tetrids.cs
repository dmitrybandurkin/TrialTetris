using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTetris
{

    /// <summary>
    /// класс описывающий элементы фигуры
    /// </summary>
    struct Tetrids
    {
        private int row;
        private int column;
        private CellsType tetridstype;

        public int pRow
        {
            get
            {
                return row;
            }
            set
            {
                row = value;
            }
        }


        public int pColumn
        {
            get
            {
                return column;
            }
            set
            {
                column = value;
            }
        }

        public CellsType pTetridstype
        {
            get
            {
                return tetridstype;
            }
            set
            {
                tetridstype = value;
            }
        }

        /// <summary>
        /// координаты элемента
        /// </summary>
        /// <param name="row">строка</param>
        /// <param name="column">столбец</param>
        public Tetrids(int row, int column)
        {
            this.row = row;
            this.column = column;
            this.tetridstype = CellsType.Fugurecell;
        }
    }
}
