using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public PlayerMove Player { get; private set; }

    [SerializeField]
    private Text textScore = null;
    [SerializeField]
    private Text textLife = null;
    [SerializeField]
    private Text textHighScore = null;
    [SerializeField]
    private GameObject enemyCroissantPrefab = null;
    [SerializeField]
    private int life = 3;
    [SerializeField]
    private GameObject enemyHogdogPrefab = null;

    public Vector2 MinPosition { get; private set;}
    public Vector2 MaxPosition { get; private set;}

    private long score = 0;
    private long highsScore = 0;
    void Start()
    {
        Player = FindObjectOfType<PlayerMove>();
        MinPosition = new Vector2(-7f, -12f);
        MaxPosition = new Vector2(7f, 12f);
        StartCoroutine(SpawnCroissant());
        StartCoroutine(SpawnHotdog());
        highsScore = PlayerPrefs.GetInt("HIGHSCORE",500);
        UpdateUI();
    }

    public void AddScore(long addSccore)
    {
        score += addSccore;
        if(score > highsScore)
        {
            highsScore = score;
            PlayerPrefs.SetInt("HIGHSCORE",(int)highsScore);
        }
        UpdateUI();
    }

    public void UpdateUI()
    {
        textScore.text = string.Format("SCORE\n{0}", score);
        textLife.text = string.Format("Life\n{0}", life);
        textHighScore.text = string.Format("HIGHSCORE\n{0}", highsScore);
    }
    public void Dead()
    {
        life--;
        UpdateUI();
        if (life <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

  

    private IEnumerator SpawnCroissant()
    {
        float spawnDelay = 0f;
        float randomX = 0f;

        while (true)
        {
            spawnDelay = Random.Range(0.3f, 0.4f);
            randomX = Random.Range(-7f, 7f);
            for (int i = 0; i < Random.Range(3,4); i++)
            {
                Instantiate(enemyCroissantPrefab, new Vector2(randomX, 20f), Quaternion.identity);
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(spawnDelay);
            
        }
    }
    private IEnumerator SpawnHotdog()
    {
        float spawnDelay = 0f;
        float randomY = 0f;

        while (true)
        {
            spawnDelay = Random.Range(0.3f, 0.4f);
            randomY = Random.Range(MaxPosition.y-2f, MaxPosition.y);
            for (int i = 0; i < Random.Range(2, 3); i++)
            {
                Instantiate(enemyHogdogPrefab, new Vector2(MaxPosition.x, randomY), Quaternion.identity);
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(spawnDelay);

        }
    }
}
