using Firebase;
using Firebase.Auth;
using Firebase.Database;
using System.Collections;
using System.Linq;
using UnityEngine;

public class AuthManager : MonoBehaviour
{
    //Firebase variables
    [Header("Firebase")]
    public DependencyStatus dependencyStatus;
    public FirebaseAuth auth;
    public static FirebaseUser User;
    public static AuthManager instance;
    public DatabaseReference DBreference;
    private void Awake()
    {
        //Check that all of the necessary dependencies for Firebase are present on the system
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                //If they are avalible Initialize Firebase
                InitializeFirebase();
            }
            else
            {
                Debug.LogError("Could not resolve all Firebase dependencies: " + dependencyStatus);
            }
        });
        if (instance == null)
            instance = this;
    }

    private void InitializeFirebase()
    {
        Debug.Log("Setting up Firebase Auth");
        //Set the authentication instance object
        auth = FirebaseAuth.DefaultInstance;
        DBreference = FirebaseDatabase.DefaultInstance.RootReference;
    }



    public async void GoogleSignIn(string token)
    {
        Credential credential = Firebase.Auth.GoogleAuthProvider.GetCredential(token, null);
        var LoginTask = await auth.SignInWithCredentialAsync(credential);
        if (LoginTask != null)
        {
            User = LoginTask;
            CustomSceneManager.instance.LoadScene("Main Menu", SceneLoadMode.Async, 0f, false);
        }

    }

    public void RefreshLeaderBoard(int level, Transform container, GameObject prefab)
    {
        StartCoroutine(LoadScoreboardData(level, container, prefab));
    }
    private IEnumerator LoadScoreboardData(int level, Transform container, GameObject prefab)
    {
        //Get all the users data ordered by kills amount
        var DBTask = DBreference.Child("users").Child(level.ToString()).OrderByChild("time").GetValueAsync();

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //Data has been retrieved
            DataSnapshot snapshot = DBTask.Result;

            //Destroy any existing scoreboard elements
            foreach (Transform child in container)
            {
                Destroy(child.gameObject);
            }

            //Loop through every users UID
            foreach (DataSnapshot childSnapshot in snapshot.Children)
            {
                string username = childSnapshot.Child("username").Value.ToString();
                int time = int.Parse(childSnapshot.Child("time").Value.ToString());
                //Instantiate new scoreboard elements
                GameObject scoreboardElement = Instantiate(prefab, container);
                scoreboardElement.GetComponent<LeaderBoardListItem>().SetUp(new LeaderBoardItemData
                {
                    username = username,
                    time = time
                });
            }
        }
    }
    private IEnumerator UpdateTime(int level, int time)
    {
        //Set the currently logged in user xp
        var DBTask = DBreference.Child("users").Child(level.ToString()).Child(User.UserId).Child("time").SetValueAsync(time);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //Xp is now updated
        }
    }
    private IEnumerator UpdateUserName(int level, string username)
    {
        //Set the currently logged in user xp
        var DBTask = DBreference.Child("users").Child(level.ToString()).Child(User.UserId).Child("username").SetValueAsync(username);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //Xp is now updated
        }
    }
    public void UpdateLeaderBoardEntry(int level, int time)
    {
        StartCoroutine(UpdateTime(level, time));
        StartCoroutine(UpdateUserName(level, User.DisplayName));
    }
}
