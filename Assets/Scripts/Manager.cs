using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {

        
    public void OnBackButtonClick()
    {
        LoadSceneManager.Instance.SceneStack.Pop();
        string SceneName = (string)LoadSceneManager.Instance.SceneStack.Pop();
        if (SceneName != "")
            SceneManager.LoadSceneAsync(SceneName);
        else
            SceneManager.LoadSceneAsync("EasyArInit");
    }
    public GameObject HideButton;

    private void Start()
    {
        HideButton.SetActive(false);
    }

    public void ShowButtons()
    {
        if(HideButton.activeSelf == true)
        {
            HideButton.SetActive(false);
        } else
        {
            HideButton.SetActive(true);
        }
        
    }
}
