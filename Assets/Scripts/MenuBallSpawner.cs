using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBallSpawner : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;
    [SerializeField] float timeBetweenSpawns;
    [SerializeField] Vector3[] spawnPosArray;

    private void Start()
    {
        StartCoroutine(SpawnBallCoro());
    }

    IEnumerator SpawnBallCoro()
    {
        while (true)
        {
            Instantiate(ballPrefab, spawnPosArray[Random.Range(0, spawnPosArray.Length)], Quaternion.identity, transform);
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }
}
