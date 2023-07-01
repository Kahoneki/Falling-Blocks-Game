using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    float screenHalfHeightInWorldUnits;
    float halfBulletHeight;

    float minBulletWidth = 0.2f;
    float maxBulletWidth = .6f;
    float bulletAspectRatio;

    void Start()
    {
        speed = 10;
        screenHalfHeightInWorldUnits = Camera.main.orthographicSize;
        halfBulletHeight = transform.localScale.y / 2f;
        bulletAspectRatio = transform.localScale.x / transform.localScale.y;

        float randomWidth = Random.Range(minBulletWidth, maxBulletWidth);
        float height = randomWidth / bulletAspectRatio;

        float randomAngle = Random.Range(-35,35);

        transform.localScale = new Vector3(randomWidth,height,0);
        transform.rotation = Quaternion.Euler(0,0,randomAngle);
    }

    void Update()
    {
        //Off-screen check
        if (transform.position.y <= -(screenHalfHeightInWorldUnits + halfBulletHeight))
            Destroy(gameObject);
        
        transform.Translate(Vector3.down*speed*Time.deltaTime);
    }
}
