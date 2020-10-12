using Assets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

internal class TaskService
{
    private readonly string[] playerNames;

    public TaskService(string[] playerNames)
    {
        this.playerNames = playerNames;
        this.ReadTasks();
    }

    private void ReadTasks()
    {
        foreach(var line in File.ReadAllLines("tasks.txt"))         //mit Resources.Load<TextAsset> ersetzen
        {
            tasks.Add(new Task { Text = line });

        }
    }

    private List<Task> tasks = new List<Task>();
        // { new Task { Text="Rettet die Welt. Nein, du hast recht, Universum klingt viel cooler" }    , new Task{Text="Da $ murs an Shot nehma" }, new Task{Text="Da $ übernimmt de nextn 10 Schlücke von $$." } };

    public string RandomTask(string current = null)
    {
        var rand = new Random();
        string task;
        while ((task = tasks[rand.Next(0, tasks.Count() - 1)].Text) == current) ;

        task = task.Replace("$$", playerNames[rand.Next(0, playerNames.Count() - 1)]);
        task = task.Replace("$", playerNames[rand.Next(0, playerNames.Count() - 1)]);       //überprüfen, ob die 2 spieler dieselbe person ist

        return task;
    }




}