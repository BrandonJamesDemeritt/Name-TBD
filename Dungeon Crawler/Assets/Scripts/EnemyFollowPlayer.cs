using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


// Video Reference https://www.youtube.com/watch?v=lHLZxd0O6XY&ab_channel=ChronoABI
public class EnemyFollowPlayer : MonoBehaviour
{
    public float speed;
    public float lineOfSite;
    
    private Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer < lineOfSite)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
            lineOfSite = 100;
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
    }


}
