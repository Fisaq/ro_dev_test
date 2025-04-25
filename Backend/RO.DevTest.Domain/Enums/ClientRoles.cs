using System.ComponentModel;

namespace RO.DevTest.Domain.Enums
{
    public enum ClientRoles
    {
        [Description("CPF")]
        CPF = 0,
        [Description("CNPJ")]
        CNPJ = 1,
    }
}
