using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boss_logic : MonoBehaviour
{
    public List<GameObject> target_list;
    public Text Timer;
    public List<Sprite> target_image_list;
    public Image cur_target_image;
    public float TStart = 15f;
    public Transform target;
    public GameObject cur_target;
    public int random_index;
    UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        random_index = Random.Range(0, target_list.Count);
        cur_target = target_list[random_index];
        target = cur_target.GetComponent<Transform>();
        cur_target_image.sprite = target_image_list[random_index];
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == cur_target) 
        {
            TStart = 15f;
            random_index = Random.Range(0, target_list.Count);
            cur_target = target_list[random_index];
            target = cur_target.GetComponent<Transform>();
            cur_target_image.sprite = target_image_list[random_index];
        }
    }

    void FixedUpdate()
    {
        
        TStart -= Time.deltaTime;
        if (TStart < 0)
        {
            TStart = 15f;
            random_index = Random.Range(0, target_list.Count);
            cur_target = target_list[random_index];
            target = cur_target.GetComponent<Transform>();
        }
        agent.SetDestination(target.position);
        cur_target_image.sprite = target_image_list[random_index];
        Timer.text = Mathf.Round(TStart).ToString();
    }
}
