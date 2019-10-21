using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTetris
{
    public enum CellsType
    {
        Emptycell,
        Bordercell,
        Fugurecell,
        Blockcell
    }



    class Cells
    {
        private CellsType celltype;
        public CellsType pCelltype
        {
            get
            {
                return celltype;
            }
            set
            {
                celltype = value;
            }
        }

        public Cells(CellsType celltype)
        {
            this.celltype = celltype;
        }

        /// <summary>
        /// переопределение метода для графического вывода ячеек
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            switch (celltype)
            {
                case CellsType.Bordercell:
                    return "■ ";
                    break;
                case CellsType.Emptycell:
                    return "  ";
                    break;
                case CellsType.Fugurecell:
                    return "# ";
                    break;
                case CellsType.Blockcell:
                    return "■ ";
                    break;
                default:
                    return "  ";
                    break;
            }
        }

        public bool pBorderorblock
        {
            get
            {
                return pCelltype == CellsType.Bordercell || pCelltype == CellsType.Blockcell;
            }
        }
    }
}
