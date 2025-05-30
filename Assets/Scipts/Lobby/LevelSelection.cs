using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public static LevelSelection Loader;

    private void Awake()
    {
        if (Loader != null && Loader != this)
            Destroy(this);
        else
            Loader = this;
    }

    public void LoadLevel(int scene)
    {
        SceneManager.LoadScene(scene + 2);
    }
}
