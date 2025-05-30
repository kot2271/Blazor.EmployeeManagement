using Blazor.EmployeeManagement.Data;
using Blazor.EmployeeManagement.Models;
using Blazor.EmployeeManagement.Models.DTOs;
using Blazor.EmployeeManagement.Models.Responses;
using Microsoft.EntityFrameworkCore;

namespace Blazor.EmployeeManagement.Services;

public interface IEmployeeService
{
    Task<GetEmployeesResponse> GetEmployees();
    Task<BaseResponse> AddEmployee(AddEmployeeForm form);
    Task<GetEmployeeResponse> GetEmployee(int id);
    Task<BaseResponse> DeleteEmployee(Employee employee);
    Task<BaseResponse> EditEmployee(Employee employee);
}

public class EmployeeService : IEmployeeService
{
    private readonly IDbContextFactory<DataContext> _factory;

    public EmployeeService(IDbContextFactory<DataContext> factory)
    {
        _factory = factory;
    }

    public async Task<BaseResponse> AddEmployee(AddEmployeeForm form)
    {
        var response = new BaseResponse();

        try
        {
            using (var context = _factory.CreateDbContext())
            {
                context.Add(new Employee
                {
                    Name = form.Name,
                    Position = form.Position,
                    Salary = form.Salary,
                    Type = form.Type,
                    ImgUrl = form.ImgUrl
                });

                var result = await context.SaveChangesAsync();

                if (result == 1)
                {
                    response.StatusCode = 200;
                    response.Message = "Employee added successfully";
                }
                else
                {
                    response.StatusCode = 400;
                    response.Message = "Error occurred while adding the employee";
                }
            }
        }
        catch (Exception ex)
        {
            response.StatusCode = 500;
            response.Message = "Error adding employee:" + ex.Message;
        }
        return response;
    }

    public async Task<BaseResponse> DeleteEmployee(Employee employee)
    {
        var response = new BaseResponse();

        try
        {
            using (var context = _factory.CreateDbContext())
            {
                context.Remove(employee);

                var result = await context.SaveChangesAsync();

                if (result == 1)
                {
                    response.StatusCode = 200;
                    response.Message = "Employee removed successfully";
                }
                else
                {
                    response.StatusCode = 400;
                    response.Message = "Error occurred while removing the employee";
                }
            }
        }
        catch (Exception ex)
        {
            response.StatusCode = 500;
            response.Message = "Error removing employee:" + ex.Message;
        }
        return response;
    }

    public async Task<BaseResponse> EditEmployee(Employee employee)
    {
        var response = new BaseResponse();

        try
        {
            using (var context = _factory.CreateDbContext())
            {
                context.Update(employee);

                var result = await context.SaveChangesAsync();

                if (result == 1)
                {
                    response.StatusCode = 200;
                    response.Message = "Employee updated successfully";
                }
                else
                {
                    response.StatusCode = 400;
                    response.Message = "Error occurred while updating the employee";
                }
            }
        }
        catch (Exception ex)
        {
            response.StatusCode = 500;
            response.Message = "Error updated employee:" + ex.Message;
        }
        return response;
    }

    public async Task<GetEmployeeResponse> GetEmployee(int id)
    {
        var response = new GetEmployeeResponse();

        try
        {
            using (var context = _factory.CreateDbContext())
            {
                var employee = await context.Employees.FirstOrDefaultAsync(x => x.Id == id);
                response.StatusCode = 200;
                response.Employee = employee;
                response.Message = "Success";
            }
        }
        catch (Exception ex)
        {
            response.StatusCode = 500;
            response.Message = "Error retrieving employee:" + ex.Message;
        }

        return response;
    }

    public async Task<GetEmployeesResponse> GetEmployees()
    {
        var response = new GetEmployeesResponse();

        try
        {
            using (var context = _factory.CreateDbContext())
            {
                var employees = await context.Employees.ToListAsync();
                response.StatusCode = 200;
                response.Employees = employees;
                response.Message = "Success";
            }
        }
        catch (Exception ex)
        {
            response.StatusCode = 500;
            response.Message = "Error retrieving employees:" + ex.Message;
            response.Employees = null;
        }

        return response;
    }
}
