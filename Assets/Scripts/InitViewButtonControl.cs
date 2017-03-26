using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

public class InitViewButtonControl : MonoBehaviour {

    public UIButton registerButton;

    //public UIInput nickNameInput;
    //public UIInput password;
    //public UIInput ageInput;
    //public UIInput realName;

    //public TweenColor nickNameInputBoxAnimation;
    //public TweenColor passwordInputBoxAnimation;
    //public TweenColor ageInputBoxAnimation;
    //public TweenColor realNameInputBoxAnimation;

 

    public UIInput[] inputs;
    public TweenColor[] tweenColors;

    public TweenPosition startViewTweenPosition;
    public TweenPosition registerVIewTweenPosition;
    public TweenPosition loginViewTweenPosition;
    public void OnLoginButtonClick()
    {
        loginViewTweenPosition.PlayForward();
        startViewTweenPosition.PlayForward();
        print("Login");
    }

    public void OnRegisterButtonClick()
    {
        startViewTweenPosition.PlayForward();
        registerVIewTweenPosition.PlayForward();
        
        print("Register");
    }

    public void OnLoginSubmittButtonClick()
    {
        loginViewTweenPosition.PlayReverse();
        //弹出选择书籍页面
        
        print("login submitt");
    }

    

    
    public void OnRegisterSubmittButtonClick()
    {
        
        for (int i=0; i<4; i++)
        {
            if (inputs[i].value == "")
            {

                PlayAnimation(i);
                return;

            } else if (i == 2)
            {
                
                int intValue = int.Parse(inputs[i].value);
                if (intValue < AgeInputLimit.minAge || intValue > AgeInputLimit.maxAge)
                {
                    PlayAnimation(2);
                    return;
                }
            }     
        }


        //实现register逻辑  
        print("register");


        //跳转到登陆界面
        
        registerVIewTweenPosition.PlayReverse();
        loginViewTweenPosition.PlayForward();


        //if (nickNameInput.value == "")
        //{
        //    PlayAnimation(AnimationType.NICKNAME);
        //    isCanRegister = false;
        //}   
        //if (ageInput.value == "")
        //{
        //    isCanRegister = false;
        //    PlayAnimation(AnimationType.AGE);
        //} else
        //{
        //    int intValue = int.Parse(ageInput.value);
        //    if (intValue < AgeInputLimit.minAge || intValue > AgeInputLimit.maxAge || ageInput == null)
        //    {
        //        PlayAnimation(AnimationType.AGE);
        //    }

        //}



    }
    //enum AnimationType
    //{
    //    NICKNAME = 0,
    //    PASSWORD = 1,
    //    AGE = 2,
    //    NAME = 3
    //}
    private void PlayAnimation(int type)
    {
        tweenColors[type].ResetToBeginning();
        tweenColors[type].PlayForward();
        //switch (type)
        //{
        //    case AnimationType.AGE:
        //        ageInputBoxAnimation.ResetToBeginning();
        //        ageInputBoxAnimation.PlayForward();
        //        break;
        //    case AnimationType.NAME:
        //        realNameInputBoxAnimation.ResetToBeginning();
        //        realNameInputBoxAnimation.PlayForward();
        //        break;
        //    case AnimationType.NICKNAME:
        //        nickNameInputBoxAnimation.ResetToBeginning();
        //        nickNameInputBoxAnimation.PlayForward();
        //        break;
        //    case AnimationType.PASSWORD:
        //        passwordInputBoxAnimation.ResetToBeginning();
        //        passwordInputBoxAnimation.PlayForward();
        //        break;
        //    default:
        //        break;
        //}
    }


}
