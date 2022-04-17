using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ANN
{
    class annprea
    {

        /// <summary>
        /// Variables
        /// </summary>
        private int num_input, num_hidden, num_output, num_datasets, num_Epoch;
        private int Epoch,Data_indexer;
        private int[] Data_used;
        private int Actual_data;
        private double eta, alpha, aError;
        private double min_Error;
        public double[,]   ih_w, ho_w, //weights
                           delta_ih_w, delta_ho_w,//delta of hidden and output layer weights
                           prev_delta_ih_w, prev_delta_ho_w,//previous deltas of the weights
                           ih_local_input, ho_local_input;
        public double[] h_bias, o_bias,//bias
                           h_out, o_out, //output of each neuron
                           oGrad, hGrad, //gradient of each layer
                           delta_h_bias, delta_o_bias, //delta of hidden and output layer biases
                           prev_delta_h_bias, prev_delta_o_bias; //previous deltas of the biases

        private double[] inputs, outputs;
        private double[,] lError;
        private double[,] NetOutputs;


        const string ANN_ACTIVATION_SIGMOID = "sigmoid",
                      ANN_ACTIVATION_LINEAR = "linear",
                      ANN_ACTIVATION_BIPOLAR_SIGMOID = "bipolar sigmoid";
        string activation_function,
                output_activation_function;
        double[,] Data;
        bool finished, MinErrorAchieved, ToUseTheNet, ToDebug;
        int NumberOfTrainings;
        Random rnd;
        
        public annprea()
        {
        }
         ~annprea()
        {
        }
        public annprea(double[,] TrainingData, int Ni, int Nh, int No, int Nd, double MinimalError, int MaxEpoch, double LearningRate, double Momentum, string hiddenActivationFunction = ANN_ACTIVATION_SIGMOID, string outputActivationFunction = ANN_ACTIVATION_SIGMOID)
        {
            num_input = Ni;
            num_hidden = Nh;
            num_output = No;
            num_datasets = Nd;
            num_Epoch = MaxEpoch;
            eta = LearningRate;
            alpha = Momentum;
            min_Error = MinimalError;
            activation_function = hiddenActivationFunction;
            output_activation_function = outputActivationFunction;

            Epoch = 0;
            Data_indexer = 0;
            Actual_data = 0;
            finished = false;
            MinErrorAchieved = false;
            ToUseTheNet = false;
            ToDebug = false;
            NumberOfTrainings = 0;
            aError = 0;
            //inisialize the vectors
            Data_used = new int[num_datasets];
            lError = new double[num_datasets, num_output];
            NetOutputs = new double[num_datasets, num_output];

            inputs = new double[num_input];
            outputs = new double[num_output];
            Data = new double[num_datasets, num_input + num_output];

            //Data = TrainingData;
            for(int i = 0; i<num_datasets; ++i)
            {
                for(int j = 0; j<num_input + num_output; ++j)
                {
                    Data[i,j] = TrainingData[i,j];
                }
            }
           ih_w = new double[num_input, num_hidden];
           ho_w = new double[num_hidden, num_output];
           delta_ih_w = new double[num_input, num_hidden];
           delta_ho_w = new double[num_hidden, num_output];
           prev_delta_ih_w = new double[num_input, num_hidden];
           prev_delta_ho_w = new double[num_hidden, num_output];
           ih_local_input = new double[num_input, num_hidden];
           ho_local_input = new double[num_hidden, num_output];

           h_bias = new double[num_hidden];
           o_bias = new double[num_output];
           h_out = new double[num_hidden];
           o_out = new double[num_output];
           oGrad = new double[num_output];
           hGrad = new double[num_hidden];
           delta_h_bias = new double[num_hidden];
           delta_o_bias = new double[num_output];
           prev_delta_h_bias = new double[num_hidden];
           prev_delta_o_bias = new double[num_output];

           for (int i = 0; i < num_datasets; ++i)
               Data_used[i] = -1;
           //Randomly initialize weights
            rnd = new Random();

           for (int i = 0; i < num_input; ++i)
           {
               for (int j = 0; j < num_hidden; ++j)
               {
                   ih_w[i,j] = ((double)(rnd.Next(-240, 240))/num_input)/100.0;
                   if(i == 0)
                   {
                       h_bias[j] = ((double)(rnd.Next(-240, 240)) / num_input) / 100.0;
                   }
               }
           }
           for (int i = 0; i < num_hidden; ++i)
           {
               for (int j = 0; j < num_output; ++j)
               {
                   ho_w[i,j] = ((double)(rnd.Next(-240, 240)) / num_hidden) / 100.0;
                   if(i == 0)
                   {
                       o_bias[j] = ((double)(rnd.Next(-240, 240)) / num_hidden) / 100.0;
                   }
               }
           }

        }
        


        

        //Get and Set functions
        public void GetWeightsAndBiases(char layer, double[] outputW)//returns a 2D array with the weights 0>ih and 1>ho
        {
            int cont = 0;
            //double[] temp;
            if (layer == 'h')
            {
                //temp = new double[num_input * num_hidden + num_hidden];
                for (int i = 0; i < num_hidden; ++i)
                {
                    for (int j = 0; j < num_input; ++j)
                    {
                        outputW[cont] = ih_w[j,i];
                        ++cont;
                    }
                    outputW[cont] = h_bias[i];
                    ++cont;
                }

            }
            else
            {
                //temp = new double[num_hidden * num_output + num_output];
                for (int i = 0; i < num_output; ++i)
                {
                    for (int j = 0; j < num_hidden; ++j)
                    {
                        outputW[cont] = ho_w[j,i];
                        ++cont;
                    }
                    outputW[cont] = o_bias[i];
                    ++cont;
                }
            }
        }
        public void SetWeightsAndBiases(double[] setW, char layer)
        {
            int c = 0;
            if(layer == 'h')
            {
                for (int i = 0; i < num_hidden; ++i)
                {
                    for (int j = 0; j < num_input; ++j)
                    {
                        ih_w[j,i] = setW[c];
                        ++c;
                    }
                    h_bias[i] = setW[c];
                    ++c;
                }
            }
            else
            {
                for (int i = 0; i < num_output; ++i)
                {
                    for (int j = 0; j < num_hidden; ++j)
                    {
                        ho_w[j,i] = setW[c];
                        ++c;
                    }
                    o_bias[i] = setW[c];
                    ++c;
                }
            }
        }
        public bool IsMinError
        {
            get
            {
                if(aError >= 0 && aError <= min_Error)
                    return true;
                else
                    return false;
            }
        }
        public double SetMinError
        {
            set
            {
                min_Error = value;
            }
        }
        public int SetMaxEpoch
        {
            set
            {
                num_Epoch = value;
            }
        }
        public int GetEpochCounter
        {
            get
            {
                return Epoch;
            }
        }
        public int GetNumberOfInputs
        {
            get
            {
                return num_input;
            }
        }
        public int GetNumberOfOutputs
        {
            get
            {
                return num_output;
            }
        }
        public bool IsFinished
        {
            get
            {
                return finished;
            }
        }
        public double GetError
        {
            get
            {
                return aError;
            }
        }
        public string GetWeights(char layer, InputLanguage language)
        {
            string output = "";
            if(layer == 'h')
            {
                for(int i = 0; i<num_hidden; ++i)
                {
                    for(int j = 0; j<num_input; ++j)
                    {
                        output += "ih_w[" + j.ToString(language.Culture) + "][" + i.ToString(language.Culture) + "] = " + ih_w[j, i].ToString(language.Culture) + "\n";
                    }
                    output += "h_bias[" + i.ToString(language.Culture) + "] = " + h_bias[i].ToString(language.Culture) + "\n\n";
                }
            }
            else
            {
                for(int i = 0; i<num_output; ++i)
                {
                    for(int j = 0; j<num_hidden; ++j)
                    {
                        output += "ho_w[" + j.ToString(language.Culture) + "][" + i.ToString(language.Culture) + "] = " + ho_w[j, i].ToString(language.Culture) + "\n";
                    }
                    output += "o_bias[" + i.ToString(language.Culture) + "] = " + o_bias[i].ToString(language.Culture) + "\n\n";
                }
            }
            return output ;
        }
        public string GetNetOutputs(int DataIndexer)
        {
            string outs = "";
            for(int j = 0; j<num_output; ++j)
            {
                outs += "NetOut[" + DataIndexer.ToString() + "][" + j.ToString() + "] = " + NetOutputs[DataIndexer,j].ToString() + "\n";
            }
            outs += "-----------------------------------\n";
            return outs;
        }

        public double[,] InputHiddenWeights
        {
            set
            {
                for (int i = 0; i < value.GetLength(0); ++i)
                {
                    for (int j = 0; j < value.GetLength(1); ++j)
                    {
                        ih_w[i, j] = value[i, j];
                    }
                }
            }
            get
            {
                return ih_w;
            }
        }
        public double[] HiddenBiases
        {
            set
            {
                for (int i = 0; i < value.GetLength(0); ++i)
                {
                    h_bias[i] = value[i];
                }
            }
            get
            {
                return h_bias;
            }
        }
        public double[,] HiddenOutputWeights
        {
            set
            {
                for (int i = 0; i < value.GetLength(0); ++i)
                {
                    for (int j = 0; j < value.GetLength(1); ++j)
                    {
                        ho_w[i, j] = value[i, j];
                    }
                }
            }
            get
            {
                return ho_w;
            }
        }
        public double[] OutputBiases
        {
            set
            {
                for (int i = 0; i < value.GetLength(0); ++i)
                {
                    o_bias[i] = value[i];
                }
            }
            get
            {
                return o_bias;
            }
        }
        //Main Functions
        public void InitializeWeights(int method = 1)
        {
            int temp = 0;
            if(method == 0)//everithing begins at zero
            {
                for (int i = 0; i < num_input; ++i)
                {
                    for (int j = 0; j < num_hidden; ++j)
                    {
                        ih_w[i,j] = 0;
                        if(temp == 0)
                            h_bias[j] = 0;
                    }
                    ++temp;
                }
                temp = 0;
                for (int i = 0; i < num_hidden; ++i)
                {
                    for (int j = 0; j < num_output; ++j)
                    {
                        ho_w[i,j] = 0;
                        if(temp == 0)
                            o_bias[j] = 0;
                    }
                    ++temp;
                }
            }
            else if(method == 1)//everything begins randonly at a certain range
            {
                for (int i = 0; i < num_input; ++i)
                {
                    for (int j = 0; j < num_hidden; ++j)
                    {
                        ih_w[i,j] = ((double)(rnd.Next(-240, 240))/num_input)/100.0;
                        if(temp == 0)
                            h_bias[j] = ((double)(rnd.Next(-240, 240)) / num_input) / 100.0;
                    }
                    ++temp;
                }
                temp = 0;
                for (int i = 0; i < num_hidden; ++i)
                {
                    for (int j = 0; j < num_output; ++j)
                    {
                        ho_w[i,j] = ((double)(rnd.Next(-240, 240)) / num_hidden) / 100.0;
                        if(temp == 0)
                            o_bias[j] = ((double)(rnd.Next(-240, 240)) / num_hidden) / 100.0;
                    }
                    ++temp;
                }
            }
            else if(method == 2)//everything begins fully randonly
            {
                for (int i = 0; i < num_input; ++i)
                {
                    for (int j = 0; j < num_hidden; ++j)
                    {
                        ih_w[i,j] = ((double)(rnd.Next(-300, 300)))/100.0;
                        if(temp == 0)
                            h_bias[j] = ((double)(rnd.Next(-300, 300)))/100.0;
                    }
                    ++temp;
                }
                temp = 0;
                for (int i = 0; i < num_hidden; ++i)
                {
                    for (int j = 0; j < num_output; ++j)
                    {
                        ho_w[i,j] = ((double)(rnd.Next(-300, 300)))/100.0;
                        if(temp == 0)
                            o_bias[j] = ((double)(rnd.Next(-300, 300)))/100.0;
                    }
                    ++temp;
                }
            }
        }
        public void InitializeVaraiables(int WeightsMethod = 1)
        {
            InitializeWeights(WeightsMethod);
            for (int i = 0; i < num_datasets; ++i)
                Data_used[i] = -1;

            Epoch = 0;
            Data_indexer = 0;
            finished = false;
            MinErrorAchieved = false;
            ToUseTheNet = false;
            ToDebug = false;
        }
        public double BipolarSigmoid(double x)//bipolar sigmoid function
        {
            return ((1.0 - Math.Exp(-x))/(1.0 + Math.Exp(-x)));
        }
        public double LogSigmoid(double x)//sigmoid function
        {
            if(x >= 45)
                return 1;
            else if(x <= -45)
                return 0;
            else
            return (1.0 / (1.0 + Math.Exp(-x)));
        }
        public double Linear(double x)
        {
            return x;
        }
        public double Activation(double val,char layer)//Uses the predefined activation functions
        {
            double output = 0.0;
            if (layer == 'h')
            {
                if (activation_function == ANN_ACTIVATION_SIGMOID)
                {
                    output =  LogSigmoid(val);
                }
                else if (activation_function == ANN_ACTIVATION_LINEAR)
                {
                    output =  Linear(val);
                }
                else// if (activation_function == ANN_ACTIVATION_BIPOLAR_SIGMOID)
                {
                    output =  BipolarSigmoid(val);
                }
            }
            else
            {
                if (output_activation_function == ANN_ACTIVATION_SIGMOID)
                {
                    output =  LogSigmoid(val);
                }
                else if (output_activation_function == ANN_ACTIVATION_LINEAR)
                {
                    output =  Linear(val);
                }
                else// if (output_activation_function == ANN_ACTIVATION_BIPOLAR_SIGMOID)
                {
                    output =  BipolarSigmoid(val);
                }
            }
            return output;
        }
        public void ComputeAverageError()
        {
            aError = 0;
            for (int i = 0; i < num_datasets; ++i)
            {
                for (int j = 0; j < num_output; ++j)
                {
                    aError += Math.Pow(lError[i,j], 2) / (2.0*((double)num_output));
                }
            }
        }
        public void ComputeOutputs()//computes the output of each neuron
        {
            double temp = 0.0;

            for (int i = 0; i < num_hidden; ++i)
            {
                temp = 0.0;
                for (int j = 0; j < num_input; ++j)
                {
                    if (!ToUseTheNet)
                    {
                        temp += Data[Actual_data,j] * ih_w[j,i];
                        ih_local_input[j,i] = Data[Actual_data,j];
                    }
                    else
                    {
                        temp += inputs[j] * ih_w[j,i];
                        ih_local_input[j,i] = inputs[j];
                    }
                }
                temp += h_bias[i];

                h_out[i] = Activation(temp,'h');
            }

            for (int i = 0; i < num_output; ++i)
            {
                temp = 0.0;
                for (int j = 0; j < num_hidden; ++j)
                {
                    temp += h_out[j] * ho_w[j,i];
                    ho_local_input[j,i] = h_out[j];
                }
                temp += o_bias[i];
                o_out[i] = Activation(temp,'o');
                NetOutputs[Actual_data,i] = o_out[i];
                if(ToUseTheNet)
                    outputs[i] = o_out[i];
            }
        }
        public void BackPropagation()//uses the algorithm to compute the gradients and the deltas
        {
            double temp = 0.0;
            for (int i = 0; i < num_output; ++i)
            {
                lError[Actual_data,i] = Data[Actual_data,i + num_input] - o_out[i];
                if (output_activation_function == ANN_ACTIVATION_SIGMOID)
                    oGrad[i] = o_out[i] * (1 - o_out[i]) * (lError[Actual_data,i]);
                else if(output_activation_function == ANN_ACTIVATION_LINEAR)
                    oGrad[i] = o_out[i] * (lError[Actual_data,i]);
                else if(output_activation_function == ANN_ACTIVATION_BIPOLAR_SIGMOID)
                    oGrad[i] = (1.0/2.0)*(1 + o_out[i])*(1 - o_out[i]) * (lError[Actual_data,i]);
            }
            for (int i = 0; i < num_hidden; ++i)
            {
                temp = 0.0;
                for (int j = 0; j < num_output; ++j)
                {
                    temp += oGrad[j] * ho_w[i,j];
                }
                if (activation_function == ANN_ACTIVATION_SIGMOID)
                    hGrad[i] = h_out[i] * (1 - h_out[i]) * (temp);
                else if(activation_function == ANN_ACTIVATION_LINEAR)
                    hGrad[i] = h_out[i] * (temp);
                else if(activation_function == ANN_ACTIVATION_BIPOLAR_SIGMOID)
                    hGrad[i] = (1.0/2.0)*(1 + h_out[i])*(1 - h_out[i]) * (temp);
            }

            //compute the deltas
            for (int i = 0; i < num_hidden; ++i)
            {
                for (int j = 0; j < num_input; ++j)
                {
                    delta_ih_w[j,i] = eta * hGrad[i] * ih_local_input[j,i];
                    ih_w[j,i] += delta_ih_w[j,i] + alpha * (prev_delta_ih_w[j,i]);
                    prev_delta_ih_w[j,i] = delta_ih_w[j,i];
                }
                delta_h_bias[i] = eta * hGrad[i] * 1.0;
                h_bias[i] += delta_h_bias[i] + alpha * prev_delta_h_bias[i];
                prev_delta_h_bias[i] = delta_h_bias[i];
            }
            for (int i = 0; i < num_output; ++i)
            {
                for (int j = 0; j < num_hidden; ++j)
                {
                    delta_ho_w[j,i] = eta * oGrad[i] * ho_local_input[j,i];
                    ho_w[j,i] += delta_ho_w[j,i] + alpha * (prev_delta_ho_w[j,i]);
                    prev_delta_ho_w[j,i] = delta_ho_w[j,i];
                }
                delta_o_bias[i] = eta * oGrad[i] * 1.0;
                o_bias[i] += delta_o_bias[i] + alpha * prev_delta_o_bias[i];
                prev_delta_o_bias[i] = delta_o_bias[i];
            }
        }
        
        public void TrainNetworkPerEpoch()//Train the network Per Epoch
        {
            while (Data_indexer < num_datasets)
            {
                while (true)
                {

                    Actual_data = rnd.Next(0, num_datasets);
                    int teste = 0;
                    for (int i = 0; i < num_datasets; ++i)
                    {
                        if (Data_used[i] == Actual_data)
                            ++teste;
                    }
                    if (teste == 0)
                    {
                        Data_used[Data_indexer] = Actual_data;
                        break;
                    }
                }
                ComputeOutputs();
                BackPropagation();
                ++Data_indexer;
            }
            ComputeAverageError();

            if (num_Epoch != -1)
            {
                if (Epoch == num_Epoch)
                {
                    finished = true;
                }
                else
                {
                    Data_indexer = 0;
                    for (int i = 0; i < num_datasets; ++i)
                        Data_used[i] = -1;
                    ++Epoch;
                }
            }
            else
            {
                Data_indexer = 0;
                for (int i = 0; i < num_datasets; ++i)
                    Data_used[i] = -1;
                ++Epoch;
            }
        }
        public void TrainNetwork()//TRain the network until max_epoch or min_error achieved
        {
            while (true)
            {
                TrainNetworkPerEpoch();
                if(IsFinished || IsMinError)
                    break;
            }
        }
        public void UseNetwork(double[] NetInput, double[] NetOut)//use the trained network for predictions
        {
            for(int i = 0;i<num_input;++i)
                inputs[i] = NetInput[i];

            ToUseTheNet = true;
            ComputeOutputs();
            ToUseTheNet = false;

            for(int i = 0;i<num_output;++i)
                NetOut[i] = outputs[i];
        }


    }
}
