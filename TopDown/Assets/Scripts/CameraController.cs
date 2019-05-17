using UnityEngine;

public class CameraController : MonoBehaviour {
    GameObject Player;
    Camera cam;
    float dist;

    void Start() {
        Player = GameObject.FindWithTag("Player");
        transform.position = new Vector3(Player.transform.position.x,Player.transform.position.y,this.transform.position.z);
        dist = Vector3.Distance(Player.transform.position,this.transform.position);
    
    }

    void Update() {
        this.transform.position = Player.transform.position - new Vector3(0,0,dist);
    
    }

}
