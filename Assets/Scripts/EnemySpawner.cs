using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public Wave[] waves;
    public Transform start;
    public static int CountEnemyAlive = 0;
    public float waveRate = 0.5f;

    // Start is called before the first frame update
    void Start(){
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy(){
        foreach (Wave wave in waves) {
            for (int i = 0; i < wave.count; i++) {
                GameObject.Instantiate(wave.enemyPrefab, start.position, Quaternion.identity);
                CountEnemyAlive++;
                if (i != wave.count - 1) {
                    yield return new WaitForSeconds(wave.rate);
                }
            }

            while (CountEnemyAlive > 0) {
                /*暂停*/
                yield return 0;
            }

            yield return new WaitForSeconds(waveRate);
        }
    }

    // Update is called once per frame
    void Update(){ }
}