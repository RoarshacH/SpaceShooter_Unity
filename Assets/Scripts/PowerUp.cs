using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float speed = 10.0f;
    [SerializeField]
    private int powerupID = 5; // 0 triple shot, 1 = speed, 2 shield

    [SerializeField]
    private AudioClip powerupSound;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);

        if (transform.position.y < -7) {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collisionObject)
    {
        if (collisionObject.tag == "Player") {
            //Debug.Log(collisionObject.name);
            Player player = collisionObject.GetComponent<Player>();
            if (player) {
                switch (powerupID) {
                    case 0:
                        player.TripleShotPowerUpOn();
                        break;
                    case 1:
                        player.SpeedPowerUpOn();
                        break;
                    case 2:
                        player.ShieldPowerUp();
                        break;
                    default:
                        break;       
                }
            }
            AudioSource.PlayClipAtPoint(powerupSound, Camera.main.transform.position, 1f);
            Destroy(this.gameObject);
        }
        
    }
}
