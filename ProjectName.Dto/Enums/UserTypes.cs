using System.ComponentModel;

namespace ProjectName.Dto.Enums
{
    public enum UserTypes
    {
        [Description("User")]
        Customer = 0,
        [Description("Operator")]
        Web = 1
    }
}
