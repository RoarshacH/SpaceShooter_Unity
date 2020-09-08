using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private GameObject[] powerups;

    private float enemyspawnrate = 5.0f;
    private float powerupspawnrate = 5.0f;
    // Start is called before the first frame update

    private GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine(EnemySpawn());
        StartCoroutine(PowerupSpown());
        
    }
    private void Update()
    {
    }

    public void startSpawnRoutine() {
        StartCoroutine(EnemySpawn());
        StartCoroutine(PowerupSpown());
    }


    IEnumerator EnemySpawn() {

        while (gameManager.gameOver == false) {
            Instantiate(enemy, new Vector3(Random.Range(-8.0f, 8.0f), 6.0f, 0), Quaternion.identity);
            yield return new WaitForSeconds(enemyspawnrate);

        }
    
    }

    IEnumerator PowerupSpown() {
        while (gameManager.gameOver == false) {
            int randomPowerUp = Random.Range(0, 3);
            Instantiate(powerups[randomPowerUp], new Vector3(Random.Range(-8.0f, 8.0f), 6.0f, 0), Quaternion.identity);
            yield return new WaitForSeconds(powerupspawnrate);
        }
    }
}
