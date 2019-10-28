using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count;
    private AudioSource myAudio;
    public AudioClip myClip;

     public float spheresize=0.2f;
    public int sphereinrow=5;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText ();
        winText.text = "";
        myAudio = GetComponent<AudioSource>();
        myAudio.PlayOneShot(myClip);
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (movement * speed);
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag ( "Pick Up"))
        {
            other.gameObject.SetActive (false);
            count = count + 1;
            SetCountText ();
           myAudio.Play();
        }
           
         if(other.gameObject.CompareTag ("Walls"))
        {
            
            explode();
            countText.text="";
            
            winText.text="Your score was "+count.ToString() + ".You Lose! :";
            
            
            

        }

        }
    
	void explode(){
        gameObject.SetActive(false);
        for (int x=0;x<sphereinrow;x++){
            for (int y=0;y<sphereinrow;y++){
                for (int z=0;z<sphereinrow;z++){
                    CreatePiece(x,y,z);
                }
            }
        }
    }
    void CreatePiece(int x,int y,int z){
        // Debug.DrawLine(Vector3(0,0,0), Vector3(100,0,0), Color.green, 2, false);
        Debug.Log("Entered Here");
        GameObject piece=GameObject.CreatePrimitive(PrimitiveType.Sphere);
        piece.transform.position=transform.position+new Vector3(spheresize*x,0,spheresize*z);
        piece.transform.localScale=new Vector3(spheresize,spheresize,spheresize);
        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass=spheresize;

    }
    

    void SetCountText ()
    {
        countText.text = "Score: " + count.ToString ();
       if (count >= 7)
        {
            winText.text = "You Win!";

            
        }
    }
}
