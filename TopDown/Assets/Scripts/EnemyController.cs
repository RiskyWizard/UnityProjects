using UnityEngine;

public class EnemyController : MonoBehaviour {
    GameObject Player;
    Animator animator;
    Vector3 dir;
    float speed = 1.0f;

    void Start() {
        Player = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
        dir = new Vector3(Random.Range(-180,180),Random.Range(0,360),0).normalized;
        animator.SetBool("Walk",true);
    
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject == Player) {
            animator.SetTrigger("Attack");
        }
    
    }
    void OnCollisionStay2D(Collision2D other) {
        dir = -dir;
    }

    void Update() {
        transform.position += dir * speed * Time.deltaTime;
    
    }
}
