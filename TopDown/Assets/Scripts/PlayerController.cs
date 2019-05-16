using UnityEngine;

public class PlayerController : MonoBehaviour {
    Camera cam;
    float camDist;
    float speed = 2.5f;

    void Start() {
        cam = Camera.main;
        camDist = Vector3.Distance(transform.position,cam.transform.position);
    }

    void Update() {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        transform.position += new Vector3(h,v,0)*Time.deltaTime*speed;
    
        cam.transform.position = transform.position - new Vector3(0,0,camDist);
    }

}
