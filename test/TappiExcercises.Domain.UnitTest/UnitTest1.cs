using TappiExcercises.Domain.Matrix;

namespace TappiExcercises.Domain.UnitTest
{
    public class UnitTest1
    {
        
        [Fact]
        public void Test1()
        {
            MatrixPorcoschifo coefficients = new MatrixPorcoschifo(3, 1);
            coefficients[0, 0] = 7;
            coefficients[1, 0] = 0;
            coefficients[2, 0] = 1;
            double?[] vector = new double?[] { 1.0, -4.0, 2.0, -3.0, -2.0, 3.0, 1.0, -2.0, 1.0 };
            SquareMatrix matrix = new SquareMatrix(vector);
            

        }
    }
}