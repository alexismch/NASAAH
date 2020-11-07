using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Script.Object
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class SpawnDiamond : MonoBehaviour
    {
        [SerializeField] public GameObject spawnedPrefab;
        [SerializeField] public int numberToSpawn;
        [SerializeField] public int radiusSpawnDiamond;
        private BoxCollider2D _spawnArea;
        private Vector2 _maxSpawnPos;


        // Use this for initialization
        private void Start()
        {
            Vector3 pos;
            _spawnArea = GetComponent<BoxCollider2D>();
            _spawnArea.enabled = false;
            var size = _spawnArea.size;
            _maxSpawnPos = new Vector2(size.x / 2, size.y / 2);
            for (var i = 0; i < numberToSpawn; i++)
            {
                //create pos for new diamond
                pos = new Vector3(Random.Range(-_maxSpawnPos.x, _maxSpawnPos.x),
                    Random.Range(-_maxSpawnPos.y, _maxSpawnPos.y), 0);
                GameObject diamond = Instantiate(spawnedPrefab, Vector3.zero, Quaternion.identity) as GameObject;
                diamond.transform.parent = transform;
                diamond.transform.localPosition = pos;

                var j = 0;
                while (j < 15 && (IsBlocked(diamond)))
                {
                    j++;
                    Debug.Log("'doit bouger" + i);
                    diamond.transform.localPosition = new Vector3(Random.Range(-_maxSpawnPos.x, _maxSpawnPos.x),
                        Random.Range(-_maxSpawnPos.y, _maxSpawnPos.y), 0);
                }
            }
        }

        private bool IsRadiusClear(GameObject diamond)
        {
            var collider2Ds = Physics2D.OverlapCircleAll(diamond.transform.position, radiusSpawnDiamond);
            foreach (var coll in collider2Ds)
            {
                if (coll.gameObject.CompareTag($"Diamond"))
                {
                    Debug.Log("il y a un diamond pas loin");
                    return false;
                }
            }

            return true;
        }

        private bool IsBlocked(GameObject prefab)
        {
            CircleCollider2D colliderPrefab = prefab.GetComponent<CircleCollider2D>();
            colliderPrefab.enabled = false;
            bool isBlocked = Physics2D.OverlapBox(colliderPrefab.bounds.center, colliderPrefab.offset, 0) != null;
            colliderPrefab.enabled = true;
            return isBlocked;
        }
    }
}