using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private float speed;
    public bool battleStart;
    Animator anime;
    Enemy_Stats enemyscript;
    // Update is called once per frame

    private void Start()
    {
        battleStart = false;
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
            battleStart = true;
            anime.SetBool("IsIdle", true);
            this.enabled = false;
            Destroy(other);
            enemyscript = other.gameObject.GetComponent<Enemy_Stats>();
            enemyscript.enabled = true;
        }
    }
}
