using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody PRigidbody; // 컴포넌트
    public float speed = 9f; // 속도

    void Start() {
        PRigidbody= GetComponent<Rigidbody>();
    }

    void Update() {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = speed * xInput;
        float zSpeed = speed * zInput;

        Vector3 newVelocity = new Vector3(xSpeed, 0f ,zSpeed);

        PRigidbody.velocity = newVelocity;
    }

    public void Die() {
        gameObject.SetActive(false);

        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.EndGame();
    }
}
