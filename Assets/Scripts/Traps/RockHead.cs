using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHead : MonoBehaviour
{
    [SerializeField] private float speedRockHead;
    [SerializeField] private Transform fisrtPoint;
    [SerializeField] private Transform finalPoint;

    private Vector3 target;
    private Animator anim;
    private GameObject player;

    private void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        target = finalPoint.position;   
    }

    private void Update()
    {
        RockHeadMovement();
    }

    private void RockHeadMovement()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speedRockHead * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            CheckPlayer();
            if (target == finalPoint.position)
            {
                target = fisrtPoint.position;
                anim.SetTrigger("righthit");
            }
            else
            {
                target = finalPoint.position;
                anim.SetTrigger("lefthit");
            }
        }
    }

    private void CheckPlayer()
    {
        if (player != null)
        {
            float distancePlayer = Vector3.Distance(transform.position, player.transform.position);

            if (distancePlayer < 1.5f)
            {
                HealthBarUI.instance.TakeDamage(100);
                PlayerMovement.Destroy(player);
            }
        }
    }
}
