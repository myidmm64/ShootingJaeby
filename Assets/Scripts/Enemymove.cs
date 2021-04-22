using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymove : MonoBehaviour
{
    [SerializeField]
    private int hp = 2;
    [SerializeField]
    private float speed = 20f;
    [SerializeField]
    private long score = 10000;

    private GameManager gameManager = null;

    private bool isDamaged = false;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>(); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        if (transform.localPosition.y < gameManager.MinPosition.y)
        {
            gameManager.Dead();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)   //영역 안에 들어왔을 때 실행
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            if (hp > 1)
            {
                if (isDamaged) return;   //이 조건을 하면 리턴해서 밑에거 실행 안함 (break랑 비슷)
                isDamaged = true;
                StartCoroutine(Damaged());
                return;
            }

            gameManager.AddScore(score); 
            Destroy(gameObject);

        }
    }
    private IEnumerator Damaged()
    {
        hp--;
        yield return new WaitForSeconds(0.1f);
        isDamaged = false;
    }
}
