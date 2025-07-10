using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BaseScript
{
    public class RandoShiker : MonoBehaviour
    {
        [SerializeField] private List<Sprite> sprites;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private float daleyTime = 0.5f;

        private int _index = 0;

        private void Start()
        {
            StartCoroutine(ActiveAnimation());
        }

        private IEnumerator ActiveAnimation()
        {
            while (true)
            {
                if (sprites.Count == 0) yield break;

                spriteRenderer.sprite = sprites[_index];

                _index++;
                if (_index >= sprites.Count)
                    _index = 0;

                yield return new WaitForSeconds(daleyTime);
            }
        }
    }
}