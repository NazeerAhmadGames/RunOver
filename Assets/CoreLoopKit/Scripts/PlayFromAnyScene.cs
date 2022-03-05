using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayFromAnyScene : MonoBehaviour
{
    private void OnEnable()
    {
        if (CoreLoopUi.instance == null)
        {
            SceneManager.LoadScene(0);
        }
    }
    
}
