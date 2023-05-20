using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator enemyAnimator, playerAnimator;
    [SerializeField]
    private float speed;
    public bool battleStart;
    private string run;

    // Update is called once per frame
    private Vector3 targetAngle = new Vector3(0f, -5f, 0f);
    private Vector3 currentAngle;
    private void Start()
    {
        currentAngle = transform.eulerAngles;
        run = "Lurus";
        battleStart = false;
        playerAnimator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (run =="Lurus")
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        else if(run=="Belok")
        {
            currentAngle = new Vector3(
            0,
            Mathf.LerpAngle(currentAngle.y, targetAngle.y, speed*Time.deltaTime),
            0);

            transform.eulerAngles = currentAngle;

            transform.position += new Vector3(0, 0, speed * Time.deltaTime);
        }
        
    }

    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        if (other.tag == "CubeCollider")
        {
            print(other.gameObject.name);
            battleStart = true;
            playerAnimator.SetBool("IsIdle", true);
            playerAnimator.SetBool("IsRunning", false);
            this.enabled = false;
            Destroy(other);
            other.gameObject.GetComponent<Enemy_Stats>().enabled=true;
            enemyAnimator = other.transform.parent.GetChild(0).GetComponent<Animator>();
            BattleScript.instance.getEnemyStats(other.gameObject.GetComponent<Enemy_Stats>());
        }

        if (other.tag == "CubeTurn")
        {
            run = "Belok";
        }
    }

}
