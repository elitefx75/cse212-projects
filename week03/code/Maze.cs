
using System;
using System.Collections.Generic;

/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represent locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean values representing valid directions.
///
/// If a direction is false, then there is a wall in that direction.
/// If a direction is true, then we can proceed.
///
/// If there is a wall, throw an InvalidOperationException with the message
/// "Can't go that way!". If there is no wall, change currX and currY.
/// </summary>
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    /// <summary>
    /// Check if you can move left. If possible, move left.
    /// Otherwise, throw an InvalidOperationException.
    /// </summary>
    public void MoveLeft()
    {
        if (!_mazeMap[(_currX, _currY)][0])
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        _currX--;
    }

    /// <summary>
    /// Check if you can move right. If possible, move right.
    /// Otherwise, throw an InvalidOperationException.
    /// </summary>
    public void MoveRight()
    {
        if (!_mazeMap[(_currX, _currY)][1])
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        _currX++;
    }

    /// <summary>
    /// Check if you can move up. If possible, move up.
    /// Otherwise, throw an InvalidOperationException.
    /// </summary>
    public void MoveUp()
    {
        if (!_mazeMap[(_currX, _currY)][2])
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        _currY--;
    }

    /// <summary>
    /// Check if you can move down. If possible, move down.
    /// Otherwise, throw an InvalidOperationException.
    /// </summary>
    public void MoveDown()
    {
        if (!_mazeMap[(_currX, _currY)][3])
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        _currY++;
    }

    /// <summary>
    /// Return the current location in the maze.
    /// </summary>
    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}
