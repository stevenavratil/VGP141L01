using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] spawnedObject;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(spawnedObject[0], transform.position, transform.rotation);
    }
}
