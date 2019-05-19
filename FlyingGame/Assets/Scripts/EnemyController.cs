using UnityEngine;
using TMPro;

// this just makes the enemy fly towards the player.
// also manages collision between player and enemy
public class EnemyController : MonoBehaviour {

    GameObject Player;
    bool dead = false;
    float speed = 0.5f;
    float maxSpeed = 5;
    Rigidbody2D RB;
    int health = 5;
    TextMeshPro text;

    void Start() {
        Player = GameObject.FindWithTag("Player");
        RB = GetComponent<Rigidbody2D>();
        text = this.transform.GetComponentInChildren<TextMeshPro>();
        text.text = health.ToString();
    
    }

    void Update() {
        if(!dead) {
            Vector3 dir = (Player.transform.position - transform.position).normalized;
            if(dir.x < 0)
                GetComponent<SpriteRenderer>().flipX = true;
            else
                GetComponent<SpriteRenderer>().flipX = false;
            RB.AddForce(dir*speed,ForceMode2D.Impulse);
            RB.velocity = Vector3.ClampMagnitude(RB.velocity,maxSpeed);
            if(RB.velocity.x < 0)
                GetComponent<SpriteRenderer>().flipX = true;
            else
                GetComponent<SpriteRenderer>().flipX = false;
            if(GetComponent<SpriteRenderer>().flipY)
                GetComponent<SpriteRenderer>().flipY = false;
        }
        else {
            GetComponent<SpriteRenderer>().flipY = true;
        }

    
        if(health <= 0) {
            Destroy(this.gameObject);
            EnemyManager.EnemyList.Remove(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject == Player) {
            ParticleSystem p = new ParticleSystem();
            foreach(ContactPoint2D contact in other.contacts) {
                p = GameObject.Instantiate(Resources.Load<GameObject>("Crash"),contact.point,Quaternion.identity).GetComponent<ParticleSystem>();
            }

            if(other.transform.position.y > this.transform.position.y) {
                if(!dead)   dead = true;
                health -= 1;
                text.text = health.ToString();
                p.startColor = new Color(0,1,0);
                p.Play();
            }
            else {
                Player.GetComponent<PlayerController>().dead = true;
                Player.GetComponent<PlayerController>().ChangeHealth(-1);
                p.startColor = new Color(1,0,0);
                p.Play();
            }

        }
        else {
            if(dead)    dead = false;
        }
    
    }

}
