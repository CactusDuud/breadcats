using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerData", menuName = "Towers/TowerData")]
public class TowerData : ScriptableObject
{
    #region Stats
	[Tooltip("How many times this tower attacks in a second.")]
    float fireRate = 0.5f;
    #endregion
}
