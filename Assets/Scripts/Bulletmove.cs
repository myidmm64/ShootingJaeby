using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletmove : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;

    private GameManager gamemanager = null;
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);//Ư�� �������� Ʈ�������� �̵�
        if (transform.localPosition.y > gamemanager.MaxPosition.y +2f)
        {
            Destroy(gameObject);
        }
    }
}
