namespace Bpositive.Utilities
{
    using UnityEngine;

    public class AdvancedBehaviour : MonoBehaviour
    {
        public enum UpdateMode { Update, FixedUpdate, LateUpdate, None }

        public UpdateMode updateMode;

        public Transform cachedTransform
        {
            get
            {
#if UNITY_EDITOR
                if (!Application.isPlaying) return transform;
#endif
                return _transform;
            }
        }

        public Rigidbody cachedRigidbody
        {
            get
            {
#if UNITY_EDITOR
                if (!Application.isPlaying) return GetComponent<Rigidbody>();
#endif
                return _rigidbody;
            }
        }

        protected Transform _transform { get; private set; }
        protected Rigidbody _rigidbody { get; private set; }

        protected void CacheTransform()
        {
            _transform = transform;
        }

        protected void CacheRigidbody()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        protected void TryAutoUpdate(UpdateMode current)
        {
            if (current == updateMode)
            {
                OnAutoUpdate();
            }
        }

        protected virtual void OnAutoUpdate()
        {

        }

        protected async void ExecuteDelayed(System.Action action, float delay)
        {
            await System.Threading.Tasks.Task.Delay(Mathf.RoundToInt(delay * 1000));
            action.Invoke();
        }
    }
}