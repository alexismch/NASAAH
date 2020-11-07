using UnityEngine;

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
            
            _spawnArea = GetComponent<BoxCollider2D>();
            _spawnArea.enabled = false; //We don't need this to test for any collisions, just to show visual bounds info in the editor.
            _maxSpawnPos = new Vector2(_spawnArea.size.x / 2, _spawnArea.size.y / 2);
            for(var i = 0; i< numberToSpawn;i++){
                GameObject spawned = Instantiate(spawnedPrefab, Vector3.zero, Quaternion.identity) as GameObject;
                spawned.transform.parent = transform;
                Vector3 pos = new Vector3(Random.Range(-_maxSpawnPos.x, _maxSpawnPos.x), Random.Range(-_maxSpawnPos.y, _maxSpawnPos.y), 0);
                spawned.transform.localPosition = pos;
        
            }
        }
        
    }
}