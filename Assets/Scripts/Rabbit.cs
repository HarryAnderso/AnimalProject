using UnityEngine;

public class Rabbit : MonoBehaviour
{

    public Vector3 targ;
    public float wanderRadius = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targ = new Vector3(Random.Range(transform.position.x - wanderRadius, transform.position.x + wanderRadius), 0, Random.Range(transform.position.y - wanderRadius, transform.position.y + wanderRadius));
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movedir = targ - transform.position;
        transform.position += movedir.normalized * Time.deltaTime * 1;
        if (Vector3.Distance(transform.position, targ) < 0.8f)
        {
            targ = new Vector3(Random.Range(transform.position.x - wanderRadius, transform.position.x + wanderRadius), 0, Random.Range(transform.position.y - wanderRadius, transform.position.y + wanderRadius));

        }
    }
}
