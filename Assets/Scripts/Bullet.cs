using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody BRigidbody;

    void Start() {
        // ���� ������Ʈ rigidbody�� �Ҵ�
        BRigidbody= GetComponent<Rigidbody>();
        // rigidbody�� �ӵ� = �� ���� * �̵� �ӷ�
        BRigidbody.velocity = transform.forward*speed;

        // 3�� �� �ڽ��� ���� ������Ʈ �ı�
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter(Collider other) {
        
        if (other.tag == "Player")
        {
            // PlayerController ã�ƿ���
            PlayerController playerController = other.GetComponent<PlayerController>();

            // playerController�� �����Դٸ�
            if (playerController != null) {

                // Die �޼��� ����
                playerController.Die();
            }
        }
    }
}
