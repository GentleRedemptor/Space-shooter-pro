using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed = 4;
    private Player player;
    private Animator animator;
    private EdgeCollider2D collider1;
    [SerializeField]
    private AudioSource explosionSFX;
    [SerializeField]
    private GameObject laser;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        if (player == null)
        {
            Debug.LogError("Player is NULL");
        }
        animator = gameObject.GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator is NULL");
        }
        collider1 = GetComponent<EdgeCollider2D>();
        if (collider1 == null)
        {
            Debug.LogError("Collider is NULL");
        }
        StartCoroutine(enemyshooting());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y <= -5.56)
        {
            transform.position = new Vector3(Random.Range(-9.8f, 9.8f), 9f, 0);
        }
    }

    IEnumerator enemyshooting()
    {
        yield return new WaitForSeconds(Random.Range(1.2f , 1.8f));
        Instantiate(laser, transform.position, Quaternion.identity);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                player.Damage();
            }
            animator.SetTrigger("TriggerEnemyDeath");
            speed = 2f;
            collider1.enabled = false;
            StopAllCoroutines();
            explosionSFX.Play();
            Destroy(gameObject, 3.2f);
        }
        else if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            if (player != null)
            {
                player.Add_Score(10);
            }
            animator.SetTrigger("TriggerEnemyDeath");
            speed = 2f;
            collider1.enabled = false;
            StopAllCoroutines(); 
            explosionSFX.Play();
            Destroy(gameObject, 3.2f);
        }

    }
}
