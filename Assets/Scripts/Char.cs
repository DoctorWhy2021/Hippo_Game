using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char : MonoBehaviour
{
    public int speedEnemy;
    public int costEnemy;
    public Transform firePoint;
    [SerializeField] private GameObject enemy;
    private float respawnTime;
    private Material matBlink;

    private Material matDefault;
    private SpriteRenderer spriteRend;
    void Start()
    {
        respawnTime = 3f;
        spriteRend = GetComponent<SpriteRenderer>();

        matBlink = Resources.Load("EnemyBlink", typeof(Material)) as Material;
        matDefault = spriteRend.material;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            spriteRend.material = matBlink;
            Invoke("ResetMatterial", 0.1f);
        }

        if (collision.CompareTag("Respawn") && !enemy.GetComponent<enemy>().alive)
        { 
            Invoke("Respawn", 2f);
        }
    }

    public void ResetMatterial()
    {
        spriteRend.material = matDefault;
    }
    void Respawn()
    {
        enemy.GetComponent<enemy>().ChangeChar();
 
    }
}
