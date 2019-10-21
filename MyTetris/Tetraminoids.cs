using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTetris
{
    class Tetraminoids
    {
        Tetramino[] tetraminoids;
        Random random = new Random();

        public Tetraminoids()
        {
            tetraminoids = new Tetramino[7];
            InitTetramino();
        }

        public Tetramino GetRandomTetramino()
        {
            Tetramino rndtetramino = tetraminoids[random.Next(7)];
            return GetCopy(rndtetramino);
        }

        public Tetramino GetCopy(Tetramino tetramino)
        {
            Tetramino copy = new Tetramino();
            copy.pTetraminoview = tetramino.pTetraminoview;
            for (int i = 0; i < 4; i++)
            {
                copy.tetrids[i] = tetramino.tetrids[i];
            }
            return copy;
        }

        private void InitTetramino()
        {
            Tetramino tetraminoI = new Tetramino();
            tetraminoI.pTetraminoview = TetraminoView.I;
            tetraminoI.tetrids[0] = new Tetrids(1, 4);//     *
            tetraminoI.tetrids[1] = new Tetrids(0, 4);//     @
            tetraminoI.tetrids[2] = new Tetrids(2, 4);//     *
            tetraminoI.tetrids[3] = new Tetrids(3, 4);//     *
            tetraminoids[0] = tetraminoI;

            Tetramino tetraminoO = new Tetramino();
            tetraminoO.pTetraminoview = TetraminoView.O;
            tetraminoO.tetrids[0] = new Tetrids(0, 4);//     @ *
            tetraminoO.tetrids[1] = new Tetrids(1, 4);//     * *
            tetraminoO.tetrids[2] = new Tetrids(0, 5);//
            tetraminoO.tetrids[3] = new Tetrids(1, 5);//
            tetraminoids[1] = tetraminoO;

            Tetramino tetraminoT = new Tetramino();
            tetraminoT.pTetraminoview = TetraminoView.T;
            tetraminoT.tetrids[0] = new Tetrids(0, 4);//   * @ *
            tetraminoT.tetrids[1] = new Tetrids(0, 3);//     *
            tetraminoT.tetrids[2] = new Tetrids(0, 5);//
            tetraminoT.tetrids[3] = new Tetrids(1, 4);//
            tetraminoids[2] = tetraminoT;

            Tetramino tetraminoL = new Tetramino();
            tetraminoL.pTetraminoview = TetraminoView.L;
            tetraminoL.tetrids[0] = new Tetrids(1, 4);//     *
            tetraminoL.tetrids[1] = new Tetrids(0, 4);//     @
            tetraminoL.tetrids[2] = new Tetrids(2, 4);//     * *
            tetraminoL.tetrids[3] = new Tetrids(2, 5);//
            tetraminoids[3] = tetraminoL;

            Tetramino tetraminoIL = new Tetramino();
            tetraminoIL.pTetraminoview = TetraminoView.IL;
            tetraminoIL.tetrids[0] = new Tetrids(1, 4);//    *
            tetraminoIL.tetrids[1] = new Tetrids(0, 4);//    @
            tetraminoIL.tetrids[2] = new Tetrids(2, 4);//  * *
            tetraminoIL.tetrids[3] = new Tetrids(2, 3);//
            tetraminoids[4] = tetraminoIL;

            Tetramino tetraminoS = new Tetramino();
            tetraminoS.pTetraminoview = TetraminoView.S;
            tetraminoS.tetrids[0] = new Tetrids(1, 4);//     * *
            tetraminoS.tetrids[1] = new Tetrids(0, 4);//   * @
            tetraminoS.tetrids[2] = new Tetrids(0, 5);//
            tetraminoS.tetrids[3] = new Tetrids(1, 3);//
            tetraminoids[5] = tetraminoS;

            Tetramino tetraminoZ = new Tetramino();
            tetraminoZ.pTetraminoview = TetraminoView.Z;
            tetraminoZ.tetrids[0] = new Tetrids(1, 4);//   * *
            tetraminoZ.tetrids[1] = new Tetrids(0, 4);//     @ *
            tetraminoZ.tetrids[2] = new Tetrids(0, 3);//
            tetraminoZ.tetrids[3] = new Tetrids(1, 5);//
            tetraminoids[6] = tetraminoZ;


        }
    }
}
