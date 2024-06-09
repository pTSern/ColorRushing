
using UnityEngine;
namespace pTS.Interfaces
{
    public interface IRootGameObject
    {
        GameObject gameObject { get; }
        Transform transform { get; }
    }
}