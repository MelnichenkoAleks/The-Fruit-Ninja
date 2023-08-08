using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButton : MonoBehaviour
{

    public void Mainmenu()
    {
        SceneManager.LoadScene(0);
    }

    public void EasyLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void HardLevel()
    {
        SceneManager.LoadScene(2);
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }
}
