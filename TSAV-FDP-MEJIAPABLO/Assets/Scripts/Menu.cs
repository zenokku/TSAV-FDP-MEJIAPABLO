
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject PLAY;
    bool pause;
    public void boton()
    {
        Time.timeScale = 1;
    }
    public void Escena2()
    {
        SceneManager.LoadScene(1);
    }
    public void Escena1()
    {
        SceneManager.LoadScene(0);
    }
    public void Escena3()
    {
        SceneManager.LoadScene(2);
    }
    void Start()
    {
    }
    void Update()
    {
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                pause = !pause;
                PLAY.SetActive(pause);

                if (!pause)
                {
                    Time.timeScale = 1;
                }
                else
                {
                    Time.timeScale = 0;
                }
            }
        }
    }
}
    

