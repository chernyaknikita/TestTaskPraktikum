using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spamer : MonoBehaviour
{
    [SerializeField]
    float SpawnWidth = 1;
    [SerializeField]
    float SpawnHeight = 4;
    [SerializeField]
    int SpawnQuantity = 2;
    [SerializeField]
    float SpawnTime = 4;
    float TimeLeft = 0;
    [SerializeField]
    GameObject SpawnField;
    [SerializeField]
    GameObject EnemyPrefab;
    [SerializeField]
    GameObject RewardPrefab;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TimeLeft -= Time.deltaTime;
        if (TimeLeft < 0)
        {
            Spawn();
            TimeLeft = SpawnTime;
        }
    }

    void Spawn()
    {
        int n = Random.Range(1, SpawnQuantity + 1);
        for (int i = 0; i < n; i++)
        {
            GameObject newEnemy = Instantiate(EnemyPrefab);
            newEnemy.transform.SetParent(SpawnField.transform, true);
            newEnemy.transform.position = new Vector3(
                transform.position.x + Random.Range(-SpawnWidth, SpawnWidth),
                transform.position.y + Random.Range(-SpawnHeight, SpawnHeight),
                0
            ); 
        }
        GameObject newReward = Instantiate(RewardPrefab);
        newReward.transform.SetParent(SpawnField.transform, true);
        newReward.transform.position = new Vector3(
            transform.position.x + Random.Range(-SpawnWidth * 2, SpawnWidth * 2),
            transform.position.y + Random.Range(-SpawnHeight / 2, SpawnHeight / 2),
            0
        );
    }
}
