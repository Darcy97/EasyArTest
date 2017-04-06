using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoseBooks : MonoBehaviour {

    public int myTag;
    public void OnBookButtonClick()
    {
        //根据选择书籍进行跳转
        //实现跳转逻辑
        LoadScene(myTag);

    }

    private void LoadScene(int index)
    {

        string sceneName = "HelloAR" + index;

        LoadSceneManager.Instance.SceneStack.Clear();
        LoadSceneManager.Instance.SceneStack.Push("EasyArInit");
        LoadSceneManager.Instance.SceneStack.Push(sceneName);
        SceneManager.LoadSceneAsync(sceneName);
        
    }
	
}
