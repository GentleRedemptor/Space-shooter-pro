using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    public float speed = 3.5f;
    public GameObject laserprefab;
    [SerializeField]
    private float cooldown = 0.5f;
    [SerializeField]
    private float canfire = -1f;
    [SerializeField]
    private int lives = 3;
    private Spawn_Manager spawn_Manager;
    [SerializeField]
    private GameObject triple_shotprefab;
    public bool Triple_Shot_A = false;
    private float original_speed;
    public bool Shield_A = false;
    public GameObject Sheild_VFX;
    public int score = 0;
    private UI_Manager uimanager;
    [SerializeField]
    private GameObject firedamage1;
    [SerializeField]
    private GameObject firedamage2;
    [SerializeField]
    private AudioSource laserSFX;
    [SerializeField]
    private GameObject explosion;
    private SpriteRenderer sprite;
    private BoxCollider2D collider1;
    private CapsuleCollider2D collider2;
    // Start is called before the first frame update
    void Start()
    {
        original_speed = speed;
        transform.position = new Vector3(0, -2, 0);
        collider1 = GetComponent<BoxCollider2D>();
        collider2 = GetComponent<CapsuleCollider2D>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
        spawn_Manager = GameObject.Find("Spawn_Manager").GetComponent<Spawn_Manager>();
        if (spawn_Manager == null)
        {
            Debug.LogError("The spawn manager is NULL");
        }
       uimanager = GameObject.Find("Canvas").GetComponent<UI_Manager>();
        if (uimanager == null)
        {
            Debug.LogError("The UI manager is NULL");
        }
    }

    // Update is called once per frame
    void Update()
    {
        movement_code();


        if (Input.GetKeyDown(KeyCode.Space) && Time.time > canfire)
        {
            Shooting();
            laserSFX.Play();
        }
    }
    void movement_code()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticallInput = Input.GetAxis("Vertical");

        Vector3 position = new Vector3(horizontalInput, verticallInput, transform.position.z);
        transform.Translate(position * speed * Time.deltaTime);

        if (transform.position.x >= 11.04)
        {
            transform.position = new Vector3(-11.04f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x <= -11.05)
        {
            transform.position = new Vector3(11.03f, transform.position.y, transform.position.z);
        }

        if (transform.position.y >= 7.56)
        {
            transform.position = new Vector3(transform.position.x, -5.55f, transform.position.z);
        }
        else if (transform.position.y <= -5.56)
        {
            transform.position = new Vector3(transform.position.x, 7.55f, transform.position.z);
        }
    }
    
    void Shooting()
    {
        canfire = Time.time + cooldown;
        if(Triple_Shot_A == true)
        {
            Instantiate(triple_shotprefab, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(laserprefab, transform.position, Quaternion.identity);
        }       
    }

    public void Activate_triple_shot()
    {
        Triple_Shot_A = true;
        StartCoroutine(powerdown_triplesoht());              
    }

    IEnumerator powerdown_triplesoht()
    {
        yield return new WaitForSeconds(5.0f);
        Triple_Shot_A = false;
    }

    public void Activate_speed_PuP()
    {
        speed = speed + 3f;
        StartCoroutine(powerdown_speed());
    }

    IEnumerator powerdown_speed()
    {
        yield return new WaitForSeconds(5.0f);
        speed = original_speed;
    }

    public void Activate_Shield_PuP()
    {
        Shield_A = true;
        Sheild_VFX.SetActive(true);
      //  StartCoroutine(Powerdown_shield());
    }

    //IEnumerator Powerdown_shield()
    //   {
    // yield return new WaitForSeconds(5.0f);
    //  Sheild_VFX.SetActive(false);
    //  Shield_A = false;
    // }
    IEnumerator iframes()
    {
        sprite.enabled = false;
        collider1.enabled = false;
        collider2.enabled = false;
        yield return new WaitForSeconds(0.1f);
        sprite.enabled = true;
        yield return new WaitForSeconds(0.1f);
        sprite.enabled = false;
        yield return new WaitForSeconds(0.1f);
        sprite.enabled = true;
        yield return new WaitForSeconds(0.1f);
        sprite.enabled = false;
        yield return new WaitForSeconds(0.1f);
        sprite.enabled = true;
        yield return new WaitForSeconds(0.1f);
        sprite.enabled = false;
        yield return new WaitForSeconds(0.1f);
        sprite.enabled = true;
        yield return new WaitForSeconds(0.1f);
        sprite.enabled = false;
        yield return new WaitForSeconds(0.1f);
        sprite.enabled = true;
        yield return new WaitForSeconds(0.1f);
        sprite.enabled = false;
        yield return new WaitForSeconds(0.1f);
        sprite.enabled = true;
        collider1.enabled = true;
        collider2.enabled = true;
    }
    
    public void Damage()
    {
        if (Shield_A == false)
        {
            lives = lives - 1;
            StartCoroutine(iframes());
            if(lives == 2)
            {
                firedamage1.SetActive(true);
            }
            else if (lives == 1)
            {
                firedamage2.SetActive(true);
            }
            uimanager.UpdateLives(lives);
            if (lives < 1)
            {
                spawn_Manager.Player_Death();
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
        else
        {
            Sheild_VFX.SetActive(false);
            StartCoroutine(iframes());
            Shield_A = false;
        }
    }

    public void Add_Score(int points)
    {
        score = score + points;
        uimanager.UpdateScore(score);
    }
}

