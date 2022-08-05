using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public Controls Controls;

    public enum State
    {
        Playing,
        Won,
        Loss,
    }

    public State CurrentState { get; private set; }

    public void OnPlayerDied()
    {
        if(CurrentState != State.Playing)
        {
            return;
        }

        CurrentState = State.Loss;
        Controls.enabled = false;
        Debug.Log("Game Over");
        Invoke("ReloadLevel", 2f);
    }

    public void OnPlayerReachfinish()
    {
        if (CurrentState != State.Playing)
        {
            return;
        }

        CurrentState = State.Won;
        Controls.enabled = false;
        Debug.Log("You won!");
        LevelIndex++;
        ReloadLevel();
    }

    public int LevelIndex
    {
        get => PlayerPrefs.GetInt(LevelIndexKey, 0);
        private set
        {
            PlayerPrefs.SetInt(LevelIndexKey, value);
            PlayerPrefs.Save();
        }
    }

    private const string LevelIndexKey = "LevelIndex";

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
