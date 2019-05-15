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
        }
    
    }

    public int GetHealth() { return health; }
    public void ChangeHealth(int x) { health += x; }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag != "Enemy")
            if(dead)    dead = false;
    }

}
