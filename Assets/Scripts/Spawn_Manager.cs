using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject EnemyPrefub;
    [SerializeField]
    private GameObject Enemy_container;
    [SerializeField]
    private GameObject[] PowerUpsPrefabs;
    [SerializeField]
    private int max_enemies = 1;
    private bool player_is_alive = true;
    
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void startspawning()
    {
        StartCoroutine(SpawnPowerUP());
        StartCoroutine(SpawnRoutine());
    }
    

    IEnumerator SpawnRoutine()
    {
        yield return new WaitForSeconds(1.0f);
        while (player_is_alive == true)
        {
                for (int enemynum = 0; enemynum < max_enemies; enemynum += 1)
                {
                    GameObject newEnemy = Instantiate(EnemyPrefub, new Vector3(Random.Range(-9.8f, 9.8f), Random.Range(10f, 12f), 0), Quaternion.identity);
                    newEnemy.transform.parent = Enemy_container.transform;
                }
                
            yield return new WaitForSeconds(5.0f);            
        }
    }

    IEnumerator SpawnPowerUP()
    {
        yield return new WaitForSeconds(1.0f);
        while (player_is_alive == true)
        {
           int randompowerup = Random.Range(0,3);
           Instantiate(PowerUpsPrefabs[randompowerup], new Vector3(Random.Range(-9.8f, 9.8f), Random.Range(10f, 12f), 0), Quaternion.identity);
           yield return new WaitForSeconds(Random.Range(3.0f,7.0f));
        }
    }



    public void Player_Death()
    {
        player_is_alive = false;
    }
}
