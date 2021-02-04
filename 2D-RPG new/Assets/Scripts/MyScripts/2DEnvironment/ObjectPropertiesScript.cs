using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPropertiesScript : MonoBehaviour
{
    private SpriteRenderer objectSprite;
    [Range(0.0f, 1.0f)]
    public float semiTransparentAlphaValue;
    // Start is called before the first frame update
    void Start()
    {
        objectSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("go!");
        //Changes Object alpha value,makes it transparent so that player is visible
        if (collision.gameObject.CompareTag("Player"))
        {
            Color tempColor = objectSprite.color;
            tempColor.a = semiTransparentAlphaValue;
            objectSprite.color = tempColor;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Color tempColor = objectSprite.color;
            tempColor.a = 1.0f;
            objectSprite.color = tempColor;
        }
    }
}
