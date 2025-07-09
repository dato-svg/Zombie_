using BaseScript.PlayerMove;
using UnityEngine;

namespace BaseScript.Spawner
{
    public class SpawnAfterStay : MonoBehaviour
    {
        [SerializeField] private float timeToSpawn = 5f;
        [SerializeField] private GameObject spawnPrefab;
        [SerializeField] private Transform spawnPoint;

        [SerializeField] private Transform forwardImage;
        
        [SerializeField] private bool turret;
        [SerializeField] private GameObject currentGun;
        
        private float _timer = 0f;
        private bool _isPlayerInside = false;

        private readonly Vector3 _startPosition = new Vector3(0f, -1f, 0f);
        private readonly Vector3 _targetPosition = new Vector3(0f, 0f, 0f);

        private readonly Vector3 _startScale = new Vector3(2f, 0f, 2f);
        private readonly Vector3 _targetScale = new Vector3(2f, 2f, 2f);
        
        private void Start()
        {
            if (forwardImage != null)
            {
                forwardImage.localPosition = _startPosition;
                forwardImage.localScale = _startScale;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<PlayerMovement>() != null)
            {
                _isPlayerInside = true;
                _timer = 0f;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.GetComponent<PlayerMovement>() != null)
            {
                _isPlayerInside = false;
                _timer = 0f;
                
                if (forwardImage != null)
                {
                    forwardImage.localPosition = _startPosition;
                    forwardImage.localScale = _startScale;
                }
            }
        }

        private void Update()
        {
            if (_isPlayerInside)
            {
                _timer += Time.deltaTime;
                
                float t = Mathf.Clamp01(_timer / timeToSpawn);
                
                forwardImage.localPosition = Vector3.Lerp(_startPosition, _targetPosition, t);
                forwardImage.localScale = Vector3.Lerp(_startScale, _targetScale, t);

                if (_timer >= timeToSpawn)
                {
                    SpawnObject();
                    _isPlayerInside = false;
                }
            }
        }

        private void SpawnObject()
        {
            if (turret)
            {
                if (spawnPrefab != null && spawnPoint != null)
                {
                    GameObject obj = Instantiate(spawnPrefab, spawnPoint.position, spawnPoint.rotation);
                }
                else
                    Debug.LogWarning("SpawnPrefab или SpawnPoint не назначены!");
            }
            else
            {
                ActivateOnly(currentGun);
            }
            
            Destroy(transform.parent.gameObject);
        }
        
        private void ActivateOnly(GameObject targetObject)
        {
            Transform parent = targetObject.transform.parent;

            foreach (Transform child in parent)
            {
                child.gameObject.SetActive(false);
            }

            targetObject.SetActive(true);
        }

    }
}
