using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject filledKey;
    Player player;

    void Start()
    {
        GetPlayerFromScene();
        filledKey.SetActive(false);
    }

    private void GetPlayerFromScene()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        if (player.hasKey)
        {
            filledKey.SetActive(true);
        }
    }
}
