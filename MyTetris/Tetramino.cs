
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTetris
{
    public enum TetraminoView
    {
        I,
        O,
        T,
        L,
        S,
        Z,
        IL
    }



    class Tetramino
    {
        private TetraminoView tetraminoview;
        public Tetrids[] tetrids;
        public TetraminoView pTetraminoview
        {
            get
            {
                return tetraminoview;
            }
            set
            {
                tetraminoview = value;
            }
        }

        public Tetramino()
        {
            tetrids = new Tetrids[4];
        }
    }
}