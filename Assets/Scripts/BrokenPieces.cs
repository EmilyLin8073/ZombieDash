using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenPieces : MonoBehaviour
{
    //Variable for how fast we want to move
    public float moveSpeed = 3f;
    private Vector3 moveDirection;

    public float deceleration = 5f;

    //Variable for how long the broken pieces show on screen
    public float lifeTime = 3f;

    //Variable for reference sprite render
    public SpriteRenderer theSR;

    //Variable for fading
    public float fadeSpeed = 1.5f;


    // Start is called before the first frame update
    void Start()
    {
        moveDirection.x = Random.Range(-moveSpeed, moveSpeed);
        moveDirection.y = Random.Range(-moveSpeed, moveSpeed);
    }


    // Update is called once per frame
    void Update()
    {
        //For letting broken pieces move
        transform.position += moveDirection * Time.deltaTime;

        //For letting broken pieces stop moving
        moveDirection = Vector3.Lerp(moveDirection, Vector3.zero, deceleration * Time.deltaTime);

        lifeTime -= Time.deltaTime;

        if(lifeTime < 0)
        {
            theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, Mathf.MoveTowards(theSR.color.a, 0f, fadeSpeed * Time.deltaTime));

            if (theSR.color.a == 0f)
            {
                Destroy(gameObject);
            }
        }
    }
}
