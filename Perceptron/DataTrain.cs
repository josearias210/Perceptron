namespace Perceptron
{
    using System;

    public class DataTrain
    {
        public double[] Inputs { get; private set; }
        public double Output { get; private set; }

        private DataTrain(double[] inputs, double output)
        {
            if (inputs is null)
            {
                throw new ArgumentNullException(nameof(inputs));
            }

            this.Inputs = inputs;
            this.Output = output;
        }

        public static DataTrain Create(double[] inputs, double output)
        {
            return new DataTrain(inputs, output);
        }
    }
}