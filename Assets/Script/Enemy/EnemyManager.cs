using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private int expectedNum = 20;
    private List<EnemyControllerBase> enemyControllers;

    private void Awake()
    {
        enemyControllers = new List<EnemyControllerBase>(expectedNum);
    }
    void Start()
    {
        //���X�g�ɓo�^
        foreach(GameObject enemyGameObject in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            EnemyControllerBase enemyController = enemyGameObject.GetComponentInChildren<EnemyControllerBase>();
            enemyControllers.Add(enemyController);
            //enemyGameObject.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        //Execute���s
        foreach(EnemyControllerBase enemyController in enemyControllers)
        {
            enemyController.Execute();
        }
    }
}
