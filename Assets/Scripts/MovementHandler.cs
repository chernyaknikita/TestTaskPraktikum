using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    [SerializeField]
    float Speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.CompareTag("Trace"))
            {
                child.localScale = child.localScale * 0.9995f;
            }
            if (child.transform.localPosition.x < -10)
            {
                Destroy(child.gameObject);
            }
            else
            {
                child.Translate(Vector3.left * Speed * Time.deltaTime);
            }
            
        }
        
    }
}
