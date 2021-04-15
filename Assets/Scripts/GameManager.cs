using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Text textScore = null;
    [SerializeField]
    private Text textLife = null;
    [SerializeField]
    private GameObject enemyCroissantPrefab = null;
    [SerializeField]
    private int life = 3;

    public Vector2 MinPosition { get; private set;}
    public Vector2 MaxPosition { get; private set;}

    private long score = 0;
    void Start()
    {
        MinPosition = new Vector2(-7f, -12f);
        MaxPosition = new Vector2(7f, 12f);
        StartCoroutine(SpawnCroissant());
    }

    public void AddScore(long addSccore)
    {
        score += addSccore;
        UpdateUI();
    }

    public void UpdateUI()
    {
        textScore.text = string.Format("SCORE\n{0}", score);
        textLife.text = string.Format("Life\n{0}", life);
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
            spawnDelay = Random.Range(0.5f, 1f);
            randomX = Random.Range(-7f, 7f);
            for (int i = 0; i < Random.Range(1,3); i++)
            {
                Instantiate(enemyCroissantPrefab, new Vector2(randomX, 20f), Quaternion.identity);
                yield return new WaitForSeconds(0.5f);
            }
            yield return new WaitForSeconds(spawnDelay);
            
        }
    }
}
