using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.AssetImporters;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 8.0F;
    [SerializeField]
    private int lives = 3;
    [SerializeField]
    private float firerate = 0.3F;
    private float nextfire = 0.0F;

    [SerializeField]
    private float powerdown = 5.0f;
    [SerializeField]
    private float speedRate = 2.0f;
    public bool tripleShot = false;
    public bool shield = false;
    [SerializeField]
    private GameObject playerExplosionAnimation;
    [SerializeField]
    private GameObject playerShield;
    private AudioSource laserSound;

    [SerializeField]
    private GameObject[] engines;

    private int hitCount = 0;


    public GameObject laserSpawn;

    private UIManager uIManager;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(transform.position.x);
        transform.position = new Vector3(0,0,0);
        uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (uIManager) {
            uIManager.updateLives(lives);
        }
        laserSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Shoot();
    }

    private void Shoot() {
        if (tripleShot)
        {
            if ((Input.GetKeyDown(KeyCode.Space)) || (Input.GetMouseButtonDown(0)))
            {
                if (Time.time > nextfire)
                {
                    laserSound.Play();
                    Vector3 laser = new Vector3(transform.position.x, transform.position.y + 0.58f, 0);
                    Vector3 laserleft = new Vector3(transform.position.x - 0.59f, transform.position.y -0.07f + 0.58f, 0);
                    Vector3 laserright = new Vector3(transform.position.x + 0.59f, transform.position.y -0.07f + 0.58f, 0);
                    //Shot Laser Spawn Laser
                    Instantiate(laserSpawn, laser, Quaternion.identity);
                    Instantiate(laserSpawn, laserleft, Quaternion.identity);
                    Instantiate(laserSpawn, laserright, Quaternion.identity);
                    nextfire = Time.time + firerate;
                }
            }
        }
        else {
            if ((Input.GetKeyDown(KeyCode.Space)) || (Input.GetMouseButtonDown(0)))
            {
                if (Time.time > nextfire)
                {
                    laserSound.Play();
                    Vector3 laser = new Vector3(transform.position.x, transform.position.y + 0.58f, 0);
                    //Shot Laser Spawn Laser
                    Instantiate(laserSpawn, laser, Quaternion.identity);
                    nextfire = Time.time + firerate;
                }
            }
        }           
    }

    public void Damage() {
        hitCount++;
        lives--;
        if (shield) {
            lives++;
            hitCount--;
            shield = false;
            playerShield.SetActive(false);
        }

        uIManager.updateLives(lives);
        if (lives < 1) {
            Instantiate(playerExplosionAnimation, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            hitCount = 0;
            gameManager.showTitleScreen();
        }

        if (hitCount == 1)
        {
            engines[0].SetActive(true);
        }
        if (hitCount == 2)
        {
            engines[1].SetActive(true);
        }
    }

    private void Movement() {
       
        float horizontalInput = Input.GetAxis("Horizontal");
        float virticalInput   = Input.GetAxis("Vertical");

        if (transform.position.x < -8.6f)
        {
            transform.position = new Vector3(8.5f, transform.position.y, 0);
        }
        else if (transform.position.x > 8.6f)
        {
            transform.position = new Vector3(-8.5f, transform.position.y, 0);
        }
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        if (transform.position.y < -5.1f)
        {
            transform.position = new Vector3(transform.position.x, 5.0f, 0);
        }
        else if (transform.position.y > 5.1f)
        {
            transform.position = new Vector3(transform.position.x, -5.0f, 0);
        }
        transform.Translate(Vector3.up * Time.deltaTime * speed * virticalInput);
    }

    public void TripleShotPowerUpOn() {
        tripleShot = true;
        StartCoroutine(TripleShotPowerDown());
    }

    public IEnumerator TripleShotPowerDown() {
        yield return new WaitForSeconds(powerdown);
        tripleShot = false;
    }

    public void ShieldPowerUp()
    {
        shield = true;
        playerShield.SetActive(true);
    }

    public void SpeedPowerUpOn()
    {
        speed = speed * speedRate;
        firerate = firerate / speedRate;
        StartCoroutine(SpeedPowerDown());
    }

    public IEnumerator SpeedPowerDown()
    {
        yield return new WaitForSeconds(powerdown);
        speed = speed / speedRate;
        firerate = firerate * speedRate;
    }

}
