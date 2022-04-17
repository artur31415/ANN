using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using System.Threading;
using System.Diagnostics;

namespace ANN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        annprea prea;
        double[,] DataSet;
        double[] UserInputs, UserOutputs;
        int NUM_OF_DATAPAIRS = 4;
        int NUM_OF_INPUT = 2, NUM_OF_HIDDEN = 10, NUM_OF_OUTPUT = 2;
        double Learning = 0.1, Momentum = 0.3;
        int MaxEpoch = 1000;
        double MinError = 0.001;

        String TrainingTime;

        Bitmap DefaultGraphImage;

        float EpochsCompresionFactor = 0;
        float DataCompresionFactor = 0;
        float HighestY = 0;

        Thread T;
        public volatile bool IsDrawing = false;
        public volatile bool StopDrawingThread = false;
        Point P0, P1;

        List<PointF> GraphData = new List<PointF>();

        int yTranslationValue = 300;

        System.Media.SoundPlayer sound = new System.Media.SoundPlayer("C:\\alarm.wav");


        int ReadNi = -1;
        int ReadNh;
        int ReadNo;
        double[,] Read_ih_w_Values;
        double[] Read_h_b_Values;
        double[,] Read_ho_w_Values;
        double[] Read_o_b_Values;

        String SavedError, SavedEpoch;

        public void GetUserData()
        {
            string[] op1 = user_input.Text.Split(' ');
            UserInputs = new double[NUM_OF_INPUT];
            UserOutputs = new double[NUM_OF_OUTPUT];
            bool UseTheNet = true;
            if (op1.Length != NUM_OF_INPUT)
            {
                UseTheNet = false;
                MessageBox.Show("Error Geting user data", "User Entered wrong data!!!");
            }
            if (UseTheNet)
            {
                double[] inputs = new double[op1.GetLength(0)];
                double output1 = 0.0;

                for (int i = 0; i < op1.GetLength(0); ++i)
                {
                    inputs[i] = double.Parse(op1[i]);
                    output1 += inputs[i];
                }

                try
                {
                    for (int i = 0; i < NUM_OF_INPUT; ++i)
                        UserInputs[i] = inputs[i];
                }
                catch (InvalidExpressionException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void GetTrainigData()
        {
            string[] op1 = INPUT.Text.Split('\n'), _op1 = OUTPUT.Text.Split('\n');
            string[] op2 = new string[op1.GetLength(0)], _op2 = new string[op1.GetLength(0)];
            double[,] inputs = new double[op1.GetLength(0), op1[0].Split(' ').GetLength(0)];
            double[,] outputs = new double[_op1.GetLength(0), _op1[0].Split(' ').GetLength(0)];
            double output1 = 0.0, output2 = 0.0;

            for (int i = 0; i < op1.GetLength(0); ++i)
            {
                op2 = op1[i].Split(' ');
                for (int j = 0; j < op2.GetLength(0); ++j)
                {
                    inputs[i, j] = double.Parse(op2[j]);
                    output1 += inputs[i, j];
                }
            }
            for (int i = 0; i < _op1.GetLength(0); ++i)
            {
                _op2 = _op1[i].Split(' ');
                for (int j = 0; j < _op2.GetLength(0); ++j)
                {
                    outputs[i, j] = double.Parse(_op2[j]);
                    output2 += outputs[i, j];
                }
            }

            FeedBack.Text = "";
            for (int i = 0; i < NUM_OF_DATAPAIRS; ++i)
            {
                for (int j = 0; j < NUM_OF_INPUT; ++j)
                {
                    DataSet[i, j] = inputs[i, j];
                }
                for (int j = 0; j < NUM_OF_OUTPUT; ++j)
                {
                    DataSet[i, j + NUM_OF_INPUT] = outputs[i, j];
                }

                //for (int j = 0; j < NUM_OF_INPUT + NUM_OF_OUTPUT; ++j)
                //{
                //    FeedBack.Text += "DataSet[" + i.ToString() + "," + j.ToString() + "] = " + DataSet[i, j].ToString() + "\n";
                //}
                //FeedBack.Text += "\n";
            }
        }

        public void Init()
        {
            DataSet = new double[NUM_OF_DATAPAIRS, NUM_OF_INPUT + NUM_OF_OUTPUT];
        }

        static public float linear(float x, float x0, float x1, float y0, float y1)
        {
            if ((x1 - x0) == 0)
            {
                return (y0 + y1) / 2;
            }
            return (y0 + (x - x0) * (y1 - y0) / (x1 - x0));
        }

        public void CreateDefaultBackground()
        {
            DefaultGraphImage = new Bitmap(PBGraph.Width, PBGraph.Height);
            Graphics g = Graphics.FromImage(DefaultGraphImage);
            g.FillRectangle(Brushes.White, new RectangleF(0, 0, DefaultGraphImage.Width, DefaultGraphImage.Height));

            int CelSizeFactor = 10;
            for (int i = 0; i < DefaultGraphImage.Width; i += CelSizeFactor)
            {
                g.DrawLine(Pens.LightGray, i, 0, i, DefaultGraphImage.Height);
            }

            for (int j = 0; j < DefaultGraphImage.Height; j += CelSizeFactor)
            {
                g.DrawLine(Pens.LightGray, 0, j, DefaultGraphImage.Width, j);
            }

            g.Dispose();
        }

        public Bitmap DrawPoints()
        {
            //Bitmap newBM = (Bitmap)DefaultGraphImage.Clone();
            Bitmap newBM = new Bitmap(DefaultGraphImage);

            Graphics g = Graphics.FromImage(newBM);

            float DotRadius = 2;



            for (int i = 0; i < GraphData.Count; ++i)
            {
                //float x = 10 + GraphData.ElementAt<PointF>(i).X * EpochsCompresionFactor;
                //float y = 10 + GraphData.ElementAt<PointF>(i).Y * DataCompresionFactor;

                float x = linear(GraphData.ElementAt<PointF>(i).X / (float)MaxEpoch, 0, 1.0f, 10, 290);
                float y = yTranslationValue - linear(GraphData.ElementAt<PointF>(i).Y, 0, HighestY, 10, 290);
                g.FillEllipse(Brushes.Red, x - DotRadius, y - DotRadius, DotRadius, DotRadius);
            }

            g.DrawLine(Pens.Blue, 0, yTranslationValue - linear(HighestY, 0, HighestY, 10, 290), PBGraph.Width, yTranslationValue - linear(HighestY, 0, HighestY, 10, 290));

            g.DrawLine(Pens.DarkGreen, 0, yTranslationValue - linear(0, 0, HighestY, 10, 290), PBGraph.Width, yTranslationValue - linear(0, 0, HighestY, 10, 290));

            g.DrawLine(Pens.Black, 0, yTranslationValue - linear((float)MinError, 0, HighestY, 10, 290), PBGraph.Width, yTranslationValue - linear((float)MinError, 0, HighestY, 10, 290));

            g.Dispose();

            return newBM;
        }

        public void DrawThread()
        {
            while(true)
            {
                if (StopDrawingThread)
                {
                    PBGraph.BackgroundImage = DrawPoints();
                    break;
                }


                while(IsDrawing)
                {

                    //PBGraph.BackgroundImage = null;

                    //PBGraph.BackgroundImage = DrawPoints();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            m_error.Text = MinError.ToString();
            eta.Text = Learning.ToString();
            alpha.Text = Momentum.ToString();
            max_epoch.Text = MaxEpoch.ToString();
            num_datasets.Text = NUM_OF_DATAPAIRS.ToString();
            num_inputs.Text = NUM_OF_INPUT.ToString();
            num_hidden.Text = NUM_OF_HIDDEN.ToString();
            num_output.Text = NUM_OF_OUTPUT.ToString();

            INPUT.Text = "0 0\n" + "0 1\n" + "1 0\n" + "1 1";
            OUTPUT.Text = "1 1\n" + "1 0\n" + "0 1\n" + "0 0";


            CreateDefaultBackground();

            PBGraph.BackgroundImage = DefaultGraphImage;

            
        }

        private void LOAD_Click(object sender, EventArgs e)
        {
            //String v = " 0.35";
            //v = v.Replace('.', ',');
            //double d = double.Parse(v);
            //MessageBox.Show("(" + d.ToString() + ")");

            OpenFileDialog open = new OpenFileDialog();
            open.ShowDialog();

            if(open.FileName != "")
            {
                MessageBox.Show(open.FileName);

                try
                {   // Open the text file using a stream reader.
                    using (StreamReader sr = new StreamReader(open.FileName))
                    {
                        // Read the stream to a string, and write the string to the console.
                        String LinesOfFile = sr.ReadToEnd();
                        FeedBack.Text = LinesOfFile;

                        String str = LinesOfFile.Split('(')[1].Split(')')[0];
                        ReadNi = int.Parse(str.Split(',')[0]);
                        ReadNh = int.Parse(str.Split(',')[1]);
                        ReadNo = int.Parse(str.Split(',')[2]);
                        MessageBox.Show(str + "\n" + ReadNi.ToString() + "; " + ReadNh.ToString() + "; " + ReadNo.ToString());

                        String[] lines = LinesOfFile.Split('\n');
                        String[] linesData = new string[4];
                        int linesDataIndex = -1;

                        for (int i = 0; i < lines.GetLength(0); ++i)
                        {
                            if(lines[i].Contains("ih_w"))
                            {
                                linesDataIndex = 0;
                            }
                            else if (lines[i].Contains("h_b"))
                            {
                                linesDataIndex = 1;
                            }
                            else if (lines[i].Contains("ho_w"))
                            {
                                linesDataIndex = 2;
                            }
                            else if (lines[i].Contains("o_b"))
                            {
                                linesDataIndex = 3;
                            }
                            else if (!lines[i].Contains("{"))
                            {
                                linesDataIndex = -1;
                            }

                            if (linesDataIndex != -1)
                            {
                                linesData[linesDataIndex] += lines[i];
                            }
                        }

                        String[] ih_w_Data = linesData[0].Split('{');
                        String[] h_b_Data = linesData[1].Split('{');
                        String[] ho_w_Data = linesData[2].Split('{');
                        String[] o_b_Data = linesData[3].Split('{');

                        Read_ih_w_Values = new double[ReadNi, ReadNh];
                        Read_h_b_Values = new double[ReadNh];
                        Read_ho_w_Values = new double[ReadNh, ReadNo];
                        Read_o_b_Values = new double[ReadNo];


                        String outS = "";
                        for (int i = 2; i < ih_w_Data.GetLength(0); ++i)
                        {
                            //outS += "ih_w_Data[" + i.ToString() + "] = (" + ih_w_Data[i].Split('}')[0] + ")\n\n";
                            String[] vals = ih_w_Data[i].Split('}')[0].Split(',');
                            for (int j = 0; j < vals.GetLength(0); ++j)
                            {
                                
                                vals[j] = vals[j].Replace('.', ',');


                                Read_ih_w_Values[i - 2, j] = double.Parse(vals[j]);
                                //outS += "vals[" + j.ToString() + "] = (" + vals[j] + ")\n";
                            }
                            //outS += "\n\n";
                        }
                        for (int i = 1; i < h_b_Data.GetLength(0); ++i)
                        {
                            //outS += "h_b_Data[" + i.ToString() + "] = (" + h_b_Data[i].Split('}')[0] + ")\n\n";
                            String[] vals = h_b_Data[i].Split('}')[0].Split(',');
                            for (int j = 0; j < vals.GetLength(0); ++j)
                            {

                                vals[j] = vals[j].Replace('.', ',');
                                Read_h_b_Values[j] = double.Parse(vals[j]);
                            }
                            //outS += "\n\n";
                        }


                        for (int i = 2; i < ho_w_Data.GetLength(0); ++i)
                        {
                            String[] vals = ho_w_Data[i].Split('}')[0].Split(',');
                            for (int j = 0; j < vals.GetLength(0); ++j)
                            {
                                vals[j] = vals[j].Replace('.', ',');
                                Read_ho_w_Values[i - 2, j] = double.Parse(vals[j]);
                            }
                        }
                        for (int i = 1; i < o_b_Data.GetLength(0); ++i)
                        {
                            String[] vals = o_b_Data[i].Split('}')[0].Split(',');
                            for (int j = 0; j < vals.GetLength(0); ++j)
                            {
                                vals[j] = vals[j].Replace('.', ',');
                                Read_o_b_Values[j] = double.Parse(vals[j]);
                            }
                        }

                        outS = "ih_Data:\n";
                        for (int j = 0; j < Read_ih_w_Values.GetLength(1); ++j)
                        {
                            for (int i = 0; i < Read_ih_w_Values.GetLength(0); ++i)
                            {
                                outS += "Read_ih_w_Values[" + i.ToString() + ", " + j.ToString() + "] = " + Read_ih_w_Values[i, j].ToString() + "\n";
                            }
                            outS += "Read_h_b_Values[" + j.ToString() + "] = " + Read_h_b_Values[j].ToString() + "\n";
                        }
                        outS += "----------------------------------\nho_Data:\n";
                        for (int j = 0; j < Read_ho_w_Values.GetLength(1); ++j)
                        {
                            for (int i = 0; i < Read_ho_w_Values.GetLength(0); ++i)
                            {
                                outS += "Read_ho_w_Values[" + i.ToString() + ", " + j.ToString() + "] = " + Read_ho_w_Values[i, j].ToString() + "\n";
                            }
                            outS += "Read_o_b_Values[" + j.ToString() + "] = " + Read_o_b_Values[j].ToString() + "\n";
                        }
                        test.Text = outS;

                        //outS += "\n\nReadData:\n";
                        //for (int i = 0; i < linesData.GetLength(0); ++i)
                        //{
                        //    outS += "linesData[" + i.ToString() + "] = {" + linesData[i] + "}\n";
                        //}
                        //test.Text = outS;
                        num_inputs.Text = ReadNi.ToString();
                        num_hidden.Text = ReadNh.ToString();
                        num_output.Text = ReadNo.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The file could not be read:" + ex.Message, "Load Weights Error");
                }

            }
        }

        private void groupBox8_Enter(object sender, EventArgs e)
        {

        }

        private void MATH_Click(object sender, EventArgs e)
        {
            try
            {
                HighestY = 0;

                Learning = double.Parse(eta.Text);
                Momentum = double.Parse(alpha.Text);
                MinError = double.Parse(m_error.Text);
                MaxEpoch = int.Parse(max_epoch.Text);
                NUM_OF_DATAPAIRS = int.Parse(num_datasets.Text);
                NUM_OF_INPUT = int.Parse(num_inputs.Text);
                NUM_OF_HIDDEN = int.Parse(num_hidden.Text);
                NUM_OF_OUTPUT = int.Parse(num_output.Text);

                ///////////////////////
                EpochsCompresionFactor = (1.0f / (float)MaxEpoch) * 200.0f;
                DataCompresionFactor = 20.0f;
                //////////////////////
                Init();
                GetTrainigData();

                

                prea = new annprea(DataSet, NUM_OF_INPUT, NUM_OF_HIDDEN, NUM_OF_OUTPUT, NUM_OF_DATAPAIRS, MinError, MaxEpoch, Learning, Momentum);

                if(ReadNi != -1)
                {
                    prea.InputHiddenWeights = Read_ih_w_Values;
                    prea.HiddenBiases = Read_h_b_Values;
                    prea.HiddenOutputWeights = Read_ho_w_Values;
                    prea.OutputBiases = Read_o_b_Values;
                }
                //train

                FeedBack.Text = "Before Training Weights\nih:\n" + prea.GetWeights('h', InputLanguage.InstalledInputLanguages[1]) + "\n---------\n" + "ho:\n" + prea.GetWeights('o', InputLanguage.InstalledInputLanguages[1]) + "\n---------\n";

                //prea.TrainNetwork();

                IsDrawing = true;
                StopDrawingThread = false;

                //CreateDefaultBackground();

                //PBGraph.BackgroundImage = DefaultGraphImage;

                GraphData.Clear();

                T = new Thread(DrawThread);

                T.Start();

                Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();

                while (true)
                {
                    prea.TrainNetworkPerEpoch();

                    if (HighestY == 0 || prea.GetError > HighestY)
                    {
                        HighestY = (float)prea.GetError;
                    }

                    GraphData.Add(new PointF(prea.GetEpochCounter, (float)prea.GetError));
                    if (prea.IsFinished || prea.IsMinError)
                        break;
                }

                watch.Stop();
                long elapsedTicks = watch.ElapsedTicks;
                long elapsedMs = watch.ElapsedMilliseconds;
                double msPerTick = (double)elapsedMs / (double)elapsedTicks;


                long millis = 0, seconds = 0, minutes = 0, hours = 0;

                millis = (long)((double)((double)elapsedMs / 1000.0 - elapsedMs / (long)1000) * 1000);
                seconds = elapsedMs / (long)1000;

                if (seconds > 60)
                {
                    minutes = seconds / (long)60;
                    seconds = (long)((double)((double)seconds / 60.0 - seconds / (long)60) * 60);

                    if (minutes > 60)
                    {
                        hours = minutes / (long)60;
                        minutes = (long)((double)((double)minutes / 60.0 - minutes / (long)60) * 60);
                    }
                }

                TrainingTime = "Training Time = (" + hours.ToString("00") + ":" + minutes.ToString("00") + ":" + seconds.ToString("00") + "." + millis.ToString("000") + ")";

                IsDrawing = false;
                StopDrawingThread = true;

                T.Join();

                FeedBack.Text += "After Training Weights\nih:\n" + prea.GetWeights('h', InputLanguage.InstalledInputLanguages[1]) + "\n---------\n" + "ho:\n" + prea.GetWeights('o', InputLanguage.InstalledInputLanguages[1]) + "\n---------\n";
                test.Text = "Error = " + prea.GetError.ToString() + "\nEpochs = " + prea.GetEpochCounter.ToString();

                test.Text += "\n\nHighest Error = " + HighestY.ToString() + "\n";
                test.Text += "elapsedTicks = " + elapsedTicks.ToString() + "\n" + "msPerTick = " + msPerTick.ToString() + "\n" + TrainingTime + "\n\n";

                //for (int i = 0; i < GraphData.Count; ++i)
                //{


                //    float x = linear(GraphData.ElementAt<PointF>(i).X / (float)MaxEpoch, 0, 1.0f, 50, 200);
                //    float y = linear(GraphData.ElementAt<PointF>(i).Y, 0, HighestY, 50, 200);

                //    test.Text += "GraphData[" + i.ToString() + "] = {" + x.ToString() + ", " + y.ToString() + "}\n";
                //}

                if (WithAlarm.Checked)
                {
                    sound.PlayLooping();
                    MessageBox.Show("Done");
                    sound.Stop();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void UseTheNet_Click(object sender, EventArgs e)
        {
            GetUserData();
            Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();

            prea.UseNetwork(UserInputs, UserOutputs);

            watch.Stop();
            long elapsedTicks = watch.ElapsedTicks;
            long elapsedMs = watch.ElapsedMilliseconds;
            long millis = 0, seconds = 0, minutes = 0, hours = 0;

            millis = (long)((double)((double)elapsedMs / 1000.0 - elapsedMs / (long)1000) * 1000);
            seconds = elapsedMs / (long)1000;

            if (seconds > 60)
            {
                minutes = seconds / (long)60;
                seconds = (long)((double)((double)seconds / 60.0 - seconds / (long)60) * 60);

                if (minutes > 60)
                {
                    hours = minutes / (long)60;
                    minutes = (long)((double)((double)minutes / 60.0 - minutes / (long)60) * 60);
                }
            }

            test.Text += "elapsedTicks = " + elapsedTicks.ToString() + "\nExecutionTime = (" + hours.ToString("00") + ":" + minutes.ToString("00") + ":" + seconds.ToString("00") + "." + millis.ToString("000") + ")\n";

            user_output.Clear();
            for (int i = 0; i < NUM_OF_OUTPUT; ++i)
            {
                user_output.Text += UserOutputs[i].ToString("F4") + " ";
            }
        }

        private void user_input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                GetUserData();
                prea.UseNetwork(UserInputs, UserOutputs);
                user_output.Clear();
                for (int i = 0; i < NUM_OF_OUTPUT; ++i)
                {
                    user_output.Text += UserOutputs[i].ToString("F4") + " ";
                }
            }
        }

        private void SAVE_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.ShowDialog();
            if (save.FileName != "")
            {
                StreamWriter writer = new StreamWriter(save.FileName + ".txt");

                writer.WriteLine("ANN_PREA(" + NUM_OF_INPUT.ToString() + ", " + NUM_OF_HIDDEN.ToString() + ", " + NUM_OF_OUTPUT.ToString() + ")");

                writer.WriteLine("Error = " + prea.GetError.ToString(InputLanguage.InstalledInputLanguages[1].Culture));
                writer.WriteLine("Epochs = " + prea.GetEpochCounter.ToString());
                writer.WriteLine(TrainingTime + "\n\n");

                writer.WriteLine("ErrorThroughEpochs:\n");

                writer.WriteLine("SquaredError = {");
                
                for (int i = 0; i < GraphData.Count; ++i)
                {
                    writer.Write("{" + GraphData.ElementAt<PointF>(i).X.ToString(InputLanguage.InstalledInputLanguages[1].Culture) + ", " + GraphData.ElementAt<PointF>(i).Y.ToString(InputLanguage.InstalledInputLanguages[1].Culture) + "}");
                    if (i < GraphData.Count - 1)
                        writer.WriteLine(", ");
                }

                writer.WriteLine("}\n       ");


                writer.WriteLine("Hidden Layer:");
                if (!VREP.Checked)
                    writer.WriteLine(prea.GetWeights('h', InputLanguage.InstalledInputLanguages[1]));
                else
                {
                    writer.Write("ih_w = {");
                    for (int i = 0; i < NUM_OF_INPUT; ++i)
                    {
                        if(i > 0)
                            writer.Write(",\n	   ");
                        writer.Write("{");
                        for (int j = 0; j < NUM_OF_HIDDEN; ++j)
                        {
                            writer.Write(prea.ih_w[i, j].ToString(InputLanguage.InstalledInputLanguages[1].Culture));
                            if (j < NUM_OF_HIDDEN - 1)
                                writer.Write(", ");
                        }
                        writer.Write("}");
                    }
                    writer.WriteLine("}");
                    writer.Write("h_b = {");
                    for (int j = 0; j < NUM_OF_HIDDEN; ++j)
                    {
                        writer.Write(prea.h_bias[j].ToString(InputLanguage.InstalledInputLanguages[1].Culture));
                        if (j < NUM_OF_HIDDEN - 1)
                            writer.Write(", ");
                    }
                    writer.WriteLine("}");
                }

                writer.WriteLine("Output Layer:");

                if (!VREP.Checked)
                    writer.WriteLine(prea.GetWeights('o', InputLanguage.InstalledInputLanguages[1]));
                else
                {
                    writer.Write("ho_w = {");
                    for (int i = 0; i < NUM_OF_HIDDEN; ++i)
                    {
                        if (i > 0)
                            writer.Write(",\n	   ");
                        writer.Write("{");
                        for (int j = 0; j < NUM_OF_OUTPUT; ++j)
                        {
                            writer.Write(prea.ho_w[i, j].ToString(InputLanguage.InstalledInputLanguages[1].Culture));
                            if (j < NUM_OF_OUTPUT - 1)
                                writer.Write(", ");
                        }
                        writer.Write("}");
                    }
                    writer.WriteLine("}");
                    writer.Write("o_b = {");
                    for (int j = 0; j < NUM_OF_OUTPUT; ++j)
                    {
                        writer.Write(prea.o_bias[j].ToString(InputLanguage.InstalledInputLanguages[1].Culture));
                        if (j < NUM_OF_OUTPUT - 1)
                            writer.Write(", ");
                    }
                    writer.WriteLine("}");
                }

                writer.Close();
            }
        }
    }
}
