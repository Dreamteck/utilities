namespace  Bpositive.Utilities
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class PhysicsAPIUtility
    {
        public enum GetComponentType { CurrentObject, Parent, Children }
        public QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal;
        public LayerMask layerMask = ~0;
        public int foundObjectsCount => _count;

        protected Collider[] _colliderBuffer { get; private set; }
        protected int _count = 0;

        public delegate bool LoopAction(Collider collider, int index);

        public PhysicsAPIUtility(LayerMask layerMask, int capacity = 100, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
        {
            this.layerMask = layerMask;
            this.queryTriggerInteraction = queryTriggerInteraction;
            _colliderBuffer = new Collider[capacity];
        }

        public void LoopColliders(LoopAction onLoop)
        {
            for (int i = 0; i < _count; i++)
            {
                if (!onLoop(_colliderBuffer[i], i))
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Retrieves a list of the specified component type of such exists within the buffer
        /// </summary>
        /// <typeparam name="T">Component type</typeparam>
        /// <returns></returns>
        public List<T> GetComponentList<T>(GetComponentType getComponentType = GetComponentType.CurrentObject)
        {
            List<T> list = new List<T>();
            LoopColliders((collider, index) =>
            {
                T component = GetComponentIn<T>(collider, getComponentType);
                if (component != null)
                {
                    list.Add(component);
                }
                return true;
            });
            return list;
        }

        /// <summary>
        /// Fills the provided array with components of the specified type if such exist within the buffer
        /// </summary>
        /// <typeparam name="T">Component type</typeparam>
        /// <param name="components">Component array to fill</param>
        /// <param name="autoExtend">If true, then the array will be expanded automatically to contain all</param>
        /// <param name="getComponentType"></param>
        public int FillComponentsArray<T>(T[] components, bool autoExtend = false, GetComponentType getComponentType = GetComponentType.CurrentObject)
        {
            int total = 0;
            bool extended = false;
            LoopColliders((collider, index) =>
            {
                if (total >= components.Length) return false;
                T component = GetComponentIn<T>(collider, getComponentType);
                if (component != null)
                {
                    components[total] = component;
                    total++;
                    if (total < _count - 1 && total >= components.Length)
                    {
                        if (autoExtend)
                        {
                            T[] newComponents = new T[_colliderBuffer.Length];
                            components.CopyTo(newComponents, 0);
                            components = newComponents;
                            extended = true;
                            newComponents = null;
                        }
                    }

                }
                return true;
            });

            if (extended)
            {
                T[] newComponents = new T[total];
                for (int i = 0; i < total; i++)
                {
                    newComponents[i] = components[i];
                }
                components = newComponents;
                newComponents = null;
            }

            return total;
        }

        protected T GetComponentIn<T>(Collider collider, GetComponentType getComponentType)
        {
            switch (getComponentType)
            {
                case GetComponentType.CurrentObject: return collider.GetComponent<T>();
                case GetComponentType.Parent:
                    T cmp = collider.GetComponent<T>();
                    if (cmp != null) return cmp;
                    return collider.GetComponentInParent<T>();
                case GetComponentType.Children: return collider.GetComponentInChildren<T>();
            }
            return default;
        }
    }
}
