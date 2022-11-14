using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface MoveBehavior
{
    /// <summary>
    /// Move unit into a new cell
    /// </summary>
    /// <param name="self">Unit being moved (composed with this move behavior)</param>
    /// <param name="cell_">new cell</param>
    void move(Unit self, Cell cell_);
}
