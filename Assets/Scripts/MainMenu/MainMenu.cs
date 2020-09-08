using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void loadSinglePlayerGame() {
        //load singleplayer scene
        SceneManager.LoadScene("SinglePlayer");

    }

    public void LoadCoOpGame(){
        //load the co op scene
        SceneManager.LoadScene("Co-Op");
}
}
