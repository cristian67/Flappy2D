using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepetBackground : MonoBehaviour
{

    private BoxCollider2D groundCollider;
    private float groundHorizontalLenght;



    void Awake()
    {
        groundCollider = GetComponent<BoxCollider2D>();

    }

    // Start is called before the first frame update
    void Start()
    {
        groundHorizontalLenght = groundCollider.size.x;

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.LogWarning(groundHorizontalLenght);

        if (transform.position.x < -(groundHorizontalLenght)) {
            RepositionBackground();
        }
    }


    void RepositionBackground()
    {
        transform.Translate(new Vector2( groundHorizontalLenght * 2, 0 ));
    }

}
