using UnityEngine;
using UnityEditor;

namespace FSMForm
{

    public class FSMSystem
    {
        enum CAR_STATE
        {
            //BY DEFAULT IT IS IN THE FIRST ONE
            DN, RIGHT, LEFT
        };

        int currentState;

        //all actions
        float kTurnRight() { return 5.0f; }
        float kDoNothing() { return 0.0f; }
        float kTurnLeft() { return -5.0f; }

        public float RunFSM(float position)
        {
            return checkTransition(position);
        }

        float checkTransition(float position)
        {
            switch (currentState)
            {
                case 2: //all rules for when you're left of the line
                    if (position > 0.0f && position < 0.5f)
                        currentState = 0;
                    break;

                case 0: //all rules for when you're on the center of the line
                    if (position < 0.0f)
                    {
                        currentState = 2;
                    }
                    else if (position > 0.5f)
                    {
                        currentState = 1;
                    }
                    break;

                case 1:   //all rules for when you're right of the line
                    if (position > 0.0f && position < 0.5f)
                        currentState = 0;
                    break;

                default:
                    break;
            }

            switch (currentState)
            {
                case 0: return kDoNothing();
                case 1: return kTurnLeft();
                case 2: return kTurnRight();
                default: return checkTransition(position);
            }
        }

    }
}