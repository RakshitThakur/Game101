using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void OnPlay()
    {
        PLayerRepo.CurrentGameMode = GameMode.Online;
        CustomSceneManager.instance.LoadScene("1st Level", SceneLoadMode.Async, 0f, true);
    }
    public void OnPractice()
    {
        PLayerRepo.CurrentGameMode = GameMode.Practice;
        CustomSceneManager.instance.LoadScene("1st Level", SceneLoadMode.Async, 0f, true);
    }
}
