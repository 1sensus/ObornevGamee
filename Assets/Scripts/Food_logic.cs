using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Food_logic : MonoBehaviour
{
    public int Score;
    public Text T_score;
    public string tag_name;
    public List<AudioClip> AudioClips;
    public AudioSource audioSource;
    void Start()
    {

        audioSource = GetComponent<AudioSource>();
        Score = 0;
    }
    

    void OnCollisionEnter2D(Collision2D collision)
    {  
        if (collision.gameObject.tag == tag_name)
        {
            Score += 1;
            collision.gameObject.transform.position = new Vector3(Random.Range(-40, 40), Random.Range(-28, 28), 0.0f);
            int x = Random.Range(0, AudioClips.Count);
            audioSource.clip=AudioClips[x];
            audioSource.Play();

        }


        if (collision.gameObject.tag == "Inkv")
        {
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
                     
    }
    
}
