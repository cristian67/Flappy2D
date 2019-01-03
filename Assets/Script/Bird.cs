using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    //variables privadas
    private bool isDead;
    private Rigidbody2D rb2d;
    private Animator anim;

    //variables publicas
    public float upForce = 200f;

   

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (isDead)
        {
            anim.SetTrigger("Die");
            return;
        }
       

            if (Input.GetMouseButtonDown(0))
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));
                anim.SetTrigger("Flap");
                SoundSystem.instance.PlayFly();

            }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isDead = true;
        SoundSystem.instance.PlayDie();
        GameController.instance.BirdDie();
    }

}
