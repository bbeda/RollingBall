using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float Speed;

    private Rigidbody rigidBody;

    public Text countText;

    public Text winText;

    private int itemCount;

    void Start()
    {
        this.rigidBody = this.GetComponent<Rigidbody>();
        this.itemCount = 0;
        this.winText.text = "";
        SetCountText();
    }

    private void SetCountText()
    {
        this.countText.text = "Count " + this.itemCount.ToString();
    }

    void FixedUpdate()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");

        var movement = new Vector3(moveHorizontal, 0, moveVertical);

        this.rigidBody.AddForce(movement * Speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            this.itemCount++;
            SetCountText();
            if (this.itemCount >= 12)
            {
                this.winText.text = "You Win!";
            }
        }
    }
}
