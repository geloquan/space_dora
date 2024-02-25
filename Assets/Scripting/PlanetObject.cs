using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Newtonsoft.Json.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlanetObject : MonoBehaviour {
    private static int nextId = 1;
    private int id;

    private float cell_pos_x;
    private float cell_pos_y;

    private int reward;
    private bool is_visited;

    public SpriteRenderer spriteRenderer;
    private GameObject new_planet;
    private Bounds boundsSpaceObject;

    public void Visit() {
        is_visited = true;
    }
    public int GetId() {
        return id;
    }
    private void Start() {
    }


    // UniqueObject[] objects = FindObjectsOfType<UniqueObject>();
    // 
    // UniqueObject obj = UniqueObject.GetById(objects, 2);
    //public static UniqueObject GetById(UniqueObject[] objects, int id) {
    //    foreach (UniqueObject obj in objects) {
    //        if (obj.GetId() == id) {
    //            return obj;
    //        }
    //    }
    //    return null;
    //}
    //
    //
    //public int Visit(UniqueObject[] objects, int id) {
    //    foreach (UniqueObject planet in objects) {
    //        if (planet.GetId() == id) {
    //            if (planet.is_visited == true) {
    //                Debug.Log("planet " + id + " is visited");
    //                return 0;
    //            } else if (planet.is_visited == false) {
    //                planet.is_visited = true;
    //                return planet.reward;
    //            } else {
    //                Debug.Log("planet property is_visited not found");
    //            }
    //        }
    //    }
    //}

    void Update() {
        
    }
}