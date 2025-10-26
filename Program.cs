using System;
public class Program
{
    static void Main()
    {
        // OR dataset (3 inputs)
        double[,] inputsForTrain = new double[,]
        {
            {0, 0, 0},
            {0, 0, 1},
            {0, 1, 0},
            {0, 1, 1},
            {1, 0, 0},
            {1, 0, 1},
            {1, 1, 0},
            {1, 1, 1},
        };

        double[,] outputsForTrain =
        {
            {0},
            {1},
            {1},
            {1},
            {1},
            {1},
            {1},
            {1},
        };

        NeuralNetwork nn = new NeuralNetwork();
        nn.Train(inputsForTrain, outputsForTrain, 1000);
        // Test the neural network with new inputs
        double[,] outputs = nn.Think(new double[,]
        {
            {0, 1, 0},
            {0, 0, 1},
            {0, 0, 1},
        }); 
        nn.PrintMatrix(outputs);

       
    }
}

