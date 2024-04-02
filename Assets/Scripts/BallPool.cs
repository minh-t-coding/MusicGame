using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPool : MonoBehaviour
{
    public static BallPool instance;

    private List<GameObject> pooledObjects = new List<GameObject>();
    private Dictionary<GameObject, Vector2> savedVelocities = new Dictionary<GameObject, Vector2>();
    [SerializeField] private int amountToPool = 20;

    [SerializeField] private GameObject ballPrefab;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    void Start() {
        Time.timeScale = 1f;

        for (int i = 0; i < amountToPool; i++) {
            GameObject obj = Instantiate(ballPrefab);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject() {
        for (int i = 0; i < pooledObjects.Count; i++) {
            if (!pooledObjects[i].activeInHierarchy) {
                return pooledObjects[i];
            }
        }

        return null;
    }

    public void PauseBalls() {
        Time.timeScale = 0f;
        savedVelocities.Clear();
        for (int i = 0; i < pooledObjects.Count; i++) {
            if (pooledObjects[i].activeInHierarchy) {
                Rigidbody2D ballRigidBody = pooledObjects[i].GetComponent<Rigidbody2D>();
                savedVelocities.Add(pooledObjects[i], ballRigidBody.velocity);
                ballRigidBody.Sleep();
            }
        }
    }

    public void UnpauseBalls() {
        Time.timeScale = 1f;

        for (int i = 0; i < pooledObjects.Count; i++) {
            if (pooledObjects[i].activeInHierarchy) {
                Rigidbody2D ballRigidBody = pooledObjects[i].GetComponent<Rigidbody2D>();
                ballRigidBody.WakeUp();
                ballRigidBody.velocity = savedVelocities[pooledObjects[i]];
            }
        }
    }
}
