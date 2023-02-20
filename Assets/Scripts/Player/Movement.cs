using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 6;
    public float turnSmooth = 0.1f;
    public Transform cam;
    public float smoothSpeed;
    private Animator animator;
    private float horizontal, vertical;
    public bool attack;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        InputPlayer();
        Move();
    }
    public void InputPlayer()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if(horizontal!=0 || vertical!=0)
        {
            animator.SetBool("Run", true);
        }
        else
            animator.SetBool("Run", false);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            attack = true;
            animator.SetBool("Attack", attack);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            attack = false;
            animator.SetBool("Attack", attack);
        }
    }

    public void Move()
    {
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;
        if(direction.magnitude>=0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothSpeed, turnSmooth);
            transform.rotation = Quaternion.Euler(0, angle, 0);

            Vector3 moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);
        }
    }


}
