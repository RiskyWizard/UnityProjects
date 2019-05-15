using UnityEngine;
using TMPro;

public class UI : MonoBehaviour {

    TextMeshProUGUI text;
    GameObject Player;
    float PlayerSpeed;
    int PlayerHealth;

    void Start() {
        Player = GameObject.FindWithTag("Player");
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update() {
        PlayerSpeed = Player.GetComponent<Rigidbody2D>().velocity.magnitude;
        PlayerHealth = Player.GetComponent<PlayerController>().GetHealth();
        text.text = "Speed: " + PlayerSpeed.ToString("#.#");
        text.text += "\nHealth: " + PlayerHealth.ToString("#");
    
    }


}
