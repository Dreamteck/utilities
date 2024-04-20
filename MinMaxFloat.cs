namespace Bpositive
{
    using System;
    using UnityEngine;

    [Serializable]
    public class MinMaxFloat : MinMaxBase<float>
    {

        public MinMaxFloat()
        {

        }

        public MinMaxFloat(float min, float max)
        {
            _min = min;
            _max = max;
        }

        public override float Lerp(float t) => Mathf.Lerp(_min, _max, t);
        public override float InverseLerp(float value) => Mathf.InverseLerp(_min, _max, value);
        public override float Random() => UnityEngine.Random.Range(_min, _max);
    }
}