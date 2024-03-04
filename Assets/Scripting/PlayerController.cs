using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerController : MonoBehaviour {
    private float horizontalInput;
    private float verticalInput;
    private float moveSpeed = 5f;
    private bool is_moving;
    private Vector2 input;
    private Animator animator;  
    private PlayerObject instPlayerObject;

    private float playerObjectMinX;
    private float playerObjectMaxX;
    private float playerObjectMinY;
    private float playerObjectMaxY;

    private float playerObjectClampX;
    private float playerObjectClampY;

    private void Awake() {
        animator = GetComponent<Animator>();
    }
    void Start() {
        instPlayerObject = FindObjectOfType<PlayerObject>();
        playerObjectMinX = instPlayerObject.minX;
        playerObjectMaxX = instPlayerObject.maxX;
        playerObjectMinY = instPlayerObject.minY;
        playerObjectMaxY = instPlayerObject.maxY;
    }

    void Update() {
        if (!is_moving) {
            input.x = Input.GetAxis("Horizontal");
            input.y = Input.GetAxis("Vertical");

            animator.SetFloat("Blend", Mathf.Abs(input.x) + Mathf.Abs(input.y));
            if (input != Vector2.zero) {
                var target_position = transform.position;
                target_position.x += input.x;
                target_position.y += input.y;
                RotateTowards(target_position);
                StartCoroutine(Move(target_position));
            }

        }
    }
    private void RotateTowards(Vector3 targetPosition) {
        Vector3 direction = targetPosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    IEnumerator Move(Vector3 target_position) {
        is_moving = true;
        while ((target_position - transform.position).sqrMagnitude > Mathf.Epsilon) {
            playerObjectClampX = Mathf.Clamp(transform.position.x, playerObjectMinX, playerObjectMaxX);
            playerObjectClampY = Mathf.Clamp(transform.position.y, playerObjectMinX, playerObjectMaxX);
            Vector3 move_to = new Vector3(playerObjectClampX, playerObjectClampY, 0f);
            transform.position = Vector3.MoveTowards(move_to, target_position, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = target_position;

        is_moving = false;
    }
}
