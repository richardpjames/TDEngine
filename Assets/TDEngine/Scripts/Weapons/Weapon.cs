using UnityEngine;

namespace richardpjames.com.TDEngine.Weapons
{
    [AddComponentMenu("")]
    public class Weapon : MonoBehaviour
    {
        [SerializeField] protected float cooldown;
        [SerializeField] protected bool overrideDamage;
        [SerializeField] protected int damage;
        protected LayerMask excludeLayers;

        protected bool firing = false;
        protected float nextFireTime;
        // Begin and stop firing (allows for holding controls)
        public virtual void SetFiring(bool newFiringValue)
        {
            firing = newFiringValue;
        }

        // Set any layers to be ignored by the weapon
        public virtual void SetExcludeLayers(LayerMask mask)
        {
            excludeLayers = mask;
        }

        // Weapons are often rotated, so make sure they appear the right way up if required
        protected void FlipSprites()
        {
            if(transform.rotation.eulerAngles.z > 0 && transform.rotation.eulerAngles.z < 180)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            else
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }

        // For destroying weapons
        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}