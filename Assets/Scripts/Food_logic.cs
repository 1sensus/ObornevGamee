using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Food_logic : MonoBehaviour
{
    public int Score;
    public Text T_score;
    public string tag_name;
    public GameObject _prefab;
    public GameObject N_obj;
    void Start()
    {
        Score = 0;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {  
        if (collision.gameObject.tag == tag_name)
        {
            Score += 1;
            Destroy(collision.gameObject);
            N_obj = Instantiate(_prefab) as GameObject;
             
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
        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    PlayAnim();
        //}        
    }
    //public void PlayAnim()
    //{
    //    anim.SetTrigger("Play");
    //}
}
