﻿using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Extensions;

namespace Abp.EntityHistory
{
    [Table("AbpEntityPropertyChanges")]
    public class EntityPropertyChange : Entity<long>, IMayHaveTenant
    {
        /// <summary>
        /// Maximum length of <see cref="PropertyName"/> property.
        /// Value: 96.
        /// </summary>
        public const int MaxPropertyNameLength = 96;

        /// <summary>
        /// Maximum length of <see cref="NewValue"/> and <see cref="OriginalValue"/> properties.
        /// Value: 512.
        /// </summary>
        public const int MaxValueLength = 512;

        /// <summary>
        /// Maximum length of <see cref="PropertyTypeFullName"/> property.
        /// Value: 512.
        /// </summary>
        public const int MaxPropertyTypeFullNameLength = 192;

        /// <summary>
        /// EntityChangeId.
        /// </summary>
        public virtual long EntityChangeId { get; set; }

        /// <summary>
        /// NewValue. Use <see cref="SetNewValue"/> to change value
        /// </summary>
        [StringLength(MaxValueLength)]
        public virtual string NewValue { get; set; }

        /// <summary>
        /// OriginalValue. Use <see cref="SetOriginalValue"/> to change value
        /// </summary>
        [StringLength(MaxValueLength)]
        public virtual string OriginalValue { get; set; }

        /// <summary>
        /// PropertyName.
        /// </summary>
        [StringLength(MaxPropertyNameLength)]
        public virtual string PropertyName { get; set; }

        /// <summary>
        /// Type of the JSON serialized <see cref="NewValue"/> and <see cref="OriginalValue"/>.
        /// It's the FullName of the type.
        /// </summary>
        [StringLength(MaxPropertyTypeFullNameLength)]
        public virtual string PropertyTypeFullName { get; set; }

        /// <summary>
        /// TenantId.
        /// </summary>
        public virtual int? TenantId { get; set; }

        /// <summary>
        /// Hash of new value, auto-generated by <see cref="SetNewValue"/>, used compare changes.
        /// </summary>
        public virtual string NewValueHash { get; set; }

        /// <summary>
        /// Hash of original value, auto-generated by <see cref="SetOriginalValue"/>, used compare changes.
        /// </summary>
        public virtual string OriginalValueHash { get; set; }

        /// <summary>
        /// Use to set NewValue. (Also fills <see cref="NewValueHash"/> according to <paramref name="newValue"/>)
        /// </summary>
        public virtual void SetNewValue(string newValue)
        {
            NewValueHash = newValue?.ToMd5();
            NewValue = newValue.TruncateWithPostfix(MaxValueLength);
        }

        /// <summary>
        /// Use to set original value. (Also fills <see cref="OriginalValueHash"/> according to <paramref name="originalValue"/>)
        /// </summary>
        public virtual void SetOriginalValue(string originalValue)
        {
            OriginalValueHash = originalValue?.ToMd5();
            OriginalValue = originalValue.TruncateWithPostfix(MaxValueLength);
        }

        /// <summary>
        /// Returns if NewValue and OriginalValue are equal. Uses hash to compare, if <see cref="NewValueHash"/> and <see cref="OriginalValueHash"/> are not null or empty.
        /// </summary>
        public virtual bool IsValuesEquals()
        {
            //To support previous data
            if (!NewValueHash.IsNullOrWhiteSpace() && !OriginalValueHash.IsNullOrWhiteSpace())
                return NewValueHash == OriginalValueHash;

            return NewValue == OriginalValue;
        }
    }
}