using Assets.Scripts.Enums;
using Assets.Scripts.Models;
using UnityEngine;

namespace Assets.Scripts
{
    internal class LayoutScript : MonoBehaviour
    {
        private const int length = 15;

        private readonly Tile[,] _layout = new Tile[length*2+1, length*2+1];

        public void Start() {}

        public void Update() {}

        public void Add(Tile type, Cord cord)
        {
            var trueCord = new Cord(cord.X+length, cord.Z+length);
            switch (type)
            {
                case Tile.Portal:
                    AddPortal(trueCord);
                    break;
                case Tile.Tower:
                    AddTower(trueCord);
                    break;
                case Tile.Chest:
                    AddChest(trueCord);
                    break;
                default:
                    break;
            }

            Debug.Log($"Adding {type} to ({cord.X}, {cord.Z})[{trueCord.X}, {trueCord.Z}]");
        }

        private void AddTower(Cord cord)
        {
            if (cord == null)
                return;
            if (_layout[cord.X, cord.Z] == Tile.Empty)
                _layout[cord.X, cord.Z] = Tile.Tower;
        }

        private void AddChest(Cord cord)
        {
            if (cord == null)
                return;
            _layout[cord.X, cord.Z] = Tile.Chest;
        }
        
        private void AddPortal(Cord cord)
        {
            if (cord == null)
                return;
            if (_layout[cord.X, cord.Z] == Tile.Empty)
                _layout[cord.X, cord.Z] |= Tile.Portal;
        }

    }
}
