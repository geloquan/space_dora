using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Transform transform_;
    public Vector3 current_position;
    // Start is called before the first frame update
    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        transform_ = GetComponent<Transform>();
        current_position = transform_.position;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(transform_.position.x + " : " + transform_.position.y);
        Debug.Log(" Z : " + transform_.rotation.z);
    }
}
