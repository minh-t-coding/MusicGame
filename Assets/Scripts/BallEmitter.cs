using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BallEmitter : MonoBehaviour {
    [SerializeField] private float spawnInterval = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObjectCoroutine());
    }

    IEnumerator SpawnObjectCoroutine() {
        while (true) {
            // Instantiate(_ball, transform.position, Quaternion.identity);
            GameObject ball = BallPool.instance.GetPooledObject();

            if (ball != null) {
                ball.transform.position = transform.position;
                ball.SetActive(true);
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
