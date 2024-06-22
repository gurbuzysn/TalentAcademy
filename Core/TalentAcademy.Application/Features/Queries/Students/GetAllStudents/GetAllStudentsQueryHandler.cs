using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TalentAcademy.Domain.Entities.Identitiy;

namespace TalentAcademy.Application.Features.Queries.Students.GetAllStudents
{
    public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQueryRequest, List<GetAllStudentsQueryResponse>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public GetAllStudentsQueryHandler(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<List<GetAllStudentsQueryResponse>> Handle(GetAllStudentsQueryRequest request, CancellationToken cancellationToken)
        {
            var allStudents = await _userManager.GetUsersInRoleAsync("Student");
            var allStudentsDto = _mapper.Map<List<GetAllStudentsQueryResponse>>(allStudents);

            foreach (var student in allStudentsDto)
            {
                if (student.ImageUri != null)
                {
                    student.ImageUri = $"https://localhost:7043/images/{student.ImageUri}";
                }
            }
            return allStudentsDto;
        }
    }
}
