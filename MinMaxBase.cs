namespace Bpositive
{
    using System;
    using UnityEngine;

    [Serializable]
    public abstract class MinMaxBase<T>
    {
        [SerializeField] protected T _min;
        [SerializeField] protected T _max;

        public T min { get => this._min; set => this._min = value; }

        public T max { get => this._max; set => this._max = value; }

        public abstract T Lerp(float t);
        public abstract float InverseLerp(T value);

        public abstract T Random();
    }
}