using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform Target;
    public float speed = 70f;
    public GameObject ImpactEffect; //reference to prefab

    public void Seek(Transform _Target)
    {
        Target = _Target;
    }


    void Update()
    {
        if (Target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = Target.position - transform.position;
        float DistanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= DistanceThisFrame) //dir.magnetidue = distance target to bullet
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * DistanceThisFrame, Space.World); //Moves my bullet to my 'translated' spot

    }

    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(ImpactEffect, transform.position, transform.rotation); //Instantiate to clone prefab
        Destroy(effectIns, 2f); //Destroying used effect after 2 sec for hierarchy to be neat
        Destroy(Target.gameObject); //Enemy
        Destroy(gameObject); //Bullet
    }
}
