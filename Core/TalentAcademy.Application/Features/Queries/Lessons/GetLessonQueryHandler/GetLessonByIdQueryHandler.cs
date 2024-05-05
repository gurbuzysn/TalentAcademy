using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAcademy.Application.Repositories;
using TalentAcademy.Domain.Entities;

namespace TalentAcademy.Application.Features.Queries.Lessons.GetLessonQueryHandler
{
    public class GetLessonByIdQueryHandler : IRequestHandler<GetLessonByIdQueryRequest, GetLessonByIdQueryResponse>
    {
        private readonly IReadRepository<Lesson> _readRepository;
        private readonly IMapper _mapper;

        public GetLessonByIdQueryHandler(IReadRepository<Lesson> readRepository, IMapper mapper)
        {
            _readRepository = readRepository;
            _mapper = mapper;
        }
        public async Task<GetLessonByIdQueryResponse> Handle(GetLessonByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var lesson = await _readRepository.GetByFilterAsync(x => x.Id == request.Id);
            return _mapper.Map<GetLessonByIdQueryResponse>(lesson);
        }
    }
}
