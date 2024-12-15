using System;
using System.Net.NetworkInformation;
using System.Text.Json.Serialization;
using Avalonia.Input;
using Digger.Architecture;

namespace Digger;

public class Terrain : ICreature
{
    public CreatureCommand Act(int x, int y)
    {
        return new CreatureCommand { DeltaX = 0, DeltaY = 0 };
    }

    public bool DeadInConflict(ICreature conflictedObject)
    {
        return true;
    }

    public int GetDrawingPriority()
    {
        return 1;
    }

    public string GetImageFileName()
    {
        return "Terrain.png";
    }
}

public class Player : ICreature
{
    public CreatureCommand Act(int x, int y) 
    {
        var command = new CreatureCommand();
        var position = new CreatureCommand() { DeltaX = x, DeltaY = y };

        switch (Game.KeyPressed)
        {
            case Key.Up:
                if (position.DeltaY > 0 && Game.Map[x, y -1] is not Sack) command.DeltaY -= 1;
                break;
            case Key.Down:
                if (position.DeltaY < Game.MapHeight - 1 && Game.Map[x, y + 1] is not Sack) command.DeltaY += 1;
                break;
            case Key.Right:
                if (position.DeltaX < Game.MapWidth - 1 && Game.Map[x + 1, y] is not Sack) command.DeltaX += 1;
                break;
            case Key.Left:
                if (position.DeltaX > 0 && Game.Map[x - 1, y] is not Sack) command.DeltaX -= 1;
                break;
        }
        return command;
    }

    public bool DeadInConflict(ICreature conflictedObject)
    {      
        if (conflictedObject is Sack || conflictedObject is Monster){
            return true;
        }
        return false;
    }

    public int GetDrawingPriority()
    {
        return 1;
    }

    public string GetImageFileName()
    {
        return "Digger.png";
    }
}

public class Sack : ICreature
{
    private bool atRest = true;
    private bool criticalDrop = false;


    public CreatureCommand Act(int x, int y)
    {
        if (y < Game.MapHeight - 1) 
        {
            if (atRest)
            {
                if (Game.Map[x, y + 1] is null)
                {
                    atRest = false;
                    return new CreatureCommand { DeltaY = 1 };
                }
            }
            else 
            {
                if (Game.Map[x, y + 1] is null || Game.Map[x, y + 1] is Player || Game.Map[x, y + 1] is Monster)
                {
                    criticalDrop = true;
                    return new CreatureCommand { DeltaY = 1 };
                }
                else if(criticalDrop)
                {
                    return new CreatureCommand { TransformTo = new Gold() };
                }
            }
        }
        else if (!atRest && criticalDrop)
        {
            return new CreatureCommand { TransformTo = new Gold() };
        }
        atRest = true;
        criticalDrop = false;
        return new CreatureCommand();
    }

    public bool DeadInConflict(ICreature conflictedObject)
    {
        return false;
    }

    public int GetDrawingPriority()
    {
        return 1;
    }

    public string GetImageFileName()
    {
        return "Sack.png";
    }
}
public class Gold : ICreature
{
    public CreatureCommand Act(int x, int y)
    {
        return new CreatureCommand();
    }

    public bool DeadInConflict(ICreature conflictedObject)
    {
        if(conflictedObject is Player)
        {
            Game.Scores += 10;
        }
        return true;
    }

    public int GetDrawingPriority()
    {
        return 1;
    }

    public string GetImageFileName()
    {
        return "Gold.png";
    }
}
public class Monster : ICreature
{
    private int[] FindPlayer()
    {
        for(int i = 0; i < Game.Map.GetLength(0); i++)
        {
            for(int j = 0; j < Game.Map.GetLength(1); j++)
            {
                if (Game.Map[i, j] is Player)
                {
                    return new int[] { i, j };
                }
            }
        }
        return null;
    }

    private bool CheckPosition(int x, int y)
    {
        ICreature ObjectAtPosition = Game.Map[x, y];
        switch (ObjectAtPosition)
        {
            case Sack:
                return false;
            case Terrain:
                return false;
            case Monster:
                return false;
        }
        return true;
    }

    public CreatureCommand Act(int x, int y)
    {
        var command = new CreatureCommand();
        var positionPlayer = FindPlayer();        

        if(positionPlayer != null)
        {
            command.DeltaX = -x.CompareTo(positionPlayer[0]);
            command.DeltaY = -y.CompareTo(positionPlayer[1]);
            if (!CheckPosition(x + command.DeltaX, y)) command.DeltaX = 0;
            if (!CheckPosition(x, y + command.DeltaY)) command.DeltaY = 0;
        }
        return command;
    }

    public bool DeadInConflict(ICreature conflictedObject)
    {
        if(conflictedObject is Sack || conflictedObject is Monster)
        {
            return true;
        }
        return false;
    }

    public int GetDrawingPriority()
    {
        return 1;
    }

    public string GetImageFileName()
    {
        return "Monster.png";
    }
}