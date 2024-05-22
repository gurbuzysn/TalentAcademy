﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace TalentAcademy.Application.Features.Queries.Students.GetAllStudents
{
    public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQueryRequest, List<GetAllStudentsQueryResponse>>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;

        public GetAllStudentsQueryHandler(UserManager<IdentityUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<List<GetAllStudentsQueryResponse>> Handle(GetAllStudentsQueryRequest request, CancellationToken cancellationToken)
        {
            // Gelen Student i veri tabanına kaydet
            // Fotografın kendisini wwwroot/a

            var allStudents = await _userManager.GetUsersInRoleAsync("Student");
            var allStudentsDto = _mapper.Map<List<GetAllStudentsQueryResponse>>(allStudents);
            return allStudentsDto;
        }
    }
}
