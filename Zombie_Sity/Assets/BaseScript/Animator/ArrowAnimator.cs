using UnityEngine;

namespace BaseScript.Animator
{
    public class ArrowAnimator : MonoBehaviour
    {
        [SerializeField] private Vector2 startPos = new Vector2(0.0154f, 0);
        [SerializeField] private Vector2 endPos = new Vector2(0.6929f, 0);
        
        [SerializeField] private Vector2 startScale = new Vector2(0.4981382f, 0.5095f);
        [SerializeField] private Vector2 endScale = new Vector2(0.01056053f, 0.5095f);
        
        [SerializeField] private float duration = 1.5f;
        [SerializeField] private bool loop = true;

        private float _timer = 0f;

        private void Start()
        {
            transform.localPosition = startPos;
            transform.localScale = startScale;
        }

        private void Update()
        {
            _timer += Time.deltaTime;
            float t = Mathf.Clamp01(_timer / duration);
            
            transform.localScale = Vector2.Lerp(startScale, endScale, t);
            transform.localPosition = Vector2.Lerp(startPos, endPos, t);

            if (t >= 1f)
            {
                if (loop)
                {
                    _timer = 0f;
                    transform.localScale = startScale;
                    transform.localPosition = startPos;
                }
                else
                {
                    enabled = false;
                }
            }
        }
    }
}