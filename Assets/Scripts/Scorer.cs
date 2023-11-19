using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scorer : MonoBehaviour
{

    [SerializeField] private Player player;
    [SerializeField] private TMP_Text text;

    private void Update( )
    {
        text.text = "Score: " + player.bestZDistance;
    }
}
