using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private FixedJoystick js;
    [SerializeField] private Animator animator;

    [SerializeField] bool hasKey;
    [SerializeField] private float moveSpeed;

    [SerializeField] PlayerLevel playerLevel;
    [SerializeField] FloatingText floatingText;
    
    void Start()
    {
        animator = GetComponent<Animator>();    
        playerLevel = GetComponent<PlayerLevel>();
    }
    private void FixedUpdate() 
    {
        rb.velocity = new Vector3(js.Horizontal * moveSpeed, rb.velocity.y, js.Vertical * moveSpeed);

        if(js.Horizontal != 0 || js.Vertical != 0)
        {
            animator.SetBool("isMoving", true);
            transform.rotation = Quaternion.LookRotation(rb.velocity);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

    private void Update()
    {
        floatingText.SetLevel(playerLevel.GetPlayerLevel());
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Debug.Log("enemy spotted");
            animator.SetBool("Attack", true);
            gameObject.SetActive(false);
        }
        else
        {
            animator.SetBool("Attack", false);
        }
    }
    
    public void SetHasKey(bool playerHasKey)
    {
        hasKey = playerHasKey;
    }
}
