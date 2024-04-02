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
            GameObject ball = BallPool.instance.GetPooledObject();

            if (ball != null && StateManager.instance.getIsPlaying()) {
                ball.transform.position = transform.position;
                ball.SetActive(true);
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
