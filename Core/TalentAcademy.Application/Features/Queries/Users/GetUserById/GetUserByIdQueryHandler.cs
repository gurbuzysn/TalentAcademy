using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAcademy.Application.Repositories;
using TalentAcademy.Domain.Entities.Identitiy;

namespace TalentAcademy.Application.Features.Queries.Users.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQueryRequest, GetUserByIdQueryResponse>
    {
        private readonly IReadRepository<AppUser> _readRepository;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IReadRepository<AppUser> readRepository, IMapper mapper)
        {
            _readRepository = readRepository;
            _mapper = mapper;
        }
        public async Task<GetUserByIdQueryResponse> Handle(GetUserByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var user = await _readRepository.GetByFilterAsync(x => x.Id == request.Id);

            var userResponse = _mapper.Map<GetUserByIdQueryResponse>(user);

            return userResponse;
        }
    }
}
