using UnityEngine;

namespace BaseScript.Component
{
    public class ScalePulse : MonoBehaviour
    {
        [SerializeField] private Vector3 minScale = Vector3.one;
        [SerializeField] private Vector3 maxScale = new Vector3(2, 2, 2);
        [SerializeField] private float speed = 2f;

        private bool _scalingUp = true;

        private void Update()
        {
            if (_scalingUp)
            {
                transform.localScale = Vector3.Lerp(transform.localScale, maxScale, Time.deltaTime * speed);

                if (Vector3.Distance(transform.localScale, maxScale) < 0.01f)
                    _scalingUp = false;
            }
            else
            {
                transform.localScale = Vector3.Lerp(transform.localScale, minScale, Time.deltaTime * speed);

                if (Vector3.Distance(transform.localScale, minScale) < 0.01f)
                    _scalingUp = true;
            }
        }
    }
}