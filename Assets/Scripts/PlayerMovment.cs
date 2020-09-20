using UnityEngine;

public class PlayerMovment : MonoBehaviour
{

    public float speed = 4;
    private Rigidbody2D myRigidBody;
    private Vector3 change;
    private Animator animator;


    void Start()
    {
       myRigidBody = GetComponent<Rigidbody2D>();
       animator = GetComponent<Animator>();
    }

    void Update()
    {
        change = Vector2.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        UpdateAnimationAndMove();
    }

    void UpdateAnimationAndMove() {
        if(change != Vector3.zero) {
             MoveCharacter();
             animator.SetFloat("moveX", change.x);
             animator.SetFloat("moveY", change.y);
             animator.SetBool("moving", true);
        } else {
            animator.SetBool("moving", false);
        }
    }

    void MoveCharacter() {
        myRigidBody.MovePosition(
            transform.position + change * speed * Time.deltaTime
        );
    }

}
