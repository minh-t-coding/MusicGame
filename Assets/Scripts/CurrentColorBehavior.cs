using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentColorBehavior : MonoBehaviour
{
    //adjust this to change speed
    [SerializeField] private float speed = 5f;
    //adjust this to change how high it goes
    [SerializeField] private float height = 0.5f;

    void Update() { 
    //calculate what the new Y position will be
    float newY = transform.position.y + Mathf.Sin(Time.unscaledTime * speed) * height;
    //set the object’s Y to the new calculated Y
    transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
