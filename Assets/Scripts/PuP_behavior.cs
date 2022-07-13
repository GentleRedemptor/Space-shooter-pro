using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuP_behavior : MonoBehaviour
{

    [SerializeField]
    private float speed = 3;
    [SerializeField]// 0=Triple shot 1=Speed boost 2=Sheild
    private int PuP_ID;
    private AudioSource pupSFX;
    // Start is called before the first frame update
    void Start()
    {
        pupSFX = GameObject.Find("power_up_sound").GetComponent<AudioSource>();
        if (pupSFX == null)
        {
            Debug.LogError("The PUPSFX is NULL");
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
       
        if (transform.position.y < (-5.56f))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            if(player != null)
            {

                switch (PuP_ID)
                {
                    case 0:
                        player.Activate_triple_shot();
                        break;
                    case 1:
                        player.Activate_speed_PuP();
                        break;
                    case 2:
                        player.Activate_Shield_PuP();
                        break;
                    default:
                        Debug.Log("default value power up");
                        break;
                }
            }
            pupSFX.Play();
            Destroy(gameObject);
        }
    }
}
