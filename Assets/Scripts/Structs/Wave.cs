using System;
using System.Collections.Generic;

namespace Assets.Scripts.Constans
{
    [Serializable]
    public struct Wave
    {
        public float InitialDelay;
        public float SpawnDelay;
        public List<Enemy> EnemyList;
    }
}
