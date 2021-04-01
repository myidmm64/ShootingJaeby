using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymove : MonoBehaviour
{
    [SerializeField]
    private int hp = 2;
    [SerializeField]
    private float speed = 3f;

    private bool isDamaged = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)   //영역 안에 들어왔을 때 실행
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            if (hp > 1)
            {
                if (isDamaged) return;
                isDamaged = true;
                StartCoroutine(Damaged());
                return;
            }
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
