using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script
{
    public class Patrol: MonoBehaviour
    {
        public List<Transform> PatrolPaths = new List<Transform>();
        public int CurrentLocationIndex = 0;
        public bool Running = true;
        public bool IsRepeat = true;
        public bool IsIncreaseLocationIndex = true;
        public float MoveSpeed = 5f;
        protected virtual void Update()
        {
            Move();
        }
        protected virtual void Move()
        {
            if(PatrolPaths.Count == 0 || !Running) return;

            Vector3 targetPosition = PatrolPaths[CurrentLocationIndex].position;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, MoveSpeed * Time.deltaTime);
            if (transform.position == PatrolPaths[CurrentLocationIndex].position) NextLocationIndex();
        }
        private void NextLocationIndex()
        {
            if(CurrentLocationIndex == PatrolPaths.Count - 1 && IsRepeat)
            {
                CurrentLocationIndex--;
                IsIncreaseLocationIndex = false;
                return;
            }
            if (CurrentLocationIndex == 0 && IsRepeat && !IsIncreaseLocationIndex)
            {
                CurrentLocationIndex++;
                IsIncreaseLocationIndex = true;
                return;
            }
            if (!IsRepeat && ((CurrentLocationIndex == PatrolPaths.Count - 1) || CurrentLocationIndex == 0))
                Running = false;
            CurrentLocationIndex = Mathf.Clamp(CurrentLocationIndex + (IsIncreaseLocationIndex ? 1 : -1), 0, PatrolPaths.Count - 1);
        }
    }
}
