using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPool : MonoBehaviour
{
    public static BallPool instance;

    [SerializeField] private List<GameObject> pooledObjects = new List<GameObject>();

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    void Start() {
    }

    public GameObject GetPooledObject() {
        for (int i = 0; i < pooledObjects.Count; i++) {
            if (!pooledObjects[i].activeInHierarchy) {
                return pooledObjects[i];
            }
        }

        return null;
    }
}
