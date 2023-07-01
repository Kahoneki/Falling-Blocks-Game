using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public float startDelay;
    public float maxDelay;
    public float delayDecreasePerInvoke;
    int numberOfInvokes;
    public GameObject bullet;

    float screenHalfWidthInWorldUnits;
    float screenHeightInWorldUnits;

    void Start()
    {
        startDelay = 0.5f;
        maxDelay = 0.15f;
        delayDecreasePerInvoke = 0.005f;
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize;
        screenHeightInWorldUnits = Camera.main.orthographicSize*2;
        Invoke("GenerateBullet", startDelay);
    }

    void GenerateBullet()
    {
        numberOfInvokes++;
        float randX = Random.Range(-screenHalfWidthInWorldUnits, screenHalfWidthInWorldUnits);
        Vector3 instantiatePosition = new Vector3(randX, screenHeightInWorldUnits, transform.position.z);
        GameObject currentBullet = (GameObject)Instantiate(bullet, instantiatePosition, transform.rotation);
        currentBullet.transform.parent = transform;
        Invoke("GenerateBullet", CalculateDelay(startDelay,maxDelay,delayDecreasePerInvoke,numberOfInvokes));
    }

    float CalculateDelay(float startDelay, float maxDelay, float delayDecreasePerInvoke, int numberOfInvokes)
    {
        float delay = startDelay - (delayDecreasePerInvoke * numberOfInvokes);
        print(delay);
        if (delay < maxDelay)
            delay = maxDelay;
        return delay;
    }
}
