using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    GameObject ObjectsStatic;
    [SerializeField]
    float PlayerSpeed = 1f;
    [SerializeField]
    Vector3 PlayerStartPos;
    public delegate void CollidedWithEnemy();
    public CollidedWithEnemy collidedWithEnemy;
    public delegate void CollidedWithReward();
    public CollidedWithEnemy collidedWithReward;


    public void Move(int Direction)
    {
        transform.Translate(Vector3.up * Direction * PlayerSpeed * Time.deltaTime);
        
    }

    public void ResetPos()
    {
        transform.localPosition = PlayerStartPos;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Enemy"))
        {
            collidedWithEnemy();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Reward"))
        {
            collidedWithReward();
            other.gameObject.transform.SetParent(ObjectsStatic.transform, true);
            other.gameObject.GetComponent<Reward>().Follow(transform.position);
        }
    }
}
