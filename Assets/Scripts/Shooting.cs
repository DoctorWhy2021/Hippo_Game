using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    private Image snowTimer;
    [SerializeField]
    private Image _powerBar;
    [SerializeField]
    private Transform _firePoint;
    [SerializeField]
    private GameObject _bulletPrefab;
    [SerializeField]
    private float _bulletForce;

    private float fillPower;
    public float offsetShot;
    private float snowVelocity;
   
    private enum State
    {
        Increasing,
        Decreacing
    }

    State StateBar = State.Increasing;


    void Start()
    {
        fillPower = 0f;
        offsetShot = MainMenu.recTime;
        snowTimer.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Global_Script.isPaused)
        {

            if (Input.GetButtonDown("Fire1") && offsetShot <= 0)
            {
                Shoot();
            }

            if (offsetShot > 0)
            {
                offsetShot -= Time.deltaTime;
                snowTimer.fillAmount += Time.deltaTime / MainMenu.recTime;
            }

            if (fillPower <= 1f && StateBar == State.Increasing)
            {
                fillPower += Time.deltaTime / 2;
                _powerBar.fillAmount = fillPower;
            }
            else
            {
                StateBar = State.Decreacing;

            }

            if (StateBar == State.Decreacing)
            {
                if (fillPower > 0)
                {
                    fillPower -= Time.deltaTime / 2;
                    _powerBar.fillAmount = fillPower;
                }
                else
                {
                    StateBar = State.Increasing;
                }
            }
        }
    }

    void Shoot()
    {
        GameObject _bullet = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
        Rigidbody2D _bulletBody = _bullet.GetComponent<Rigidbody2D>();
        _bulletBody.AddForce(_firePoint.up * _bulletForce * fillPower, ForceMode2D.Impulse);
        offsetShot = MainMenu.recTime;
        snowTimer.fillAmount = 0f;
    }

}
