using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankgroundMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.5f;

    private MeshRenderer meshRenderer = null;
    private Vector2 offset = Vector2.zero;


    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (meshRenderer == null) return;
        offset.y += speed * Time.deltaTime;
        meshRenderer.material.SetTextureOffset("_MainTex",offset);
    }
}
