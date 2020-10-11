using System;
using System.Linq;

internal class TaskService
{
    private readonly string[] playerNames;

    public TaskService(string[] playerNames)
    {
        this.playerNames = playerNames;
    }

    private readonly string[] tasks = new string[] { "Rettet die Welt. Nein, du hast recht, Universum klingt viel cooler", "Da $ murs an Shot nehma", "Da $ übernimmt de nextn 10 Schlücke von $$." };

    public string RandomTask(string current = null)
    {
        var rand = new Random();
        string task;
        while ((task = tasks[rand.Next(0, tasks.Count() - 1)]) == current) ;

        task = task.Replace("$$", playerNames[rand.Next(0, playerNames.Count() - 1)]);
        task = task.Replace("$", playerNames[rand.Next(0, playerNames.Count() - 1)]);

        return task;
    }
}