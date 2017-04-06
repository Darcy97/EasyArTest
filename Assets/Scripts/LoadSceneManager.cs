using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : Singleton<LoadSceneManager> {

    public Stack SceneStack;

	void Start () {
        DontDestroyOnLoad(this);
        SceneStack = new Stack();
        SceneManager.LoadSceneAsync("EasyArInit");
	}
	
}
