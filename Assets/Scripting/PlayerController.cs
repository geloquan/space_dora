using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private float horizontalInput;
    private float verticalInput;
    private float moveSpeed = 5f;

    private PlayerObject instPlayerObject;
    void Start() {
        instPlayerObject = FindObjectOfType<PlayerObject>();

    }

    void Update() {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        if (horizontalInput != 0 || verticalInput != 0 ) {

            Vector3 moveDirection = new Vector3(horizontalInput, verticalInput, 0f).normalized;

            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, moveDirection);
            targetRotation = Quaternion.Euler(0, 0, targetRotation.eulerAngles.z); // Keep the z-axis rotation constant

            instPlayerObject.transform.rotation = Quaternion.RotateTowards(instPlayerObject.transform.rotation, targetRotation, 500f * Time.deltaTime);

            instPlayerObject.transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }
    }
}
