using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using ObjectPool;
using PlayAria;
using Tiles;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

/// <summary>
/// Responsible for object creation
/// </summary>
public class SpawnSprits : MonoBehaviour
{
    public List<Figure> SelectedObjects
    {
        get => _selectedObjects;
        set => _selectedObjects = value;
    }

    public float Time
    {
        get => _time;
        set => _time = value;
    }
    
    public PhysicsMaterial2D Material
    {
        get => _material;
        set => _material = value;
    }
    
    public float DestroyTime
    {
        get => _destroyTime;
        set => _destroyTime = value;
    }
    
    public float Velocity
    {
        get => _velocity;
        set => _velocity = value;
    }

    public List<GameObject> Game
    {
        get => _game;
        set => _game = value;
    }
    [SerializeField] private PhysicsMaterial2D _material;
    [SerializeField] 
    private List<SpawnPoint> _spawnPoint;
    [SerializeField] private SelectingListTails _selectingListTails;
    [SerializeField] private ObjectPooler _object;
    [SerializeField] private PooledObjectType[] _objectw;
    private List<Figure> _selectedObjects = new List<Figure>();
    private List<GameObject> _game = new List<GameObject>();
    private float _time, _destroyTime, _oldDestroyTime, _velocity;
    private int _oldIndex;
    private Coroutine _currentCoroutine;
    private int _numObjectsToSpawn;

    private void Start()
    {
        _oldDestroyTime = _destroyTime;
    }
    
    private void FixedUpdate()
    {
        if (_game != null)
        {
            if (_selectingListTails.IndexTil != _oldIndex)
            {
                for (int i = 0; i < _game.Count; i++)
                {
                    if (_game[i] != null)
                    {
                        _game[i].GetComponent<VersionTails>().SelectedTailsVersion(_selectingListTails.IndexTil);
                    }
                }

                _oldIndex = _selectingListTails.IndexTil;
            }

        }

        if (_destroyTime != _oldDestroyTime)
        {
            for (int i = 0; i < _game.Count; i++)
            {
                if (_game[i] != null)
                {
                    _game[i].GetComponent<DestroyObject>().DestroyTime = _destroyTime;
                }
            }

            _oldDestroyTime = _destroyTime;
        }
        
        if (_numObjectsToSpawn > 0 && _SpawnObject())
        {
            _numObjectsToSpawn -= 1;
        }
    }

    public void SpawnTile(int button)
    {
        DestroyObj();
        if (button == 1)
        {
            if (_selectedObjects != null)
            {
                _currentCoroutine = StartCoroutine(Spawn(1));
            }
            else
            {
                Debug.Log("Select pre-set");
            }
        }

        else
        {
            if (_selectedObjects != null)
            {
                _currentCoroutine = StartCoroutine(Spawn(button));
            }
            else
            {
                Debug.Log("Select pre-set");
            }
        }
    }

    private IEnumerator Spawn(int cycle)
    {
        for (int i = 0; i < cycle; i++)
        {
            SpawnObject();
            yield return new WaitForSeconds(_time);
        }
    }

    private SpawnPoint GetRandomSpawnPoint()
    {
        var availableSpawnPoints = _spawnPoint.FindAll(p => p.IsSpawnTime);

        if (availableSpawnPoints.Count == 0) {
            return null;
        }

        return availableSpawnPoints[Random.Range(0, availableSpawnPoints.Count)];
    }
    
    public void SpawnObject()
    {
        _numObjectsToSpawn += 1;
    }

    public bool _SpawnObject()
    {
        var indexSpite = Random.Range(0, _selectedObjects.Count);
        var spawnPoint = GetRandomSpawnPoint();
        if (spawnPoint == null) 
        {
            return false;
        }
        var obj =_object.SpawnFromPool(_objectw[indexSpite],spawnPoint.GetPosition(),new Quaternion());
        var rgb = obj.GetComponent<Rigidbody2D>();
        var des = obj.GetComponent<DestroyObject>();
        rgb.velocity = new Vector2(0,-_velocity);
        for (int i = 0; i < des.Capsule.Count; i++)
        {
            des.Capsule[i].sharedMaterial = _material;
        }

        des.GetComponent<VersionTails>().SelectedTailsVersion(_selectingListTails.IndexTil);
        des.DestroyTime = _destroyTime;

        _game.Add(obj);
        obj.GetComponent<DestroyObject>().OnDead += SpawnObject;
        return true;
    }

    private void OnDestroy()
    {
        if (_game != null)
        {
            foreach (var game in _game)
            {
                if (game != null)
                {
                    game.GetComponent<DestroyObject>().OnDead -= SpawnObject;
                }
            } 
        }
        
    }


    private void StopCoroutine()
    {
        if (_currentCoroutine != null) 
        {
            StopCoroutine(_currentCoroutine); 
            _currentCoroutine = null;
        }
    }
    
    public void DestroyObj()
    {
        StopCoroutine();
        
        for (int i = 0; i < _game.Count; i++)
        {
            _game[i].SetActive(false);
        }
        _game.Clear();
    }
}
