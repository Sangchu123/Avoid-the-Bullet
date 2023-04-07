using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody BRigidbody;

    void Start() {
        // 게임 오브젝트 rigidbody를 할당
        BRigidbody= GetComponent<Rigidbody>();
        // rigidbody의 속도 = 앞 방향 * 이동 속력
        BRigidbody.velocity = transform.forward*speed;

        // 3초 뒤 자신의 게임 오브젝트 파괴
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter(Collider other) {
        
        if (other.tag == "Player")
        {
            // PlayerController 찾아오기
            PlayerController playerController = other.GetComponent<PlayerController>();

            // playerController를 가져왔다면
            if (playerController != null) {

                // Die 메서드 실행
                playerController.Die();
            }
        }
    }
}
