using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameOver = true;
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject titleScreen;

    private SpwnManager spwnManager;
    private UIManager uiManager;


    private void Start()
    {
        spwnManager = GameObject.Find("SpwnManager").GetComponent<SpwnManager>();
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if (gameOver) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                gameOver = false;
                hideTitleScreen();
                Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);
                spwnManager.startSpawnRoutine();
            
            }
        }
    }

    public void showTitleScreen()
    {
        gameOver = true;
        uiManager.resetScore();
        titleScreen.SetActive(true);
    }

    public void hideTitleScreen()
    {
        titleScreen.SetActive(false);
    }
}
