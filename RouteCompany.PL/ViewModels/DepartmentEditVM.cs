namespace RouteCompany.PL.ViewModels
{
    public class DepartmentEditVM
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } 
        public DateTime CreatedOn { get; set; }

    }
}
