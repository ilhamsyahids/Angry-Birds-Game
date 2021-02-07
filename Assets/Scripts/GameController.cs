﻿using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public SlingShooter SlingShooter;
    public List<Bird> Birds;
    public List<Enemy> Enemies;
    private bool _isGameEnded = false;
    void Start()
    {
        for (int i = 0; i < Birds.Count; i++)
        {
            Birds[i].OnBirdDestroy += ChangeBird;
        }
        for (int i = 0; i < Enemies.Count; i++)
        {
            Enemies[i].OnEnemyDestroy += CheckGameEnd;
        }
        SlingShooter.InitiateBird(Birds[0]);
    }

    public void ChangeBird() {
        if (_isGameEnded) return;

        Birds.RemoveAt(0);

        if (Birds.Count > 0) {
            SlingShooter.InitiateBird(Birds[0]);
        }
    }

    public void CheckGameEnd(GameObject destroyedEnemy) {
        for (int i = 0; i < Enemies.Count; i++) {
            if (Enemies[i].gameObject == destroyedEnemy) {
                Enemies.RemoveAt(i);
                break;
            }
        }

        if (Enemies.Count == 0) {
            _isGameEnded = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
