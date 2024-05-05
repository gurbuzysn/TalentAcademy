using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAcademy.Application.Repositories;
using TalentAcademy.Domain.Entities;

namespace TalentAcademy.Application.Features.Queries.Lessons.GetAllLessonsQueryHandler
{
    public class GetAllLessonsQueryHandler : IRequestHandler<GetAllLessonsQueryRequest, List<GetAllLessonsQueryResponse>>
    {
        private readonly IReadRepository<Lesson> _readRepository;
        private readonly IMapper _mapper;

        public GetAllLessonsQueryHandler(IReadRepository<Lesson> readRepository , IMapper mapper)
        {
            _readRepository = readRepository;
            _mapper = mapper;
        }
        public async Task<List<GetAllLessonsQueryResponse>> Handle(GetAllLessonsQueryRequest request, CancellationToken cancellationToken)
        {
            var allLessons = await _readRepository.GetAllAsync();
            return _mapper.Map<List<GetAllLessonsQueryResponse>>(allLessons);
        }
    }
}
