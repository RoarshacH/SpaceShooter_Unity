using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;
    private float firerate = 1.0F;
    private float nextfire = 0.0F;
    private UIManager uIManager;

    [SerializeField]
    private GameObject enemyExplosionAnimation;

    [SerializeField]
    private GameObject laserSpawn;

    [SerializeField]
    private AudioClip exposionSound;

    // Start is called before the first frame update
    void Start()
    {
        uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
        if (transform.position.y < -6.0f)
        {
            transform.position = new Vector3(Random.Range(-8.0f, 8.0f), 6.0f, 0);
        }
        Vector3 laser = new Vector3(transform.position.x, transform.position.y + 0.80f, 0);
        //Shot Laser Spawn Laser
        
        if (Time.time > nextfire) {
            Instantiate(laserSpawn, laser, Quaternion.identity);
            nextfire = Time.time + firerate;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Laser")
        {
            Destroy(collision.gameObject);
            Instantiate(enemyExplosionAnimation, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            AudioSource.PlayClipAtPoint(exposionSound, Camera.main.transform.position, 1f);
            uIManager.updateScore();
        }
        else if (collision.tag == "Player")
        {
            Player player = collision.GetComponent<Player>();

            if (player)
            {
                player.Damage();
            }
            Instantiate(enemyExplosionAnimation, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(exposionSound, Camera.main.transform.position, 1f);
            Destroy(this.gameObject);
        }
        else if (collision.tag == "EnemyFire") {
            Player player = collision.GetComponent<Player>();

            if (player)
            {
                player.Damage();
            }
        }
    }
}
