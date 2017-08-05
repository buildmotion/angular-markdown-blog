using System;
using System.Text;
using BuildMotion.Entity;

namespace BuildMotion.MarkdownMotion.Service.Entity
{
    public class ServiceEntityBase<T> : EntityBase<T>, IEntity, IEquatable<T>
    {
        /// <summary>
        ///     Gets or sets the created on.
        /// </summary>
        /// <value>
        ///     The created on.
        /// </value>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        ///     Gets or sets the created by.
        /// </summary>
        /// <value>
        ///     The created by.
        /// </value>
        public string CreatedBy { get; set; }

        /// <summary>
        ///     Gets or sets the updated on.
        /// </summary>
        /// <value>
        ///     The updated on.
        /// </value>
        public DateTime? UpdatedOn { get; set; }

        /// <summary>
        ///     Gets or sets the updated by.
        /// </summary>
        /// <value>
        ///     The updated by.
        /// </value>
        public string UpdatedBy { get; set; }

        /// <summary>
        ///     Gets or sets the original entity.
        /// </summary>
        /// <value>
        ///     The original entity.
        /// </value>
        public T OriginalEntity { get; set; }

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        public Guid Id { get; set; } // implementation of the IEntity.Id - identifier

        /// <summary>
        ///     Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        ///     true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(T other)
        {
            // Check whether the compared object is null. 
            if (ReferenceEquals(other, null))
                return false;

            // Check whether the compared object references the same data. 
            if (ReferenceEquals(this, other))
                return true;

            // Cannot compare (2) different types; 
            if (GetType() != other.GetType())
                return false;

            return GetHashCode().Equals(other.GetHashCode());
        }

        public override bool Equals(object obj)
        {
            if (obj is T)
                return Equals((T) obj);
            return false;
        }

        /// <summary>
        ///     Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>
        ///     A hash code for the current <see cref="T:System.Object" />.
        /// </returns>
        public override int GetHashCode()
        {
            // Retrieve the hash code for the Identifier for the object. 
            var hashId = Id.GetHashCode();

            // calculate the hash code for the object;
            return hashId;
        }

        /// <summary>
        ///     Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        ///     A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            var newline = Environment.NewLine;
            sb.AppendFormat("Id: {0}{1}", Id, newline);
            sb.AppendFormat("CreatedOn: {0}{1}", CreatedOn, newline);
            sb.AppendFormat("CreatedBy: {0}{1}", CreatedBy, newline);
            sb.AppendFormat("UpdatedOn: {0}{1}", UpdatedOn, newline);
            sb.AppendFormat("UpdatedBy: {0}{1}", UpdatedBy, newline);
            return sb.ToString();
        }
    }
}