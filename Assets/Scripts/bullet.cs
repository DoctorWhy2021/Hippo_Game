using UnityEngine;
using UnityEngine.UI;

public class bullet : MonoBehaviour
{

    private int _Damage;
    private Object explotion;
    private Rigidbody2D _snowBody;
    
    // Start is called before the first frame update

    private void Start()
    {
        _Damage = 1;
        explotion = Resources.Load("Explotion");
        _snowBody = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Global_Script.isPaused)
        {
            _snowBody.Sleep();
        }
        if (_snowBody.IsSleeping())
        {
            _snowBody.WakeUp();
        }
        if (!Global_Script.isPaused)
        {
            if (_snowBody.velocity.magnitude < 2)
            {
                DestroySnowBall();
            }
        }
       
        
    }

    void OnTriggerEnter2D(Collider2D _collision)
    {
        if (_collision.CompareTag("Enemy"))
        {

            enemy _enemy = _collision.GetComponent<enemy>();
                _enemy.TakeDamage(_Damage);
                Global_Script.scorePoint += _enemy.chars[_enemy.chousenChar].GetComponent<Char>().costEnemy;
                DestroySnowBall();
      
        }
        if (_collision.CompareTag("Player"))
        {
            Player _player = _collision.GetComponent<Player>();
                _player.TakeDamage(_Damage);
                DestroySnowBall();
        }
        
       
    }

    void DestroySnowBall()
    {
        GameObject explotionRef = (GameObject) Instantiate(explotion);
        explotionRef.transform.position =
            new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Destroy(gameObject);
        
    }

    
}
