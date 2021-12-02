using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelDataManager", menuName = "Level 4/LevelManagerData")]
public class LevelManager : ScriptableObject {
    public int levelUnlock;
    public int simulasiUnlock, puzzleUnlock;

}
