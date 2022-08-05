using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] PlatformPrefabs;
    public GameObject FirstPlatformPrefab;
    public int MinPlatform;
    public int MaxPlatform;
    public float DistanseBetweenPlatforms;
    public Transform parent;
    public Transform finishPlatform;
    public Transform CylinderRoot;
    public Game Game;

    private void Awake()
    {
        int levelIndex = Game.LevelIndex;
        int PlatformCounts = Random.Range(MinPlatform + levelIndex, MaxPlatform + levelIndex + 1);

        for(int i = 0; i < PlatformCounts; i++)
        {
            int PrefabIndex = Random.Range(0, PlatformPrefabs.Length);
            GameObject platfromPrefab = i == 0 ? FirstPlatformPrefab : PlatformPrefabs[PrefabIndex];
            GameObject platform = Instantiate(platfromPrefab, transform);
            platform.transform.SetParent(parent);
            platform.transform.localPosition = CalculatePlatformPosition(i);
            if(i > 0)
                platform.transform.localRotation = Quaternion.Euler(0, Random.Range(0, 360f), 0);
        }

        finishPlatform.localPosition = CalculatePlatformPosition(PlatformCounts);
        CylinderRoot.transform.localScale = new Vector3(1, PlatformCounts * DistanseBetweenPlatforms / 2 + 1, 1);
        CylinderRoot.transform.localPosition = new Vector3(0, PlatformCounts * DistanseBetweenPlatforms / -4 + 1, 0);
    }

    private Vector3 CalculatePlatformPosition(int platformIndex)
    {
         return new Vector3(0, -DistanseBetweenPlatforms * platformIndex, 0);
    }
}
