using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossmon : MonoBehaviour
{

    public Transform target;
    public Transform[] iciclePositions;
    public Transform swordFish;
    public int health = 500;
    public GameObject projectile;
    public GameObject heart;
    public Rigidbody2D snowballRigid;
    public Animator bossAnim;
    public GameObject exitDoor;

    public float shotsPerSecond = 0.5f;
    public float projectileSpeed;
    public float projectileSpeed2;
    public float moveSpeed;
   public bool isMoving;

    private Rigidbody2D myRigidBody;

    void Start()
    {
        StartCoroutine(KillSwordFish());
        InvokeRepeating("Movement", 5, 13);

    }

    // Update is called once per frame
    void Update()
    {
        

        /*float probability = Time.deltaTime * shotsPerSecond;
        if(health >= 300f && Random.value < probability)
        {
            Fire();
        }
        if(health <=299 && Random.value < probability)
        {
            Fire2();
            Debug.Log("Fire2");
        }
        */

        if (health <= 0)
        {
            Destroy(gameObject);
            exitDoor.SetActive(true);
        }
        




    }




    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Icicles")
        {
            health -= 100;
        }

        SnowballScript snowball = other.gameObject.GetComponent<SnowballScript>();


    }

    



    void Movement()
    {
        StartCoroutine(MoveAfter());
    }
    
    IEnumerator KillSwordFish()
    {


        yield return new WaitForSeconds(3);
        int s = 0;
        while(s < 1)
        {
            Vector3 startPosition = transform.position;
            Vector3 direction1 = swordFish.position- startPosition;
            direction1.Normalize();
            float rot_z = Mathf.Atan2(direction1.y, direction1.x) * Mathf.Rad2Deg;
            GameObject missile = Instantiate(projectile, startPosition, Quaternion.identity);
            missile.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
            missile.GetComponent<Rigidbody2D>().velocity = direction1 * projectileSpeed;
            s++;
            yield return new WaitForSeconds(.1f);

        }
    }
    



    IEnumerator MoveAfter()
    {
        bossAnim = GetComponent<Animator>();

        // First Attack
        while (transform.position.x != iciclePositions[0].position.x)
        {
            bossAnim.GetComponent<Animator>().Play("Movement");
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(iciclePositions[0].position.x, iciclePositions[0].position.y), moveSpeed * Time.deltaTime);
            yield return null;
        }
        bossAnim.GetComponent<Animator>().Play("Shot1");
        yield return new WaitForSeconds(1f);
        int i = 0;
        while (i < 6)
        {
            

            Vector3 startPosition = transform.position;
            Vector3 direction = (Vector3)target.position - startPosition;
            direction.Normalize();
            float rot_z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            GameObject missile = Instantiate(projectile, startPosition, Quaternion.identity);
            missile.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
            missile.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;
            i++;
            yield return new WaitForSeconds(.1f);
        }
        // second attack
        while (transform.position.x != iciclePositions[2].position.x)
        {
            bossAnim.GetComponent<Animator>().Play("Movement");
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(iciclePositions[2].position.x, iciclePositions[2].position.y), moveSpeed * Time.deltaTime);
            yield return null;
            
        }
        bossAnim.GetComponent<Animator>().Play("Shot2");
        yield return new WaitForSeconds(2f);
        int u = 0;
        while (u < 6)
        {


            Vector3 startPosition1 = transform.position * Random.value;
            Vector3 direction1 = (Vector3)target.position - startPosition1;
            direction1.Normalize();
            float rot_z = Mathf.Atan2(direction1.y, direction1.x) * Mathf.Rad2Deg;
            GameObject missile = Instantiate(projectile, startPosition1, Quaternion.identity);
            missile.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
            missile.GetComponent<Rigidbody2D>().velocity = direction1 * projectileSpeed;
            u++;
            yield return new WaitForSeconds(.1f);

        }
        // third attack
        while (transform.position.x != iciclePositions[1].position.x)
        {
            bossAnim.GetComponent<Animator>().Play("Movement");
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(iciclePositions[1].position.x, iciclePositions[1].position.y), (moveSpeed * Time.deltaTime));
            yield return null;

        }
        bossAnim.GetComponent<Animator>().Play("Shot3");
        yield return new WaitForSeconds(.4f);

        int o = 0;
        while (o < 6)
        {


            Vector3 startPosition1 = transform.position * Random.value;
            Vector3 direction1 = (Vector3)target.position - startPosition1;
            direction1.Normalize();
            float rot_z = Mathf.Atan2(direction1.y, direction1.x) * Mathf.Rad2Deg;
            GameObject missile = Instantiate(projectile, startPosition1, Quaternion.identity);
            missile.transform.localScale = new Vector2(1.5f, 1.5f);
            missile.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
            missile.GetComponent<Rigidbody2D>().velocity = direction1 * projectileSpeed;
            o++;
            yield return new WaitForSeconds(.1f);


        }
        // health give

        while (transform.position.x != iciclePositions[4].position.x)
        {
            bossAnim.GetComponent<Animator>().Play("Movement");
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(iciclePositions[4].position.x, iciclePositions[4].position.y), (moveSpeed * Time.deltaTime));
            yield return null;
        }

        yield return new WaitForSeconds(1f);
        int h = 0;
        while (h < 1)
        {
            Vector3 startPosition = transform.position;
            Vector3 direction = (Vector3)target.position - startPosition;
            direction.Normalize();
            GameObject health = Instantiate(heart, startPosition, Quaternion.identity);

            h++;
            yield return new WaitForSeconds(.1f);

        }
        while (transform.position.x != iciclePositions[3].position.x)
        {
            bossAnim.GetComponent<Animator>().Play("Movement");
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(iciclePositions[3].position.x, iciclePositions[3].position.y), (moveSpeed * Time.deltaTime));
            yield return null;
        }

    }
    
}
