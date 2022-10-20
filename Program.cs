using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {


            var listCases = new List<(List<PeanutModel> listPeanuts, List<BoxesModel> listBox)>();
            var listPeanuts = new List<PeanutModel>();
            var listBox = new List<BoxesModel>();

            Console.WriteLine($"Write the numer of the Cases: ");
            var cases = Int32.Parse(Console.ReadLine());
            do
            {
                if (cases > 30)
                {
                    Console.WriteLine("Cases cannot be more than 30");
                    Console.WriteLine("");
                    Console.WriteLine($"Write the numer of the Cases: ");
                    cases = Int32.Parse(Console.ReadLine());
                }
            }
            while (cases > 30);

            for (int i = 0; i < cases; i++)
            {
                InputBoxes(listBox);
                InputPeanuts(listPeanuts);

                listCases.Add((listPeanuts, listBox));

                listPeanuts = new List<PeanutModel>();
                listBox = new List<BoxesModel>();
            }

            Calculate(listCases);
        }
        static void InputBoxes(List<BoxesModel> listBox)
        {
            var cases = InputCases("Boxes", 30);
            var nCases = cases.sequence;

            if (cases.isValid)
            {
                for (int j = 0; j < nCases; j++)
                {
                    bool verifyBox = false;
                    do
                    {
                        BoxesModel coordinate = new BoxesModel();
                        Console.WriteLine($" ----- Type de List of boxes Coordinate and Size Index {j} -----");
                        Console.WriteLine(" ----- X1 -----");
                        coordinate.X1 = double.Parse(Console.ReadLine());
                        Console.WriteLine(" ----- Y1 -----");
                        coordinate.Y1 = double.Parse(Console.ReadLine());
                        Console.WriteLine(" ----- X2 -----");
                        coordinate.X2 = double.Parse(Console.ReadLine());
                        Console.WriteLine(" ----- Y2 -----");
                        coordinate.Y2 = double.Parse(Console.ReadLine());
                        Console.WriteLine(" ----- Description small, medium, or large -----");
                        coordinate.Description = Console.ReadLine();
                        verifyBox = UtilMethods.VerifyBoxes(listBox, coordinate);
                        if (verifyBox)
                            Console.WriteLine(" ----- There are no two boxes that overlap or toutch try again-----");
                        else
                            listBox.Add(coordinate);

                    } while (verifyBox);
                }
            }
        }

       static void InputPeanuts(List<PeanutModel> listPeanuts)
        {
            InputPeanuts inputPeanuts = new InputPeanuts();
            var sequences = InputCases("Peanuts", 100);
            do
            {
                if (!sequences.isValid)
                {
                    Console.WriteLine("Peanuts cannot be more than 100");
                    sequences = InputCases("Peanuts", 100);
                }
                else
                {
                    inputPeanuts.Sequence = sequences.sequence;
                    for (int i = 0; i < inputPeanuts.Sequence; i++)
                    {
                        PeanutModel coordinate = new PeanutModel();
                        Console.WriteLine($" ----- Type de List of Peanuts Coordinate and Size Index {i} -----");
                        Console.WriteLine(" ----- X -----");
                        coordinate.X = double.Parse(Console.ReadLine());
                        Console.WriteLine(" ----- Y -----");
                        coordinate.Y = double.Parse(Console.ReadLine());
                        Console.WriteLine(" ----- Description small, medium, or large -----");
                        coordinate.Description = Console.ReadLine();
                        listPeanuts.Add(coordinate);
                    }
                    inputPeanuts.Peanuts.AddRange(listPeanuts);
                }
            } while (!sequences.isValid);
        }

       static  (double sequence, bool isValid) InputCases(string type, int range)
        {
            Console.WriteLine($"Write the Nº of {type}");
            var digit = Double.Parse(Console.ReadLine());
            return (digit, UtilMethods.MaximumLenght(digit, range));
        }
        public static void Calculate(List<(List<PeanutModel> listPeanuts, List<BoxesModel> listBox)> listCases)
        {
            Console.WriteLine("");
            Console.WriteLine("Result:");
            Console.WriteLine("");

            foreach (var cases in listCases)
            {
                Console.WriteLine("");

                foreach (var peanut in cases.listPeanuts)
                {
                    var boxCorrect = cases.listBox.FirstOrDefault(box => (box.X1 == peanut.X && peanut.Y >= box.Y1 && peanut.Y <= box.Y2) ||
                                                                         (box.Y1 == peanut.Y && peanut.X >= box.X1 && peanut.X <= box.X2) ||
                                                                         ((peanut.X >= box.X1 && peanut.X <= box.X2) && (peanut.Y >= box.Y1 && peanut.Y <= box.Y2)) ||
                                                                         (peanut.X == box.X2 && peanut.Y == box.Y2)
                                                                 );

                    if (boxCorrect != null)
                    {
                        if (boxCorrect.Description == peanut.Description)
                            Console.WriteLine(peanut.Description + " correct");
                        else
                            Console.WriteLine(peanut.Description + " " + boxCorrect.Description);
                    }
                    else
                    {
                        var box = cases.listBox.FirstOrDefault(box => (peanut.X >= box.X1 && peanut.X <= box.X2) &&
                                                                (peanut.Y >= box.Y1 && peanut.Y <= box.Y2)
                        );
                        if (box != null)
                            Console.WriteLine(peanut.Description + " " + box.Description);
                        else
                            Console.WriteLine(peanut.Description + " floor");
                    }
                }
            }
        }
    }
}
