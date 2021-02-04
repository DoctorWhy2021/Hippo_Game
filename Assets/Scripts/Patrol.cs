using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    private float speed;
    private float waitTime;
    [SerializeField] private Transform[] patrolSpots;
    [SerializeField] private Transform[] respawnSpots;

    [SerializeField] private int respawmSpot;
    private int _randomSpot;
    private float _time_on_spot;
    private enemy enemy;

    void Start()
    {
        _randomSpot = Random.Range(0, patrolSpots.Length);
        enemy = GetComponent<enemy>();
    }

    void Update()
    {
        speed = enemy.chars[enemy.chousenChar].GetComponent<Char>().speedEnemy;

        // for (int i = 0; i < respawnSpots.Length - 1; i++)
        // {
        //     if (Vector2.Distance(transform.position, respawnSpots[i].position) >
        //         Vector2.Distance(transform.position, respawnSpots[i + 1].position))
        //     {
        //         respawmSpot = i+1;
        //     }
        // }
        if (!Global_Script.isPaused)
        {
            switch (enemy.alive)
            {
                case true:
                    transform.position =
                        Vector2.MoveTowards(transform.position, patrolSpots[_randomSpot].position,
                            speed * Time.deltaTime);

                    if (Vector2.Distance(transform.position, patrolSpots[_randomSpot].position) < 0.2f)
                    {

                        if (waitTime <= 0)
                        {
                            _randomSpot = Random.Range(0, patrolSpots.Length);
                            waitTime = Random.Range(1, 10);
                        }
                        else
                        {
                            waitTime -= Time.deltaTime;
                        }
                    }
                break;
                case false:
                    transform.position =
                        Vector2.MoveTowards(transform.position, respawnSpots[1].position, speed * Time.deltaTime);
                    break;
            }
        }
    }
}
