using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

public class InitViewButtonControl : MonoBehaviour {

    public UIButton registerButton;

    private Dictionary<string, string> accounts;

    //public UIInput nickNameInput;
    //public UIInput password;
    //public UIInput ageInput;
    //public UIInput realName;

    //public TweenColor nickNameInputBoxAnimation;
    //public TweenColor passwordInputBoxAnimation;
    //public TweenColor ageInputBoxAnimation;
    //public TweenColor realNameInputBoxAnimation;

 

    /// <summary>
    /// nickname
    /// password
    /// age
    /// name
    /// sex
    /// email
    /// </summary>
    public UIInput[] inputs;
    public TweenColor[] tweenColors;

    public TweenPosition startViewTweenPosition;
    public TweenPosition registerVIewTweenPosition;
    public TweenPosition loginViewTweenPosition;
    public TweenPosition choseBookViewTweenPosition;

    private void Awake()
    {
        accounts = new Dictionary<string, string>();
        alert = GameObject.Find("Alert");
        alert.SetActive(false);
    }
    public void OnLoginButtonClick()
    {
        loginViewTweenPosition.PlayForward();
        startViewTweenPosition.PlayForward();
        print("Login");
    }

    public void OnRegisterButtonClick()
    {
        loginViewTweenPosition.PlayForward();
        registerVIewTweenPosition.PlayForward();
        
        print("Register");
    }

    public UIInput loginNameInput;
    public UIInput loginPasswordInput;
    private GameObject alert;
    public void OnLoginSubmittButtonClick()
    {

        //测试用
        if (loginNameInput.value == "darcy" && loginPasswordInput.value == "123")
        {
            loginViewTweenPosition.PlayForward();
            choseBookViewTweenPosition.PlayForward();
            loginNameInput.value = "";
            loginPasswordInput.value = "";

            return;
        }
        if (accounts.Count == 0)
        {
            alert.SetActive(true);

            alert.GetComponent<TweenColor>().ResetToBeginning();
            alert.GetComponent<TweenColor>().PlayForward();
        }
        foreach(KeyValuePair<string, string> account in accounts)
        {
            if (loginNameInput.value == account.Key && loginPasswordInput.value == account.Value)
            {
                loginViewTweenPosition.PlayForward();
                choseBookViewTweenPosition.PlayForward();
                loginNameInput.value = "";
                loginPasswordInput.value = "";
            } else
            {
                alert.SetActive(true);
                
                alert.GetComponent<TweenColor>().ResetToBeginning();
                alert.GetComponent<TweenColor>().PlayForward();
            }
        }    
    }

    public void OnFinishPlayAlert()
    {
        alert.SetActive(false);
    }

    public void OnRegisterSubmittButtonClick()
    {
        
        for (int i=0; i<inputs.Length; i++)
        {
            if (inputs[i].value == "")
            {

                PlayAnimation(i);
                return;

            }     
        }




        //实现register逻辑
        accounts.Add(inputs[0].value, inputs[1].value);
        


        //跳转到登陆界面
        
        registerVIewTweenPosition.PlayReverse();
        loginViewTweenPosition.PlayReverse();


        /*if (nickNameInput.value == "")
        {
            PlayAnimation(AnimationType.NICKNAME);
            isCanRegister = false;
        }   
        if (ageInput.value == "")
        {
            isCanRegister = false;
            PlayAnimation(AnimationType.AGE);
        } else
        {
            int intValue = int.Parse(ageInput.value);
            if (intValue < AgeInputLimit.minAge || intValue > AgeInputLimit.maxAge || ageInput == null)
            {
                PlayAnimation(AnimationType.AGE);
            }

        }
        */

        foreach(UIInput input in inputs)
        {
            input.value = "";
        }

        



    }

    public void OnRegisterViewBackButtonClick()
    {
        loginViewTweenPosition.PlayReverse();
        registerVIewTweenPosition.PlayReverse();
    }

    public void OnLoginViewBackButtonClick()
    {
        loginViewTweenPosition.PlayReverse();
        startViewTweenPosition.PlayReverse();
    }

    public void OnChoseBookViewBackButtonClick()
    {
        loginViewTweenPosition.PlayReverse();
        choseBookViewTweenPosition.PlayReverse();
    }

    public void OnARViewBackButtonClick()
    {

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
