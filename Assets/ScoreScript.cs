using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Text _ScoreText;

    public void SetScoreText(string Text)
    {
        _ScoreText.text= Text;

    }
    
}