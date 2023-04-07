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
        // �ֱ� ���� ���� �����ð� �ʱ�ȭ
        timeAfterSpawn = 0f;
        // ���� �ֱ� ���� ����
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        // PlayerController ������Ʈ ���� ������Ʈ ����
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
