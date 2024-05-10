using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAcademy.Application.Repositories;
using TalentAcademy.Domain.Entities.Identitiy;

namespace TalentAcademy.Application.Features.Queries.Students.GetAllStudents
{
    public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQueryRequest, List<GetAllStudentsQueryResponse>>
    {
        private readonly UserManager<AppUser> _userManager;

        public GetAllStudentsQueryHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<List<GetAllStudentsQueryResponse>> Handle(GetAllStudentsQueryRequest request, CancellationToken cancellationToken)
        {
            var allStudents = await _userManager.GetUsersInRoleAsync("Admin");

            return new List<GetAllStudentsQueryResponse>();
        }
    }
}
