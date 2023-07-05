using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.Base
{
    public abstract class BaseJump: MonoBehaviour
    {
        [Header("BaseJump")]
        public float JumpForce = 5f;
        private bool IsJumping = false;
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

        protected virtual void Jump()
        {
            // Jumping logic
            if (Input.GetButtonDown("Jump") && !IsJumping)
            {
                Rigidbody2D.velocity.Set(Rigidbody2D.velocity.x, 0);
                Rigidbody2D.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                IsJumping = true;
            }
        }
        protected virtual void OnCollisionEnter2D(Collision2D collision)
        {
            print(collision.gameObject.tag);
            // Check if the player is touching the ground
            if (collision.gameObject.CompareTag("Ground"))
            {
                IsJumping = false;
            }
        }
    }
}
