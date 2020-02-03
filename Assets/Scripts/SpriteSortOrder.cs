using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSortOrder : MonoBehaviour
{
    //Variable for reference sprite
    private SpriteRenderer theSR;
    // Start is called before the first frame update
    void Start()
    {
        //For sorting the layer order for the object
        theSR = GetComponent<SpriteRenderer>();
        theSR.sortingOrder = Mathf.RoundToInt( transform.position.y * -10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
