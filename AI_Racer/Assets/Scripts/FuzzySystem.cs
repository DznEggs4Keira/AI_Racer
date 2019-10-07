using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FuzzyForm
{
    public class Fuzzy
    {
        FuzzyForm.FuzzyLogic F1 = new FuzzyForm.FuzzyLogic();

        //input variables
        //1. 'distance' member functions
        double dLeft;
        double dCentre;
        double dRight;

        //2. 'current steering' member functions
        double cTurnLeft;
        double cNoChange;
        double cTurnRight;

        //output variable
        //'steering' member functions
        double sLeft;
        double sNoChange;
        double sRight;

        //rule variables --- this will be a degree of the output that i want.
        double steerL;
        double steerNC;
        double steerR;

        double finalSteerVal;

        // this function returns the result of the fis as a float value so that it may be applied to the race car 
        public float ReturnVal()
        {
            return (float)finalSteerVal;
        }

        // this function recieves the two inputs from game.cpp
        public void RunFuzzy(float distance, float velocity)
        {
            //pass the recieved values to set up the mfs
            setMembershipFunc(distance, velocity);

            //call the rules function to use the set mfs
            Rules();

            //using this approach
            //convert results back into useable crisp values via defuzzififcation -- Singleton
            Singleton();

            //convert results back into useable crisp values via defuzzififcation -- Centroid
            //Defuzzify();
        }

        double getRule(int rule)
        {
            switch (rule)
            {
                //case 1 - steerL
                case 1: return steerL;
                //case 2 - steerNC
                case 2: return steerNC;
                //case 3 - steerR
                case 3: return steerR;
                // if all cases fail, return 0
                default: return 0;
            }
        }

        // define the membership functions
        void setMembershipFunc(float distance, float velocity)
        {
            //input 1 - distance between race line and race car
            dLeft = F1.FuzzyReverseGrade(distance, -800, -0.5);
            dCentre = F1.FuzzyTriangle(distance, -500, 0, 500);
            dRight = F1.FuzzyGrade(distance, 0.5, 800);

            //input 2 - current velocity of race car
            cTurnLeft = F1.FuzzyReverseGrade(velocity, -250, -0.5);
            cNoChange = F1.FuzzyTriangle(velocity, -150, 0, 150);
            cTurnRight = F1.FuzzyGrade(velocity, 0.5, 250);

        }

        void Rules()
        {
            //define rules and place them in rule variables
            steerL = F1.FuzzyOR(F1.FuzzyOR(F1.FuzzyAND(dRight, cTurnRight), F1.FuzzyAND(dRight, cNoChange)), F1.FuzzyAND(dCentre, cTurnRight));
            steerNC = F1.FuzzyOR(F1.FuzzyOR(F1.FuzzyAND(dLeft, cTurnRight), F1.FuzzyAND(dCentre, cNoChange)), F1.FuzzyAND(dRight, cTurnLeft));
            steerR = F1.FuzzyOR(F1.FuzzyOR(F1.FuzzyAND(dLeft, cTurnLeft), F1.FuzzyAND(dCentre, cTurnLeft)), F1.FuzzyAND(dLeft, cNoChange));

        }

        //DEFUZZIFICATION
        //using singleton
        void Singleton()
        {
            //steering - the max value by which steering of the car can occur
            double maxV = 5.0f;

            //a formulae i found in the book which seems to give the right output
            finalSteerVal = ((-maxV * steerL) + ((0.0f) * (1 - steerNC)) + (maxV * steerR));
        }
    }
}
