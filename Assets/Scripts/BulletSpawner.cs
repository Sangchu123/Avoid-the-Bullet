using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour {

    public GameObject bulletPerfab;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3f;

    private Transform target;
    private float spawnRate;
    private float timeAfterSpawn;

    void Start()
    {
        // 최근 생성 이후 누적시간 초기화
        timeAfterSpawn = 0f;
        // 생성 주기 랜덤 조정
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        // PlayerController 컴포넌트 가진 오브젝트 조준
        target = FindObjectOfType<PlayerController>().transform;
    }

    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if (timeAfterSpawn >= spawnRate) {

            timeAfterSpawn = 0f;

            GameObject bullet = Instantiate(bulletPerfab, transform.position, transform.rotation);
            bullet.transform.LookAt(target);
            spawnRate = Random.Range(spawnRateMin,spawnRateMax);
        }

    }
}
