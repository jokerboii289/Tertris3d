using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterNPC : MonoBehaviour
{
    [HideInInspector]
    public static CharacterNPC instance;
    Animator animator;

    [SerializeField] float runSpeed;

    [Header("Groundcheck")]
    bool grounded;
    [SerializeField] Transform raycastPoint;
    [SerializeField] Transform restPoint;

 
    // Start is called before the first frame update
    void Start()
    {
        grounded = false;
        instance = this;
        animator = GetComponent<Animator>();
    }


    private void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(raycastPoint.position,-transform.up,out hit,2f))
        {
            if (hit.transform.CompareTag("Ground") && hit.distance < 0.1f)
            {
                StartCoroutine(DelayRun());                          
            }
            else if(hit.transform.CompareTag("cube") && hit.distance < 0.1f)
            {
                GoIdleState();
            }
        }

        if(grounded && (new Vector3(restPoint.position.x, transform.position.y, restPoint.position.z) - transform.position).magnitude>.1f)
        {
            var direction = (new Vector3(restPoint.position.x,transform.position.y,restPoint.position.z) - transform.position).normalized;
            transform.forward = direction;
            transform.position += direction * runSpeed *Time.deltaTime;         
        }
        else if(grounded && (new Vector3(restPoint.position.x, transform.position.y, restPoint.position.z) - transform.position).magnitude <= .1f)
        {
            animator.SetBool("run", false);
        }
    }

    IEnumerator DelayRun()
    {
        animator.SetBool("run", true);
        yield return new WaitForSeconds(1.5f);
        grounded = true;
    }

    public void Jump()
    {
        animator.SetBool("Jump", true);
    }

    public void GoIdleState()
    {
        animator.SetBool("Jump", false);
    }   
}
