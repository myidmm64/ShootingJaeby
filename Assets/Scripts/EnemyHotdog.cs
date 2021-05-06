using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHotdog : Enemymove
{
    [SerializeField]
    private GameObject bulletPrefeb = null;
    [SerializeField]
    private float fireRate = 0.05f;
    private GameObject newBullet = null;
    private float timer =0f;
    private Vector2 diff = Vector2.zero;
    private float rotationZ = 0f;
    protected override void Move()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        timer += Time.deltaTime;

        if(transform.localPosition.x < gameManager.MinPosition.x-2f)
        {
            Destroy(gameObject);
        }
        if(timer >= fireRate)
        {
            timer = 0f;
            newBullet = Instantiate(bulletPrefeb, transform);
            diff = gameManager.Player.transform.position - transform.position;
            diff.Normalize();

            rotationZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            newBullet.transform.rotation = Quaternion.Euler(0f,0f,rotationZ - 90f);
            newBullet.transform.SetParent(null);
        }
    }
}

