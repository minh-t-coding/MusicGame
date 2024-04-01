using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    void OnBecameInvisible() {
        gameObject.SetActive(false);
    }
}
