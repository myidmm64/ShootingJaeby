using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private Transform bulletPosition = null;
    [SerializeField]
    private GameObject bulletPrefab = null;
    [SerializeField]
    private float speed = 5f;
    private Vector2 targetPosition = Vector2.zero;
    private GameManager gameManager = null;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        StartCoroutine(Fire());
    }

    void Update()
    { 
        if (Input.GetMouseButton(0))
        {
            targetPosition =
                Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.localPosition =
            Vector2.MoveTowards(transform.localPosition,
            targetPosition, speed * Time.deltaTime);
        }
    }
    private IEnumerator Fire()
    {
        GameObject bullet;
        while (true)
        {
            bullet = Instantiate(bulletPrefab, bulletPosition);
            bullet.transform.SetParent(null);
            yield return new WaitForSeconds(0.2f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameManager.Dead();
    }
}
