using PROJE2;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJE2
{
    class Program
    {
        static void Main()
        {
            double[][] inputSet = new double[21][];
            inputSet[0] = new double[] { 7.6, 11 };
            inputSet[1] = new double[] { 8, 10 };
            inputSet[2] = new double[] { 6.6, 8 };
            inputSet[3] = new double[] { 8.4, 10 };
            inputSet[4] = new double[] { 8.8, 12 };
            inputSet[5] = new double[] { 7.2, 10 };
            inputSet[6] = new double[] { 8.1, 11 };
            inputSet[7] = new double[] { 9.5, 9 };
            inputSet[8] = new double[] { 7.3, 9 };
            inputSet[9] = new double[] { 8.9, 11 };
            inputSet[10] = new double[] { 7.5, 11 };
            inputSet[11] = new double[] { 7.6, 9 };
            inputSet[12] = new double[] { 7.9, 10 };
            inputSet[13] = new double[] { 8, 10 };
            inputSet[14] = new double[] { 7.2, 9 };
            inputSet[15] = new double[] { 8.8, 10 };
            inputSet[16] = new double[] { 7.6, 11 };
            inputSet[17] = new double[] { 7.5, 10 };
            inputSet[18] = new double[] { 9, 10 };
            inputSet[19] = new double[] { 7.7, 9 };
            inputSet[20] = new double[] { 8.1, 11 };

            double[][] trialInputSet = new double[5][];
            trialInputSet[0] = new double[] { 9.1, 7 };
            trialInputSet[1] = new double[] { 7.4, 9 };
            trialInputSet[2] = new double[] { 6.9, 11};
            trialInputSet[3] = new double[] { 8.3, 8 };
            trialInputSet[4] = new double[] { 9.6, 10 };

            double[] targets = { 77, 70, 55, 78, 95, 67, 80, 87, 60, 88, 72, 58, 70, 76, 58, 81, 74, 67, 82, 62, 82 };
            List<double> trialOutputs = new List<double>(); // for 5 trial outputs
            // first input divided by 10, second is 15 and targets list is 100 for Normalize
            double normalizeFactorInput1 = 10;
            double normalizeFactorInput2 = 15;
            double normalizeFactorTargets = 100;
            // Data Normalize
            Normalize(inputSet, normalizeFactorInput1, normalizeFactorInput2);
            Normalize(targets, normalizeFactorTargets);
            //trial data Normalize
            Normalize(trialInputSet, normalizeFactorInput1, normalizeFactorInput2);

            Neuron neuron = new Neuron();

            int epochs = 50;
            neuron.Train(inputSet, targets, epochs, trialInputSet, trialOutputs);

            Console.WriteLine("Girdi Değerleri\t\tHedef Değer\tTahmini Değer");
            for (int i = 0; i < inputSet.Length; i++)
            {
                double output = neuron.Activate(inputSet[i][0], inputSet[i][1]);
                Console.WriteLine($"{inputSet[i][0]}\t {inputSet[i][1]:F2}\t\t{targets[i]}\t\t{output:F2}");
            }

            double mse = CalculateMSE(neuron, inputSet, targets);
            Console.WriteLine($"MSE: {mse}");
            Console.WriteLine();
            Console.WriteLine("Rastgele veriler ile tahmini sonuçlar: ");
            int k = 1;
            foreach (var item in trialOutputs)
            {
                Console.WriteLine($"{k}. verilerin tahmini değeri: {item}");
                k++;
            }

            Console.ReadLine();
        }

        static void Normalize(double[][] data, double factor1, double factor2) // Normalize for weights
        {
            for (int i = 0; i < data.Length; i++)
            {
                data[i][0] /= factor1;
                data[i][1] /= factor2;
            }
        }

        static void Normalize(double[] data, double factor) // Normalize for targets list
        {
            for (int i = 0; i < data.Length; i++)
            {
                data[i] /= factor;
            }
        }

        static double CalculateMSE(Neuron neuron, double[][] inputSet, double[] targets)
        {
            double sumSquaredError = 0;
            for (int i = 0; i < inputSet.Length; i++)
            {
                double output = neuron.Activate(inputSet[i][0], inputSet[i][1]);
                double error = targets[i] - output;
                sumSquaredError += Math.Pow(error, 2);
            }
            return sumSquaredError / inputSet.Length;
        }
    }
}
