using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField]
    public GameObject[] chars;

    public int chousenChar;
    [SerializeField]
    private GameObject _snowballPrefab;
    
    private Transform _firePoint;
    [SerializeField]
    private float _snowballForce;

    private int hp;
    public float _timeShot;

    public bool alive;
    
    [SerializeField]
    private GameObject _player;
    private Rigidbody2D _playerBody;
    // Start is called before the first frame update
    void Start()
    {
        hp = 1;
        alive = true;
        _timeShot = Random.Range(MainMenu.enemRecharge,MainMenu.enemRecharge+1);
        _playerBody = _player.GetComponent<Rigidbody2D>();
        ChangeChar();
    }

    // Update is called once per frame
    void Update()
    {
        _firePoint = chars[chousenChar].GetComponent<Char>().firePoint;
        gameObject.GetComponent<CircleCollider2D>().radius = chars[chousenChar].GetComponent<CircleCollider2D>().radius;
        gameObject.GetComponent<CircleCollider2D>().offset = chars[chousenChar].GetComponent<CircleCollider2D>().offset;
        if (!Global_Script.isPaused)
        {
            
            if (_timeShot <= 0 && alive)
            {
                Shoot();
            }

            if (_timeShot > 0)
            {
                _timeShot -= Time.deltaTime;
            }
            Vector2 _lookAtPlayer =chars[chousenChar].GetComponent<Rigidbody2D>().position - _playerBody.position;
            chars[chousenChar].GetComponent<Rigidbody2D>().rotation = Mathf.Atan2(-_lookAtPlayer.y, -_lookAtPlayer.x) * Mathf.Rad2Deg -90 ;
        }
    }
    
    void Shoot()
    {
        GameObject _snowball = Instantiate(_snowballPrefab, _firePoint.position, _firePoint.rotation);
        Rigidbody2D _snowballBody = _snowball.GetComponent<Rigidbody2D>();
        _snowballBody.AddForce(_firePoint.up* _snowballForce, ForceMode2D.Impulse);
        _timeShot = Random.Range(MainMenu.enemRecharge,MainMenu.enemRecharge+1);
    }

    public void TakeDamage(int _Damage)
    {
        hp -= _Damage;
        if (hp <= 0)
        {
            alive = false;
        }
    }

    
    
    public void ChangeChar()
    {
        alive = true;
        chousenChar = Random.Range(0, 3);
        switch (chousenChar)
        {
            case 0:
                chars[0].SetActive(true);
                chars[1].SetActive(false);
                chars[2].SetActive(false);
                break;
            case 1:
                chars[0].SetActive(false);
                chars[1].SetActive(true);
                chars[2].SetActive(false);
                break;
            case 2:
                chars[0].SetActive(false);
                chars[1].SetActive(false);
                chars[2].SetActive(true);
                break;
        }
        
    }
}
