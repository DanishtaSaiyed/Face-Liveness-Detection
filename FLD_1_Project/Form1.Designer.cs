namespace FLD_1_Project
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
            this.buttonTrainDiffusion = new System.Windows.Forms.Button();
            this.buttonTrainRNN = new System.Windows.Forms.Button();
            this.buttonTest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonTrainDiffusion
            // 
            this.buttonTrainDiffusion.Location = new System.Drawing.Point(64, 32);
            this.buttonTrainDiffusion.Name = "buttonTrainDiffusion";
            this.buttonTrainDiffusion.Size = new System.Drawing.Size(132, 23);
            this.buttonTrainDiffusion.TabIndex = 0;
            this.buttonTrainDiffusion.Text = "Diffusion Training";
            this.buttonTrainDiffusion.UseVisualStyleBackColor = true;
            this.buttonTrainDiffusion.Click += new System.EventHandler(this.buttonTrainDiffusion_Click);
            // 
            // buttonTrainRNN
            // 
            this.buttonTrainRNN.Location = new System.Drawing.Point(64, 82);
            this.buttonTrainRNN.Name = "buttonTrainRNN";
            this.buttonTrainRNN.Size = new System.Drawing.Size(132, 23);
            this.buttonTrainRNN.TabIndex = 1;
            this.buttonTrainRNN.Text = "RNN Training";
            this.buttonTrainRNN.UseVisualStyleBackColor = true;
            // 
            // buttonTest
            // 
            this.buttonTest.Location = new System.Drawing.Point(64, 130);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(132, 23);
            this.buttonTest.TabIndex = 2;
            this.buttonTest.Text = "Test Liveness";
            this.buttonTest.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 190);
            this.Controls.Add(this.buttonTest);
            this.Controls.Add(this.buttonTrainRNN);
            this.Controls.Add(this.buttonTrainDiffusion);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonTrainDiffusion;
        private System.Windows.Forms.Button buttonTrainRNN;
        private System.Windows.Forms.Button buttonTest;
    }
}

