using UnityEngine;

namespace Tiles
{
    /// <summary>
    /// Clicking on game objects
    /// </summary>
    public class Click : MonoBehaviour
    {
        void Update ()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var hit = Physics2D.Raycast(p, Vector2.zero); 
                if (hit.collider != null)
                {
                    var destroyObj = hit.collider.gameObject.GetComponent<DestroyObject>();
                    if (destroyObj != null)
                    {
                        destroyObj.CheckMatch();
                    }
                } else {
                    Debug.Log("Select game object");
                }
            }
        }
    }
}
