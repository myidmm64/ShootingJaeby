using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyCroissantPrefab = null;
   
    void Start()
    {
        StartCoroutine(SpawnCroissant());
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
