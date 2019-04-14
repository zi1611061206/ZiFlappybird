using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFly : MonoBehaviour
{
    private GameObject obj;
    float flappingUp;
    GameObject gameController;
    public AudioClip flyClip;
    public AudioClip endGameClip;
    private AudioSource audioSource;
    public GameObject objFly1;
    private Animator anim;

	// Use this for initialization
	void Start ()
    {
        obj = gameObject;
        flappingUp = 50;
        gameController = GameObject.FindGameObjectWithTag("GameController");
        audioSource = obj.GetComponent<AudioSource>();
        audioSource.clip = flyClip;
        anim = objFly1.GetComponent<Animator>();
        anim.SetBool("isDead", false);
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKey("space") || Input.GetKey("up") || Input.GetMouseButton(0)) //đầu vào là click chuột (0 là chuột trái 1 là chuột phải)
        {
            if(!gameController.GetComponent<GameController>().isEndGame)
            {
                audioSource.Play();
            }
            obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(/*obj.transform.position.x*/0, flappingUp));
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EndGame();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        gameController.GetComponent<GameController>().GetPoint();
    }

    private void EndGame()
    {
        anim.SetBool("isDead", true);
        audioSource.clip = endGameClip;
        audioSource.Play();
        gameController.GetComponent<GameController>().EndGame();
    }
}
