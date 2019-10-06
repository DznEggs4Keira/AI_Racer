using UnityEngine;
using UnityEditor;

namespace FuzzyForm
{
    public class FuzzyLogic
    {
        //FUZZIFIED FUNCTIONS
        //triangle member function
        public double FuzzyTriangle(double value, double x0, double x1, double x2)
        {
            double result = 0;
            double x = value;
            if ((x <= x0) || (x >= x2))
                result = 0;
            else if (x == x1)
                result = 1;
            else if ((x > x0) && (x < x1))
                result = (x / (x1 - x0)) - (x0 / (x1 - x0));
            else
                result = (-x / (x2 - x1)) + (x2 / (x2 - x1));
            return result;
        }

        //trapizoid member function
        public double FuzzyTrapezoid(double value, double x0, double x1, double x2, double x3)
        {
            double result = 0;
            double x = value;
            if ((x <= x0) || (x >= x3))
                result = 0;
            else if ((x >= x1) && (x <= x2))
                result = 1;
            else if ((x > x0) && (x < x1))
                result = (x / (x1 - x0)) - (x0 / (x1 - x0));
            else
                result = (-x / (x3 - x2)) + (x3 / (x3 - x2));
            return result;
        }
        //reverse grade member function
        public double FuzzyReverseGrade(double value, double x0, double x1)
        {
            double result = 0;
            double x = value;
            if (x <= x0)
                result = 1;
            else if (x >= x1)
                result = 0;
            else
                result = (-x / (x1 - x0)) + (x1 / (x1 - x0));
            return result;
        }
        //grade member function
        public double FuzzyGrade(double value, double x0, double x1)
        {
            double result = 0;
            double x = value;
            if (x <= x0)
                result = 0;
            else if (x >= x1)
                result = 1;
            else
                result = (x / (x1 - x0)) - (x0 / (x1 - x0));
            return result;
        }

        //fuzzy operators
        public double FuzzyAND(double A, double B)
        {
            return GetMIN(A, B);
        }
        public double FuzzyOR(double A, double B)
        {
            return GetMAX(A, B);
        }
        public double FuzzyNOT(double A)
        {
            return 1.0 - A;
        }

        //MIN and MAX Functions to calculate fuzzyOR and fuzzyAND
        double GetMIN(double A, double B)
        {
            if (A > B)
                return B;
            else
                return A;
        }

        double GetMAX(double A, double B)
        {
            if (A > B)
                return A;
            else
                return B;
        }
    }
}