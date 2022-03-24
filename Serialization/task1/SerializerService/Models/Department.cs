namespace SerializerService.Models
{
    [Serializable]
    public class Department
    {
        public string DepartmentName { get; set; }
        public List<Employee> Employees { get; set; }

        public override string ToString()
        {
            return $"DepartmentName: {this.DepartmentName}" + Environment.NewLine +
                $"Employees: {string.Join(", ", this.Employees)}";
        }
    }
}