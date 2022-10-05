using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >= 10)
        {
            winTextObject.SetActive(true);
        }
    }

    void FixedUpdate() // Because we are using forces
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Game");
        }

        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp")) 
        {
            other.gameObject.SetActive(false);
            count += 1;

            SetCountText();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown ("space") && GetComponent<Rigidbody>().transform.position.y <= 0.5f) {
            Vector3 jump = new Vector3 (0.0f, 400.0f, 0.0f);
        
            rb.AddForce(jump);
        }
    }

    /* Update is called once per frame

    Recap

    static colliders shouldn't move

    Dynamic colliders can move and have a Rigidbody attached

    Standard Rigidbodies are moved using physics' forces
    
    Kinematic Rigidbodies are moved using their transform
    
    */
}
