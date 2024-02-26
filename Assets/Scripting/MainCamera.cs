using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MainCamera : MonoBehaviour {
    private SpaceObject instSpaceObject;
    private PlayerObject instPlayerObject;
    public SpriteRenderer spriteRenderer;
    public SpriteRenderer instSpaceObjectSpriteRenderer;
    public Transform target;
    public float minX;
    public float minY;
    public float maxX;
    public float maxY;

    void Start() {
        instSpaceObject = FindObjectOfType<SpaceObject>();
        instSpaceObjectSpriteRenderer = instSpaceObject.GetComponent<SpriteRenderer>();
        instPlayerObject = FindObjectOfType<PlayerObject>();
        target = FindObjectOfType<PlayerObject>().transform;
        Transform transform = GetComponent<Transform>();
        minX = -(instSpaceObjectSpriteRenderer.localBounds.size.x / 2) + (Camera.main.orthographicSize * 2);
        minY = -instSpaceObjectSpriteRenderer.localBounds.size.x / 2 + (Camera.main.orthographicSize * 2 * Camera.main.aspect);
        maxX = instSpaceObjectSpriteRenderer.localBounds.size.y / 2 - (Camera.main.orthographicSize * 2);
        maxY = instSpaceObjectSpriteRenderer.localBounds.size.y / 2 - (Camera.main.orthographicSize * 2 * Camera.main.aspect);

    }
    void Update() {
        Vector3 direction = target.position - transform.position;
        transform.position += direction * 5f * Time.deltaTime;



    }
}
