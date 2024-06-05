using UnityEngine;
using System.Collections;
using TMPro;
public class Fly : MonoBehaviour {
     private float throttle;
 public float throttleIncrement = 0.1f;
    public float MaxThrust = 200f;
// Use this for initialization
public float lift = 135f;
Rigidbody rb;
[SerializeField] TextMeshProUGUI hud;
    
    private void Awake(){
        rb = GetComponent<Rigidbody>();
    }
void Start () {
Debug.Log("Fly script added to: " + gameObject.name);
}

    
    


// Update is called once per frame
void Update () {
   
    UpdateHUD();
        if(Input.GetKey(KeyCode.Space)) throttle += throttleIncrement;
        else if (Input.GetKey(KeyCode.LeftControl)) throttle -= throttleIncrement;
        throttle = Mathf.Clamp(throttle, 0f, 100f);

    
transform.Rotate( Input.GetAxis("Vertical"), 0.0f, Input.GetAxis("Horizontal") );

float terrainHeightWhereWeAre = Terrain.activeTerrain.SampleHeight( transform.position );

if (terrainHeightWhereWeAre > transform.position.y) {
transform.position = new Vector3(transform.position.x, terrainHeightWhereWeAre, transform.position.z);
}
}
private void FixedUpdate(){
    rb.AddForce(transform.forward * MaxThrust * throttle);
    rb.AddForce(Vector3.up * rb.velocity.magnitude * lift);
}
private void UpdateHUD(){
    hud.text = "";
    hud.text += "Brzina: " + (rb.velocity.magnitude * 3.6f).ToString("F0") + "km/h" + "\n";
    hud.text += "Visina: " + (transform.position.y.ToString("F0") + "m");
}
}