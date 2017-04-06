using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalInformation : Singleton<GlobalInformation> {

    public bool isLogin = false;

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

}
