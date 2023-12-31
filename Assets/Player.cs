using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public event System.Action OnPlayerDeath;

    public float speed = 10;

    float screenHalfWidthInWorldUnits;
    float halfPlayerWidth;

    void Start()
    {
        halfPlayerWidth = transform.localScale.x / 2f;
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize;
    }

    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float velocity = inputX*speed;
        transform.Translate(Vector2.right * velocity * Time.deltaTime);

        if (transform.position.x < -screenHalfWidthInWorldUnits - halfPlayerWidth)
            transform.position = new Vector2(screenHalfWidthInWorldUnits, transform.position.y);
        else if (transform.position.x > screenHalfWidthInWorldUnits + halfPlayerWidth)
            transform.position = new Vector2(-screenHalfWidthInWorldUnits, transform.position.y);
    }

    void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Bullet")
        {
            if (OnPlayerDeath != null)
                OnPlayerDeath();
            Destroy(gameObject);
        }
    }
}
