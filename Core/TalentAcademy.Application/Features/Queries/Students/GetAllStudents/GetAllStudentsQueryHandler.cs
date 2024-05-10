using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAcademy.Application.Repositories;
using TalentAcademy.Domain.Entities.Identitiy;

namespace TalentAcademy.Application.Features.Queries.Students.GetAllStudents
{
    public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQueryRequest, GetAllStudentsQueryResponse>
    {
        private readonly IReadRepository<AppUser> _readRepository;
        private readonly IMapper _mapper;

        public GetAllStudentsQueryHandler(IReadRepository<AppUser> readRepository, IMapper mapper)
        {
            _readRepository = readRepository;
            _mapper = mapper;
        }
        public Task<GetAllStudentsQueryResponse> Handle(GetAllStudentsQueryRequest request, CancellationToken cancellationToken)
        {
            var allUsers = _readRepository.GetAllAsync();

            var allStudents = allUsers.Result.Where(x => x. == "")
            
        }
    }
}
