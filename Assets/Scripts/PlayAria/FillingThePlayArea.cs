using System.Collections.Generic;
using ObjectPool;
using Tiles;
using UnityEngine;
using Random = System.Random;

namespace PlayAria
{
    /// <summary>
    /// The entire play area in sprites
    /// </summary>
    public class FillingThePlayArea : MonoBehaviour
    {
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
    
        public float DestroyTime
        {
            get => _destroyTime;
            set => _destroyTime = value;
        }

        public List<Figure> SelectedTails
        {
            get => _selectedTails;
            set => _selectedTails = value;
        }


        [SerializeField] private List<int> _gameRotation = new List<int>();
        [SerializeField]
        private Grid _grid;
        [SerializeField] private SpawnSprits _sprits;
        [SerializeField] private ObjectPooler _object;
        [SerializeField] private PooledObjectType[] _objectw;
        [SerializeField] private SelectingListTails _selectingListTails;
        private int _gameColumn,_firstPoint1,_firstPoint2,_lastPoint,_lineWidth;
        private List<Figure> _selectedTails = new List<Figure>();
        private float _destroyTime;
        


        public void SpawnTile(int button)
        {
            if (_sprits.Game != null)
            {
                _sprits.DestroyObj();
            }
            var rnd = new Random();
            Vector3Int cellPosition = _grid.WorldToCell(Vector3.zero);
            foreach (var around in GetCellsAround(cellPosition))
            {
                var sprites = rnd.Next(0, _selectedTails.Count);
                var obj =_object.SpawnFromPool(_objectw[sprites],_grid.GetCellCenterWorld(around),Quaternion.Euler(0, 0, _gameRotation[rnd.Next(0,_gameRotation.Count)]));
                obj.GetComponent<DestroyObject>().DestroyTime = _destroyTime;
                obj.GetComponent<DestroyObject>().OnDead += _sprits.SpawnObject;
                obj.GetComponent<VersionTails>().SelectedTailsVersion(_selectingListTails.IndexTil);
                _sprits.Game.Add(obj);
            }
        }

        private IEnumerable<Vector3Int> GetCellsAround(Vector3Int cell)
        {
            for (int i = 0; i < _gameColumn; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < _lineWidth; j++)
                    {
                        yield return new Vector3Int(cell.x + j - _firstPoint1, cell.y + i - _lastPoint, cell.z);
                    }
                }
                else
                {
                    for (int j = 0; j < _lineWidth - 1; j++)
                    {
                        yield return new Vector3Int(cell.x + j - _firstPoint2, cell.y + i - _lastPoint, cell.z);
                    }
                }  
            }   
        }
    
        private void OnDestroy()
        {
            if (_sprits.Game != null)
            {
                foreach (var game in _sprits.Game)
                {
                    if (game != null)
                    {
                        game.GetComponent<DestroyObject>().OnDead -= _sprits.SpawnObject;
                    }
                } 
            }
        }
    }
}
