using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public Animator animator;
    public CinemachineFreeLook[] cams;
    public GameObject[] canvas;
    public GameObject[] panels;
    public GameObject settingsButton;

    private AudioSource music;

    public bool isStart = false;

    void Start()
    {
        music = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        animator = GameObject.Find("Player").GetComponent<Animator>();
        cams[0].gameObject.SetActive(false);
        cams[1].gameObject.SetActive(true);
    }

    public void StartGameDelay()
    {
        isStart = true;
        music.Play();
        animator.SetBool("isStart", true);

        canvas[0].gameObject.SetActive(true);
    }
    public void GameOver()
    {
        isStart = false;
        animator.SetTrigger("death");
        Invoke("GameOverDelay", 3f);
    }
    public void GameOverDelay()
    {
        canvas[2].gameObject.SetActive(true);
    }

    public void Buttons(string thinks)
    {
        switch (thinks)
        {
            case "Start":

                canvas[1].gameObject.SetActive(false);
                cams[0].gameObject.SetActive(true);
                cams[1].gameObject.SetActive(false);
                Invoke("StartGameDelay", 2f);

                break;

            case "Settings":

                Time.timeScale = 0;
                panels[1].gameObject.SetActive(false);
                settingsButton.gameObject.SetActive(false);
                panels[0].gameObject.SetActive(true);

                break;

            case "Exit":

                Time.timeScale = 1;
                panels[1].gameObject.SetActive(true);
                settingsButton.gameObject.SetActive(true);
                panels[0].gameObject.SetActive(false);

                break;

            case "Again":

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

                break;

        }
    }

}
