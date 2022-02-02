using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Tiles
{
    public class VersionTails : MonoBehaviour
    {
        [SerializeField] private List<SpriteRenderer> _circle, _orion, _pentagon, _square, _star, _triangle;
        private List<SpriteRenderer> _spriteRenderers = new List<SpriteRenderer>();

        public void SelectedTailsVersion(int button)
        {
            switch (transform.parent.name)
            {
                case "Circle":
                    if (gameObject.name != transform.parent.name)
                    {
                        gameObject.name = transform.parent.name;
                    }
                    SelectedTailsVersions(_circle, button);
                    break;

                case "Orion":
                    if (gameObject.name != transform.parent.name)
                    {
                        gameObject.name = transform.parent.name;
                    }
                    SelectedTailsVersions(_orion, button);
                    break;

                case "Pentagon":
                    if (gameObject.name != transform.parent.name)
                    {
                        gameObject.name = transform.parent.name;
                    }
                    SelectedTailsVersions(_pentagon, button);
                    break;

                case "Square":
                    if (gameObject.name != transform.parent.name)
                    {
                        gameObject.name = transform.parent.name;
                    }
                    SelectedTailsVersions(_square, button);
                    break;

                case "Star":
                    if (gameObject.name != transform.parent.name)
                    {
                        gameObject.name = transform.parent.name;
                    }
                    SelectedTailsVersions(_star, button);
                    break;

                case "Triangle":
                    if (gameObject.name != transform.parent.name)
                    {
                        gameObject.name = transform.parent.name;
                    }
                    SelectedTailsVersions(_triangle, button);
                    break;
            }
        }

        void SelectedTailsVersions(List<SpriteRenderer> list, int button)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite =
                list[button].sprite;
        }
    }
}
