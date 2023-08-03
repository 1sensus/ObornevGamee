using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.AI.Navigation;

public class Food_logic : MonoBehaviour
{
    public int Score;
    public Text T_score;
    public string tag_name;
    public GameObject Food;
    public List<AudioClip> AudioClips;
    public AudioSource audioSource;
    public float TStart = 10f;

    void Start()
    {
        Food.transform.position = new Vector3(Random.Range(-40, 40), Random.Range(-28, 28), 0.0f);
        audioSource = GetComponent<AudioSource>();
        Score = 0;
    }

    

    void OnCollisionEnter2D(Collision2D collision)
    {  
        if (collision.gameObject.tag == tag_name)
        {
            Score += 1;
            collision.gameObject.transform.position = new Vector3(Random.Range(-40, 40), Random.Range(-28, 28), 0.0f);
            int x = Random.Range(0, AudioClips.Count-2);
            audioSource.clip=AudioClips[x];
            audioSource.Play();
            TStart = 10f;
        }


        if (collision.gameObject.tag == "Inkv")
        {
            audioSource.clip = AudioClips[AudioClips.Count - 2];
            audioSource.Play();
            if (Score < 5)
            {
                Score = 0;
            }
            else
            {
                Score -= 5;
            }
        }
        if (collision.gameObject.tag == "Zadir")
        {
            audioSource.clip = AudioClips[AudioClips.Count-1];
            audioSource.Play();
            if (Score < 3)
            {
                Score = 0;
            }
            else
            {
                Score -= 3;
            }


        }
    }
    void FixedUpdate()
    {
        T_score.text = Score.ToString();
        
        if (true)
        {
            TStart -= Time.deltaTime;

        }
        if (TStart < 0)
        {
            TStart = 10f;
            Food.transform.position = new Vector3(Random.Range(-40, 40), Random.Range(-28, 28), 0.0f);

        }
    }
    
}
