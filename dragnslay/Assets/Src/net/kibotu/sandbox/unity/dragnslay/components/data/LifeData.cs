using UnityEngine;

namespace Assets.Src.net.kibotu.sandbox.unity.dragnslay.components.data
{
    public class LifeData : MonoBehaviour {
	
        public int maxHp;
        public int currentHp;
        public int armor;
        public int maxShield;
        public int currentShield;
        public float hpRegen; 	    // hp 			/ sec
        public float shieldRegen;   // shield_regen / sec

        public void Init(int maxHp, int currentHp, int armor, int maxShield, int currentShield, float hpRegen, float shieldRegen)
        {
            this.maxHp = maxHp;
            this.currentHp = currentHp;
            this.armor = armor;
            this.maxShield = maxShield;
            this.currentShield = currentShield;
            this.hpRegen = hpRegen;
            this.shieldRegen = shieldRegen;
        }
    }
}
