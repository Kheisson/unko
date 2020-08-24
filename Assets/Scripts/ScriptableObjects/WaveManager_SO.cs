using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLevel", menuName = "New Level Layout")]
public class WaveManager_SO : ScriptableObject
{
    public string levelID;
    public List<GameObject> enemiesToSpawn;
}
