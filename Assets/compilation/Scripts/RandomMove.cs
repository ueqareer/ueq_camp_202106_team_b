using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

[RequireComponent(typeof(NavMeshAgent))]
public class RandomMove : MonoBehaviour
{
    public Transform central;
    public GameObject childframe;
    public GameObject childphrase;
    public GameObject megb;
    public GameObject nextgb;
    public AudioClip audioclip1;
    public AudioClip audioclip2;
    public AnimationClip[] faceanimations;

    private AudioSource audiosource;
    private bool isGUI = true;
    private Text text;
    private NavMeshAgent agent;
    private Quaternion rotation;
    private int charnum = 0;
    [SerializeField] float updtime = 0;
    [SerializeField] float radius = 3;
    [SerializeField] float waitTime = 5;
    [SerializeField] float time = 0;
    [SerializeField] float frameActiveTime = 0;
    [SerializeField] float step = 1f;
    Animator anim;
    Vector3 pos;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        agent.autoBraking = false;
        agent.updateRotation = false;
        text = childphrase.GetComponent<Text>();
        audiosource = gameObject.GetComponent<AudioSource>();

        GotoNextPoint();
    }

    void GotoNextPoint()
    {
        agent.isStopped = false;
        float posX = Random.Range(-1 * radius, radius);
        float posZ = Random.Range(-1 * radius, radius);

        pos = central.position;
        pos.x += posX;
        pos.z += posZ;

        Vector3 direction = new Vector3(pos.x, transform.position.y, pos.z);
        rotation = Quaternion.LookRotation(direction - transform.position, Vector3.up);
        //transform.rotation = rotation;
        agent.destination = pos;
    }

    void StopHere()
    {
        agent.isStopped = true;
        time += Time.deltaTime;
        frameActiveTime += Time.deltaTime;
        if(time > waitTime)
        {
            GotoNextPoint();
            time = 0;
        }
    }


    // Update is called once per frame
    void Update()
    {
        updtime += Time.deltaTime;

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            StopHere();

        anim.SetFloat("Blend", agent.velocity.sqrMagnitude);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, step);

        if(updtime > 2.5)
        {
            childframe.SetActive(false);
        }
        if(updtime > 5)
        {
            anim.CrossFade(faceanimations[2].name, 0);
        }

    }
   private void OnGUI()
    {
        if (isGUI)
        {/*
            GUI.Box(new Rect(Screen.width - 110, 10, 100, 120), "Motion");
            if (GUI.Button(new Rect(Screen.width - 100, 40, 80, 20), "homeru"))
            {
                anim.SetTrigger("jump");
                text.text = "がんばったね！";
                anim.CrossFade(faceanimations[0].name, 0);
                audiosource.clip = audioclip;
                audiosource.Play();
                updtime = 0;
                childframe.SetActive(true);
                frameActiveTime = 0;

                agent.isStopped = false;
                pos = central.position;
                pos.z = 2.0f;
                Vector3 direction = new Vector3(pos.x, transform.position.y, pos.z);
                rotation = Quaternion.LookRotation(direction - transform.position, Vector3.up);
                agent.destination = pos;
            }
            if (GUI.Button(new Rect(Screen.width - 100, 70, 80, 20), "homeru"))
            {
                anim.SetTrigger("scold");
                text.text = "こら！";
                anim.CrossFade(faceanimations[1].name, 0);
                audiosource.clip = audioclip;
                audiosource.Play();
                updtime = 0;
                childframe.SetActive(true);
                frameActiveTime = 0;

                agent.isStopped = false;
                pos = central.position;
                pos.z = 2.0f;
                Vector3 direction = new Vector3(pos.x, transform.position.y, pos.z);
                rotation = Quaternion.LookRotation(direction - transform.position, Vector3.up);
                agent.destination = pos;
            }
            if (GUI.Button(new Rect(Screen.width - 100, 100, 80, 20), "changeModel"))
            {
                nextgb.SetActive(true);
                megb.SetActive(false);
            }*/
        }
    }

    public void compliment()
    {
        anim.SetTrigger("jump");
        text.text = "がんばったね！";
        anim.CrossFade(faceanimations[0].name, 0);
        audiosource.clip = audioclip1;
        audiosource.Play();
        updtime = 0;
        childframe.SetActive(true);
        frameActiveTime = 0;

        agent.isStopped = false;
        pos = central.position;
        pos.z = 2.0f;
        Vector3 direction = new Vector3(pos.x, transform.position.y, pos.z);
        rotation = Quaternion.LookRotation(direction - transform.position, Vector3.up);
        agent.destination = pos;
    }
    public void scold()
    {
        anim.SetTrigger("scold");
        text.text = "こら！";
        anim.CrossFade(faceanimations[1].name, 0);
        audiosource.clip = audioclip2;
        audiosource.Play();
        updtime = 0;
        childframe.SetActive(true);
        frameActiveTime = 0;

        agent.isStopped = false;
        pos = central.position;
        pos.z = 2.0f;
        Vector3 direction = new Vector3(pos.x, transform.position.y, pos.z);
        rotation = Quaternion.LookRotation(direction - transform.position, Vector3.up);
        agent.destination = pos;
    }
    public void changeCharacter()
    {
        nextgb.SetActive(true);
        megb.SetActive(false);
    }
}
