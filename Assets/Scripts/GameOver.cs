using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameOver : MonoBehaviour {

    public Text roundsText;

    private void OnEnable()
    {
        roundsText.text = PlayerStats.rounds.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //reloads current scene for a restart
    }

    public void Menu()
    {
        Debug.Log("Go to main menu.");
    }
}
