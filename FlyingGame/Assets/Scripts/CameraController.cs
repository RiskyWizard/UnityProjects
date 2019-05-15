using UnityEngine;

// camera follows player, offset on z-axis

public class CameraController : MonoBehaviour {

    GameObject Player;
    Camera cam;
    float distance;
    float moveTime = 0.5f;
    Vector3 velocity = Vector3.zero;
    float mapHeight,mapWidth;
    Rect viewport;

    void Awake() {
        cam = this.GetComponent<Camera>();
        Player = GameObject.FindWithTag("Player");
        distance = Vector3.Distance(Player.transform.position,this.transform.position);
        transform.position = Player.transform.position - new Vector3(0,0,distance);
        mapHeight = Map.height;
        mapWidth = Map.width;
        viewport = new Rect(0,0,cam.orthographicSize*cam.aspect,cam.orthographicSize);
    }

    void Update() {
        Vector3 newPos = Vector3.SmoothDamp(this.transform.position,Player.transform.position - new Vector3(0,0,distance),ref velocity, moveTime);
        newPos.x = Mathf.Clamp(newPos.x,viewport.width-0.5f,mapWidth-viewport.width-0.5f);
        newPos.y = Mathf.Clamp(newPos.y,viewport.height-0.5f,mapHeight-viewport.height-0.5f);
        transform.position = newPos;
    
    }

    bool HitWall() {
        if(Player.transform.position.x < viewport.width) return true;
        return false;
    }

}
