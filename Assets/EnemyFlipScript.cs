using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlipScript : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer=gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.flipX = true;
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
