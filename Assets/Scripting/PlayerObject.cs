using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerObject : MonoBehaviour {
    private SpaceObject instSpaceObject;
    public SpriteRenderer spriteRenderer;

    public Transform transform_;
    public Vector3 current_position;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float clampedX;
    public float clampedY;
    public float movementSpeed = 4f;

    public bool is_visited;
    public int grid_distance_from_base;

    // Start is called before the first frame update
    void Start() {
        instSpaceObject = FindObjectOfType<SpaceObject>();
        SpriteRenderer instSpaceObjectSpriteRenderer = instSpaceObject.GetComponent<SpriteRenderer>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        transform_ = GetComponent<Transform>();
        current_position = transform_.position;

        minX = instSpaceObjectSpriteRenderer.bounds.min.x + transform_.localScale.x;
        maxX = instSpaceObjectSpriteRenderer.bounds.max.x - transform_.localScale.x;
        minY = instSpaceObjectSpriteRenderer.bounds.min.y + transform_.localScale.y;
        maxY = instSpaceObjectSpriteRenderer.bounds.max.y - transform_.localScale.y;

        Debug.Log(spriteRenderer.bounds.size.x + " : " + spriteRenderer.bounds.size.y);


        clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
    }
    //public void Move(Vector3 moveDirection, Quaternion targetRotation, Vector2 input) {
    //    float clampedX = Mathf.Clamp(transform.position.x + moveDirection.x * movementSpeed * Time.deltaTime, minX, maxX);
    //    float clampedY = Mathf.Clamp(transform.position.y + moveDirection.y * movementSpeed * Time.deltaTime, minY, maxY);
    //    Vector3 clampedPosition = new Vector3(clampedX, clampedY, transform.position.z);
    //    Vector3 nextGridPosition = instSpaceObject.MoveSpriteByGrid(clampedPosition, input);
    //    transform.position = nextGridPosition;
    //
    //    transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 10000f * Time.deltaTime);
    //}
    void Update()
    {
    }
}
