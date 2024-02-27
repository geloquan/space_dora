using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour {
    private float horizontalInput;
    private float verticalInput;
    private float moveSpeed = 5f;
    private bool is_moving;
    private Vector2 input;

    private PlayerObject instPlayerObject;
    void Start() {
        instPlayerObject = FindObjectOfType<PlayerObject>();
    }

    void Update() {
        if (!is_moving) {
            input.x = Input.GetAxis("Horizontal");
            input.y = Input.GetAxis("Vertical");
            if (input != Vector2.zero) {
                var target_position = transform.position;
                target_position.x += input.x;
                target_position.y += input.y;
                StartCoroutine(Move(target_position));
            }

        }
        //horizontalInput = Input.GetAxis("Horizontal");
        //verticalInput = Input.GetAxis("Vertical");
        //
        //if (horizontalInput != 0 || verticalInput != 0) {
        //    Vector3 moveDirection = new Vector3(horizontalInput, verticalInput, 0f).normalized;
        //
        //    Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, moveDirection);
        //    targetRotation = Quaternion.Euler(0, 0, targetRotation.eulerAngles.z); // Keep the z-axis rotation constant
        //
        //    instPlayerObject.Move(moveDirection, targetRotation, new Vector2(horizontalInput, verticalInput));
        //}
    }
    IEnumerator Move(Vector3 target_position) {
        is_moving = true;
        while ((target_position - transform.position).sqrMagnitude > Mathf.Epsilon) {
            transform.position = Vector3.MoveTowards(transform.position, target_position, moveSpeed * Time.deltaTime);
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, target_position);
            targetRotation = Quaternion.Euler(0, 0, targetRotation.eulerAngles.z);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 5000000f * Time.deltaTime);
            yield return null;
        }
        transform.position = target_position;

        is_moving = false;
    }
}
