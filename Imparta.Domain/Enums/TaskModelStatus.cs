using System.ComponentModel;

namespace Imparta.Domain.Enums
{
    public enum TaskModelStatus
    {
        Open = 0,
        [Description("In Progress")]
        InProgress = 1,
        Completed = 2,
    }
}
