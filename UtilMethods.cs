using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public static class UtilMethods
    {
        public static bool MaximumLenght(double value, int maxLenght) => !(value > maxLenght || value <= 0);
        public static bool VerifyBoxes(List<BoxesModel> list, BoxesModel obj)
        {
            return list.FindAll(l => l.X1.Equals(obj.X1) && l.X2.Equals(obj.X2) && l.Y1.Equals(obj.Y1) && l.Y1.Equals(obj.Y1) && l.Y2.Equals(obj.Y2)).Any();

        }
    }
    public enum Enums
    {
        [Description("Floor")]
        floor,

    };
}
