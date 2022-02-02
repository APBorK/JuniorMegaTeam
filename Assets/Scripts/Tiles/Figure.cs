using UnityEngine;

namespace Tiles
{
    public class Figure : MonoBehaviour
    {
        public VersionTails Tails => _tails;

        [SerializeField]
        private VersionTails _tails;

    }
}
