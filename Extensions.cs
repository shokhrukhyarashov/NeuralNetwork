public static class Extensions
{
     public static double[,] Transpose(this double[] array , int rows, int cols)
    {
        // Matritsaning transpozini olish funksiyasi
        double[,] transposedMatrix = new double[cols, rows];
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                transposedMatrix[col, row] = array[row * cols + col];
            }
        }
        return transposedMatrix;
    }
    
}