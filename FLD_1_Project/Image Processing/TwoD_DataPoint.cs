using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoadMNIST;
namespace FLD_1_Project.Image_Processing
{
    class TwoD_DataPoint : DataPoint
    {
        public TwoD_DataPoint(int labelInput, int dimension, double[] dataInput) : base(labelInput, dimension, dataInput)
        {
        }
    }
}
