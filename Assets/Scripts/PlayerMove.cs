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
    private float speed = 1f;

    private float timer = 0f;

    private Vector2 targetPosition = Vector2.zero;
    private GameManager gameManager = null;
    private SpriteRenderer spriteRenderer = null;
    private bool isDamaged = false;
    private float fireRate = 0.2f;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(Fire());
        StartCoroutine(Skill());
    }

    void Update()
    {
        timer += Time.deltaTime;
        
        if (Input.GetMouseButton(0))
        {
            targetPosition =
                Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.x = Mathf.Clamp(targetPosition.x,gameManager.MinPosition.x,gameManager.MaxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, gameManager.MinPosition.y, gameManager.MaxPosition.y);
            transform.localPosition =
            Vector2.MoveTowards(transform.localPosition,
            targetPosition, speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
                transform.Translate(Vector2.up * speed * Time.deltaTime);
                
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);

        }
        if(transform.localPosition.x > gameManager.MaxPosition.x)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        if(transform.localPosition.x < gameManager.MinPosition.x)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }
    private IEnumerator Fire()
    {
        GameObject bullet;
        while (true)
        {
            bullet = Instantiate(bulletPrefab, bulletPosition);
            bullet.transform.SetParent(null);
            yield return new WaitForSeconds(fireRate);
        }
    }
    private IEnumerator Skill()
    {
        while (true)
        {
            if (timer >= 3f)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    fireRate = 0.01f;
                    timer = 0f;
                }
            }
            yield return new WaitForSeconds(2f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDamaged) return;
        isDamaged = true;
        StartCoroutine(Damage());
    }

    private IEnumerator Damage()
    {

        gameManager.Dead();
        for (int i = 0; i < 4; i++)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
        isDamaged = false;
    }
}
