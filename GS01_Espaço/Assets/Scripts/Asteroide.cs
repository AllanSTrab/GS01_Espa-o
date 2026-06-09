using UnityEngine;

public class Asteroide : MonoBehaviour
{
    float speed = 7f;
    int life = 3;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(-1.0f * Time.deltaTime * speed, 0f, 0.0f);
        if (transform.position.x < -10f)
        {
            transform.position = new Vector3(10f, Random.Range(-4f, 4f), 0f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Nave")
        {
            transform.position = new Vector3(10f, Random.Range(-4f, 4f), 0f);
            life--;
            print(life);
            if (life == 0)
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
