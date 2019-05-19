using UnityEngine;

public class PlayerController : MonoBehaviour {

    int health = 10;
    float distance;
    Vector2 speed = new Vector2(8,6);
    float maxSpeed = 10;
    float mapWidth;
    float mapHeight;
    Rigidbody2D PlayerRB;
    public bool dead = false;


    void Start() {
        mapWidth = Map.width;
        mapHeight = Map.height;
        PlayerRB = GetComponent<Rigidbody2D>();
        transform.position = Map.SpawnPoint();
        Debug.Log(transform.position);
    }


    void Update() {
        if(!dead) {
            float move = Input.GetAxisRaw("Horizontal")*speed.x;
            PlayerRB.AddForce(new Vector2(move,0),ForceMode2D.Force);
            if(Input.GetKeyDown(KeyCode.Space))
                PlayerRB.AddForce(new Vector2(0,speed.y),ForceMode2D.Impulse);
            PlayerRB.velocity = Vector3.ClampMagnitude(PlayerRB.velocity,maxSpeed);
            if(PlayerRB.velocity.x < 0) {
                GetComponent<SpriteRenderer>().flipX = true;
                transform.rotation = Quaternion.Euler(transform.rotation.x,transform.rotation.y,30);
            }
            else if(PlayerRB.velocity.x > 0) {
                GetComponent<SpriteRenderer>().flipX = false;
                transform.rotation = Quaternion.Euler(transform.rotation.x,transform.rotation.y,-30);
            }
            GetComponent<SpriteRenderer>().flipY = false;
        }
        else {
            GetComponent<SpriteRenderer>().flipY = true;
        }
    
    }

    public int GetHealth() { return health; }
    public void ChangeHealth(int x) { health += x; }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag != "Enemy")
            if(dead)    dead = false;
    }

}
