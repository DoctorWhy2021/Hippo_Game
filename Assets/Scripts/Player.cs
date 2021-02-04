using System;
using SimpleInputNamespace;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private float _moveSpeed;
    public static float _HP;
    [SerializeField]
    private Rigidbody2D _playerBody;
    [SerializeField]
    private GameObject _player;
   
    [SerializeField] 
    private Text textTimer;

    private float timeStart;
    [SerializeField]
    private GameObject youLose;

    public Joystick joyStickGo;
    public Joystick joyStickLook;
    private Material matBlink;
    float lastAngle;
    float _angle;
    private Material matDefault;
    [SerializeField]
    private SpriteRenderer spriteRend;
    Vector2 _movement;
    Vector2 _mousePosition;

    private void Start()
    {
        _moveSpeed = MainMenu.hipSpeed;
        _HP = 3f;
        youLose.SetActive(false);
        matBlink = Resources.Load("EnemyBlink", typeof(Material)) as Material;
        matDefault = spriteRend.material;
        timeStart = 0f;
        textTimer.text = timeStart.ToString(@"mm\:ss");
    }

    void Update()
    {
        if (!Global_Script.isPaused)
        {
            _movement.x = joyStickGo.xAxis.value;
            _movement.y = joyStickGo .yAxis.value;
            _mousePosition = joyStickLook.Value;
            timeStart += Time.deltaTime;
            String minutes = Mathf.Floor(timeStart / 60).ToString("00");
            String seconds = Mathf.RoundToInt(timeStart % 60).ToString("00");
            textTimer.text = String.Concat(minutes,":",seconds);
        }
    }

    void FixedUpdate()
    {
        if (!Global_Script.isPaused)
        {
            _playerBody.MovePosition(_playerBody.position + (_movement * _moveSpeed * Time.deltaTime));
            
            if (_mousePosition.x != 0 || _mousePosition.y != 0)
            {
                _angle = Mathf.Atan2(_mousePosition.y, _mousePosition.x) * Mathf.Rad2Deg - 90f;
                lastAngle = _angle;
            }
            else if(_mousePosition.x == 0 && _mousePosition.y == 0)
            {
                _angle = lastAngle;
            }
            _playerBody.rotation = _angle;
        }
    }


    public void TakeDamage(float _Damage)
    {
        _HP -= _Damage;
        
        if (_HP <= 0)
        {
            _player.SetActive(false);
            Global_Script.isPaused = true; 
            Invoke("YouLose", 0.3f);
        }
        else
        {
            Invoke("ResetMatterial", 0.1f);
        }
    }

    void YouLose()
    {
       youLose.SetActive(true);
    }

    void ResetMatterial()
    {
        spriteRend.material = matDefault;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            spriteRend.material = matBlink;
        }
    }
}
