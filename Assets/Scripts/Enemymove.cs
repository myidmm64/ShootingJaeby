using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymove : MonoBehaviour
{
    [SerializeField]
    private int hp = 2;
    [SerializeField]
    protected float speed = 20f;
    [SerializeField]
    private long score = 10000;

    protected GameManager gameManager = null;
    private Animator animator = null;
    private Collider2D col = null;
    protected bool isDead = false;
    bool isDamaged = false;
    private SpriteRenderer spriteRenderer = null;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameManager = FindObjectOfType<GameManager>();
        animator = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {

        if (isDead) return;
        Move();
        CheckLimit();
    }
    protected virtual void Move()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
    private void CheckLimit()
    {
        if (transform.localPosition.y < gameManager.MinPosition.y-5f)
        {
            Destroy(gameObject);
        }
        if (transform.localPosition.y > gameManager.MaxPosition.y +10f)
        {
            Destroy(gameObject);
        }
        if (transform.localPosition.x < gameManager.MinPosition.x-5f)
        {
            Destroy(gameObject);
        }
        if (transform.localPosition.x > gameManager.MaxPosition.x + 5f)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)   //영역 안에 들어왔을 때 실행
    {
        if (isDead) return;

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
        
            if (isDead) return;
            isDead = true;
            gameManager.AddScore(score);
            StartCoroutine(ShowDeadAnimation());

        }
    }
    private IEnumerator Damaged()
    {
        col.enabled = false;
        hp--;
        spriteRenderer.material.SetColor("_Color",new Color(15f,10f,10f,100f));
        yield return new WaitForSeconds(0.1f);
        col.enabled = true;
        spriteRenderer.material.SetColor("_Color", new Color(0f, 0f, 0f, 0f));
        isDamaged = false;
    }
    private IEnumerator ShowDeadAnimation()
    {
        animator.Play("Explosion");
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
