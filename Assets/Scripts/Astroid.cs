using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroid : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float rotate_speed = 30.0f;
    [SerializeField]
    private GameObject explosion;
    private Spawn_Manager spawn_Manager;
    void Start()
    {
        spawn_Manager = GameObject.Find("Spawn_Manager").GetComponent<Spawn_Manager>();
        if (spawn_Manager == null)
        {
            Debug.LogError("The spawn manager is NULL");
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3( 0 , 0 , rotate_speed) * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Instantiate(explosion , transform.position , Quaternion.identity);
            spawn_Manager.startspawning();
            Destroy(gameObject);
        }
    }


}
