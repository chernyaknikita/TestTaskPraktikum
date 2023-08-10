using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reward : MonoBehaviour
{
    public bool IsFollow = false;
    Vector3 FollowPos;
    Vector3 StartPos;
    float TimeToFollow = 0.5f;
    float FollowTime = 0;

    // Update is called once per frame
    void Update()
    {
        if (IsFollow)
        {   
            if (FollowTime <= TimeToFollow)
            {
                FollowTime += Time.deltaTime;
                transform.position = Vector3.Lerp(StartPos, FollowPos, FollowTime / TimeToFollow);
                
            }
            else
            {
                Destroy(this.gameObject);
            }
            
        }
        if (transform.localPosition.x < -10)
        {
            Destroy(this.gameObject);
        }
    }

    public void Follow(Vector3 NewFollowPos)
    {
        GetComponent<Collider2D>().enabled = false;
        StartPos = transform.position;
        FollowPos = NewFollowPos;
        IsFollow = true;
    }
}
