using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private void Awake()
    {
        Physics2D.gravity = new Vector2(0f,-9.8f);
    }
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
