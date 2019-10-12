using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputScript : MonoBehaviour
{
    FuzzyForm.Fuzzy f2 = new FuzzyForm.Fuzzy();

    public InputField Distance;
    public InputField Velocity;
    public Text FinalText;

    public void setget()
    {
        f2.RunFuzzy(float.Parse(Distance.text), float.Parse(Velocity.text));

        FinalText.text = f2.ReturnVal().ToString();
    }
}
