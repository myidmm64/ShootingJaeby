
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public void OnclickRetry()
    {
        SceneManager.LoadScene("Main");
    }
}