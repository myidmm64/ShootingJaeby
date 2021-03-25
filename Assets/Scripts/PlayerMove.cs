using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    private Vector2 targetPosition = Vector2.zero;


    void Start()
    {
        
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
}
