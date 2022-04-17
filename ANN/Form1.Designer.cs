namespace ANN
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.user_input = new System.Windows.Forms.TextBox();
            this.UseTheNet = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.user_output = new System.Windows.Forms.RichTextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.MATH = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.test = new System.Windows.Forms.RichTextBox();
            this.FeedBack = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.SIGMOIDE = new System.Windows.Forms.RadioButton();
            this.Threshold = new System.Windows.Forms.RadioButton();
            this.Linear = new System.Windows.Forms.RadioButton();
            this.alpha = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.num_output = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.num_hidden = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.LOAD = new System.Windows.Forms.Button();
            this.SAVE = new System.Windows.Forms.Button();
            this.num_inputs = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.num_datasets = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.max_epoch = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.eta = new System.Windows.Forms.TextBox();
            this.m_error = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.INPUT = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.OUTPUT = new System.Windows.Forms.RichTextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.VREP = new System.Windows.Forms.CheckBox();
            this.WithAlarm = new System.Windows.Forms.CheckBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.PBGraph = new System.Windows.Forms.PictureBox();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.user_input);
            this.groupBox2.Controls.Add(this.UseTheNet);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.user_output);
            this.groupBox2.Location = new System.Drawing.Point(474, 259);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(288, 145);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Using the trained Net";
            // 
            // user_input
            // 
            this.user_input.Location = new System.Drawing.Point(9, 32);
            this.user_input.Name = "user_input";
            this.user_input.Size = new System.Drawing.Size(273, 20);
            this.user_input.TabIndex = 17;
            this.user_input.KeyDown += new System.Windows.Forms.KeyEventHandler(this.user_input_KeyDown);
            // 
            // UseTheNet
            // 
            this.UseTheNet.Location = new System.Drawing.Point(9, 112);
            this.UseTheNet.Name = "UseTheNet";
            this.UseTheNet.Size = new System.Drawing.Size(152, 23);
            this.UseTheNet.TabIndex = 17;
            this.UseTheNet.Text = "Use The Net";
            this.UseTheNet.UseVisualStyleBackColor = true;
            this.UseTheNet.Click += new System.EventHandler(this.UseTheNet_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "INPUT:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "OUTPUT :";
            // 
            // user_output
            // 
            this.user_output.Location = new System.Drawing.Point(9, 78);
            this.user_output.Name = "user_output";
            this.user_output.Size = new System.Drawing.Size(273, 29);
            this.user_output.TabIndex = 7;
            this.user_output.Text = "";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.progressBar1);
            this.groupBox5.Controls.Add(this.MATH);
            this.groupBox5.Location = new System.Drawing.Point(246, 316);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(222, 88);
            this.groupBox5.TabIndex = 20;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Train The Net";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(6, 58);
            this.progressBar1.Maximum = 1000;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(205, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 16;
            // 
            // MATH
            // 
            this.MATH.Location = new System.Drawing.Point(6, 19);
            this.MATH.Name = "MATH";
            this.MATH.Size = new System.Drawing.Size(205, 23);
            this.MATH.TabIndex = 2;
            this.MATH.Text = "Keep Calm And Do Ze Math";
            this.MATH.UseVisualStyleBackColor = true;
            this.MATH.Click += new System.EventHandler(this.MATH_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.test);
            this.groupBox4.Controls.Add(this.FeedBack);
            this.groupBox4.Location = new System.Drawing.Point(474, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(394, 241);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Training FeedBack";
            // 
            // test
            // 
            this.test.Location = new System.Drawing.Point(214, 16);
            this.test.Name = "test";
            this.test.Size = new System.Drawing.Size(174, 219);
            this.test.TabIndex = 17;
            this.test.Text = "";
            // 
            // FeedBack
            // 
            this.FeedBack.Location = new System.Drawing.Point(6, 16);
            this.FeedBack.Name = "FeedBack";
            this.FeedBack.Size = new System.Drawing.Size(202, 219);
            this.FeedBack.TabIndex = 15;
            this.FeedBack.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox6);
            this.groupBox3.Controls.Add(this.alpha);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.num_output);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.num_hidden);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.LOAD);
            this.groupBox3.Controls.Add(this.SAVE);
            this.groupBox3.Controls.Add(this.num_inputs);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.num_datasets);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.max_epoch);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.eta);
            this.groupBox3.Controls.Add(this.m_error);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(246, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(222, 298);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Constants, Setup and Training";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.SIGMOIDE);
            this.groupBox6.Controls.Add(this.Threshold);
            this.groupBox6.Controls.Add(this.Linear);
            this.groupBox6.Enabled = false;
            this.groupBox6.Location = new System.Drawing.Point(6, 220);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(210, 44);
            this.groupBox6.TabIndex = 24;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "ActivationFunction";
            // 
            // SIGMOIDE
            // 
            this.SIGMOIDE.AutoSize = true;
            this.SIGMOIDE.Location = new System.Drawing.Point(137, 14);
            this.SIGMOIDE.Name = "SIGMOIDE";
            this.SIGMOIDE.Size = new System.Drawing.Size(68, 17);
            this.SIGMOIDE.TabIndex = 18;
            this.SIGMOIDE.TabStop = true;
            this.SIGMOIDE.Text = "Sigmoide";
            this.SIGMOIDE.UseVisualStyleBackColor = true;
            // 
            // Threshold
            // 
            this.Threshold.AutoSize = true;
            this.Threshold.Location = new System.Drawing.Point(66, 14);
            this.Threshold.Name = "Threshold";
            this.Threshold.Size = new System.Drawing.Size(72, 17);
            this.Threshold.TabIndex = 17;
            this.Threshold.TabStop = true;
            this.Threshold.Text = "Threshold";
            this.Threshold.UseVisualStyleBackColor = true;
            // 
            // Linear
            // 
            this.Linear.AutoSize = true;
            this.Linear.Checked = true;
            this.Linear.Location = new System.Drawing.Point(6, 14);
            this.Linear.Name = "Linear";
            this.Linear.Size = new System.Drawing.Size(54, 17);
            this.Linear.TabIndex = 1;
            this.Linear.TabStop = true;
            this.Linear.Text = "Linear";
            this.Linear.UseVisualStyleBackColor = true;
            // 
            // alpha
            // 
            this.alpha.Location = new System.Drawing.Point(99, 65);
            this.alpha.Name = "alpha";
            this.alpha.Size = new System.Drawing.Size(112, 20);
            this.alpha.TabIndex = 29;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 68);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 13);
            this.label12.TabIndex = 28;
            this.label12.Text = "Momentum :";
            // 
            // num_output
            // 
            this.num_output.Location = new System.Drawing.Point(99, 194);
            this.num_output.Name = "num_output";
            this.num_output.Size = new System.Drawing.Size(112, 20);
            this.num_output.TabIndex = 27;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 197);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(27, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "No :";
            // 
            // num_hidden
            // 
            this.num_hidden.Location = new System.Drawing.Point(99, 169);
            this.num_hidden.Name = "num_hidden";
            this.num_hidden.Size = new System.Drawing.Size(112, 20);
            this.num_hidden.TabIndex = 25;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 172);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Nh :";
            // 
            // LOAD
            // 
            this.LOAD.Location = new System.Drawing.Point(111, 269);
            this.LOAD.Name = "LOAD";
            this.LOAD.Size = new System.Drawing.Size(100, 23);
            this.LOAD.TabIndex = 19;
            this.LOAD.Text = "Load the weights";
            this.LOAD.UseVisualStyleBackColor = true;
            this.LOAD.Click += new System.EventHandler(this.LOAD_Click);
            // 
            // SAVE
            // 
            this.SAVE.Location = new System.Drawing.Point(6, 269);
            this.SAVE.Name = "SAVE";
            this.SAVE.Size = new System.Drawing.Size(100, 23);
            this.SAVE.TabIndex = 18;
            this.SAVE.Text = "Save the weights";
            this.SAVE.UseVisualStyleBackColor = true;
            this.SAVE.Click += new System.EventHandler(this.SAVE_Click);
            // 
            // num_inputs
            // 
            this.num_inputs.Location = new System.Drawing.Point(99, 143);
            this.num_inputs.Name = "num_inputs";
            this.num_inputs.Size = new System.Drawing.Size(112, 20);
            this.num_inputs.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 146);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Ni :";
            // 
            // num_datasets
            // 
            this.num_datasets.Location = new System.Drawing.Point(99, 117);
            this.num_datasets.Name = "num_datasets";
            this.num_datasets.Size = new System.Drawing.Size(112, 20);
            this.num_datasets.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Num_DataSets :";
            // 
            // max_epoch
            // 
            this.max_epoch.Location = new System.Drawing.Point(99, 91);
            this.max_epoch.Name = "max_epoch";
            this.max_epoch.Size = new System.Drawing.Size(112, 20);
            this.max_epoch.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Max_Epoch :";
            // 
            // eta
            // 
            this.eta.Location = new System.Drawing.Point(99, 39);
            this.eta.Name = "eta";
            this.eta.Size = new System.Drawing.Size(112, 20);
            this.eta.TabIndex = 17;
            // 
            // m_error
            // 
            this.m_error.Location = new System.Drawing.Point(99, 16);
            this.m_error.Name = "m_error";
            this.m_error.Size = new System.Drawing.Size(112, 20);
            this.m_error.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Eta :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Minimal Error :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.INPUT);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.OUTPUT);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(228, 392);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DataSet IO";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "INPUT:";
            // 
            // INPUT
            // 
            this.INPUT.Location = new System.Drawing.Point(9, 32);
            this.INPUT.Name = "INPUT";
            this.INPUT.Size = new System.Drawing.Size(213, 169);
            this.INPUT.TabIndex = 1;
            this.INPUT.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "OUTPUT :";
            // 
            // OUTPUT
            // 
            this.OUTPUT.Location = new System.Drawing.Point(9, 220);
            this.OUTPUT.Name = "OUTPUT";
            this.OUTPUT.Size = new System.Drawing.Size(213, 156);
            this.OUTPUT.TabIndex = 7;
            this.OUTPUT.Text = "";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.VREP);
            this.groupBox7.Controls.Add(this.WithAlarm);
            this.groupBox7.Location = new System.Drawing.Point(768, 259);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(100, 145);
            this.groupBox7.TabIndex = 22;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Configurations";
            // 
            // VREP
            // 
            this.VREP.AutoSize = true;
            this.VREP.Checked = true;
            this.VREP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.VREP.Location = new System.Drawing.Point(18, 43);
            this.VREP.Name = "VREP";
            this.VREP.Size = new System.Drawing.Size(56, 17);
            this.VREP.TabIndex = 23;
            this.VREP.Text = "V-Rep";
            this.VREP.UseVisualStyleBackColor = true;
            // 
            // WithAlarm
            // 
            this.WithAlarm.AutoSize = true;
            this.WithAlarm.Checked = true;
            this.WithAlarm.CheckState = System.Windows.Forms.CheckState.Checked;
            this.WithAlarm.Location = new System.Drawing.Point(18, 20);
            this.WithAlarm.Name = "WithAlarm";
            this.WithAlarm.Size = new System.Drawing.Size(74, 17);
            this.WithAlarm.TabIndex = 0;
            this.WithAlarm.Text = "WithAlarm";
            this.WithAlarm.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.PBGraph);
            this.groupBox8.Location = new System.Drawing.Point(874, 13);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(312, 325);
            this.groupBox8.TabIndex = 23;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Error Development";
            this.groupBox8.Enter += new System.EventHandler(this.groupBox8_Enter);
            // 
            // PBGraph
            // 
            this.PBGraph.Location = new System.Drawing.Point(6, 15);
            this.PBGraph.Name = "PBGraph";
            this.PBGraph.Size = new System.Drawing.Size(300, 300);
            this.PBGraph.TabIndex = 0;
            this.PBGraph.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 415);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "ANN";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PBGraph)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox user_input;
        private System.Windows.Forms.Button UseTheNet;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox user_output;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button MATH;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox test;
        private System.Windows.Forms.RichTextBox FeedBack;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton SIGMOIDE;
        private System.Windows.Forms.RadioButton Threshold;
        private System.Windows.Forms.RadioButton Linear;
        private System.Windows.Forms.TextBox alpha;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox num_output;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox num_hidden;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button LOAD;
        private System.Windows.Forms.Button SAVE;
        private System.Windows.Forms.TextBox num_inputs;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox num_datasets;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox max_epoch;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox eta;
        private System.Windows.Forms.TextBox m_error;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox INPUT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox OUTPUT;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.CheckBox WithAlarm;
        private System.Windows.Forms.CheckBox VREP;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.PictureBox PBGraph;
    }
}

