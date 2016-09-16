/*************************************************************
 * Class Description:
 *      - This class is used for spawning monster to the scene.
 *      - Can be called via 'Run' function.
 *      - Currently called from GameController script.
 *************************************************************/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

    private Player player;

    [SerializeField]
    private Transform[] spawnPoints;


    [SerializeField]
    private Cat cat;
    [SerializeField]
    private JackO jackO;
    [SerializeField]
    private Robot robot;
    [SerializeField]
    private Shooter shooter;

    private int randNum;

    public void Run(int amount)
    {
        StartCoroutine("Spawn", amount);
    }

    //Spawn monster based on current level
    public IEnumerator Spawn(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            if (LevelManager.level <= 10)
            {
                Instantiate(cat, spawnPoints[Random.Range(0, 2)].position, spawnPoints[Random.Range(0, 2)].rotation);
                yield return new WaitForSeconds(Random.Range(1, 2));
            }
            else if (LevelManager.level <= 20)
            {
                randNum = Random.Range(1, 101);

                if (randNum <= 50)
                {
                    Instantiate(cat, spawnPoints[Random.Range(0, 2)].position, spawnPoints[Random.Range(0, 2)].rotation);
                    yield return new WaitForSeconds(Random.Range(1, 2));
                }
                else
                {
                    Instantiate(jackO, spawnPoints[Random.Range(0, 2)].position, spawnPoints[Random.Range(0, 2)].rotation);
                    yield return new WaitForSeconds(Random.Range(1, 2));
                }
            }
            else if (LevelManager.level <= 30)
            {
                randNum = Random.Range(1, 101);
                
                if (randNum <= 33)
                {
                    Instantiate(cat, spawnPoints[Random.Range(0, 2)].position, spawnPoints[Random.Range(0, 2)].rotation);
                    yield return new WaitForSeconds(Random.Range(1, 2));
                }
                else if(randNum <= 66)
                {
                    Instantiate(jackO, spawnPoints[Random.Range(0, 2)].position, spawnPoints[Random.Range(0, 2)].rotation);
                    yield return new WaitForSeconds(Random.Range(1, 2));
                }
                else
                {
                    Instantiate(robot, spawnPoints[Random.Range(0, 2)].position, spawnPoints[Random.Range(0, 2)].rotation);
                    yield return new WaitForSeconds(Random.Range(1, 2));
                }
            }
            else if (LevelManager.level <= 40)
            {
                randNum = Random.Range(1, 101);

                if (randNum <= 5)
                {
                    Instantiate(cat, spawnPoints[Random.Range(0, 2)].position, spawnPoints[Random.Range(0, 2)].rotation);
                    yield return new WaitForSeconds(Random.Range(1, 2));
                }
                else if (randNum <= 20)
                {
                    Instantiate(jackO, spawnPoints[Random.Range(0, 2)].position, spawnPoints[Random.Range(0, 2)].rotation);
                    yield return new WaitForSeconds(Random.Range(1, 2));
                }
                else if (randNum <= 60)
                {
                    Instantiate(robot, spawnPoints[Random.Range(0, 2)].position, spawnPoints[Random.Range(0, 2)].rotation);
                    yield return new WaitForSeconds(Random.Range(1, 2));
                }
                else
                {
                    Instantiate(shooter, spawnPoints[Random.Range(0, 2)].position, spawnPoints[Random.Range(0, 2)].rotation);
                    yield return new WaitForSeconds(Random.Range(1, 2));
                }
            }
            
        }
    }
}
