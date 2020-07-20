using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float speed = 10;
    private Transform[] positions;
    private int index = 0;

    void Start(){
        positions = WayPoints.positions;
    }

    // Update is called once per frame
    void Update(){
        Move();
    }

    void Move(){
        /*移动到最后一个节点*/
        if (index > positions.Length - 1) {
            return;
        }
        /*开始移动*/
        transform.Translate((positions[index].position - transform.position).normalized * Time.deltaTime * speed);
        /*移动到下个节点*/
        if (Vector3.Distance(positions[index].position, transform.position) < 0.2) {
            index++;
        }

        /*到达终点，销毁*/
        if (index > positions.Length - 1) {
            ReachDestination();
        }
    }

    void ReachDestination(){
        GameObject.Destroy(this.gameObject);
    }

    private void OnDestroy(){
        EnemySpawner.CountEnemyAlive--;
    }
}