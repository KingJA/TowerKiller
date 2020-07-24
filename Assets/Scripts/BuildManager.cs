using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour {
    public TurretData laserTurretData;
    public TurretData missileTurretData;
    public TurretData standardTurretData;
    public TurretData selectedTurretData;
    public Text moneyText;
    public Animator moneyAnimator;

    private int money = 1000;

    void ChangeMoney(int change = 0){
        money += change;
        moneyText.text = "¥" + money;
    }

    private void Update(){
        //鼠标被按下
        if (Input.GetMouseButtonDown(0)) {
            //UI没有被选中
            if (EventSystem.current.IsPointerOverGameObject() == false) {
                //MapCube上没有建过炮塔
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//Camera.main tag上标记MainCamera即可
                RaycastHit hit;
                bool isCollider = Physics.Raycast(ray, out hit, 1000, LayerMask.GetMask("MapCube"));
                if (isCollider) {
                    MapCube mapCube = hit.collider.GetComponent<MapCube>(); //得到点击的mapCube
                    if (mapCube.turretGo == null) {
                        //建造
                        if (money >= selectedTurretData.cost) {
                            mapCube.BuildTurret(selectedTurretData.turretPrefab);
                            ChangeMoney(-selectedTurretData.cost);
                        }
                        else {
                            //提示钱不够
                            moneyAnimator.SetTrigger("Flicker");
                        }
                    }
                    else {
                        //升级
                        if (money >= selectedTurretData.costUpgraded) {
                            ChangeMoney(-selectedTurretData.costUpgraded);
                        }
                        else {
                            //提示钱不够
                        }
                    }
                }
            }
        }
    }

    public void OnLaserSelected(bool inOn){
        if (inOn) {
            selectedTurretData = laserTurretData;
        }
    }

    public void OnMissileSelected(bool inOn){
        if (inOn) {
            selectedTurretData = missileTurretData;
        }
    }

    public void OnStandardSelected(bool inOn){
        if (inOn) {
            selectedTurretData = standardTurretData;
        }
    }
}