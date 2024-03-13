using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    [SerializeField] GameObject enemybulletPrefab;
    private GameObject enemybullet;

    public float speed = 3.0f;
    public float obstaclerange = 5.0f;

    private bool isAlive;

    private void Start()
    {
        isAlive = true;
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {   if (isAlive)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hit;

        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;
            if (hitObject.GetComponent<PlayerChracter>())
            {
                Debug.Log("Detected Obstacle");


                if (enemybullet == null)
                {
                    enemybullet = Instantiate(enemybulletPrefab) as GameObject;
                    enemybullet.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                    enemybullet.transform.rotation = transform.rotation;
                }
                
            }

            else if (hit.distance < obstaclerange)
            {
                float angle = Random.Range(-110, 100);
                transform.Rotate(0, angle, 0);
            }
        }
        
    }

    public void Setalive(bool alive)
    {
        isAlive = alive;
    }
}
