using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WordBank : MonoBehaviour
{

    public String[] wordBank;
    private int wordSelect;
    private int previousWord;
    public TMP_Text text;
    private Char[] chars;

    void Start()
    {     
        previousWord = -1;
        OnWordChange();
    }


    void Update()
    {
        if(Input.GetMouseButtonDown(0)) OnWordChange();
    }

    private void OnWordChange()
    {
        GetWordSelect();
        text.text = wordBank[wordSelect];
        for (int i = 0; i < wordBank[wordSelect].Length; i++)
        {
            chars = wordBank[wordSelect].ToCharArray();
        }

    }



    private int GetWordSelect()
    {
        wordSelect = UnityEngine.Random.Range(0, wordBank.Length);
        while (wordSelect == previousWord) wordSelect = UnityEngine.Random.Range(0, wordBank.Length);
        previousWord = wordSelect;
        return wordSelect;
    }
}
