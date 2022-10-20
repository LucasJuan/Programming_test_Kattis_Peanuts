using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{

    public class InputPeanuts
    {
        public double Sequence { get; set; }
        public List<PeanutModel> Peanuts { get; set; } = new List<PeanutModel>();


    }
    public class BoxesModel
    {
        public double X1 { get; set; }
        public double X2 { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool ValidateCoordinate() => !(X1 < X2 || Y1 < Y2);
    }
    public class PeanutModel
    {
        public double X { get; set; }
        public double Y { get; set; }
        public string Description { get; set; } = string.Empty;

    }
}
