using System.Collections.Generic;
using PlayAria;
using Tiles;
using UnityEngine;
using UnityEngine.UI;

namespace Settings
{
    public class ScreenWidthSettings : MonoBehaviour
    {
        public int ButtonSreen
        {
            get => _buttonSreen;
            set => _buttonSreen = value;
        }
        [SerializeField] private Grid _gridBack, _gridPlay;
        [SerializeField] private TileMapHelper _tileMapHelper;
        [SerializeField] private FillingThePlayArea _fillingThePlayArea;
        [SerializeField] private GameObject _wallRight, _wallLeft,_wall, _bottomUI, _topUI, _hexLeft, _hexRight;
        [SerializeField] private List<Button> _buttonsScreen;
        [SerializeField] private Color _color;
        [SerializeField] private List<Vector3> _gridScale;
        [SerializeField] private List<int> _gameColum, _lineWidth, _firstPoint1, _firstPoint2, _lastPoint,_numberCollider;
        [SerializeField] private List<float> _circleRadius,offsetCollider;
        [SerializeField] private List<Vector2> _startPositionCollider;

        private int _buttonSreen;
        private bool _spawn;

        public void Screen(int button)
        {
            SelectedButtons(_buttonsScreen,button);
            _buttonSreen = button;
            _gridBack.transform.localScale = _gridScale[button];
            _gridPlay.transform.localScale = _gridScale[button];
            _fillingThePlayArea.GameColumn = _gameColum[button];
            _fillingThePlayArea.LineWidth = _lineWidth[button];
            _fillingThePlayArea.FirstPoint1 = _firstPoint1[button];
            _fillingThePlayArea.FirstPoint2 = _firstPoint2[button];
            _fillingThePlayArea.LastPoint = _lastPoint[button];
            CreateCircleCollider(_startPositionCollider[button],offsetCollider[button],_circleRadius[button],_numberCollider[button]);
        
            switch (button)
            {
                case 1:
                    SelectedButtons(_buttonsScreen,button);
                    _buttonSreen = button;
                    _gridBack.transform.localScale = _gridScale[button];
                    _gridPlay.transform.localScale = _gridScale[button];
                    _fillingThePlayArea.GameColumn = 15;
                    _fillingThePlayArea.LineWidth = 9;
                    _fillingThePlayArea.FirstPoint1 = 4;
                    _fillingThePlayArea.FirstPoint2 = 4;
                    _fillingThePlayArea.LastPoint = 8;
                    _wall.GetComponent<EdgeCollider2D>().edgeRadius = 0.24f;
                    _wall.GetComponent<EdgeCollider2D>().offset = new Vector2(0,0.03f);
                    _wall.GetComponent<EdgeCollider2D>().points = new[]
                    {
                        new Vector2(-0.417669863f,0.409110993f),
                        new Vector2(-0.37127766f,0.135407597f),
                        new Vector2(-0.326680511f,0.409327447f),
                        new Vector2(-0.282495916f,0.133399457f),
                        new Vector2(-0.234853029f,0.409545958f),
                        new Vector2(-0.190272093f,0.140296906f),
                        new Vector2(-0.143021271f,0.409764469f),
                        new Vector2(-0.0994277522f,0.129386187f),
                        new Vector2(-0.0511920974f,0.409982979f),
                        new Vector2(-0.00721001998f,0.134052873f),
                        new Vector2(0.0391953252f,0.410198122f),
                        new Vector2(0.0856959298f,0.134270906f),
                        new Vector2(0.13027595f,0.410414934f),
                        new Vector2(0.179982796f,0.134486794f),
                        new Vector2(0.221682578f,0.410632521f),
                        new Vector2(0.270826101f,0.123574555f),
                        new Vector2(0.314347833f,0.410853177f),
                        new Vector2(0.358917534f,0.108219832f),
                        new Vector2(0.405031949f,0.411069274f)
                    };
                
                    break;
                case 2:
                    SelectedButtons(_buttonsScreen,button);
                    _buttonSreen = button;
                    _gridBack.transform.localScale = _gridScale[button];
                    _gridPlay.transform.localScale = _gridScale[button];
                    _fillingThePlayArea.GameColumn = 14;
                    _fillingThePlayArea.LineWidth = 10;
                    _fillingThePlayArea.FirstPoint1 = 5;
                    _fillingThePlayArea.FirstPoint2 = 4;
                    _fillingThePlayArea.LastPoint = 9;
                    _wallRight.transform.position = new Vector2(2.4f,_wallRight.transform.position.y);
                    _wallLeft.transform.position = new Vector2(-2.362f,_wallLeft.transform.position.y);
                    _wall.GetComponent<EdgeCollider2D>().edgeRadius = 0.19f;
                    _wall.GetComponent<EdgeCollider2D>().offset = new Vector2(0,-0.03f);
                    _wall.GetComponent<EdgeCollider2D>().points = new[]
                    {
                        new Vector2(-0.423006564f,0.493870556f),
                        new Vector2(-0.37636131f,0.0464324653f),
                        new Vector2(-0.340473831f,0.493870646f),
                        new Vector2(-0.300020337f,0.080201447f),
                        new Vector2(-0.257608026f,0.493870795f),
                        new Vector2(-0.215849519f,0.0759804249f),
                        new Vector2(-0.173437193f,0.493870944f),
                        new Vector2(-0.127111435f,0.0844228268f),
                        new Vector2(-0.089266941f,0.493871123f),
                        new Vector2(-0.0455505811f,0.0823123157f),
                        new Vector2(-0.00574861281f,0.493871272f),
                        new Vector2(0.0340527855f,0.0823127329f),
                        new Vector2(0.0764646381f,0.493871272f),
                        new Vector2(0.116918623f,0.0928654671f),
                        new Vector2(0.161287948f,0.493871272f),
                        new Vector2(0.205656856f,0.0928654671f),
                        new Vector2(0.24480629f,0.493871272f),
                        new Vector2(0.282650292f,0.135076523f),
                        new Vector2(0.328324586f,0.493871272f),
                        new Vector2(0.37008357f,0.200503826f),
                        new Vector2(0.41380021f,0.493871123f),
                        new Vector2(0.496737599f,0.493870705f),
                    };
                    break;
                case 3:
                    SelectedButtons(_buttonsScreen,button);
                    _buttonSreen = button;
                    _gridBack.transform.localScale = _gridScale[button];
                    _gridPlay.transform.localScale = _gridScale[button];
                    _fillingThePlayArea.GameColumn = 12;
                    _fillingThePlayArea.LineWidth = 11;
                    _fillingThePlayArea.FirstPoint1 = 5;
                    _fillingThePlayArea.FirstPoint2 = 5;
                    _fillingThePlayArea.LastPoint = 10;
                    _wall.GetComponent<EdgeCollider2D>().edgeRadius = 0.19f;
                    _wall.GetComponent<EdgeCollider2D>().offset = new Vector2(0,-0.03f);
                    _wall.GetComponent<EdgeCollider2D>().points = new[]
                    {
                        new Vector2(-0.530884743f,0.133201152f),
                        new Vector2(-0.435285002f,0.480275989f),
                        new Vector2(-0.389914751f,0.0790131688f),
                        new Vector2(-0.355465323f,0.479449213f),
                        new Vector2(-0.316681713f,-0.0125032365f),
                        new Vector2(-0.276641846f,0.484385908f),
                        new Vector2(-0.242707714f,-0.0394694209f),
                        new Vector2(-0.1996907f,0.481696606f),
                        new Vector2(-0.151733086f,-0.0978740156f),
                        new Vector2(-0.121146016f,0.480325729f),
                        new Vector2(-0.0848387778f,-0.0958479941f),
                        new Vector2(-0.0432349816f,0.475319803f),
                        new Vector2(-0.00524963951f,-0.0498716831f),
                        new Vector2(0.0337120146f,0.480472088f),
                        new Vector2(0.0744076371f,-0.0619844198f),
                        new Vector2(0.110594265f,0.486804694f),
                        new Vector2(0.142066926f,-0.0293381214f),
                        new Vector2(0.189227134f,0.484272093f),
                        new Vector2(0.223602116f,0.0206866264f),
                        new Vector2(0.265497416f,0.484393895f),
                        new Vector2(0.301313639f,0.137301028f),
                        new Vector2(0.346258372f,0.481790811f),
                        new Vector2(0.382125676f,0.0322815478f),
                        new Vector2(0.42302379f,0.474168181f),
                        new Vector2(0.437438577f,0.0230539199f)
                    };
                    break;
            
                case 4:
                    SelectedButtons(_buttonsScreen,button);
                    _buttonSreen = button;
                    _gridBack.transform.localScale = _gridScale[button];
                    _gridPlay.transform.localScale = _gridScale[button];
                    _fillingThePlayArea.GameColumn = 10;
                    _fillingThePlayArea.LineWidth = 12;
                    _fillingThePlayArea.FirstPoint1 = 6;
                    _fillingThePlayArea.FirstPoint2 = 5;
                    _fillingThePlayArea.LastPoint = 9;
                    _wallRight.transform.position = new Vector2(2.461f,_wallRight.transform.position.y);
                    _wallLeft.transform.position = new Vector2(-2.425f,_wallLeft.transform.position.y);
                    _wall.GetComponent<EdgeCollider2D>().edgeRadius = 0.176f;
                    _wall.GetComponent<EdgeCollider2D>().offset = new Vector2(0,0.04f);
                    _wall.GetComponent<EdgeCollider2D>().points = new[]
                    {
                        new Vector2(-0.536707759f,0.217261568f),
                        new Vector2(-0.444781929f,0.436259031f),
                        new Vector2(-0.398589253f,0.0276113749f),
                        new Vector2(-0.362269074f,0.427752674f),
                        new Vector2(-0.323805809f,-0.0917517543f),
                        new Vector2(-0.291297734f,0.429866701f),
                        new Vector2(-0.251267523f,-0.0406574905f),
                        new Vector2(-0.218884259f,0.42922011f),
                        new Vector2(-0.188658088f,-0.0737545192f),
                        new Vector2(-0.148633838f,0.423523694f),
                        new Vector2(-0.123879686f,-0.114142954f),
                        new Vector2(-0.0763977394f,0.424404144f),
                        new Vector2(-0.0526030771f,-0.0881665647f),
                        new Vector2(-0.00514314976f,0.41500932f),
                        new Vector2(0.0298912302f,-0.0929951072f),
                        new Vector2(0.0665812492f,0.419841677f),
                        new Vector2(0.0922350436f,-0.0481860042f),
                        new Vector2(0.13908428f,0.423615873f),
                        new Vector2(0.164883435f,-0.0213936865f),
                        new Vector2(0.211237967f,0.428221434f),
                        new Vector2(0.240909711f,0.0279262662f),
                        new Vector2(0.280973405f,0.4197066f),
                        new Vector2(0.317920655f,0.0443897843f),
                        new Vector2(0.353454173f,0.426213443f),
                        new Vector2(0.397594243f,-0.19723779f),
                        new Vector2(0.423739284f,0.431115001f)
                    };
                    break;
            }
        
        }


        void CreateCircleCollider(Vector2 startPosition, float offset, float radius,int number)
        {
            List<CircleCollider2D> _circle = new List<CircleCollider2D>(number);
            for (int i = 0; i < number; i++)
            {
                if (i == 0)
                {
                    _circle.Add(_wall.AddComponent<CircleCollider2D>());
                    _circle[i].radius = radius;
                    _circle[i].offset = startPosition;
                }
                else
                {
                    _circle.Add(_wall.AddComponent<CircleCollider2D>());
                    _circle[i].radius = radius;
                    _circle[i].offset =  new Vector2(_circle[i-1].offset.x + offset,startPosition.y);
                }
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

            _spawn = true;
        }
    }
}
