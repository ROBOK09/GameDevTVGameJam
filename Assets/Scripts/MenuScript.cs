using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuScript : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;

    public static bool GameisPaused = false;
    public GameObject pauseMenuUI;

    [SerializeField] PlayerScript player;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)|| Input.GetKeyDown(KeyCode.P))
        {
            if(GameisPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        player.StopOrResumeTime(false);
        GameisPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        player.StopOrResumeTime(true);
        GameisPaused = true;
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Next()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
