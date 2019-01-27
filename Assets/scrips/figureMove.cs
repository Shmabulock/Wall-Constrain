using UnityEngine;
using System.Collections;
public class figureMove : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    public float Speed = 1;

    [Range(-1.0f, 1.0f)]
    public float rotationSpeed;
    ObstaclesSpawner spawner;
    public enum Napr { left, right, up, down };
    public Napr what;
    public float destroyDelay;
    float x;
    float y;
    float multiplier;
    int counter;
    Vector3 moveVec;

    void Start()
    {
        
        spawner = GameObject.Find("obstaclesSpawner").GetComponent<ObstaclesSpawner>();
        counter = 1;
        multiplier = 1.0f;
        switch (what)
        {
            case Napr.left:
                {
                    x = -1;
                    y = 0;
                    break;
                }
            case Napr.right:
                {
                    x = 1;
                    y = 0;
                    break;
                }
            case Napr.up:
                {
                    x = 0;
                    y = 1;
                    break;
                }
            case Napr.down:
                {
                    x = 0;
                    y = -1;
                    break;
                }


        }
        moveVec.x = x * Speed * Time.fixedDeltaTime;
        moveVec.y = y * Speed * Time.fixedDeltaTime;
        moveVec.z = 0;
    }

    void FixedUpdate()
    {
        moveVec.x = x * Speed * multiplier * Time.fixedDeltaTime;
        moveVec.y = y * Speed * multiplier * Time.fixedDeltaTime;
        transform.position = transform.position + moveVec;
        Vector3 a;
        a = Vector3.forward;
        transform.Rotate(Vector3.back*rotationSpeed);
        counter++;
        if (counter % 1000 == 0)
        {
            counter = 1;
            multiplier += 0.05f;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("1 collision");
        if (collision.gameObject.tag == TAGS.Player)
        {
           // Debug.Log("2 tag player");

            if (collision.gameObject.GetComponent<movePlayer>().isInSupermode())
            {
           //     Debug.Log("3 angVel > 700f");
                collision.rigidbody.angularVelocity /= 4;
                spawner.spawnNCollectables(collision.transform.position, (int)Random.Range(5, 10));
                Destroy(this.gameObject);
            }
          
        }

    }
    public Napr GetNapr()
    {
        return what;
    }
    public void SetNapr(Napr n)
    {
        what = n;
    }
   private void OnDestroy()
    {

       // Debug.Log("hahahaha");
        if(spawner != null)
        spawner.GetComponent<ObstaclesSpawner>().setObstaclesCount(spawner.GetComponent<ObstaclesSpawner>().getObstaclesCount() - 1);
    }
}