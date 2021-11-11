using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretFindRotate : MonoBehaviour
{
    private Transform Target;

    [Header("Attributes")]

    public float Range = 15f;
    public float FireCountdown = 0f;
    private float FireRate = 1f;

    [Header("Target Tag")]

    public string enemyTag = "Enemy";

    [Header("Turn Speed")]

    public float TurnSpeed = 10f;

    [Header("References")]

    public Transform ToRotate;
    public GameObject BulletPrefab;
    public Transform FirePoint;


    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity; 
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float DistanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (DistanceToEnemy < shortestDistance)
            {
                shortestDistance = DistanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= Range)
        {
            Target = nearestEnemy.transform;
        }
        else
        {
            Target = null;
        }
    }
    void Update()
    {
        if (Target == null)
        {
            return;
        }
        Vector3 direction = Target.position - transform.position;
        Quaternion LookRotation = Quaternion.LookRotation(direction);
        Vector3 Rotation = Quaternion.Lerp(ToRotate.rotation, LookRotation, Time.deltaTime * TurnSpeed).eulerAngles;
        ToRotate.rotation = Quaternion.Euler(0f, Rotation.y, 0f);


        if (FireCountdown <= 0)
        {
            Shoot();
            FireCountdown = 1f / FireRate;
        }
        FireCountdown -= Time.deltaTime;
    }
    void Shoot()
    {
        GameObject BulletGO = (GameObject)Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        Bullet bullet = BulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(Target);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
