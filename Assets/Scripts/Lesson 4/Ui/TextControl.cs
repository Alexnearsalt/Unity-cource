using System;
using TMPro;
using UnityEngine;

public class TextControl : MonoBehaviour
{
    private TMP_Text _text;
    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void Update()
    {

    }

    public void ChangeText(int score, string result)
    {
        _text.text = @$"{score}

{result}";
    }
}
