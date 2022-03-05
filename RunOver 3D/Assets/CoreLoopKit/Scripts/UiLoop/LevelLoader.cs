using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader instance;


    public GameObject loadingScreen;
   


    public int levelIndex,totalLevels;

    public bool isDebug;

    // Start is called before the first frame update
    void Awake()
    {

        
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;//Avoid doing anything else
        }
        
        instance = this;
        DontDestroyOnLoad(this.gameObject);
       
  
        StartCoroutine(LoadLevel());

    }




    IEnumerator LoadLevel()
    {

        yield return new WaitForSeconds(.1f);
        AsyncOperation asyncLoadLevel;

        if (!isDebug)
        {
            asyncLoadLevel = SceneManager.LoadSceneAsync(PlayerPrefs.GetInt("SCENEX"), LoadSceneMode.Single);
        }

        else
        {
            asyncLoadLevel = SceneManager.LoadSceneAsync(levelIndex, LoadSceneMode.Single);

        }
        while (!asyncLoadLevel.isDone)
        {
            yield return null;
        }
    
        loadingScreen.SetActive(false);
        // GameController.instance.onLevelLoad();
      //TinySauce.OnGameStarted("Level" + PlayerPrefs.GetInt("CURRENTLEVEL"));
    }
}
