using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody2D rb2d;
    private int count = 0;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        countText.text = "Count: " + count;
        winText.text = "";
    }

    private void FixedUpdate()
    {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis("Vertical");

        // Use horizontal and vertical inputs to move the player
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rb2d.AddForce(movement * speed);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Colliding with " + other.tag);
        if (other.gameObject.CompareTag("PickUp")) {
            //other.gameObject.SetActive(false);
            Destroy(other.gameObject);
            count++;
            SetCountText();
        }
    }

    private void SetCountText() {
        countText.text = "Count: " + count;
        if (count >= 4) {
            winText.text = "You win!";
        }
    }
}
