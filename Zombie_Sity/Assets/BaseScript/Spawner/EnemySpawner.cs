using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BaseScript.Spawner
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private float delay;
        [SerializeField] private List<SpawnEntry> entries =  new List<SpawnEntry>();
        [SerializeField] private Transform spawnPoint;
        
        [SerializeField] private List<GameObject> interactables = new List<GameObject>();

        private void Awake()
        {
            spawnPoint = transform;
            ActiveInteractable(true);
        }
        
        [ContextMenu("ActiveSpawn")]
        public void ActiveSpawn() => 
            StartCoroutine(SpawnRoutine());

        private IEnumerator  SpawnRoutine()
        {
            ActiveInteractable(false);
            foreach (var entry in entries)
            {
                for (int i = 0; i < entry.count; i++)
                {
                    SpawnMob(entry.mobPrefab);
                    yield return new WaitForSeconds(delay);
                }
            }
        }
        
        private void SpawnMob(GameObject prefab) => 
            Instantiate(prefab, spawnPoint.position + new Vector3(Random.Range(-1,1),0,0), Quaternion.identity);

        private void ActiveInteractable(bool active)
        {
            for (int i = interactables.Count - 1; i >= 0; i--)
            {
                if (interactables[i] != null)
                    interactables[i].SetActive(active);
                
                else
                    interactables.RemoveAt(i);
            }
        }

    }
}