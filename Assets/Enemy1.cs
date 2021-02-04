
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _HP;
    [SerializeField]
    private Rigidbody2D _enemyBody;
    [SerializeField]
    private GameObject _snowballPrefab;
    [SerializeField]
    private Transform _firePoint;
    [SerializeField]
    private float _snowballForce;
    [SerializeField]
    private GameObject char1, char2, char3;
    private int _charOn;

    public int cost;
    [SerializeField]
    private float respawnTime;
    public bool alive;
    private float _timeShot;
    [SerializeField]
    private GameObject _player;
    private Rigidbody2D _playerBody;
    private Material matBlink;

    private Material matDefault;
    private SpriteRenderer spriteRend;

    private void Start()
    {
        _HP = 1;
        alive = true;
        _timeShot = Random.Range(MainMenu.enemRecharge,MainMenu.enemRecharge+1);
        _playerBody = _player.GetComponent<Rigidbody2D>();
        spriteRend = GetComponent<SpriteRenderer>();

        matBlink = Resources.Load("EnemyBlink", typeof(Material)) as Material;
        matDefault = spriteRend.material;
        ChangeChar();
    }

    private void Update()
    {
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
            Vector2 _lookAtPlayer =_enemyBody.position - _playerBody.position;
            _enemyBody.rotation = Mathf.Atan2(-_lookAtPlayer.y, -_lookAtPlayer.x) * Mathf.Rad2Deg -90 ;
        }
    }


    void Shoot()
    {
        GameObject _snowball = Instantiate(_snowballPrefab, _firePoint.position, _firePoint.rotation);
        Rigidbody2D _snowballBody = _snowball.GetComponent<Rigidbody2D>();
        _snowballBody.AddForce(_firePoint.up* _snowballForce, ForceMode2D.Impulse);
        _timeShot = Random.Range(MainMenu.enemRecharge,MainMenu.enemRecharge+1);
    }
    public void TakeDamage(float _Damage)
    {
        _HP -= _Damage;
        if (_HP <= 0)
        {
            alive = false;
            // Invoke("ChangeChar",  respawnTime);
            
        }
        Invoke("ResetMatterial", 0.1f);
    }

    public void ResetMatterial()
    {
        spriteRend.material = matDefault;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            spriteRend.material = matBlink;
        }

        if (collision.CompareTag("Respawn"))
        {
            Invoke("ChangeChar",  respawnTime);
        }
    }

    void ChangeChar()
    {
        _charOn = Random.Range(1, 4);
        switch (_charOn)
        {
            case 3:
                char1.GetComponent<Enemy>().alive = false;
                char2.GetComponent<Enemy>().alive = false;
                char3.GetComponent<Enemy>().alive = true;
                char1.GetComponent<Enemy>()._HP = 0;
                char2.GetComponent<Enemy>()._HP = 0;
                char3.GetComponent<Enemy>()._HP = 1;
                char1.gameObject.SetActive(false);
                char2.gameObject.SetActive(false);
                char3.gameObject.SetActive(true);
                break;
            case 2:
                char1.GetComponent<Enemy>()._HP = 0;
                char2.GetComponent<Enemy>()._HP = 1;
                char3.GetComponent<Enemy>()._HP = 0;
                char1.GetComponent<Enemy>().alive = false;
                char2.GetComponent<Enemy>().alive = true;
                char3.GetComponent<Enemy>().alive = false;
                char1.gameObject.SetActive(false);
                char2.gameObject.SetActive(true);
                char3.gameObject.SetActive(false);
                break;
            case 1:
                char1.GetComponent<Enemy>()._HP = 1;
                char2.GetComponent<Enemy>()._HP = 0;
                char3.GetComponent<Enemy>()._HP = 0;
                char1.GetComponent<Enemy>().alive = true;
                char2.GetComponent<Enemy>().alive = false;
                char3.GetComponent<Enemy>().alive = false;
                char1.gameObject.SetActive(true);
                char2.gameObject.SetActive(false);
                char3.gameObject.SetActive(false);
                break;
        }
        
    }
}
