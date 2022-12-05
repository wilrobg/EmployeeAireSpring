namespace Employee.Web.ViewModels.Employee;

public class IndexViewModel
{
    public IEnumerable<EmployeeViewModel> Employees { get; set; }
    public SearchEmployeeViewModel SearchEmployee { get; set; }
}
