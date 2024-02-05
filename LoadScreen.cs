using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LoadScreen : MonoBehaviour
{
    public GameObject LoadingScreen;
    public Slider slidet;
    // Start is called before the first frame update
    public void Loading()
    {
       LoadingScreen.SetActive(true);
       StartCoroutine(LoadAsync());
    }

    IEnumerator LoadAsync()
    {
        AsyncOperation loadAsync = SceneManager.LoadSceneAsync(0);
        loadAsync.allowSceneActivation = false;
    

    while (!loadAsync.isDone)
    {

        slidet.value = loadAsync.progress;
        if(loadAsync.progress>= .9f && !loadAsync.allowSceneActivation)
        {
            yield return new WaitForSeconds(2f);
            loadAsync.allowSceneActivation = true;
        }
        yield return null;
    }
    }
}
