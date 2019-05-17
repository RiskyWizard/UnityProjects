using UnityEngine;

public class PlayerController : MonoBehaviour {
    float speed = 2.5f;
    Animator animator;

    void Start() {
        animator = this.GetComponent<Animator>();
    }

    void Update() {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        if(h > 0) {
            animator.SetBool("moveLeft",false);
            animator.SetBool("moveRight",true);
            animator.SetBool("moveUp",false);
            animator.SetBool("moveDown",false);
        }
        else if(h < 0) {
            animator.SetBool("moveLeft",true);
            animator.SetBool("moveRight",false);
            animator.SetBool("moveUp",false);
            animator.SetBool("moveDown",false);
        }
        else if(v > 0) {
            animator.SetBool("moveLeft",false);
            animator.SetBool("moveRight",false);
            animator.SetBool("moveUp",true);
            animator.SetBool("moveDown",false);
        }
        else if(v < 0) {
            animator.SetBool("moveLeft",false);
            animator.SetBool("moveRight",false);
            animator.SetBool("moveUp",false);
            animator.SetBool("moveDown",true);
        }
        if(h == 0 && v == 0)    animator.SetFloat("isMoving",0);
        else  {
            animator.SetFloat("isMoving",1);
        }
        transform.position += new Vector3(h,v,0)*Time.deltaTime*speed;
    
    }

}
