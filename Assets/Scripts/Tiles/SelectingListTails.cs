using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Tiles
{
    public class SelectingListTails : MonoBehaviour
    {
        public int IndexTil
        {
            get => _indexTil;
            set => _indexTil = value;
        }

        [SerializeField] private List<Figure> _tiles = new List<Figure>();
        [SerializeField] private RandomSprites _randomSprites;
        [SerializeField] private List<Button> _buttonsTiles = new List<Button>();
        [SerializeField] private Color _color;
        private int _indexTil;
    
        public void SelectedObj(int button)
        {
            _indexTil = button;
            Record(_tiles);
            SelectedButtons(_buttonsTiles, button);
        }

        private void Record(List<Figure> tails)
        {
            _randomSprites.SelectedTails = new List<Figure>(6);
            for (int i = 0; i < tails.Count; i++)
            {
                _randomSprites.SelectedTails.Add(tails[i]);
            }
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
