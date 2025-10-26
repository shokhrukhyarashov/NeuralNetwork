
// public class NeuralNetwork
// {
//     public double[,] Weights;
//     enum OERATION
//     {
//         Add,
//         Subtract,
//         Multiply,
//     }
//     public NeuralNetwork()
//     {
//         Random rand = new Random(1);
//         int numberOfInputNodes = 3;
//         int numberOfOutputNodes = 1;
//         Weights = new double[numberOfInputNodes, numberOfOutputNodes];
//         for (int i = 0; i < numberOfInputNodes; i++)
//         {
//             for (int j = 0; j < numberOfOutputNodes; j++)
//             {
//                 Weights[i, j] = 2 * rand.NextDouble() - 1;
//             }
//         }
//     }
//     private double[,] Activate(double[,] matrix, bool isDerivative)
//     {
//         int numberOfRows = matrix.GetLength(0);
//         int numberOfCols = matrix.GetLength(1);
//         double[,] result = new double[numberOfRows, numberOfCols];
//         for (int row = 0; row < numberOfRows; row++)
//         {
//             for (int col = 0; col < numberOfCols; col++)
//             {
//                 double sigmoidOutput = result[row, col] = 1 / (1 + Math.Exp(-matrix[row, col]));
//                 double direvativeSigmoidOutput = result[row, col] = matrix[row, col] * (1 + Math.Exp(-matrix[row, col]));
//                 result[row, col] = isDerivative ? direvativeSigmoidOutput : sigmoidOutput;

//             }
//         }
//         return result;
//     }

//     public void Train(double[,] trainingInputs, double[,] trainingOutputs, int numberOfTrainingIterations)
//     {
//         for (int iteration = 0; iteration < numberOfTrainingIterations; iteration++)
//         {
//             double[,] output = Activate(trainingInputs, false);
//             double[,] error = PerformOperation(trainingOutputs, output, OERATION.Subtract);
//             double[,] adjustments = DotProduct(Transpose(trainingOutputs), Activate(error, true), OERATION.Multiply);
//             Weights = PerformOperation(Weights, adjustments, OERATION.Add);
//         }
//     }

//     private double[,] DotProduct(double[,] matrix1, double[,] matrix2, OERATION multiply)
//     {
//         int matrix1Rows = matrix1.GetLength(0);
//         int matrix1Cols = matrix1.GetLength(1);
//         int matrix2Rows = matrix2.GetLength(0);
//         int matrix2Cols = matrix2.GetLength(1);

//         double[,] result = new double[matrix1Cols, matrix2Cols];
//         for (int rowsMatrix1 = 0; rowsMatrix1 < matrix1Rows; rowsMatrix1++)
//         {
//             for (int colsMatrix2 = 0; colsMatrix2 < matrix2Cols; colsMatrix2++)
//             {
//                 double sum = 0;
//                 for (int colsMatrix1 = 0; colsMatrix1 < matrix1Cols; colsMatrix1++)
//                 {
//                     sum += matrix1[rowsMatrix1, colsMatrix1] * matrix2[colsMatrix1, colsMatrix2];
//                 }
//                 result[rowsMatrix1, colsMatrix2] = sum;
//             }
//         }
//         return result;
//     }
//     public double[,] Think(double[,] inputs)
//     {
//         return Activate(DotProduct(inputs, Weights, OERATION.Multiply), false);
//     }

//     private double[,] PerformOperation(double[,] matrix1, double[,] matrix2, OERATION operation)
//     {
//         int rows = matrix1.GetLength(0);
//         int cols = matrix1.GetLength(1);
//         double[,] result = new double[rows, cols];
//         for (int row = 0; row < rows; row++)
//         {
//             for (int col = 0; col < cols; col++)
//             {
//                 switch (operation)
//                 {
//                     case OERATION.Add:
//                         result[row, col] = matrix1[row, col] + matrix2[row, col];
//                         break;
//                     case OERATION.Subtract:
//                         result[row, col] = matrix1[row, col] - matrix2[row, col];
//                         break;
//                     case OERATION.Multiply:
//                         result[row, col] = matrix1[row, col] * matrix2[row, col];
//                         break;
//                 }
//             }
//         }
//         return result;
//     }
//     public static double[,] Transpose(double[,] matrix)
//     {
//         return matrix.Cast<double>().ToArray().Transpose(matrix.GetLength(0), matrix.GetLength(1));
//     }


//     public static void Main(string[] args)
//     {
//         NeuralNetwork neuralNetwork = new NeuralNetwork();
//         double[,] trainingInputs = new double[,]
//         {
//             {0,0,0},
//             {1,1,1},
//             {1,0,0 }
//         };
//         double[,] trainingOutputs = new double[,]
//         {
//             {0},
//             {1},
//             {1}
//         };
//         neuralNetwork.Train(trainingInputs, trainingOutputs, 10000);
//         double[,] output = neuralNetwork.Think(new double[,]
//         {
//             {0,1,0},
//             {0,0,0},
//             {0,0,1}
//         });

//         PrintMatrix(output);

    
//     }

//     private static void PrintMatrix(double[,] matrix)
//     {
//         int rows = matrix.GetLength(0);
//         int cols = matrix.GetLength(1);
//         for (int row = 0; row < rows; row++)
//         {
//             for (int col = 0; col < cols; col++)
//             {
//                 Console.Write(Math.Round(matrix[row, col]) + " ");
//             }
//             Console.WriteLine();
//         }
//     }
// }
// public static class Extensions
// {
//     public static double[,] Transpose(this double[] matrix,int rows, int cols)
//     {
//         double[,] transposedMatrix = new double[cols, rows];
//         for (int row = 0; row < rows; row++)
//         {
//             for (int col = 0; col < cols; col++)
//             {
//                 transposedMatrix[col, row] = matrix[row * cols + col];
//             }
//         }
        
//         return transposedMatrix;
//     }
// }   

using System;

public class NeuralNetwork
{
    public double[,] Weights;

    enum OPERATION
    {
        Add,
        Subtract,
        Multiply,
    }

    public NeuralNetwork()
    {
        Random rand = new Random(1);
        int numberOfInputNodes = 3;
        int numberOfOutputNodes = 1;

        Weights = new double[numberOfInputNodes, numberOfOutputNodes];
        for (int i = 0; i < numberOfInputNodes; i++)
        {
            for (int j = 0; j < numberOfOutputNodes; j++)
            {
                // [-1, 1] oralig‘ida random og‘irlik
                Weights[i, j] = 2 * rand.NextDouble() - 1;
            }
        }
    }

    // Sigmoid aktivatsiya funksiyasi
    private double[,] Activate(double[,] matrix, bool isDerivative)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        double[,] result = new double[rows, cols];

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                double sigmoid = 1 / (1 + Math.Exp(-matrix[r, c]));
                double derivative = sigmoid * (1 - sigmoid);
                result[r, c] = isDerivative ? derivative : sigmoid;
            }
        }
        return result;
    }

    // Asosiy o‘qitish jarayoni
    public void Train(double[,] trainingInputs, double[,] trainingOutputs, int numberOfTrainingIterations)
    {
        for (int iteration = 0; iteration < numberOfTrainingIterations; iteration++)
        {
            // 1. Forward pass
            double[,] output = Activate(DotProduct(trainingInputs, Weights), false);

            // 2. Error = expected - actual
            double[,] error = PerformOperation(trainingOutputs, output, OPERATION.Subtract);

            // 3. Adjustments = (inputs^T * error) * derivative
            double[,] adjustments = DotProduct(Transpose(trainingInputs), Activate(error, true));

            // 4. Update weights
            Weights = PerformOperation(Weights, adjustments, OPERATION.Add);
        }
    }

    // Dot Product (matritsa ko‘paytirish)
    private double[,] DotProduct(double[,] matrix1, double[,] matrix2)
    {
        int rows1 = matrix1.GetLength(0);
        int cols1 = matrix1.GetLength(1);
        int rows2 = matrix2.GetLength(0);
        int cols2 = matrix2.GetLength(1);

        if (cols1 != rows2)
            throw new Exception("Matritsalarni ko‘paytirish mumkin emas: o‘lchamlar mos emas.");

        double[,] result = new double[rows1, cols2];

        for (int i = 0; i < rows1; i++)
        {
            for (int j = 0; j < cols2; j++)
            {
                double sum = 0;
                for (int k = 0; k < cols1; k++)
                {
                    sum += matrix1[i, k] * matrix2[k, j];
                }
                result[i, j] = sum;
            }
        }
        return result;
    }

    // Element-wise operation (qo‘shish, ayirish, ko‘paytirish)
    private double[,] PerformOperation(double[,] matrix1, double[,] matrix2, OPERATION operation)
    {
        int rows = matrix1.GetLength(0);
        int cols = matrix1.GetLength(1);
        double[,] result = new double[rows, cols];

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                switch (operation)
                {
                    case OPERATION.Add:
                        result[r, c] = matrix1[r, c] + matrix2[r, c];
                        break;
                    case OPERATION.Subtract:
                        result[r, c] = matrix1[r, c] - matrix2[r, c];
                        break;
                    case OPERATION.Multiply:
                        result[r, c] = matrix1[r, c] * matrix2[r, c];
                        break;
                }
            }
        }
        return result;
    }

    // Matritsani Transpose qilish
    public static double[,] Transpose(double[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        double[,] result = new double[cols, rows];

        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                result[j, i] = matrix[i, j];

        return result;
    }

    // Forward pass (fikrlash)
    public double[,] Think(double[,] inputs)
    {
        return Activate(DotProduct(inputs, Weights), false);
    }

    // Natijani chiqarish
    private static void PrintMatrix(double[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                Console.Write(Math.Round(matrix[r, c], 3) + " ");
            }
            Console.WriteLine();
        }
    }

    // Main()
    public static void Main(string[] args)
    {
        NeuralNetwork nn = new NeuralNetwork();

        double[,] trainingInputs = new double[,]
        {
            {0,0,1},
            {1,1,1},
            {1,0,1},
            {0,1,1}
        };

        double[,] trainingOutputs = new double[,]
        {
            {0},
            {1},
            {1},
            {0}
        };

        Console.WriteLine("⏳ Training the network...");
        nn.Train(trainingInputs, trainingOutputs, 10000);
        Console.WriteLine("✅ Training complete.\n");

        double[,] newInputs = new double[,]
        {
            {1,0,0},
            {0,1,0},
            {1,1,0},
            {0,0,0}
        };

        double[,] output = nn.Think(newInputs);

        Console.WriteLine("🧠 Predicted outputs:");
        PrintMatrix(output);
    }
}
