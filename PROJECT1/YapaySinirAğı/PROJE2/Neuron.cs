using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJE2
{
    public class Neuron
    {
        private double weight1;
        private double weight2;
        private double learningRate = 0.01;

        public Neuron()
        {
            Random random = new Random();
            weight1 = random.NextDouble(); // 0 between 1
            weight2 = random.NextDouble();
        }

        public double Activate(double input1, double input2)
        {
            return input1 * weight1 + input2 * weight2;
        }

        public void Train(double[][] inputSet, double[] targets, int epochs, double[][] trialInputSet, List<double> trialOutputs)
        {
            for (int epoch = 0; epoch < epochs; epoch++)
            {
                for (int i = 0; i < inputSet.Length; i++)
                {
                    double output = Activate(inputSet[i][0], inputSet[i][1]);
                    double error = targets[i] - output;

                    weight1 += learningRate * error * inputSet[i][0];
                    weight2 += learningRate * error * inputSet[i][1];
                }
            }
            // trial inputs
            // weight1 and weight2 are trained.
            for (int i = 0; i < trialInputSet.Length; i++)
            {
                double output = trialInputSet[i][0] * weight1 + trialInputSet[i][1] * weight2;
                trialOutputs.Add(output);
            }
        }
    }
}
