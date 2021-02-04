using UnityEngine;
using UnityEngine.UI;

public class Global_Script : MonoBehaviour
{
    [SerializeField]
    private Sprite fullLife;
    [SerializeField]
    private Sprite emptyLife;
    [SerializeField]
    private Image[] lives;
    [SerializeField]
    private GameObject[] stars;
    [SerializeField]
    private GameObject youWin;
    [SerializeField]
    private Text scoreText;
    private int totalScore;
   
    
    public static bool isPaused;
    public static int scorePoint;
    // public GameObject _enemyPrefab;

    // public GameObject[] _spawn_point;
    // private int _rnd_value = 0;
    // Start is called before the first frame update
    // void Start()
    // {
    //     _spawn_point = GameObject.FindGameObjectsWithTag("Spawn Point");
    //     _rnd_value = Random.Range(0, 3);
    //     Instantiate(_enemyPrefab, _spawn_point[_rnd_value].transform.position, _spawn_point[_rnd_value].transform.rotation);
    // }

    private void Start()
    {
        isPaused = false;
        scorePoint = 0;
        if (scoreText != null && youWin != null)
        { 
            scoreText.text = "00:00";
            youWin.SetActive(false);
            totalScore = MainMenu.score;
            
        }
    }

    private void Update()
    {

        if (scoreText != null)
        {
            scoreText.text = scorePoint.ToString();
        }
        for (int i = 0; i < lives.Length; i++)
        {
            if (i < Player._HP)
            {
                lives[i].sprite = fullLife;
            }
            else
            {
                lives[i].sprite = emptyLife;
            }
        }

        if (youWin != null)
        {
            if (scorePoint >= totalScore)
            {
                youWin.SetActive(true);
                isPaused = true;
                for (int i = 0; i < lives.Length; i++)
                {
                    if (i < Player._HP)
                    {
                        stars[i].SetActive(true);
                    }
                    else
                    {
                        stars[i].SetActive(false);
                    }
                }
            }
        }
    }


   
}
