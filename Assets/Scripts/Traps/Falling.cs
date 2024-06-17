using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    private float fallDelay = 1f;
    private float destroyTime = 3f;

    [SerializeField] private Rigidbody2D rb;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        }
    }

    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        anim.SetTrigger("drop");
        rb.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, destroyTime);
    }
}
