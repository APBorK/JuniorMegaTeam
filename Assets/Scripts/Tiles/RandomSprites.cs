using System.Collections.Generic;
using PlayAria;
using UnityEngine;
using Random = System.Random;
namespace Tiles
{
    /// <summary>
    /// Selects the type of objects
    /// </summary>
    public class RandomSprites : MonoBehaviour
    {
        
        public List<Figure> SelectedTails
        {
            get => _selectedTails;
            set => _selectedTails = value;
        }

        private List<Figure> _selectedTails,_selectedRecordTails1;
        [SerializeField]
        private SpawnSprits _sprites;
        [SerializeField] private FillingThePlayArea _fillingThePlayArea;




        public void RandomTile(int button)
        {
            var rnd = new Random();
            if (button == 1)
            {
                var tile = rnd.Next(0, 6);
                _sprites.SelectedObjects = new List<Figure>(1);
                _sprites.SelectedObjects.Add(_selectedTails[tile]);
                _fillingThePlayArea.SelectedTails = new List<Figure>(1);
                _fillingThePlayArea.SelectedTails.Add(_selectedTails[tile]);
            }

            if (button != 1)
            {
                _sprites.SelectedObjects = new List<Figure>(button);
                _fillingThePlayArea.SelectedTails = new List<Figure>(button);
                _selectedRecordTails1 = new List<Figure>(button);
                var number = 6;

                for (int i = 0; i < button; i++)
                {
                    var teile = rnd.Next(0, number);
                    _sprites.SelectedObjects.Add(_selectedTails[teile]);
                    _fillingThePlayArea.SelectedTails.Add(_selectedTails[teile]);
                    _selectedRecordTails1.Add(_selectedTails[teile]);
                    _selectedTails.RemoveAt(teile);
                    number--;
                }

                for (int i = 0; i < _selectedRecordTails1.Count; i++)
                {
                    _selectedTails.Add(_selectedRecordTails1[i]);
                }
            }
        }
    }
}
