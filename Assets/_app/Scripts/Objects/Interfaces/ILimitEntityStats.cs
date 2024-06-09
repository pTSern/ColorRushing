
namespace pTS.Interfaces
{
    public interface IEntityLimitedStats
    {
        float current_vallue { get; }
        float max_vallue { get; }
        string name { get; }

        /// <summary>
        /// Increase the current value by a certain amount
        /// </summary>
        /// <param name="amount">The amount to increase the current value</param>
        void Add(float amount);
        /// <summary>
        /// Increase the max value by a certain amount 
        /// </summary>
        /// <param name="amount">The amount to increase the max value</param>
        void Extends(float amount);
    }
}