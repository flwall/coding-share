﻿using System;
using System.Collections.Generic;
using System.Linq;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public InputField InputPrefab;

    private List<InputField> names = new List<InputField>();


    // Start is called before the first frame update
    void Start()
    {

        var start = Instantiate(this.InputPrefab, this.transform, false);


        names.Add(start);

    }

    // Update is called once per frame
    void Update()
    {

    }

    




    public void StartClicked()
    {
        GameController.PlayerNames = names.Select(f => f.text).ToArray();       //.Select is des gleiche wie a viel längere foreach-Schleife
                                                                                //, die bei jedem InputField den Text nimmt und ihn zu den "PlayerNames" hinzufügt.

        SceneManager.LoadScene("GameScene");
    }
    public void RmClicked()
    {
        if (names.Any())
        {
            var toRm = names[names.Count - 1];
            Destroy(toRm.gameObject);
            names.Remove(toRm);
        }


    }
    public void AddClicked()
    {

        //var transform = InputPrefab.transform;

        var clone = Instantiate(this.InputPrefab, this.transform, true);
        clone.transform.localPosition = new Vector3(0, 90 - 30 * (names.Count), 0);
        
        EventSystem.current.SetSelectedGameObject(clone.gameObject);
        
        names.Add(clone);


    }
}
