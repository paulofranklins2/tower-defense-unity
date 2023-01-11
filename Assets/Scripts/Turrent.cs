using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Turrent : MonoBehaviour
{
    [Header("Attributes")]
    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;


    [Header("Unity Setup")]
    public Transform target;
    public string enemyTag = "Enemy";
    public float speedRotation = 10f;
    public Transform rotatePart;
    public GameObject bulletPrefab;
    public Transform firePoint;






    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5F);
        
    }
    
    void Update(){
        if(target == null)
            return;

            //Target Lock on
            Vector3 dir = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(rotatePart.rotation, lookRotation, Time.deltaTime * speedRotation).eulerAngles;
            rotatePart.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        if (fireCountdown <= 0)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;


    }

    void Shoot()
    {
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        BulletScript bullet = bulletGo.GetComponent<BulletScript>();
        if(bullet != null)
        {
            bullet.Seek(target);
        }
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies)
        {
            float distancyToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distancyToEnemy < shortestDistance)
            {
                shortestDistance = distancyToEnemy;
                nearestEnemy = enemy;
            }
        }
            if(nearestEnemy != null && shortestDistance <= range)
            {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
        {

        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
