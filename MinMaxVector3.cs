namespace Bpositive
{
    using System;
    using UnityEngine;

    [Serializable]
    public class MinMaxVector3 : MinMaxBase<Vector3>
    {
        public override Vector3 Lerp(float t) => Vector3.Lerp(_min, _max, t);

        public override float InverseLerp(Vector3 value)
        {
            float x = Mathf.InverseLerp(_min.x, _max.x, value.x);
            float y = Mathf.InverseLerp(_min.y, _max.y, value.y);
            float z = Mathf.InverseLerp(_min.z, _max.z, value.z);
            return (x + y + z) / 3f;
        }

        public override Vector3 Random() => new Vector3(UnityEngine.Random.Range(_min.x, _max.x), UnityEngine.Random.Range(_min.y, _max.y), UnityEngine.Random.Range(_min.z, _max.z));
    }
}