using Perceptron;

Func<double, double> activation = (double value) => value > 0 ? 1 : 0;

List<DataTrain> dataTrain = new()
{
    DataTrain.Create(new double[]{ 0,0},0),
    DataTrain.Create(new double[]{ 0,1},0),
    DataTrain.Create(new double[]{ 1,0},0),
    DataTrain.Create(new double[]{ 1,1},1),
};

PerceptronSimple perceptron = new(2, 0.2, activation);
bool isSuccess = perceptron.Train(dataTrain, 1000);
if (!isSuccess)
{
    Console.WriteLine("The iteration number was met and a model was not generated for the input data.");
}
else
{
    Console.WriteLine($"0  0  = {perceptron.Predice(new double[] { 0, 0 })}");
    Console.WriteLine($"0  1  = {perceptron.Predice(new double[] { 0, 1 })}");
    Console.WriteLine($"1  0  = {perceptron.Predice(new double[] { 1, 0 })}");
    Console.WriteLine($"1  1  = {perceptron.Predice(new double[] { 1, 1 })}");
}


Console.ReadKey();