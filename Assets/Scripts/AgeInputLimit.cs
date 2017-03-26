using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgeInputLimit : MonoBehaviour {
    private UIInput input;

    public static int minAge = 12;
    public static int maxAge = 68;

    private TweenColor ageInputBoxAnimator;

    private void Awake()
    {
        input = this.GetComponent<UIInput>();
        ageInputBoxAnimator = this.GetComponent<TweenColor>();
    }

    public void OnCommit()
    {

        if (input.value != "")
        {
            int intValue = int.Parse(input.value);
            if (intValue < minAge)
            {
                ageInputBoxAnimator.ResetToBeginning();
                ageInputBoxAnimator.PlayForward();
                input.value = minAge.ToString();
            }
            else if (intValue > maxAge)
            {
                ageInputBoxAnimator.ResetToBeginning();
                ageInputBoxAnimator.PlayForward();
                input.value = maxAge.ToString();
            }
        }
       
    }

  

}
