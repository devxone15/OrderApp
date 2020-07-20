using System.ComponentModel;

namespace OrdersApp.Enums 
{
    public enum OrderStatus
    {
        [Description("In Progress")]
        InProgress,
        Complete
    }
}