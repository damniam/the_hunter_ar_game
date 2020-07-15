using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingTargetScreen : MonoBehaviour
{
    public void LoadSceneNum(int num)
    {
        if(num<0 || num >= SceneManager.sceneCountInBuildSettings)
        {
            Debug.LogWarningFormat("Nie można załadować " + num + " tej sceny");
            return;
        }

        LoadingScreenManager.LoadScene(num);
    }

}

