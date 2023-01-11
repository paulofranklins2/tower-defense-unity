using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    public GameObject bulletImpactEffect; 

    public void Seek(Transform _target)
    {
        target = _target;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceFrame, Space.World);

        
    }

    void HitTarget()
    {
        GameObject bulletEffect = (GameObject)Instantiate(bulletImpactEffect, transform.position, transform.rotation);
        Destroy(bulletEffect, 1f);
        Destroy(target.gameObject);
        Destroy(gameObject);

    }
}
