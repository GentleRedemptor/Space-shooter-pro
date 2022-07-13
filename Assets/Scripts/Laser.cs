using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float speed = 8f;
    [SerializeField]
    private float offset = 0.7f;
   


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + offset, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
       
        transform.Translate(Vector3.up * Time.deltaTime * speed);

        if(transform.position.x > (11.27f))
        {
            Destroy(gameObject);
        }
        else if (transform.position.x < (-11.27f))
        {
            Destroy(gameObject);
        }
        else if (transform.position.y > (7.56f))
        {
            Destroy(gameObject);
        }
        else if (transform.position.y < (-5.56f))
        {
            Destroy(gameObject);
        }
    }
}
