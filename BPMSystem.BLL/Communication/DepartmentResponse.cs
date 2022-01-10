namespace BPMSystem.Web.Communication
{
    public class DepartmentResponse : BaseResponse
    {
        public dynamic Departments { get; set; } = null!;
        public DepartmentResponse(bool success, string message, dynamic departments) : base(success, message)
        {
            Departments = departments;
        }
    }
}
