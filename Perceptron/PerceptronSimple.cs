namespace Perceptron
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PerceptronSimple
    {
        private int N { get; set; }
        private double Bios { get; set; }
        private double[] Weights { get; set; }
        private double Alpha { get; set; }
        private Func<double, double> Activation { get; }

        public PerceptronSimple(int inputs, double alpha, Func<double, double> activation)
        {
            if (inputs < 1)
            {
                throw new ArgumentException($"You must enter tickets greater than 0.");
            }

            this.N = inputs;
            this.Alpha = alpha;
            this.Bios = Random();
            this.Weights = Enumerable.Repeat(0, this.N).Select(i => Random()).ToArray();
            this.Activation = activation ?? throw new ArgumentNullException(nameof(activation));
        }

        public double Predice(double[] inputs)
        {
            double predice = 0f;
            for (int i = 0; i < N; i++)
            {
                predice += inputs[i] * this.Weights[i];
            }

            predice += this.Bios;
            return this.Activation(predice);
        }

        public bool Train(IEnumerable<DataTrain> data, int limit = 10000)
        {
            double y;
            double error = 0f;

            this.EnsuredDataTrain(data);
            for (int l = 1; l <= limit; l++)
            {
                foreach (var d in data)
                {
                    y = this.Predice(d.Inputs);
                    error = d.Output - y;
                    if (error != 0)
                    {
                        this.UpdateWeights(error, d.Inputs);
                        break;
                    }
                }

                if (error == 0f)
                {
                    return true;
                }

            }
            return false;
        }

        private void UpdateWeights(double error, double[] inputs)
        {
            for (int w = 0; w < this.N; w++)
            {
                this.Weights[w] += this.Alpha * error * inputs[w];
            }
            this.Bios += this.Alpha * error;
        }

        private void EnsuredDataTrain(IEnumerable<DataTrain> data)
        {
            if (data is null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            if (data.Any(a => a.Inputs.Length != this.N))
            {
                throw new ArgumentException($"All input data must have the length of {this.N} indicated above.");
            }
        }

        private double Random()
        {
            var rand = new Random();
            return rand.NextDouble() * 2 - 1;
        }
    }
}