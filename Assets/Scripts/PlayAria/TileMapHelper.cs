using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlayAria
{
    /// <summary>
    /// Hex grid
    /// </summary>
    public class TileMapHelper : MonoBehaviour
    {
        public GameObject HexFront
        {
            get => _hexFront;
            set => _hexFront = value;
        }
    
        [SerializeField]
        private Grid _grid;
        [SerializeField]
        private GameObject _hexFront;
        [SerializeField] private int _height, _width;
        private List<GameObject> _hexList = new List<GameObject>();
        private bool _spawn;

        private void Start()
        {
            SpawnHex();
        }

        private IEnumerable<Vector3Int> GetCellsAround(Vector3Int cell)
        {
            yield return new Vector3Int(cell.x, cell.y , cell.z);

            for (int i = 1; i < _height; i++)
            {
                yield return new Vector3Int(cell.x, cell.y + i, cell.z);
                yield return new Vector3Int(cell.x, cell.y - i, cell.z);
                yield return new Vector3Int(cell.x + i, cell.y, cell.z);
                yield return new Vector3Int(cell.x - i, cell.y, cell.z);
                for (int j = 1; j < _width; j++)
                {
                    yield return new Vector3Int(cell.x - j, cell.y + i, cell.z);
                    yield return new Vector3Int(cell.x + j, cell.y - i, cell.z);
                    yield return new Vector3Int(cell.x + i, cell.y + j, cell.z);
                    yield return new Vector3Int(cell.x - i, cell.y - j, cell.z);
                }
            }
        }

        public void SpawnHex()
        {
            if (_spawn != false)
            {
                DestroyObj();
                _spawn = false;
            }
            Vector3Int cellPosition = _grid.LocalToCell(Vector3.zero);
            foreach (var around in GetCellsAround(cellPosition))
            {
                _hexList.Add(Instantiate(_hexFront,gameObject.transform));
                _hexFront.transform.position = _grid.GetCellCenterLocal(around);
            }
            _spawn = true;
        }

        public void DestroyObj()
        {
            for (int i = 0; i < _hexList.Count; i++)
            {
                Destroy(_hexList[i]);
            }
        }
    }
}
