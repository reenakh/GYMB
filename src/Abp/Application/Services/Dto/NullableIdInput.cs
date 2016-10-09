using System;

namespace Abp.Application.Services.Dto
{
    /// <summary>
    /// This DTO can be directly used (or inherited)
    /// to pass an nullable Id value to an application service method.
    /// </summary>
    /// <typeparam name="TId">Type of the Id</typeparam>
    [Serializable]
    public class NullableIdInput<TId>
        where TId : struct
    {
        public TId? Id { get; set; }

        public NullableIdInput()
        {

        }

        public NullableIdInput(TId? id)
        {
            Id = id;
        }
    }

    /// <summary>
    /// A shortcut of <see cref="NullableIdInput{TPrimaryKey}"/> for <see cref="int"/>.
    /// </summary>
    [Serializable]
    public class NullableIdInput : NullableIdInput<int>
    {
        public NullableIdInput()
        {

        }

        public NullableIdInput(int? id)
            : base(id)
        {

        }
    }
}