using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TappiExcercises.Domain.Matrix
{
    internal class SquareMatrix : Matrix
    {
        public SquareMatrix(int dimension) : base(dimension, dimension)
        { }

        public SquareMatrix(double[] original) : base((int)Math.Sqrt(original.Length), (int)Math.Sqrt(original.Length))
        {
            int end = vector.Length;
            for (int i = 0; i < end; i++)
                vector[i] = original[i];
        }

        public SquareMatrix() : this(3)
        { }

        public int Dimension => Rows;

        public double? Determinant(SquareMatrix matrix)
        {
            // Restituisce il determinante della matrice.
            //
            // 'matrix': matrice quadrata, di dimensione almeno 2.
            //

            int dim = matrix.Dimension;   // Dimensione matrice di input.
            double? result = 0;

            if (dim == 2)
            {
                result = matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            }
            else
            {
                int r = 0;   // Riga sulla quale si calcola il determinante.
                int k = 0;   // +1 o -1, coefficiente.

                for (int c = 0; c < dim; c++)
                {
                    // Calcolo del segno basato sulla posizione (r+c)
                    if ((r + c) % 2 == 0)
                        k = 1;
                    else
                        k = -1;

                    // Espansione di Laplace: elemento * segno * determinante della sottomatrice
                    result += k * matrix[r, c] * Determinant(SubMatrix(matrix, r, c));
                }
            }

            return result;
        }

        public SquareMatrix SubMatrix(SquareMatrix? matrix, int row, int col)
        {
            // Restituisce la Sottomatrice della matrice 'matrix' eliminando la riga 'row' e la colonna 'col'.
            //
            // 'matrix': matrice quadrata, di dimensione almeno 3.
            // 'row': indice riga da eliminare, a base 0.
            // 'col': indice colonna da eliminare, a base 0.

            // TODO

            for (int c=0; c<Columns;c++)
            {
                matrix[row, c] = null;
            }

            for (int r = 0; r < Rows; r++)
            {
                matrix[r, col] = null;
            }

            SquareMatrix result = new SquareMatrix(matrix.Rows - 1);

            for(int r=0;r<matrix.Rows;r++)
            {
                for(int c=0;c<matrix.Columns;c++)
                {
                    if(r >= matrix.Rows ||)
                }
            }
        }
    }
}
