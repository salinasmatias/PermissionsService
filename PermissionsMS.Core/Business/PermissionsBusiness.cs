using AutoMapper;
using PermissionsMS.Core.Business.Interfaces;
using PermissionsMS.Core.DTOs;
using PermissionsMS.Entities;
using PermissionsMS.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermissionsMS.Core.Business
{
    public class PermissionsBusiness : IPermissionsBusiness
    {
        private readonly IPermissionsRepository _repository;
        private readonly IMapper _mapper;

        public PermissionsBusiness(IPermissionsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Permission AddPermission(PermissionDtoForCreation permission)
        {
            var mappedPermission = _mapper.Map<Permission>(permission);
            mappedPermission.PermissionDate = DateTime.Now.Date;
            _repository.AddPermission(mappedPermission);

            return mappedPermission;
        }

        public Permission DeletePermission(Permission permission)
        {
            _repository.DeletePermission(permission);

            return permission;
        }

        public Task<IEnumerable<PermissionDtoForDisplay>> GetAllPermissionsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PermissionDtoForDisplay> GetPermissionByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Permission UpdatePermission(PermissionDtoForEdit permission)
        {
            var mappedPermission = _mapper.Map<Permission>(permission);
            _repository.UpdatePermission(mappedPermission);

            return mappedPermission;
        }
    }
}
