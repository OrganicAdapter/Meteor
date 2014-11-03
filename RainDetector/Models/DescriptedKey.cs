using System;
using System.Collections.Generic;

namespace MSSCV.RainDetector.Models
{
    /// <summary>
    /// Keys for dictionaries with additional description about the key-value pair.
    /// </summary>
    public interface IDescriptedKey
    {
        /// <summary>
        /// Description of the key-value pair.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Key.
        /// </summary>
        string Key { get; set; }
    }


    public class DescriptedKey : IDescriptedKey, IEqualityComparer<IDescriptedKey>
    {
        public string Description { get; set; }

        public string Key { get; set; }

        public bool Equals(IDescriptedKey x, IDescriptedKey y)
        {
            return x.Key.Equals(y.Key, StringComparison.OrdinalIgnoreCase);
        }

        public int GetHashCode(IDescriptedKey obj)
        {
            var hashCode = obj.Key;

            return hashCode.GetHashCode();
        }

        public override string ToString()
        {
            return Description;
        }
    }
}
