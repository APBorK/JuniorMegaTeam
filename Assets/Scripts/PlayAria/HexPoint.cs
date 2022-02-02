using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Creates capture points in a hex
/// </summary>
public class HexPoint : MonoBehaviour
{
    public Action<List<GameObject>> OnSpawn;
    public List<GameObject> HexPointAll
    {
        get => _hexPointAll;
        set => _hexPointAll = value;
    }
    
    public int GameColumn
    {
        get => _gameColumn;
        set => _gameColumn = value;
    }
    public int FirstPoint1
    {
        get => _firstPoint1;
        set => _firstPoint1 = value;
    }
    public int FirstPoint2
    {
        get => _firstPoint2;
        set => _firstPoint2 = value;
    }
    public int LastPoint
    {
        get => _lastPoint;
        set => _lastPoint = value;
    }
    public int LineWidth
    {
        get => _lineWidth;
        set => _lineWidth = value;
    }
    
    [SerializeField] private Grid _grid;

    [SerializeField] private GameObject _hexPoint, _gridObj;
    private List<GameObject> _hexPointAll;
    private int _gameColumn,_firstPoint1,_firstPoint2,_lastPoint,_lineWidth;

    public void SpawnPoint()
    {
        _hexPointAll = new List<GameObject>(128);
        Vector3Int cellPosition = _grid.WorldToCell(Vector3.zero);
        foreach (var around in GetCellsAround(cellPosition))
        {
            var hexPoint = Instantiate(_hexPoint, _gridObj.transform);
            _hexPoint.transform.position = _grid.GetCellCenterWorld(around);
            _hexPointAll.Add(hexPoint);
        }
        
        //OnSpawn.Invoke(_hexPointAll);
    }

    private IEnumerable<Vector3Int> GetCellsAround(Vector3Int cell)
    {
        for (int i = 0; i < GameColumn; i++)
        {
            if (i % 2 == 0)
            {
                for (int j = 0; j < LineWidth; j++)
                {
                    yield return new Vector3Int(cell.x + j - FirstPoint1, cell.y + i - LastPoint, cell.z);
                }
            }
            else
            {
                for (int j = 0; j < LineWidth - 1; j++)
                {
                    yield return new Vector3Int(cell.x + j - FirstPoint2, cell.y + i - LastPoint, cell.z);
                }
            }  
        }   
    }
}
