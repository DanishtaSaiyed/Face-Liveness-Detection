using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoadMNIST;
using NeuralNetworkLibAM;
using NeuralNetworkNG;
using System.Windows.Forms;
using PCALib;

namespace FLD_1_Project
{
    public partial class Form1 : Form
    {
        double[][] diffusedImages = null;
        double[][] imagedata = null;

        Network nn = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonTrainDiffusion_Click(object sender, EventArgs e)
        {
            String trainDir = "C:\\Users\\pavilion\\Documents\\University of Bridgeport\\MS in Computer Science\\Spring 2016\\Parallel and Distributed Computing\\Projects\\data\\train";

            /* Step 1- Convert image to grayscale */
            /* Step 2- Convert to 2-D image i.e. conversion to vector */
            DataPoint[] data = ImageReader.ReadAllDataUnscaled(trainDir);   

            imagedata = ImageReader.GetData(data);
            int option = 1; // option for first or second equation
            double kappa = 0.5; // ----------------------------------------------------change for correct results

            //Convert these vectors into diffused images using the Apply Diffusion function

            diffusedImages = Diffusion.apply_Diffusion(data, option, kappa);
            
            //---------------------------------then comvert 2D to 1D for NN----------------Incomplete
            // then pass that data through NN
            int[] layers = { 50, 10 }; // neurons in hidden layer, ouput layer
            nn = new Network(imagedata[0].Length, layers);   // # of inputs

            nn.randomizeAll();
            nn.LearningAlg.ErrorTreshold = 0.0001f;
            nn.LearningAlg.MaxIteration = 10000;

            nn.LearningAlg.Learn(imagedata, diffusedImages);


            //double[][] trainData = PCA.Transpose(trainDataOrig, trainDataOrig[0].Length);
        }
    }
}
