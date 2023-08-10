using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float LifeTime = 0f;
    float AmpMin = 2f;
    float AmpMax = 5f;
    float Amp;
    float StartPos;
    // Start is called before the first frame update
    void Start()
    {
        Amp = Random.Range(AmpMin, AmpMax);
        StartPos = transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        LifeTime += Time.deltaTime;
        transform.Translate(Vector3.up * (Amp * Mathf.Sin(LifeTime) - (transform.localPosition.y - StartPos)));
    }
}
