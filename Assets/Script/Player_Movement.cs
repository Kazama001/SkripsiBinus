using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private float speed;


    Animator anime;
    // Update is called once per frame

    private void Start()
    {
        anime = GetComponent<Animator>();
    }

    void Update()
    {
        transform.position += new Vector3(speed, 0, 0);

    }

    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        if (other.tag == "CubeCollider")
        {
            print("ada");
            anime.SetBool("IsIdle", true);
            this.enabled = false;
            
        }
    }
}
