using AutoMapper;
using PermissionsMS.Abstractions;
using PermissionsMS.Core.Business.Interfaces;
using PermissionsMS.Core.DTOs;
using PermissionsMS.Entities;
using PermissionsMS.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PermissionsMS.Core.Business
{
    public class PermissionsBusiness : IPermissionsBusiness
    {
        private readonly IPermissionsRepository _repository;
        private readonly IPermissionTypeRepository _permissionsTypesRepository;
        private readonly IMapper _mapper;

        public PermissionsBusiness(IPermissionsRepository repository, IPermissionTypeRepository permissionTypeRepository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _permissionsTypesRepository = permissionTypeRepository;
        }

        public async Task<PermissionDtoForDisplay> AddPermission(PermissionDtoForCreation permission)
        {
            var response = await _permissionsTypesRepository.GetPermissionTypeByIdAsync(permission.PermissionTypeId);
            if (response != null)
            {
                var mappedPermission = _mapper.Map<Permission>(permission);
                mappedPermission.PermissionDate = DateTime.Now.Date;
                _repository.AddPermission(mappedPermission);


                return _mapper.Map<PermissionDtoForDisplay>(mappedPermission);
            }

            return null;
        }

        public int CountPermissions()
        {
            return _repository.CountPermissions();
        }

        public Permission DeletePermission(Permission permission)
        {
            _repository.DeletePermission(permission);

            return permission;
        }

        public async Task<IEnumerable<PermissionDtoForDisplay>> GetAllPermissionsAsync(IPaginationFilter filter)
        {
            var permissions = await _repository.PaginatedGetAllPermissionsAsync(filter);
            var mappedPermissions = _mapper.Map<List<PermissionDtoForDisplay>>(permissions);
            return mappedPermissions;
        }

        public async Task<Permission> GetPermissionByIdAsync(int id)
        {
            return await _repository.GetPermissionByIdAsync(id);
        }

        public async Task<Permission> UpdatePermission(Permission permission, PermissionDtoForEdit permissionDto)
        {
            var response = await _permissionsTypesRepository.GetPermissionTypeByIdAsync(permissionDto.PermissionTypeId);
            
            if(response != null)
            {
                var mappedPermission = _mapper.Map(permissionDto, permission);
                _repository.UpdatePermission(mappedPermission);

                return mappedPermission;
            }

            return null;
        }
    }
}
