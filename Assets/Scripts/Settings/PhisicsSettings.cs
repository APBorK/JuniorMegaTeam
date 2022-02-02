using System.Collections.Generic;
using PlayAria;
using UnityEngine;
using UnityEngine.UI;

namespace Settings
{
    public class PhisicsSettings : MonoBehaviour
    {
        public int ButtonBounce
        {
            get => _buttonBounce;
            set => _buttonBounce = value;
        }

        public int ButtonDropspeed
        {
            get => _buttonDropspeed;
            set => _buttonDropspeed = value;
        }

        public int ButtonDropDelay
        {
            get => _buttonDropDelay;
            set => _buttonDropDelay = value;
        }

        public int ButtonMatchSpeed
        {
            get => _buttonMatchSpeed;
            set => _buttonMatchSpeed = value;
        }

        public int ButtonSpawnVelocity
        {
            get => _buttonSpawnVelocity;
            set => _buttonSpawnVelocity = value;
        }
        [SerializeField] private SpawnSprits _spawnSprits;
        [SerializeField] private FillingThePlayArea _fillingThePlayArea;
        [SerializeField] private List<SpawnPoint> _spawnPoints;
        [SerializeField] private List<float> _timeDrop,_tilesBounce, _matchSpeed;
    

        [SerializeField]
        private List<Button> _buttonsDropSpeed, _buttonsTilesDrop, _buttonsTilesBounce,_buttonsMatchSpeed,_buttonsSpawnVelocity ;

        [SerializeField] private Color _color;
        private int _buttonDropspeed, _buttonSpawnVelocity, _buttonDropDelay, _buttonBounce, _buttonMatchSpeed;

        public void DropSpeed(int button)
        {
            _buttonDropspeed = button;
            Physics2D.gravity = new Vector2(0, -9.8f * 0.5f * (button + 1));
            SelectedButtons(_buttonsDropSpeed,button);
        }
    
        public void SpawnVelocity(int button)
        {
            _buttonSpawnVelocity = button;
            _spawnSprits.Velocity = button;
            SelectedButtons(_buttonsSpawnVelocity,button);
        }
    
        public void TilesDropDelay(int button)
        {
            _buttonDropDelay = button;
            _spawnSprits.Time = _timeDrop[button];
            for (int i = 0; i < _spawnPoints.Count; i++)
            {
                _spawnPoints[i].Delay = _timeDrop[button];
            }
            SelectedButtons(_buttonsTilesDrop, button);
        }
    
        public void TilesBounce(int button)
        {
            _buttonBounce = button;
            _spawnSprits.Material.bounciness = _tilesBounce[button];
            SelectedButtons(_buttonsTilesBounce, button);
        }
    
        public void MatchSpeed(int button)
        {
            _buttonMatchSpeed = button;
            _fillingThePlayArea.DestroyTime = _matchSpeed[button];
            _spawnSprits.DestroyTime = _fillingThePlayArea.DestroyTime;
            SelectedButtons(_buttonsMatchSpeed, button);
        }

        private void SelectedButtons(List<Button> button, int index)
        {
            for (int i = 0; i < button.Count; i++)
            {
                if (index == i)
                {
                    var colorBlock = button[i].colors;
                    colorBlock.normalColor = Color.black;
                    button[i].colors = colorBlock;
                }
                else
                {
                    var colorBlock = button[i].colors;
                    colorBlock.normalColor = _color;
                    button[i].colors = colorBlock;
                }
            }
        }
    }
}
