using AutoMapper;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;
        private readonly IGetAdditionalInformation _information;
 

        public EmployeeService(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Employee> AddAsync(Employee employee)
        {
            var mappedEmployee = _mapper.Map<EmployeeEntity>(employee);
            return _mapper.Map<Employee>(await _repository.AddAsync(mappedEmployee));
        }


        public Task<bool> DeleteByIdAsync(int id)
        {
           return _repository.DeleteByIdAsync(id);
        }

        public string GetAdditionalInformation(int age)
        {
            if (age > 0 && age <= 18)
            {
                return new GetInformationAboutYoungPeople().GetAdditionalInformation();
            }
            else if (age > 18 && age < 60)
            {
                return new GetInformationAboutMiddlePeople().GetAdditionalInformation();
            }
            else if (age > 60)
            {
                return new GetInformationAboutRetirePeople().GetAdditionalInformation(); 
            }
            else
            {
                return "Your age is not correct";
            }
          //  return _information.GetAdditionalInformation(age);
            //StringBuilder sb = new();
            /*   if (age > 0 && age < 18)
               {
                 return sb.Append("You are young people").ToString();
               }
               else if (age > 18 && age < 40)
               {
                   return sb.Append("You are middle people").ToString();
               }
               else if (age > 60)
               {
                   return sb.Append("You are retiree").ToString();
               }
               else
               {
                   return sb.Append("Your age is not correct").ToString();                    
               }*/
        //    return null;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            var employee = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<Employee>>(employee);
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            var employee = await _repository.GetByIdAsync(id);
            return _mapper.Map<Employee>(employee);
        }

        public async Task<Employee> UpdateAsync(Employee employee)
        {
            var mapped = _mapper.Map<EmployeeEntity>(employee);
            return _mapper.Map<Employee>(await _repository.UpdateAsync(mapped));
        }
    }
}
