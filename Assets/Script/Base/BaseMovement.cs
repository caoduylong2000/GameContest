using UnityEngine;

namespace Assets.Script.Base
{
    public abstract class BaseMovement : MonoBehaviour
    {
        [Header("BaseMovement")]
        public float MoveSpeed = 5f;
        protected Rigidbody2D Rigidbody2D;
        protected virtual void Reset()
        {
            LoadComponent();
        }
        protected virtual void Awake()
        {
            LoadComponent();
        }

        protected virtual void LoadComponent()
        {
            LoadComponentRigidbody2D();
        }
        protected virtual void LoadComponentRigidbody2D()
        {
            Rigidbody2D = Rigidbody2D ?? GetComponentInParent<Rigidbody2D>();
            if (Rigidbody2D != null) return;
            transform.parent.gameObject.AddComponent<Rigidbody2D>();
            LoadComponentRigidbody2D();
        }
        protected virtual void Move()
        {
            /*float moveX = Input.GetAxis("Horizontal");

            // Move the player horizontally
            Rigidbody2D.velocity = new Vector2(moveX * MoveSpeed, Rigidbody2D.velocity.y);*/
        }
    }
}
