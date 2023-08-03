using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class Switcher : MonoBehaviour
{
    public Color CColor;
    public Color NCColor;
    public Color Q_E_NCColor;
    public Text Q_text;
    public Text E_text;
    public List<GameObject> players;
    public List<Image> Chars;
    [SerializeField] private CinemachineVirtualCamera[] virtualCameras;
    public int cur_player=0;
    
    void Start()
    {
        CColor.a = 0.8f;
        NCColor.a = 1f;
        for (int i = 0; i < Chars.Count; i++)
        {
            Chars[i].color = CColor;
            players[i].GetComponent<AudioSource>().enabled = false;
        }
        E_text.color = CColor;
        Q_text.color = CColor;
        Chars[0].color = NCColor;
        players[cur_player].GetComponent< AFKmove > ().enabled = false;
        players[cur_player].GetComponent< Move> ().enabled = true;
        players[cur_player].GetComponent<AudioSource>().enabled = true;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (cur_player == 5) { cur_player = -1; }
            cur_player += 1;
            E_text.color = Q_E_NCColor;
            Switch(cur_player);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (cur_player == 0) { cur_player = 6; }
            cur_player -= 1;
            Q_text.color = Q_E_NCColor;
            Switch(cur_player);
        }
        if (Input.GetKeyUp(KeyCode.E)) { 
            E_text.color = NCColor; }
        if (Input.GetKeyUp(KeyCode.Q)) { 
            Q_text.color = NCColor; 
        }

    }
    void Switch(int cur_player) 
    {
        for (int i = 0; i < 6; i++) 
        {
            var script_ = players[i].GetComponent<AFKmove>();
            script_.enabled = true;
            var script_1 = players[i].GetComponent<Move>();
            script_1.enabled = false;
            var script_2 = players[i].GetComponent<UnityEngine.AI.NavMeshAgent>();
            script_2.enabled = true;
            virtualCameras[i].gameObject.SetActive(false);  
            var script_3 = players[i].GetComponent<AudioSource>();
            script_3.enabled = false;
            Chars[i].color = CColor;
            
        }
        Chars[cur_player].color = NCColor;
        players[cur_player].GetComponent<AFKmove>().enabled=false;
        players[cur_player].GetComponent<Move>().enabled = true;
        players[cur_player].GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        players[cur_player].GetComponent<AudioSource>().enabled = true;
        virtualCameras[cur_player].gameObject.SetActive(true);
    }

}
