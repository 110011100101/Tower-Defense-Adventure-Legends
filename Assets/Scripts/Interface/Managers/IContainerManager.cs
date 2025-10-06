using UnityEngine;

namespace TowerDefenseAdventureLegends.Assets.Scripts.Interface
{ 
    public interface IContainerManager
    {
        public void AddItemToContainer(GameObject container, GameObject prefab);
        public void UpdateContainer();
    }
}
