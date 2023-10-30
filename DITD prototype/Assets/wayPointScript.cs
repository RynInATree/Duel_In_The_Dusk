using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class wayPointScript : MonoBehaviour
{
    float randomX;
    float randomY;
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        RandomPos();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
        }
        else
        {
            RandomPos();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
        }
        else
        {
            RandomPos();
        }
    }

    public void RandomPos()
    {
        randomX = Random.Range(36.431f, 98.337f);
        Debug.Log(randomX);
        randomY = Random.Range(-21.051f, 25.116f);
        Debug.Log(randomY);
        pos = new Vector3(randomX, randomY, 0);
        transform.position = pos;
    }
}
