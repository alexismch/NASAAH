using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Script.Object
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class SpawnDiamond : MonoBehaviour {
        [SerializeField] public GameObject spawnedPrefab;
        [SerializeField] public int numberToSpawn;
        private BoxCollider2D _spawnArea;
        private Vector2 _maxSpawnPos;


        // Use this for initialization
        private void Start ()
        {
            Vector3 pos;
            _spawnArea = GetComponent<BoxCollider2D>();
            _spawnArea.enabled = false;
            var size = _spawnArea.size;
            _maxSpawnPos = new Vector2(size.x / 2, size.y / 2);
            for(var i = 0; i< numberToSpawn;i++){
                
                
                pos = new Vector3(Random.Range(-_maxSpawnPos.x, _maxSpawnPos.x),
                        Random.Range(-_maxSpawnPos.y, _maxSpawnPos.y), 0);
                GameObject prefab = Instantiate(spawnedPrefab, Vector3.zero, Quaternion.identity) as GameObject;
                prefab.transform.parent = transform;
                prefab.transform.localPosition = pos;
                
                CircleCollider2D colliderPrefab = prefab.GetComponent<CircleCollider2D>();
                colliderPrefab.enabled = false;
                var j = 0;
                while (j < 15 && Physics2D.OverlapBox(colliderPrefab.bounds.center, colliderPrefab.offset, 0) != null)
                {
                    j++;
                    Debug.Log("'doit bouger " + i);
                    prefab.transform.localPosition = new Vector3(Random.Range(-_maxSpawnPos.x, _maxSpawnPos.x),
                        Random.Range(-_maxSpawnPos.y, _maxSpawnPos.y), 0);
                }
                colliderPrefab.enabled = true;
            }
        }

        private bool canSpawn(CircleCollider2D colliderPrefab )
        {
            bool isSpawnFree = Physics2D.OverlapBox(colliderPrefab.bounds.center, colliderPrefab.offset, 0) == null;
            bool isNearAnotherPrefab;
            return isSpawnFree;
        }
    }
}