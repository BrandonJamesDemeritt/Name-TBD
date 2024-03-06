using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


// Video Reference https://www.youtube.com/watch?v=lHLZxd0O6XY&ab_channel=ChronoABI
public class EnemyShooter : MonoBehaviour
{
    public float speed;
    public float lineOfSite;
    public float shootingRange;
    public float fireRate = 1f;
    private float nextFireTime;
    public GameObject bullet;
    public GameObject bulletParent;
    private Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer < lineOfSite && distanceFromPlayer > shootingRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
            lineOfSite = 7;
        }
        else if (distanceFromPlayer <= shootingRange & nextFireTime < Time.time)
        {
            Instantiate(bullet, this.transform.position, Quaternion.identity);
            nextFireTime = Time.time + fireRate;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, shootingRange);

    }

    private void OnParticleCollision(GameObject Flames)
    {
        gameObject.SetActive(false);
    }
}
