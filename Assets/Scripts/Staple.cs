using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staple : MonoBehaviour
{

    public float stapleSpeed = 1f;

    public GameObject stapler;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = stapler.transform.position;
        transform.rotation = stapler.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * stapleSpeed);
    }
}
