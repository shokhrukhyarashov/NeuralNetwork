public class NeuralNetwork
{
    private double[,] weights;
    enum OPERATION
    {
        Add,
        Subtract,
        Multiply
    }

    public NeuralNetwork()
    {
        Random random = new Random();
        int numberOfInputNodes = 3;
        int numberOfOutputNodes = 1;
        weights = new double[numberOfInputNodes, numberOfOutputNodes];
        for (int i = 0; i < numberOfInputNodes; i++)
        {
            for (int j = 0; j < numberOfOutputNodes; j++)
            {
                weights[i, j] = 2 * random.NextDouble() - 1;
            }
        }
    }
    
    private double[,] Activate(double[,] matrix, bool isDerivative)
    {
        // Activation function: Sigmoid matritsani har biri uchun sigmoid yoki direvative sifmoidni qo'llash funksiyasini qo'llash
        int numberOfRows = matrix.GetLength(0);
        int numberOfCols = matrix.GetLength(1);
        double[,] result = new double[numberOfRows, numberOfCols];
        for (int row = 0; row < numberOfRows; row++)
        {
            for (int col = 0; col < numberOfCols; col++)
            {
                double sigmoidOutput = 1 / (1 + Math.Exp(-matrix[row, col]));
                double derivativeSigmoidOutput = sigmoidOutput * (1 - sigmoidOutput);
                result[row, col] = isDerivative ? derivativeSigmoidOutput : sigmoidOutput;
            }
        }
        return result;

    }
    
    public void Train(double[,] traininigInputs, double[,] trainingOutputs, int numberOfIterations)
    {
        for (int iteration = 0; iteration < numberOfIterations; iteration++)
        {
            double[,] output = Think(traininigInputs);
            double[,] error = PerformOperation(trainingOutputs, output, OPERATION.Subtract);
            double[,] adjustments = DotProduct(Transpose(trainingOutputs), Activate(error, true));
            weights = PerformOperation(weights, adjustments, OPERATION.Add);
        }
    }
    
    private double[,] DotProduct(double[,] matrix1, double[,] matrix2)
    {
        // Matritsalarni ko'paytirish funksiyasi
        //  C=A×B
        /*
        Savol: matritsalar ko‘payishi uchun qanday shart bajarilishi kerak?
        👉 (Masalan, A o‘lchami m × n, B o‘lchami n × p bo‘lsa, ko‘paytma m × p bo‘ladi, to‘g‘rimi?)
        */
        int numberOfMatrix1Rows = matrix1.GetLength(0);
        int numberOfMatrix1Cols = matrix1.GetLength(1);
        int numberOfMatrix2Rows = matrix2.GetLength(0);
        int numberOfMatrix2Cols = matrix2.GetLength(1);

      double[,] result = new double[numberOfMatrix1Rows, numberOfMatrix2Cols];


        for (int rowInMatrix1 = 0; rowInMatrix1 < numberOfMatrix1Rows; rowInMatrix1++)
    {
        for (int colInMatrix2 = 0; colInMatrix2 < numberOfMatrix2Cols; colInMatrix2++)
        {
            double sum = 0.0;
            for (int colInMatrix1 = 0; colInMatrix1 < numberOfMatrix1Cols; colInMatrix1++)
            {
                sum += matrix1[rowInMatrix1, colInMatrix1] * matrix2[colInMatrix1, colInMatrix2];
            }
            result[rowInMatrix1, colInMatrix2] = sum;
        }
    }
        return result;
    }
    
    public double[,] Think(double[,] inputs)
    {
        return Activate(DotProduct(inputs, weights), false);
    }

    private double[,] PerformOperation(double[,] matrix1, double[,] matrix2, OPERATION operation)
    {
        // Matritsalar ustida arifmetik amallarni bajarish funksiyasi
        int numberOfRows = matrix1.GetLength(0);
        int numberOfCols = matrix1.GetLength(1);
        double[,] result = new double[numberOfRows, numberOfCols];
        for (int row = 0; row < numberOfRows; row++)
        {
            for (int col = 0; col < numberOfCols; col++)
            {
                switch (operation)
                {
                    case OPERATION.Add:
                        result[row, col] = matrix1[row, col] + matrix2[row, col];
                        break;
                    case OPERATION.Subtract:
                        result[row, col] = matrix1[row, col] - matrix2[row, col];
                        break;
                    case OPERATION.Multiply:
                        result[row, col] = matrix1[row, col] * matrix2[row, col];
                        break;
                }
            }
        }
        return result;
    }
    
    private double[,] Transpose(double[,] matrix)
    {
        return matrix.Cast<double>().ToArray().Transpose(matrix.GetLength(0), matrix.GetLength(1));
    }

    internal void PrintMatrix(double[,] outputs)
    {
        int rows = outputs.GetLength(0);
        int cols = outputs.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(Math.Round(outputs[i, j]) + " ");
            }
            Console.WriteLine();
        }
    }
}
