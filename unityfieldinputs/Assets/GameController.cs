using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using System;
using System.Threading.Tasks;
using UnityEngine.Assertions;

public class GameController : MonoBehaviour
{
    public static string[] PlayerNames { get; set; }

    public Text _currentText;      //versteh nd

    private TaskService taskService;

    // Start is called before the first frame update
    void Start()
    {
        taskService = new TaskService(PlayerNames);

        Assert.IsNotNull(_currentText, "Text Field should not be null");
        
        _currentText.text = SwipeToNextTask();

        Debug.Log($"List of all Players: {string.Join(",", PlayerNames)}");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Assert.IsNotNull(_currentText, "Text Field should not be null");
            _currentText.text = SwipeToNextTask();
        }
    }

    private string SwipeToNextTask()
    {

        return taskService.RandomTask(current: _currentText.text);
        
    }
}
