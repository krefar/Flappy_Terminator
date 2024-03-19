using Assets.Scripts.Services.Shooting;
using System;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    private void Update()
    {
        if (transform.localPosition.x > 1)
        {
            transform.localPosition += Vector3.left * Time.deltaTime;
        }
    }
}