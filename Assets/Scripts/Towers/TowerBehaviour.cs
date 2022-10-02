using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class TowerBehaviour : MonoBehaviour
{
    [SerializeField] TowerData _data;

    [Header("References")]
    public Transform graphic;
    public Transform target {get; private set;}

    [SerializeField] private float fireRate = 2.0f;
    [SerializeField] private float fireCountdown = 0.0f;
    
    [SerializeField] private float range = 5.0f;
    [SerializeField] private float rotationSpeed = 30.0f;
    [SerializeField] private float targetUpdateFrequency = 1.0f;
    private string creepTag = "Creep";

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] Transform firePoint;


    /// <summary> Callback to draw gizmos only if the object is selected. </summary>
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    // Start is called before the first frame update
    private void Start()
    {
        //TODO: This runs awfully, thanks Brackeys. Replace.
        InvokeRepeating("UpdateTarget", 0f, targetUpdateFrequency);
    }

    /// <summary> Update is called every frame, if the MonoBehaviour is enabled. </summary>
    private void Update()
    {
        if (target == null) return;

        // Rotate graphic to face target
        Vector2 dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationSpeed);
    
        if (fireCountdown <= 0f)
        {
            Fire();
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }

    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(creepTag);
        float shortestDistance = range;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                target = enemy.transform;
            }
        }
    }

    private void Fire()
    {
        GameObject bullet_go = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation, transform);
        Bullet bullet = bullet_go.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }
}
