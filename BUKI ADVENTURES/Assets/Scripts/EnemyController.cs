using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed = 2f;
    public float distance = 3f;

    private float positionLeft;
    private float positionRight;

    private bool isMovingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        positionLeft = gameObject.transform.position.x - distance;
        positionRight = gameObject.transform.position.x + distance;

    }

    // Update is called once per frame
    void Update()
    {
        if(isMovingRight==true)
        {
            gameObject.transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            gameObject.transform.Translate(Vector2.left * speed * Time.deltaTime);

        }
    }
}
