using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public enum SceneLoadMode { Async, Sync }
public class CustomSceneManager : MonoBehaviour
{
    public static CustomSceneManager instance;
    private readonly Stack<string> backStack = new Stack<string>();
    [SerializeField]
    private GameObject loadingScreen;
    [SerializeField]
    private Animator screenTransitionController;
    private GameObject instantiatedLoadingScreen;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        instantiatedLoadingScreen = Instantiate(loadingScreen, transform);
        instantiatedLoadingScreen.SetActive(false);
    }
    public void LoadScene(string sceneName, SceneLoadMode loadSceneMode, float disableDelay, bool addToStack = true, string menu = null)
    {
        if (addToStack)
            backStack.Push(SceneManager.GetActiveScene().name);
        switch (loadSceneMode)
        {
            case SceneLoadMode.Sync:
                EnableLoadingScreen();
                SceneManager.LoadScene(sceneName);
                DisableLoadingScreen();
                if (menu != null)
                {
                    MenuManager.Instance.OpenMenu(menu);
                }
                break;
            case SceneLoadMode.Async:
                StartCoroutine(IELoadSceneAsync(sceneName, menu, disableDelay));
                break;
        }
    }
    public void GoBack(float disableDelay)
    {
        Time.timeScale = 1;
        if (backStack.Count > 0)
        {
            LoadScene(backStack.Peek(), SceneLoadMode.Async, disableDelay);
            backStack.Pop();
        }
        else
        {
            Application.Quit();
        }
    }
    private IEnumerator IELoadSceneAsync(string sceneName, string menu, float disableDelay)
    {
        EnableLoadingScreen();
        StartCoroutine(IEEnableTransition());
        var task = SceneManager.LoadSceneAsync(sceneName);
        while (!task.isDone)
        {
            yield return null;
        }

        StartCoroutine(IEDisableTransition(disableDelay));

        DisableLoadingScreen();
        if (menu != null)
        {
            MenuManager.Instance.OpenMenu(menu);
        }
    }
    public void EnableLoadingScreen()
    {
        instantiatedLoadingScreen.SetActive(true);
    }
    public void DisableLoadingScreen()
    {
        instantiatedLoadingScreen.SetActive(false);
    }
    public void EnableTransition()
    {
        screenTransitionController.SetBool("isLoadingStart", true);
    }
    private void DisableTransition()
    {
        screenTransitionController.SetBool("isLoadingStart", false);
    }
    private IEnumerator IEDisableTransition(float disableDelay)
    {

        yield return new WaitForSecondsRealtime(disableDelay);
        //DisableTransition();
    }
    private IEnumerator IEEnableTransition()
    {
        //EnableTransition();
        yield return new WaitForSecondsRealtime(1f);
    }

}
