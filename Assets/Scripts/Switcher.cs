using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class Switcher : MonoBehaviour
{
    public Color CColor;
    public Color NCColor;
    public Color E_R_NCColor;
    public Text E_text;
    public Text R_text;
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
        }
        R_text.color = CColor;
        E_text.color = CColor;
        Chars[0].color = NCColor;
        players[cur_player].GetComponent< AFKmove > ().enabled = false;
        players[cur_player].GetComponent< Move> ().enabled = true;
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (cur_player == 5) { cur_player = -1; }
            cur_player += 1;
            R_text.color = E_R_NCColor;
            Swirch(cur_player);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (cur_player == 0) { cur_player = 6; }
            cur_player -= 1;
            E_text.color = E_R_NCColor;
            Swirch(cur_player);
        }
        if (Input.GetKeyUp(KeyCode.E)) { E_text.color = NCColor; }
        if (Input.GetKeyUp(KeyCode.R)) { R_text.color = NCColor; }

    }
    void Swirch(int cur_player) 
    {
        for (int i = 0; i < 6; i++) {
            var script_ = players[i].GetComponent<AFKmove>();
            script_.enabled = true;
            var script_1 = players[i].GetComponent<Move>();
            script_1.enabled = false;
            var script_2 = players[i].GetComponent<UnityEngine.AI.NavMeshAgent>();
            script_2.enabled = true;
            virtualCameras[i].gameObject.SetActive(false);
            Chars[i].color = CColor;
            
        }
        Chars[cur_player].color = NCColor;
        players[cur_player].GetComponent<AFKmove>().enabled=false;
        players[cur_player].GetComponent<Move>().enabled = true;
        players[cur_player].GetComponent< UnityEngine.AI.NavMeshAgent>().enabled = false;
        virtualCameras[cur_player].gameObject.SetActive(true);
    }

}
